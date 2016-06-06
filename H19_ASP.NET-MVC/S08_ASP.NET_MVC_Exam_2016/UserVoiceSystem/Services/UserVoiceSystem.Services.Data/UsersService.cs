namespace UserVoiceSystem.Services.Data
{
    using System.Linq;
    using Common;
    using UserVoiceSystem.Data.Common;
    using UserVoiceSystem.Data.Models;
    using Web.Common;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<ApplicationUser> users;
        private readonly IIdentifierProvider identifierProvider;

        public UsersService(IDbRepository<ApplicationUser> users, IIdentifierProvider identifierProvider)
        {
            this.users = users;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }

        public ApplicationUser GetById(string id)
        {
            var user = this.users.GetById(id);

            return user;
        }

        public void Create(ApplicationUser user)
        {
            this.users.Add(user);
            this.users.Save();
        }

        public void Update(ApplicationUser user)
        {
            this.users.Update(user);
            this.users.Save();
        }

        public void Delete(ApplicationUser user)
        {
            this.users.Delete(user);
            this.users.Save();
        }
    }
}
