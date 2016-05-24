namespace UserVoiceSystem.Services.Data.Common
{
    using System.Linq;
    using UserVoiceSystem.Common;
    using UserVoiceSystem.Data.Models;

    public interface IIdeasService
    {
        IQueryable<Idea> GetAll(IdeasOrder orderBy);

        Idea GetById(string id);

        void Create(Idea idea);

        void Update(Idea idea);

        void Delete(Idea idea);
    }
}
