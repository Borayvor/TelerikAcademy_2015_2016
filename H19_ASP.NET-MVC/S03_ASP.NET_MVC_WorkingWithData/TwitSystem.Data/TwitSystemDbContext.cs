namespace TwitSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TwitSystemDbContext : IdentityDbContext<User>, ITwitSystemDbContext
    {
        public TwitSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Tweet> Tweets { get; set; }

        public static TwitSystemDbContext Create()
        {
            return new TwitSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
