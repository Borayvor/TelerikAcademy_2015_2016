namespace MyApp.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;

        public UsersService( IRepository<User> users )
        {
            this.users = users;
        }

        public User GetById( string id )
        {
            return this.users.GetById( id );
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public void UpdateUser( User user )
        {
            this.users.Update( user );
        }

        public int SaveChanges()
        {
            return this.users.SaveChanges();
        }
    }
}
