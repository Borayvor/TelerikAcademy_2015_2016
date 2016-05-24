namespace UserVoiceSystem.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common;
    using Services.Web;
    using ViewModels.Comments;

    public class CommentController : Controller
    {
        private readonly ICommentsService comments;
        private readonly IIdentifierProvider identifier;

        public CommentController(ICommentsService comments, IIdentifierProvider identifier)
        {
            this.comments = comments;
            this.identifier = identifier;
        }

        // GET: Comment
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
        public ActionResult Create(CommentPostViewModel commentModel)
        {
            if (commentModel != null && this.ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Content = commentModel.Content
                };

                if (this.User.Identity.IsAuthenticated)
                {
                    comment.AuthorId = this.User.Identity.GetUserId();
                }

                this.comments.Create(comment);

                return this.View();
            }

            throw new HttpException(400, "Invalid comment !");
        }

        [ChildActionOnly]
        public ActionResult ChildActionCreateComment()
        {
            return this.PartialView("_CreateComment");
        }
    }
}
