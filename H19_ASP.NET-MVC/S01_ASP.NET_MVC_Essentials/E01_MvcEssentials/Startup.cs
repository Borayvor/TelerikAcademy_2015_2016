using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E01_MvcEssentials.Startup))]
namespace E01_MvcEssentials
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
