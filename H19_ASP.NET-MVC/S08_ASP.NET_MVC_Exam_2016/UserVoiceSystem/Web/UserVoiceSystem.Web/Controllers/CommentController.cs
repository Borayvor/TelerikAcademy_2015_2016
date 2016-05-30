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
        [ChildActionOnly]
        public ActionResult GetCommentsForIdea(int ideaId, string ideaUrl, int page = 1)
        {
            var allComments = this.comments.GetAll().Where(x => x.IdeaId == ideaId);

            var totalpages = (int)Math.Ceiling(allComments.Count() / (decimal)GlobalConstants.CommentsPerIdeaPage);
            var pagesToSkip = (page - 1) * GlobalConstants.CommentsPerIdeaPage;

            var commentsForIdea = allComments
                .Skip(pagesToSkip)
                .Take(GlobalConstants.CommentsPerIdeaPage)
                .To<CommentGetViewModel>()
                .ToList();

            var viewModel = new CommentsListViewModel
            {
                Comments = commentsForIdea,
                CurrentPage = page,
                TotalPages = totalpages,
                Url = ideaUrl
            };

            return this.PartialView("_CommentsList", viewModel);
        }

        [AjaxGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [Authorize]
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

                comment.IdeaId = commentModel.IdeaId;

                this.comments.Create(comment);

                var commentsForIdea = this.comments.GetAll()
                    .Where(x => x.IdeaId == commentModel.IdeaId)
                    .Skip(1)
                    .Take(GlobalConstants.CommentsPerIdeaPage)
                    .To<CommentGetViewModel>()
                    .ToList();

                var totalpages = (int)Math.Ceiling(commentsForIdea.Count() / (decimal)GlobalConstants.CommentsPerIdeaPage);

                var viewModel = new CommentsListViewModel
                {
                    Comments = commentsForIdea,
                    CurrentPage = 1,
                    TotalPages = totalpages,
                    Url = commentModel.Url
                };

                return this.PartialView("_CommentsList", viewModel);
            }

            throw new HttpException(400, "Invalid comment !");
        }
    }
}
