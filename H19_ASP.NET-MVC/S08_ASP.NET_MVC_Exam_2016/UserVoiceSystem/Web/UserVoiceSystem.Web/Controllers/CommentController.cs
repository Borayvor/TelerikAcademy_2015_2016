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
        private readonly IAuthorsService authors;
        private readonly IIdentifierProvider identifier;

        public CommentController(ICommentsService comments, IAuthorsService authors, IIdentifierProvider identifier)
        {
            this.comments = comments;
            this.authors = authors;
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
                    var currentUserId = this.User.Identity.GetUserId();

                    var author = this.authors.GetAll().FirstOrDefault(x => x.UserId == currentUserId);

                    comment.AuthorEmail = author.Email;
                    comment.AuthorIp = author.Ip;
                }
                else
                {
                    var author = this.authors.GetAll().FirstOrDefault(x => x.Ip == this.Request.UserHostAddress);

                    if (author == null)
                    {
                        var newAuthor = new Author
                        {
                            Email = commentModel.AuthorEmail,
                            Ip = this.Request.UserHostAddress,
                            VotePoints = 10
                        };

                        this.authors.Create(newAuthor);

                        comment.AuthorIp = this.Request.UserHostAddress;
                    }
                    else
                    {
                        comment.AuthorIp = author.Ip;
                    }

                    comment.AuthorEmail = commentModel.AuthorEmail;
                }

                comment.IdeaId = commentModel.IdeaId;

                this.comments.Create(comment);

                var commentsForIdea = this.comments.GetAll()
                    .Where(x => x.IdeaId == commentModel.IdeaId);

                var totalpages = (int)Math.Ceiling(commentsForIdea.Count() / (decimal)GlobalConstants.CommentsPerIdeaPage);

                var pagedComments = commentsForIdea
                    .Skip(1)
                    .Take(GlobalConstants.CommentsPerIdeaPage)
                    .To<CommentGetViewModel>()
                    .ToList();

                var viewModel = new CommentsListViewModel
                {
                    Comments = pagedComments,
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
