﻿using System;
using System.Web;
using System.Web.Security;
using AbstractConfigurationManager;
using Logging;

namespace Todo.Controllers
{
    public class SessionBaseController : BaseController
    {
        protected IConfigurationManager _configurationManager;

        public SessionBaseController(IConfigurationManager configurationManager, ILogger logger) : base(logger)
        {
            _configurationManager = configurationManager;
        }

        protected void CreateCookie(string userName, int timeInMinutes = 30)
        {
            Response.Cookies.Add(new HttpCookie(_configurationManager.AppSetting("cookie"), 
                                                FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1,
                                                                                                          userName,
                                                                                                          DateTime.Now,
                                                                                                          DateTime.Now.AddMinutes(timeInMinutes),
                                                                                                          false,
                                                                                                          ""))));
        }
    }
}