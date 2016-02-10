namespace MyApp.Services
{
    using System.Linq;
    using Data.Repositories;
    using Models;
    using MyApp.Services.Contracts;

    public class DirectorsService : IDirectorsService
    {
        private readonly IRepository<Director> directors;

        public DirectorsService( IRepository<Director> directors )
        {
            this.directors = directors;
        }

        public Director Create( string firstName, string lastName )
        {
            var director = new Director()
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.directors.Add( director );

            return director;
        }

        public IQueryable<Director> GetAll()
        {
            return this.directors.All();
        }

        public Director GetById( int id )
        {
            return this.directors.GetById( id );
        }

        public void UpdateFirstNameById( int id, string firstName )
        {
            this.directors.GetById( id ).FirstName = firstName;
        }

        public void DeleteById( int id )
        {
            this.directors.Delete( id );
        }

        public int SaveChanges()
        {
            return this.directors.SaveChanges();
        }
    }
}
