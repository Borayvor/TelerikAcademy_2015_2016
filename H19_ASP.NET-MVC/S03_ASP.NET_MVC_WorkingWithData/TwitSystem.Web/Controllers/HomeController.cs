namespace TwitSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Models;
    using Ninject;
    using Services;

    public class HomeController : BaseController
    {
        public HomeController(ITagService tags, IUserService users)
        {
            this.Tags = tags;
            this.Users = users;
        }

        [Inject]
        private ITagService Tags { get; set; }

        [Inject]
        private IUserService Users { get; set; }


        public ActionResult Index()
        {
            var tags = this.Tags.GetAll().To<TagsResponseViewModel>().ToList();

            var users = this.Users.GetAll().To<UsersResponseViewModel>().ToList();

            var viewModel = new HomePageViewModel
            {
                AllTags = tags,
                AllUsers = users
            };

            return View(viewModel);
        }


    }
}