namespace E05_FindAllSalesByRegion
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using E01_NorthwindDbContext;

    public class FindAllSalesByRegion
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            FindAllSalesByDateRange("SP", 1995, 2001);
        }

        static void FindAllSalesByDateRange(string region, int startDate, int endDate)
        {
            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders
                    .Where(order => order.ShipRegion == region
                                    && order.OrderDate.Value.Year >= startDate
                                    && order.ShippedDate.Value.Year <= endDate)
                    .ToList();

                foreach (var sale in sales)
                {
                    Console.WriteLine("Ship Region: {0}, Ship Country: {1}",
                                        sale.ShipRegion, sale.ShipCountry);
                }
            }
        }
    }
}
