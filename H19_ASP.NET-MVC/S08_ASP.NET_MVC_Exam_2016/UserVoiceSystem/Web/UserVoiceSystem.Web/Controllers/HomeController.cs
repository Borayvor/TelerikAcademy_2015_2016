namespace UserVoiceSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Filters;
    using Infrastructure.Mapping;
    using Services.Data.Common;
    using ViewModels.Home;
    using ViewModels.Ideas;

    public class HomeController : BaseController
    {
        private readonly IIdeasService ideas;

        public HomeController(IIdeasService ideas)
        {
            this.ideas = ideas;
        }

        [HttpGet]
        public ActionResult Index(string search, int order = 0, int page = 1)
        {
            var newViewModel = this.GetIdeas(order, page, search);

            return this.View(newViewModel);
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string search, int order = 0, int page = 1)
        {
            var newViewModel = this.GetIdeas(order, page, search);

            return this.PartialView("_IdeasList", newViewModel);
        }

        private IdeasListViewModel GetIdeas(int order, int page, string search)
        {
            var allIdeas = this.ideas.GetAll((IdeasOrder)order);
            var pagesToSkip = (page - 1) * GlobalConstants.ItemsPerPageHome;
            var totalpages = (int)Math.Ceiling(allIdeas.Count() / (decimal)GlobalConstants.ItemsPerPageHome);

            IEnumerable<IdeaGetViewModel> ideas;

            if (string.IsNullOrWhiteSpace(search))
            {
                ideas = allIdeas
                .Skip(pagesToSkip)
                .Take(GlobalConstants.ItemsPerPageHome)
                .To<IdeaGetViewModel>()
                .ToList();
            }
            else
            {
                ideas = allIdeas
                .Where(idea => idea.Title.ToLower().Contains(search.ToLower()))
                .Skip(pagesToSkip)
                .Take(GlobalConstants.ItemsPerPageHome)
                .To<IdeaGetViewModel>()
                .ToList();
            }

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
