namespace E06_CreatingNorthwindTwinDb
{
    using System;
    using E01_NorthwindDbContext;

    public class CreatingNorthwindTwinDb
    {
        public static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                // In App.config file in connectionStrings Northwind is changed with NorthwindTwin
                // to generate NorthwindTwin clone of Northwind

                // Summary:
                //     Creates a new database on the database server for the model defined in the backing
                //     context, but only if a database with the same name does not already exist on
                //     the server.
                //
                // Returns:
                //     True if the database did not exist and was created; false otherwise.
                var flag = db.Database.CreateIfNotExists();
                Console.WriteLine("Is database not exist ? --> {0}", flag);
            }
        }
    }
}
