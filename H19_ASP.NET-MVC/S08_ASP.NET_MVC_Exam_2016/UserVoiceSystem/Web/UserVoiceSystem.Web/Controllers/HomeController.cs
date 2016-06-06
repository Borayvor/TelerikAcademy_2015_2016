namespace UserVoiceSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Filters;
    using Infrastructure.Mapping;
    using Services.Data.Common;
    using ViewModels.Ideas;

    public class HomeController : BaseController
    {
        private readonly IIdeasService ideas;
        private readonly IUsersService users;

        public HomeController(IIdeasService ideas, IUsersService users)
        {
            this.ideas = ideas;
            this.users = users;
        }

        [HttpGet]
        public ActionResult Index(int order = 0, int page = 1, string search = "")
        {
            var newViewModel = this.GetIdeas(order, page, search);

            return this.View(newViewModel);
        }

        public ActionResult Error()
        {
            return this.View();
        }

        [AjaxGet]
        public ActionResult Search()
        {
            return this.PartialView();
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(int order = 0, int page = 1, string search = "")
        {
            var newViewModel = this.GetIdeas(order, page, search);

            return this.PartialView("_IdeasList", newViewModel);
        }

        private IdeasListViewModel GetIdeas(int order, int page, string search)
        {
            var allIdeas = this.ideas.GetAll((IdeasOrder)order);

            int totalpages = 0;
            var pagesToSkip = (page - 1) * GlobalConstants.IdeasPerHomePage;

            if (!string.IsNullOrWhiteSpace(search))
            {
                allIdeas = allIdeas.Where(idea => idea.Title.ToLower().Contains(search.ToLower()));
            }

            totalpages = (int)Math.Ceiling(allIdeas.Count() / (decimal)GlobalConstants.IdeasPerHomePage);

            var ideas = allIdeas
            .Skip(pagesToSkip)
            .Take(GlobalConstants.IdeasPerHomePage)
            .To<IdeaGetViewModel>()
            .ToList();

            var newViewModel = new IdeasListViewModel
            {
                Ideas = ideas,
                CurrentPage = page,
                TotalPages = totalpages,
                Order = order,
                Search = search
            };

            return newViewModel;
        }
    }
}
