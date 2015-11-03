namespace MusicStoreSystem.Api
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MusicStoreSystemDbContext, Configuration>());

            MusicStoreSystemDbContext.Create().Database.Initialize(true);
        }
    }
}