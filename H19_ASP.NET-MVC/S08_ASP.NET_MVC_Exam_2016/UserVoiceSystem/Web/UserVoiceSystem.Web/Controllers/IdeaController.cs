namespace UserVoiceSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Filters;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common;
    using Services.Web.Common;
    using ViewModels.Ideas;

    public class IdeaController : BaseController
    {
        private readonly IIdeasService ideas;
        private readonly IIdentifierProvider identifier;

        public IdeaController(IIdeasService ideas, IIdentifierProvider identifier)
        {
            this.ideas = ideas;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult Suggestions(string idAndTitle)
        {
            var id = this.identifier.DecodeIdTitle(idAndTitle);
            var idea = this.ideas.GetById(idAndTitle);
            var ideaViewModel = this.Mapper.Map<IdeaDetailsViewModel>(idea);

            if (ideaViewModel == null)
            {
                throw new HttpException(404, "Idea not found !");
            }

            return this.View(ideaViewModel);
        }

        [AjaxGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [Authorize]
        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdeaPostViewModel ideaModel)
        {
            if (ideaModel != null && this.ModelState.IsValid)
            {
                var idea = this.Mapper.Map<Idea>(ideaModel);

                if (this.User.Identity.IsAuthenticated)
                {
                    idea.AuthorId = this.User.Identity.GetUserId();
                }

                this.ideas.Create(idea);

                var allIdeas = this.ideas
                    .GetAll(IdeasOrder.New)
                    .Skip(1)
                    .Take(GlobalConstants.IdeasPerHomePage)
                    .To<IdeaGetViewModel>()
                    .ToList();

                var totalpages = (int)Math.Ceiling(allIdeas.Count() / (decimal)GlobalConstants.IdeasPerHomePage);

                var newViewModel = new IdeasListViewModel
                {
                    Ideas = allIdeas,
                    CurrentPage = 1,
                    TotalPages = totalpages,
                    Order = (int)IdeasOrder.New,
                    Search = string.Empty
                };

                return this.PartialView("_IdeasList", newViewModel);
            }

            throw new HttpException(400, "Invalid idea !");
        }
    }
}
