namespace E03_ProductsAndCategories
{
    using System;
    using System.Data.SqlClient;

    public class ProductsAndCategories
    {
        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand categoryProductName = new SqlCommand(
                    "SELECT CategoryName, ProductName " +
                    "FROM Categories c " +
                    "JOIN Products p " +
                    "ON c.CategoryID = p.CategoryID",
                    dbCon);

                var reader = categoryProductName.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("CategoryName  |  ProductName");

                    while (reader.Read())
                    {
                        var categoryName = reader["CategoryName"].ToString();
                        var productName = reader["ProductName"].ToString();

                        Console.WriteLine("{0}  |  {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
