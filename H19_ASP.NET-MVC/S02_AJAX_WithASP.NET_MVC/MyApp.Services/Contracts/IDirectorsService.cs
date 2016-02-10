namespace MyApp.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IDirectorsService
    {
        Director GetById( int id );

        IQueryable<Director> GetAll();

        Director Create( string firstName, string lastName );

        void UpdateFirstNameById( int id, string firstName );

        void DeleteById( int id );

        int SaveChanges();
    }
}
