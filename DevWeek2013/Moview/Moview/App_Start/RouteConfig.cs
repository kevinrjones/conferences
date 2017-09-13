using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Moview
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(this RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Create",
            //    url: "movie/create",
            //    defaults: new { controller = "Movie", action = "ActionError" },
            //    constraints: new {HttpMethod = new HttpMethodConstraint("GET")}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Movie", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}