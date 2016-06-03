namespace UserVoiceSystem.Web.Infrastructure.Filters
{
    using System.Web.Mvc;

    public class UserIpAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            const string HeaderName = "X-ROSES-ARE-RED-VIOLETS-ARE-BLUE-I-KNOW-EVERYTHING-ABOUT-YOU";

            if (string.IsNullOrWhiteSpace(filterContext.HttpContext.Response.Headers[HeaderName]))
            {
                var userIp = filterContext.HttpContext.Request.UserHostAddress;

                filterContext.HttpContext.Response.Headers.Add(HeaderName, userIp);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
