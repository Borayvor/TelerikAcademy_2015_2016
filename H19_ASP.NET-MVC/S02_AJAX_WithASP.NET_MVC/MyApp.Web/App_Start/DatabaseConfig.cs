namespace MyApp.Web.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<MyAppDbContext, Configuration>() );
            MyAppDbContext.Create().Database.Initialize( true );
        }
    }
}