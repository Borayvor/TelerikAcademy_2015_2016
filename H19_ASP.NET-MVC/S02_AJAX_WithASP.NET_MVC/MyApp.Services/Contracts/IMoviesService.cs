namespace MyApp.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IMoviesService
    {
        void CreateMovie( Movie movie );

        IQueryable<Movie> GetAll();

        Movie GetById( int id );

        void UpdateMovie( Movie movie );

        void DeleteMovie( int id );

        int SaveChanges();
    }
}
