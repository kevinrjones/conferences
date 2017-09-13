using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace Moview
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteTable.Routes.RegisterRoutes();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {

            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            var serviceAssemblies = Assembly.Load("Service");
            builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces();

            var repoAssemblies = Assembly.Load("MovieRepo");
            builder.RegisterAssemblyTypes(repoAssemblies).AsImplementedInterfaces();

            builder.RegisterFilterProvider();
        }

    }
}