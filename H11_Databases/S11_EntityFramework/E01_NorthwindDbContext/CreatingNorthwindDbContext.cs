namespace E01_NorthwindDbContext
{
    using System;
    using System.Linq;

    public class CreatingNorthwindDbContext
    {
        public static void Main(string[] args)
        {
            var northwindDb = new NorthwindEntities();

            using (northwindDb)
            {
                var companies = northwindDb.Categories.Select(c => c.CategoryName).ToList();

                companies.ForEach(Console.WriteLine);
            }
        }
    }
}
