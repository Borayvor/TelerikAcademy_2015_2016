using System.Web;
using System.Web.Mvc;

namespace E02_MVC_Sumator_Converter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
