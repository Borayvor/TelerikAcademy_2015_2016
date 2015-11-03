namespace MusicStoreSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MusicStoreSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicStoreSystemDbContext context)
        {
            this.SeedAlbums(context);
            this.SeedSongs(context);
        }

        private void SeedAlbums(MusicStoreSystemDbContext context)
        {
            if (context.Albums.Any())
            {
                return;
            }

            context.Albums.AddOrUpdate(
                a => a.Title,
                new Album { Title = "Helloween" }
                );
        }

        private void SeedSongs(MusicStoreSystemDbContext context)
        {
            if (context.Songs.Any())
            {
                return;
            }

            context.Songs.AddOrUpdate(
                s => s.Title,
                new Song { Title = "Future World" }
                );
        }
    }
}
