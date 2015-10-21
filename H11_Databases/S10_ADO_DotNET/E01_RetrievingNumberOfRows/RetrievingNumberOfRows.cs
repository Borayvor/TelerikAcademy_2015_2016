namespace E01_RetrievingNumberOfRows
{
    using System;
    using System.Data.SqlClient;

    public class RetrievingNumberOfRows
    {
        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand categoryRowsCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);

                int numberOfRows = (int)categoryRowsCount.ExecuteScalar();

                Console.WriteLine();
                Console.WriteLine("Number of rows in the Categories table: --> {0}", numberOfRows);
                Console.WriteLine();
            }
        }
    }
}
