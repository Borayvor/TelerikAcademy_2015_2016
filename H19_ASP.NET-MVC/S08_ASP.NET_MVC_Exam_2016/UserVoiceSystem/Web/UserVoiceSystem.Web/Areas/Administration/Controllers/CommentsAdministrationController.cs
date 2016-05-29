namespace UserVoiceSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Common;
    using Services.Web.Common;
    using ViewModels.Comments;

    [Authorize]
    public class CommentsAdministrationController : Controller
    {
        private readonly ICommentsService comments;
        private readonly IIdentifierProvider identifier;

        public CommentsAdministrationController(ICommentsService comments, IIdentifierProvider identifier)
        {
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
            var commentsList = this.comments.GetAll()
                .To<CommentOutputViewModel>()
                .ToDataSourceResult(request);

            return this.Json(commentsList);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CommentInputViewModel comment)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.comments.GetById(this.identifier.EncodeIdTitle(comment.Id, comment.AuthorEmail));
                entity.Content = comment.Content;

                this.comments.Update(entity);
            }

            return this.Json(new[] { comment }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, Comment comment)
        {
            var commentToDelete = this.comments.GetById(this.identifier.EncodeIdTitle(comment.Id, comment.CreatedOn.ToString()));
            this.comments.Delete(commentToDelete);

            var commentsToDisplay = this.comments.GetAll()
                .To<CommentOutputViewModel>();

            return this.Json(commentsToDisplay.ToDataSourceResult(request, this.ModelState));
        }
    }
}
