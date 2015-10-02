namespace E12_ExtractPriceWithLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractPriceWithLINQ
    {
        public static void Main(string[] args)
        {
            var xmlDoc = XDocument.Load("../../../E01_Create_XML_Catalogue/catalogue.xml");

            var albums = from album in xmlDoc.Descendants("album")
                         where (int.Parse(album.Element("year").Value) < 1990)
                         select new
                         {
                             Title = album.Element("name").Value,
                             Price = album.Element("price").Value
                         };

            Console.WriteLine("Found {0} albums:", albums.Count());

            foreach (var album in albums)
            {
                Console.WriteLine(" Album Name {0} --> Price {1}.00 USD", album.Title, album.Price);
            }
        }
    }
}
