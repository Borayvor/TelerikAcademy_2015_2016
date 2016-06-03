namespace UserVoiceSystem.Web
{
    using System.Web.Mvc;
    using Infrastructure.Filters;

    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UserIpAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
