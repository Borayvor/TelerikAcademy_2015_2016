namespace UserVoiceSystem.Services.Data
{
    using System.Linq;
    using Common;
    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;
    using Web.Common;

    public class VotesService : IVotesService
    {
        private readonly IDbRepository<Vote> votes;
        private readonly IIdentifierProvider identifierProvider;

        public VotesService(IDbRepository<Vote> votes, IIdentifierProvider identifierProvider)
        {
            this.votes = votes;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Vote> GetAll()
        {
            return this.votes.All();
        }

        public Vote GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var vote = this.votes.GetById(intId);

            return vote;
        }

        public void Create(Vote vote)
        {
            this.votes.Add(vote);
            this.votes.Save();
        }

        public void Update(Vote vote)
        {
            this.votes.Update(vote);
            this.votes.Save();
        }

        public void Delete(Vote vote)
        {
            this.votes.Delete(vote);
            this.votes.Save();
        }
    }
}
