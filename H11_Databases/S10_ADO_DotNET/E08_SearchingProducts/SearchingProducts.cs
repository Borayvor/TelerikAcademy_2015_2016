namespace E08_SearchingProducts
{
    using System;
    using System.Data.SqlClient;

    public class SearchingProducts
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a serch word: ");
            var searchWord = Console.ReadLine();

            FindProductByGivenSearchWord(searchWord);
        }

        private static void FindProductByGivenSearchWord(string searchWord)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            using (dbConnection)
            {
                dbConnection.Open();

                var command = GetSearchByPatternSqlCommand(dbConnection, searchWord);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productName = reader["ProductName"];

                        Console.WriteLine(" - " + productName);
                    }
                }
            }
        }

        private static SqlCommand GetSearchByPatternSqlCommand(SqlConnection sqlConnection, string pattern)
        {
            var command = new SqlCommand(@"SELECT ProductName
                                                     FROM Products
                                                     WHERE CHARINDEX(@pattern, ProductName) > 0",
                                                     sqlConnection);
            command.Parameters.AddWithValue("@pattern", pattern);

            return command;
        }
    }
}
