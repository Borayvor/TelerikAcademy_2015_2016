namespace MyApp.Services
{
    using System.Linq;
    using Contracts;
    using Data.Repositories;
    using Models;

    public class StudiosService : IStudiosService
    {
        private readonly IRepository<Studio> studios;

        public StudiosService( IRepository<Studio> studios )
        {
            this.studios = studios;
        }

        public Studio GetById( int id )
        {
            return this.studios.GetById( id );
        }

        public IQueryable<Studio> GetAll()
        {
            return this.studios.All();
        }

        public int SaveChanges()
        {
            return this.studios.SaveChanges();
        }
    }
}
