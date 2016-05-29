﻿namespace UserVoiceSystem.Web.Controllers
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
        public ActionResult Suggestions(string idAndTitle, int page = 1)
        {
            var id = this.identifier.DecodeIdTitle(idAndTitle);
            var pagesToSkip = (page - 1) * GlobalConstants.CommentsPerIdeaPage;

            var idea = this.ideas.GetAll()
                .Where(x => x.Id == id)
                .To<IdeaDetailsViewModel>()
                .FirstOrDefault();

            if (idea == null)
            {
                throw new HttpException(404, "Idea not found !");
            }

            var totalpages = (int)Math.Ceiling(idea.CommentsCount / (decimal)GlobalConstants.CommentsPerIdeaPage);

            idea.TotalPages = totalpages;
            idea.CurrentPage = page;

            idea.Comments = idea.Comments
                .AsQueryable()
                .Skip(pagesToSkip)
                .Take(GlobalConstants.CommentsPerIdeaPage)
                .ToList();

            return this.View(idea);
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

                ////var ideaViewModel = this.Mapper.Map<IdeaGetViewModel>(idea);

                ////return this.PartialView("_IdeaHome", ideaViewModel);

                return this.RedirectToAction("Index", "Home");
            }

            throw new HttpException(400, "Invalid idea !");
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote()
        {
            return this.View();
        }
    }
}
