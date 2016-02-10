namespace MyApp.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IUsersService
    {
        User GetById( string id );

        IQueryable<User> GetAll();

        void UpdateUser( User currentUser );

        int SaveChanges();
    }
}
