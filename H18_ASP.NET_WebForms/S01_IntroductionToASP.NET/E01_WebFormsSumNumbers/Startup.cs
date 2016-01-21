using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E01_WebFormsSumNumbers.Startup))]
namespace E01_WebFormsSumNumbers
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
