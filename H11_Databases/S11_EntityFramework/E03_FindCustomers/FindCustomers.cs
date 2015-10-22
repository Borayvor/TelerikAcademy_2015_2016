namespace E03_FindCustomers
{
    using System;
    using System.Linq;
    using E01_NorthwindDbContext;

    public class FindCustomers
    {
        public static void Main(string[] args)
        {
            FindAllCustomers(1997, "Canada");
        }

        private static void FindAllCustomers(int orderDate, string shipDestination)
        {
            using (var db = new NorthwindEntities())
            {
                var orders =
                    db.Orders.Where(
                        order => order.OrderDate.Value.Year == orderDate
                        && order.ShipCountry == shipDestination);

                foreach (var item in orders)
                {
                    Console.WriteLine("Order made by: {0} with CustomerId: {1}",
                        item.Customer.ContactName, item.Customer.CustomerID);
                }
            }
        }
    }
}
