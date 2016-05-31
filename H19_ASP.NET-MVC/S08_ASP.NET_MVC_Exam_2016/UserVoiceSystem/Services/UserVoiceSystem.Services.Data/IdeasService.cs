namespace UserVoiceSystem.Services.Data
{
    using System.Linq;
    using Common;
    using UserVoiceSystem.Common;
    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;
    using Web.Common;

    public class IdeasService : IIdeasService
    {
        private readonly IDbRepository<Idea> ideas;
        private readonly IIdentifierProvider identifierProvider;

        public IdeasService(IDbRepository<Idea> ideas, IIdentifierProvider identifierProvider)
        {
            this.ideas = ideas;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Idea> GetAll(IdeasOrder orderBy = IdeasOrder.TopIdeas)
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

        public Idea GetById(string idTitle)
        {
            var intId = this.identifierProvider.DecodeIdTitle(idTitle);
            var idea = this.ideas.GetById(intId);

            return idea;
        }

        ////public IdeasListViewModel GetIdeasList(int order, int page, string search)
        ////{
        ////    var allIdeas = this.ideas.GetAll((IdeasOrder)order);

        ////    int totalpages = 0;
        ////    var pagesToSkip = (page - 1) * GlobalConstants.IdeasPerHomePage;

        ////    if (!string.IsNullOrWhiteSpace(search))
        ////    {
        ////        allIdeas = allIdeas.Where(idea => idea.Title.ToLower().Contains(search.ToLower()));
        ////    }

        ////    totalpages = (int)Math.Ceiling(allIdeas.Count() / (decimal)GlobalConstants.IdeasPerHomePage);

        ////    var ideas = allIdeas
        ////    .Skip(pagesToSkip)
        ////    .Take(GlobalConstants.IdeasPerHomePage)
        ////    .To<IdeaGetViewModel>()
        ////    .ToList();

        ////    var newViewModel = new IdeasListViewModel
        ////    {
        ////        Ideas = ideas,
        ////        CurrentPage = page,
        ////        TotalPages = totalpages,
        ////        Order = order,
        ////        Search = search
        ////    };

        ////    return newViewModel;
        ////}

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
