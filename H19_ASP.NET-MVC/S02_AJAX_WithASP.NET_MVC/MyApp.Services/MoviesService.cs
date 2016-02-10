namespace MyApp.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> movies;

        public MoviesService( IRepository<Movie> movies )
        {
            this.movies = movies;
        }

        public void CreateMovie( Movie movie )
        {
            this.movies.Add( movie );
        }

        public IQueryable<Movie> GetAll()
        {
            return this.movies.All();
        }

        public Movie GetById( int id )
        {
            return this.GetById( id );
        }

        public void UpdateMovie( Movie movie )
        {
            this.movies.Update( movie );
        }

        public void DeleteMovie( int id )
        {
            this.movies.Delete( id );
        }

        public int SaveChanges()
        {
            return this.movies.SaveChanges();
        }
    }
}
