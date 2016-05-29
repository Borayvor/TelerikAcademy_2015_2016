namespace UserVoiceSystem.Services.Data.Common
{
    using System.Linq;
    using UserVoiceSystem.Common;
    using UserVoiceSystem.Data.Models;

    public interface IIdeasService
    {
        IQueryable<Idea> GetAll(IdeasOrder orderBy = IdeasOrder.TopIdeas);

        Idea GetById(string idTitle);

        void Create(Idea idea);

        void Update(Idea idea);

        void Delete(Idea idea);
    }
}
