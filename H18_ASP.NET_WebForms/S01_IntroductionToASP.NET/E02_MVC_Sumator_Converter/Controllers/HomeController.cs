namespace E02_MVC_Sumator_Converter.Controllers
{
    using System.Web.Mvc;

    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Sumator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sumator(SumatorViewModels model)
        {
            model.Sum = model.FirstNumber + model.SecondNumber;
            return this.View(model);
        }
    }
}