namespace UserVoiceSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common;
    using Services.Web;
    using ViewModels.Ideas;

    public class IdeaController : Controller
    {
        private readonly IIdeasService ideas;
        private readonly IIdentifierProvider identifier;

        public IdeaController(IIdeasService ideas, IIdentifierProvider identifier)
        {
            this.ideas = ideas;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdeaPostViewModel ideaModel)
        {
            if (ideaModel != null && this.ModelState.IsValid)
            {
                var idea = new Idea
                {
                    Title = ideaModel.Title,
                    Description = ideaModel.Description
                };

                if (this.User.Identity.IsAuthenticated)
                {
                    idea.AuthorId = this.User.Identity.GetUserId();
                }

                this.ideas.Create(idea);

                return this.RedirectToAction("Index", "Home");
            }

            throw new HttpException(400, "Invalid idea !");
        }

        [ChildActionOnly]
        public ActionResult ChildActionCreateIdea()
        {
            return this.PartialView("_CreateIdea");
        }
    }
}
