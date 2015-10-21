namespace E09_MySQL_Library
{
    using System;
    using System.Globalization;
    using MySql.Data.MySqlClient;

    public class MySQL_Library
    {
        private static readonly Library Library = new Library();
        private static MySqlConnection mySqlConnection;

        public static void Main(string[] args)
        {
            string connectionStr = "Server=localhost; Database=library; Uid=John Doe; Pwd=Telerik;";
            mySqlConnection = new MySqlConnection(connectionStr);
            mySqlConnection.Open();

            try
            {
                AddBooks();
                FindBooksByName("Nulla");
                ListingAllBooks();
                DeleteAllRecords();
            }
            finally
            {
                DisconnectFromDatabase();
            }
        }

        private static void AddBooks()
        {
            Console.WriteLine("Adding books: ");

            var mySqlCommand = new MySqlCommand(@"INSERT INTO Books (Title, Author, PublishDate, ISBN)
                                                           VALUES (@title, @author, @publishDate, @isbn)",
                mySqlConnection);

            foreach (var book in Library.Books)
            {
                var title = book.Title;
                var author = book.Author;
                var publishDate = book.PublishDate;
                var isbn = book.Isbn;

                mySqlCommand.Parameters.AddWithValue("@title", title);
                mySqlCommand.Parameters.AddWithValue("@author", author);
                mySqlCommand.Parameters.AddWithValue("@publishDate", publishDate.Value.ToShortDateString());
                mySqlCommand.Parameters.AddWithValue("@isbn", isbn);

                var queryResult = mySqlCommand.ExecuteNonQuery();
                mySqlCommand.Parameters.Clear();

                Console.WriteLine("    ({0} row(s) affected)", queryResult);
            }
        }

        private static void FindBooksByName(string substring)
        {
            Console.WriteLine("\nFinding books by name '{0}':", substring);

            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM Books
                                                           WHERE LOCATE(@substring, Title)", mySqlConnection);

            mySqlCommand.Parameters.AddWithValue("@substring", substring);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var dateAsString = reader["PublishDate"].ToString();
                    var publishDate = DateTime.ParseExact(dateAsString, "d/M/yyyy", CultureInfo.InvariantCulture);
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        Isbn = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void ListingAllBooks()
        {
            Console.WriteLine("Listing all books: ");

            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                           FROM Books", mySqlConnection);

            using (var reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var dateAsString = reader["PublishDate"].ToString();
                    var publishDate = DateTime.ParseExact(dateAsString, "d/M/yyyy", CultureInfo.InvariantCulture);
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        Isbn = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void DeleteAllRecords()
        {
            Console.WriteLine("Deleting all books: ");

            var mySqlCommand = new MySqlCommand(@"DELETE FROM Books
                                                           WHERE Id > 0", mySqlConnection);
            var queryResult = mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("    ({0} row(s) affected)\n", queryResult);
        }

        private static void DisconnectFromDatabase()
        {
            mySqlConnection?.Close();
        }
    }
}
