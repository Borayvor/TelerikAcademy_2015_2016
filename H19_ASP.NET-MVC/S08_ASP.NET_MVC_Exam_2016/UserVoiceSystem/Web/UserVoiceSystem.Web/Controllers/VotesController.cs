namespace UserVoiceSystem.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNet.Identity;
    using Services.Data.Common;
    using ViewModels.Votes;

    [Authorize]
    public class VotesController : BaseController
    {
        private readonly IVotesService votes;
        private readonly IAuthorsService authors;
        private readonly IIdeasService ideas;

        public VotesController(IVotesService votes, IAuthorsService authors, IIdeasService ideas)
        {
            this.votes = votes;
            this.authors = authors;
            this.ideas = ideas;
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(VotePostViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var author = this.authors.GetAll().FirstOrDefault(x => x.UserId == userId);

                if ((author.VotePoints - model.Points) > 0)
                {
                    author.VotePoints -= model.Points;
                    this.authors.Update(author);

                    var vote = new Vote
                    {
                        AuthorIp = author.Ip,
                        IdeaId = model.IdeaId,
                        Points = model.Points
                    };

                    this.votes.Create(vote);
                }

                var newIdeaVotes = this.votes
                    .GetAll()
                    .Where(x => x.IdeaId == model.IdeaId)
                    .Sum(x => x.Points);

                return this.Json(new { VotesCount = newIdeaVotes });
            }

            throw new HttpException(404, "not found !");
        }
    }
}
