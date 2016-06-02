namespace UserVoiceSystem.Services.Data.Common
{
    using System.Linq;
    using UserVoiceSystem.Data.Models;

    public interface IVotesService
    {
        IQueryable<Vote> GetAll();

        Vote GetById(string id);

        void Create(Vote vote);

        void Update(Vote vote);

        void Delete(Vote vote);
    }
}
