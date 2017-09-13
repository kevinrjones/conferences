using System;
using System.Security.Principal;
using System.Threading;
using System.Web.Mvc;
using AbstractConfigurationManager;
using ServiceInterfaces;
using Todo.Controllers;
using Todo.Infrastructure;
using Todo.Models.Users;

namespace Todo.Filters
{
    public class GetCookieUserFilterAttribute : AuthorizeAttribute
    {
        public const string UserCookieName = "USER";

        public IUserService UserService { get; set; }
        public IConfigurationManager ConfigurationManager { get; set;  }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;
            if (controller != null)
            {
                var userViewModel = new UserViewModel();
                

                if (filterContext.HttpContext.Request.Cookies[UserCookieName] != null)
                {
                    string cookie = filterContext.HttpContext.Request.Cookies[UserCookieName].Value;
                    byte[] cipherText = Convert.FromBase64String(cookie);
                    var user = UserService.GetRegisteredUser();
                    if (user != null)
                    {
                        string name = cipherText.Decrypt(user.Salt, ConfigurationManager.AppSetting("keyphrase"));
                        userViewModel.Name = name;                        
                        userViewModel.Email = user.Email;
                        //    userViewModel.Name = user.Name;
                        //    userViewModel.IsLoggedIn = true;
                    }
                }
                filterContext.HttpContext.User = Thread.CurrentPrincipal = new GenericPrincipal(userViewModel, null);
            }
        }
    }
}