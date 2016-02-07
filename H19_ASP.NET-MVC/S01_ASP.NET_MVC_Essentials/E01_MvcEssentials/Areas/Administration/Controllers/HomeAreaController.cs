namespace E01_MvcEssentials.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class HomeAreaController : Controller
    {
        // GET: Administration/HomeArea
        public ActionResult Index()
        {
            return View();
        }
    }
}