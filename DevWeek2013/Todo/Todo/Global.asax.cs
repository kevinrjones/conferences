﻿using System;
using System.Configuration;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using Logging;
using Logging.NLog;
using Microsoft.AspNet.SignalR;
using Todo.App_Start;
using Todo.Hubs;
using Todo.Models.Users;

namespace Todo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalHost.DependencyResolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);

            GlobalConfiguration.Configuration.Register();
            GlobalFilters.Filters.RegisterGlobalFilters();
            RegisterHubs.Start();
            RouteTable.Routes.RegisterRoutes();
            BundleTable.Bundles.RegisterBundles();
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies.Get(ConfigurationManager.AppSettings["cookie"]);
            if (authCookie != null)
            {
                try
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (ticket != null && !ticket.Expired)
                    {
                        CreateIdentity(ticket.Name);
                    }
                }
                catch 
                {
                    Response.Cookies.Add(new HttpCookie(authCookie.Name) {Expires = new DateTime(1970, 1, 1)});
                }
            }
        }

        private void CreateIdentity(string name)
        {
            var identity = new UserViewModel { Name = name };
            HttpContext.Current.User = new GenericPrincipal(identity, null);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            string baseDirectory = HttpContext.Current.Server.MapPath("~/App_Data") + ConfigurationManager.AppSettings["dataFolderName"];

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var repositoryAssemblies = Assembly.Load("FileRepository");
            builder.RegisterAssemblyTypes(repositoryAssemblies).AsImplementedInterfaces().WithParameter(new NamedParameter("path", baseDirectory));

            var serviceAssemblies = Assembly.Load("Services");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces();

            var configurationManagerWrapperAssembly = Assembly.Load("ConfigurationManagerWrapper");
            builder.RegisterAssemblyTypes(configurationManagerWrapperAssembly).AsImplementedInterfaces();

            var fileAssembly = Assembly.Load("SystemFileAdapter");
            builder.RegisterAssemblyTypes(fileAssembly).AsImplementedInterfaces();

            //builder.RegisterType<NLogLogger>().As<ILogger>();
            builder.Register(c => new NLogLogger()).As<ILogger>().InstancePerHttpRequest();
            builder.RegisterType<UserHub>();
            builder.RegisterType<TodoHub>();
            //            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            builder.RegisterFilterProvider();
        }
    }
}