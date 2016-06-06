namespace UserVoiceSystem.Services.Data.Common
{
    using System.Linq;
    using UserVoiceSystem.Data.Models;

    public interface IUsersService
    {
        IQueryable<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);

        void Create(ApplicationUser user);

        void Update(ApplicationUser user);

        void Delete(ApplicationUser user);
    }
}
