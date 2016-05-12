namespace Library_System.Controllers
{
    using System.Data.Entity.SqlServer;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Models;
    using Utilities;
    using ViewModels;

    public class HomeController : Controller
    {
        Library_SystemDbContext db = new Library_SystemDbContext();

        public ActionResult Index()
        {
            var found = db.Categories.Include("Books")
                .Select(c => new TreeCategoryNode
                {
                    Name = c.Name,
                    HasChildren = c.Books.Any(),
                    Items = c.Books.Select(b => new BookNode
                    {
                        Name = b.Title,
                        Url = SqlFunctions.StringConvert((double) b.Id)
                    }),
                }).ToList();

            var treeNodes = found.Select(c => new TreeViewItemModel
            {
                Text = c.Name,
                HasChildren = c.HasChildren,
                Items = c.Items.Select(b => new TreeViewItemModel
                {
                    Text = b.Name,
                    Url = string.Format("{0}{1}", "Home/BookDetails/", b.Url.TrimStart()),
                    Encoded = false
                }).ToList()
            }).ToList();

            var indexVm = new ViewModels.IndexViewModel();

            indexVm.TreeViewItems = treeNodes;
            indexVm.Books = db.Books.ConvertToBookViewModel();


            return View(indexVm);
        }

        public ActionResult BookDetails(int? Id)
        {
            if (Id != null)
            {
                var found = db.Books.Single(x => x.Id == Id);
                return View("BookDetails", found);
            }

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}