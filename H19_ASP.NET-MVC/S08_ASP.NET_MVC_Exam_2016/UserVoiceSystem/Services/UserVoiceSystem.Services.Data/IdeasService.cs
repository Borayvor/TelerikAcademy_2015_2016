namespace UserVoiceSystem.Services.Data
{
    using System.Linq;
    using Common;
    using UserVoiceSystem.Common;
    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;
    using Web;

    public class IdeasService : IIdeasService
    {
        private readonly IDbRepository<Idea> ideas;
        private readonly IIdentifierProvider identifierProvider;

        public IdeasService(IDbRepository<Idea> ideas, IIdentifierProvider identifierProvider)
        {
            this.ideas = ideas;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Idea> GetAll(IdeasOrder orderBy)
        {
            switch (orderBy)
            {
                case IdeasOrder.New:
                    {
                        return this.ideas.All().OrderByDescending(x => x.CreatedOn);
                    }

                default:
                    {
                        return this.ideas.All().OrderByDescending(x => x.Votes.Sum(v => v.Points));
                    }
            }
        }

        public Idea GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var idea = this.ideas.GetById(intId);

            return idea;
        }

        public void Create(Idea idea)
        {
            this.ideas.Add(idea);
            this.ideas.Save();
        }

        public void Update(Idea idea)
        {
            this.ideas.Update(idea);
            this.ideas.Save();
        }

        public void Delete(Idea idea)
        {
            this.ideas.Delete(idea);
            this.ideas.Save();
        }
    }
}
