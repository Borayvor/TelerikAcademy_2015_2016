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
        private readonly IAuthorsService authors;
        private readonly IIdentifierProvider identifier;

        public IdeaController(IIdeasService ideas, IAuthorsService authors, IIdentifierProvider identifier)
        {
            this.ideas = ideas;
            this.authors = authors;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult Suggestions(string idAndTitle)
        {
            if (string.IsNullOrWhiteSpace(idAndTitle))
            {
                throw new HttpException(404, "Idea not found !");
            }

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
                    var currentUserId = this.User.Identity.GetUserId();

                    var author = this.authors.GetAll().FirstOrDefault(x => x.UserId == currentUserId);

                    if (author != null)
                    {
                        idea.AuthorIp = author.Ip;
                    }
                    else
                    {
                        var newAuthor = new Author
                        {
                            Ip = this.Request.UserHostAddress
                        };

                        this.authors.Create(newAuthor);

                        idea.AuthorIp = this.Request.UserHostAddress;
                    }
                }

                this.ideas.Create(idea);

                var allIdeas = this.ideas.GetAll(IdeasOrder.New);

                var totalpages = (int)Math.Ceiling(allIdeas.Count() / (decimal)GlobalConstants.IdeasPerHomePage);

                var pagedIdeas = allIdeas
                    .Skip(1)
                    .Take(GlobalConstants.IdeasPerHomePage)
                    .To<IdeaGetViewModel>()
                    .ToList();

                var newViewModel = new IdeasListViewModel
                {
                    Ideas = pagedIdeas,
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
