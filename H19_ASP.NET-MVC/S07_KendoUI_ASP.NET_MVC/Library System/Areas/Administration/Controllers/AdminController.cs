namespace Library_System.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        [HttpPost]
        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}