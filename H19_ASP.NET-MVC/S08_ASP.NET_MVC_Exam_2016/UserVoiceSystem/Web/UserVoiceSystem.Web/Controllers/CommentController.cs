namespace UserVoiceSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common;
    using Services.Web.Common;
    using ViewModels.Comments;

    public class CommentController : BaseController
    {
        private readonly ICommentsService comments;
        private readonly IIdentifierProvider identifier;

        public CommentController(ICommentsService comments, IIdentifierProvider identifier)
        {
            this.comments = comments;
            this.identifier = identifier;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentPostViewModel commentModel)
        {
            if (commentModel != null && this.ModelState.IsValid)
            {
                var comment = this.Mapper.Map<Comment>(commentModel);

                if (this.User.Identity.IsAuthenticated)
                {
                    comment.AuthorId = this.User.Identity.GetUserId();
                }

                this.comments.Create(comment);

                var commentViewModel = this.Mapper.Map<CommentGetViewModel>(comment);

                return this.PartialView(commentViewModel);
            }

            throw new HttpException(400, "Invalid comment !");
        }
    }
}
