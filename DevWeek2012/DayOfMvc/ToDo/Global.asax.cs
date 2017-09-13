using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using ToDo.Infrastructure;
using TodoRepository.Interfaces;
using TodoRepository.Repositories;

namespace ToDo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "New",
                "Todo/New",
                new { controller = "todo", action="new" },
                new { httpMethod = new HttpMethodConstraint("GET") }
                );

            routes.MapRoute(
                "Create",
                "Todo/Create",
                new { controller = "todo", action = "create" },
                new { httpMethod = new HttpMethodConstraint("POST") }
                );

            routes.MapRoute(
                "Edit",
                "Todo/Edit/{id}",
                new { controller = "todo", action = "edit" },
                new { httpMethod = new HttpMethodConstraint("GET") }
                );

            routes.MapRoute(
                "Update",
                "Todo/Update",
                new { controller = "todo", action = "update" },
                new { httpMethod = new HttpMethodConstraint("POST") }
                );

            routes.MapRoute(
                "Index",
                "",
                new { controller = "todo", action = "index" },
                new { httpMethod = new HttpMethodConstraint("GET") }
                );

            routes.MapRoute(
                "Validation",
                "Validation/{action}",
                new { controller = "validation", action = "IsTitleValid" },
                new { httpMethod = new HttpMethodConstraint("POST") }
                );

            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Todo", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);

        }

        protected void Application_Start()
        {
            IUnityContainer container =  IntializeUnity();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private IUnityContainer IntializeUnity()
        {
            var ctor = new InjectionConstructor(
                ConfigurationManager.ConnectionStrings["todo"].ConnectionString);
            IUnityContainer container = new UnityContainer()
                .RegisterType<ITodoRepository, TodosRepository>(ctor)
                ;
            return container;
        }
    }
}