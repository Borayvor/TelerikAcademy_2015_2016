namespace MyApp.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using MyApp.Models;

    public interface IMyAppDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Movie> Movies { get; set; }

        IDbSet<Actor> Actors { get; set; }

        IDbSet<Director> Directors { get; set; }

        IDbSet<Studio> Studios { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>( TEntity entity ) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
