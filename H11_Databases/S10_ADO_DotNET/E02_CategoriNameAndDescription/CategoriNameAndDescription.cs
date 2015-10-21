namespace E02_CategoriNameAndDescription
{
    using System;
    using System.Data.SqlClient;

    public class CategoriNameAndDescription
    {
        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand categoryDescription = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", dbCon);

                var reader = categoryDescription.ExecuteReader();

                using (reader)
                {
                    Console.WriteLine("CategoryName  |  Description");

                    while (reader.Read())
                    {
                        var categoryName = reader["CategoryName"].ToString();
                        var description = reader["Description"].ToString();

                        Console.WriteLine("{0}  |  {1}", categoryName, description);
                    }
                }
            }
        }
    }
}
