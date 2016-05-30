namespace UserVoiceSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Filters;
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
        public ActionResult Suggestions(string idAndTitle, int page = 1)
        {
            var id = this.identifier.DecodeIdTitle(idAndTitle);
            var idea = this.ideas.GetById(idAndTitle);
            var ideaViewModel = this.Mapper.Map<IdeaDetailsViewModel>(idea);

            if (ideaViewModel == null)
            {
                throw new HttpException(404, "Idea not found !");
            }

            var totalpages = (int)Math.Ceiling(ideaViewModel.CommentsCount / (decimal)GlobalConstants.CommentsPerIdeaPage);
            var pagesToSkip = (page - 1) * GlobalConstants.CommentsPerIdeaPage;

            ideaViewModel.TotalPages = totalpages;
            ideaViewModel.CurrentPage = page;

            ideaViewModel.Comments = ideaViewModel.Comments
                .AsQueryable()
                .Skip(pagesToSkip)
                .Take(GlobalConstants.CommentsPerIdeaPage)
                .ToList();

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

                return this.RedirectToAction("Index", "Home");
            }

            throw new HttpException(400, "Invalid idea !");
        }

        [AjaxGet]
        public ActionResult Vote()
        {
            return this.PartialView();
        }

        [Authorize]
        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int voteValue)
        {


            return this.PartialView();
        }
    }
}
