using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwitSystem.Web.Startup))]
namespace TwitSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
