namespace E04_AddingNewProduct
{
    using System;
    using System.Data.SqlClient;

    public class AddingNewProduct
    {
        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                var newProductId = InsertProducts("Bob", 2, 5, "1000", 0.01M, 2000, 50, 0, false, dbCon);

                Console.WriteLine("New Product Id: {0}", newProductId);
            }
        }

        private static int InsertProducts(string productName, int supplierID, int categoryID, string quantityPerUnit,
            decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued,
            SqlConnection dbCon)
        {
            SqlCommand cmdInsertProducts = new SqlCommand(
                "INSERT INTO Products(ProductName, SupplierID, categoryID, QuantityPerUnit, " +
                "UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, " +
                "@unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)",
                dbCon);

            cmdInsertProducts.Parameters.AddWithValue("@productName", productName);
            cmdInsertProducts.Parameters.AddWithValue("@supplierID", supplierID);
            cmdInsertProducts.Parameters.AddWithValue("@categoryID", categoryID);
            cmdInsertProducts.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmdInsertProducts.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmdInsertProducts.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmdInsertProducts.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmdInsertProducts.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmdInsertProducts.Parameters.AddWithValue("@discontinued", discontinued);

            cmdInsertProducts.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();

            return insertedRecordId;
        }
    }
}
