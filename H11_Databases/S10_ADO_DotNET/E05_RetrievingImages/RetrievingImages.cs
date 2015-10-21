namespace E05_RetrievingImages
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;

    public class RetrievingImages
    {
        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                var cmd = new SqlCommand("SELECT Picture FROM Categories", dbCon);

                RetrieveImagesFromDatabase(cmd);
            }

            Console.WriteLine("All pictures are stored !");
        }

        private static void RetrieveImagesFromDatabase(SqlCommand command)
        {
            var reader = command.ExecuteReader();

            using (reader)
            {
                var index = 1;

                while (reader.Read())
                {
                    var picture = (byte[])reader["Picture"];
                    StorePicturesAsJpegFiles(picture, "Picture" + index, ".jpg");
                    index++;
                }
            }
        }

        private static void StorePicturesAsJpegFiles(byte[] imgBinaryData, string fileName, string fileExtension)
        {
            const int oleMetaPictStartPosition = 78;

            var memoryStream =
                new MemoryStream(imgBinaryData, oleMetaPictStartPosition,
                imgBinaryData.Length - oleMetaPictStartPosition);

            using (memoryStream)
            {
                using (var image = Image.FromStream(memoryStream, true, true))
                {
                    image.Save("../../" + fileName + fileExtension);
                }
            }
        }
    }
}
