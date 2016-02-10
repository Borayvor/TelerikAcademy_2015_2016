namespace MyApp.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class MyAppDbContext : IdentityDbContext<User>, IMyAppDbContext
    {
        public MyAppDbContext()
            : base( "DefaultConnection", throwIfV1Schema: false )
        {
        }

        public IDbSet<Director> Directors { get; set; }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Studio> Studios { get; set; }

        public static MyAppDbContext Create()
        {
            return new MyAppDbContext();
        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }

}
