namespace E06_ExtractsAllSongTitlesWithLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractsAllSongTitlesWithLINQ
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Load("../../../E01_Create_XML_Catalogue/catalogue.xml");

            var songTitles = from song in doc.Descendants("song")
                             select song.Element("title").Value;

            songTitles = songTitles.OrderBy(t => t);

            foreach (var title in songTitles)
            {
                Console.WriteLine("Song Title: {0}", title);
            }

            Console.WriteLine();
        }
    }
}
