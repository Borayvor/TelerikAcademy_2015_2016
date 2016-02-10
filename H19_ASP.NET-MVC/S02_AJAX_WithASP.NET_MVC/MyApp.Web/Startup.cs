using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyApp.Web.Startup))]
namespace MyApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
