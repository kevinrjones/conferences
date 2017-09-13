using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DfTModel;

namespace DesignForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserDao>().As<IUserDao>();
            builder.RegisterType<Application>().As<IApplication>();

            var container = builder.Build();

            var app = container.Resolve<IApplication>();

            //var app = new Application(new UserDao());
            Console.WriteLine(app.Run());
        }
    }


    /*
      var builder = new ContainerBuilder();
      builder.RegisterType<UserDao>().As<IUserDao>();

      var container = builder.Build();

      IApplication app = container.Resolve<IApplication>();
     */
}
