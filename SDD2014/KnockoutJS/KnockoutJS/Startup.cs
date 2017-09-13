using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KnockoutJS.Startup))]
namespace KnockoutJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
