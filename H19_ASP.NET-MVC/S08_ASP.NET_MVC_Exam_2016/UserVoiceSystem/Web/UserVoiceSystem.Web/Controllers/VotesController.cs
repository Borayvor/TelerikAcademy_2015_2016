namespace UserVoiceSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Filters;
    using Services.Data.Common;

    [Authorize]
    public class VotesController : BaseController
    {
        private readonly IVotesService votes;

        public VotesController(IVotesService votes)
        {
            this.votes = votes;
        }

        [AjaxPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int voteValue, int ideaId, string authorIp)
        {
            if (voteValue < 0)
            {
                voteValue = 0;
            }

            if (voteValue > 3)
            {
                voteValue = 3;
            }

            var user = this.User;

            var vote = this.votes.GetAll()
                .FirstOrDefault(x => x.IdeaId == ideaId && x.AuthorIp == authorIp);

            if (vote == null)
            {
                vote = new Vote
                {
                    IdeaId = ideaId,
                    AuthorIp = authorIp,
                    Points = voteValue
                };
            }
            else
            {
                vote.Points = voteValue;
            }

            var ideaVotes = this.votes.GetAll()
                .Where(x => x.IdeaId == ideaId)
                .Sum(x => x.Points);

            return this.Json(new { Count = ideaVotes });
        }
    }
}
