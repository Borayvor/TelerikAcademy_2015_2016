using System.Linq;
using MyApp.Data.Repositories;
using MyApp.Models;
using MyApp.Services.Contracts;

namespace MyApp.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IRepository<Actor> actors;

        public ActorsService( IRepository<Actor> actors )
        {
            this.actors = actors;
        }

        public Actor Create( string firstName, string lastName, Gender gender )
        {
            var actor = new Actor()
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender
            };

            this.actors.Add( actor );

            this.actors.SaveChanges();

            return actor;
        }

        public IQueryable<Actor> GetAll()
        {
            return this.actors.All();
        }

        public Actor GetById( int id )
        {
            return this.actors.GetById( id );
        }

        public void UpdateFirstNameById( int id, string firstName )
        {
            this.actors.GetById( id ).FirstName = firstName;
        }

        public void DeleteById( int id )
        {
            this.actors.Delete( id );
        }

        public int SaveChanges()
        {
            return this.actors.SaveChanges();
        }
    }
}
