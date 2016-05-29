namespace UserVoiceSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Common;
    using Services.Web.Common;
    using ViewModels.Ideas;

    [Authorize]
    public class IdeasAdministrationController : Controller
    {
        private readonly IIdeasService ideas;
        private readonly ICommentsService comments;
        private readonly IIdentifierProvider identifier;

        public IdeasAdministrationController(IIdeasService ideas, ICommentsService comments, IIdentifierProvider identifier)
        {
            this.ideas = ideas;
            this.comments = comments;
            this.identifier = identifier;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var ideasList = this.ideas.GetAll()
                .To<IdeaOutputViewModel>()
                .ToDataSourceResult(request);

            return this.Json(ideasList);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, IdeaInputViewModel idea)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.ideas.GetById(this.identifier.EncodeIdTitle(idea.Id, idea.Title));
                entity.Title = idea.Title;
                entity.Description = idea.Description;

                this.ideas.Update(entity);
            }

            return this.Json(new[] { idea }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, Idea idea)
        {
            var ideaToDelete = this.ideas.GetById(this.identifier.EncodeIdTitle(idea.Id, idea.Title));

            foreach (var comment in ideaToDelete.Comments)
            {
                this.comments.Delete(comment);
            }

            this.ideas.Delete(ideaToDelete);

            var ideasToDisplay = this.ideas.GetAll()
                .To<IdeaOutputViewModel>();

            return this.Json(ideasToDisplay.ToDataSourceResult(request, this.ModelState));
        }
    }
}
