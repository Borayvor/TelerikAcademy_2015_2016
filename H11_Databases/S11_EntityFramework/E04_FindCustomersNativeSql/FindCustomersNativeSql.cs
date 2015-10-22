namespace E04_FindCustomersNativeSql
{
    using System;
    using E01_NorthwindDbContext;

    public class FindCustomersNativeSql
    {
        public static void Main(string[] args)
        {
            FindAllCustomersWithNativeSql(1997, "Canada");
        }

        static void FindAllCustomersWithNativeSql(int orderDate, string country)
        {
            using (var db = new NorthwindEntities())
            {
                string sqlQuery = @"SELECT c.ContactName from Customers c " +
                                  "INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                                  "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1})";

                object[] parameters =
                {
                    orderDate,
                    country
                };

                var sqlQueryResult = db.Database.SqlQuery<string>(sqlQuery, parameters);

                foreach (var order in sqlQueryResult)
                {
                    Console.WriteLine(order);
                }
            }
        }
    }
}
