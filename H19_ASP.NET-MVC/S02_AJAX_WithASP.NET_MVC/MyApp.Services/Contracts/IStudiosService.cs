namespace MyApp.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IStudiosService
    {
        Studio GetById( int id );

        IQueryable<Studio> GetAll();

        int SaveChanges();
    }
}
