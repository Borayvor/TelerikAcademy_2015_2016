namespace MyApp.Services.Contracts
{
    using System.Linq;
    using MyApp.Models;

    public interface IActorsService
    {
        Actor GetById( int id );

        IQueryable<Actor> GetAll();

        Actor Create( string firstName, string lastName, Gender gender );

        void UpdateFirstNameById( int id, string firstName );

        void DeleteById( int id );

        int SaveChanges();
    }
}
