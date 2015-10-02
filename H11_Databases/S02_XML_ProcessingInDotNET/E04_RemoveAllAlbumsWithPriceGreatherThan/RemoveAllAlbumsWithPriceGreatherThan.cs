namespace E04_RemoveAllAlbumsWithPriceGreatherThan
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Xml;

    public class RemoveAllAlbumsWithPriceGreatherThan
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var doc = new XmlDocument();
            doc.Load("../../../E01_Create_XML_Catalogue/catalogue.xml");
            var root = doc.DocumentElement;
            
            RemoveAllAlbumsWithPriceGreatherThanTwenty(root);

            doc.Save("../../updatedCatalogue.xml");
            Console.WriteLine("new catalogue saved as updatedCatalogue.xml");
            Console.WriteLine();
        }

        private static void RemoveAllAlbumsWithPriceGreatherThanTwenty(XmlElement root)
        {
            const double maxPrice = 20.0;
                        
            var albums = root.SelectNodes("/catalogue/album");

            foreach (XmlElement album in albums)
            {
                var albumPrice = album["price"].InnerText;
                var price = double.Parse(albumPrice); 

                if (price > maxPrice)
                {
                    root.RemoveChild(album);
                }
            }
        } 
    }
}
