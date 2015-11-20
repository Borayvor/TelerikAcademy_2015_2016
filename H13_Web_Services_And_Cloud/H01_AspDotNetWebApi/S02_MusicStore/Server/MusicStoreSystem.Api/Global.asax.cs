namespace MusicStoreSystem.Api
{
    using System.Reflection;
    using System.Web.Http;
    using MusicStore.Common.Constants;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
