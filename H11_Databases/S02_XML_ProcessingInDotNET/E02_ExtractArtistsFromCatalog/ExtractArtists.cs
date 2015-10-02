namespace E02_ExtractArtistsFromCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractArtists
    {
        public static void Main(string[] args)
        {
            var doc = new XmlDocument();
            doc.Load("../../../E01_Create_XML_Catalogue/catalogue.xml");
            var root = doc.DocumentElement;
                        
            PrintArtistsAndNumberOfAlbums(GetUniqueArtistsAndNumberOfAlbums(root));
            Console.WriteLine();
        }

        private static Dictionary<string, int> GetUniqueArtistsAndNumberOfAlbums(XmlElement root)
        {
            var artistsAndAlbums = new Dictionary<string, int>();
            var artists = root.GetElementsByTagName("artist");

            foreach (XmlElement artist in artists)
            {
                var artistName = artist.InnerText;

                if (artistsAndAlbums.ContainsKey(artistName))
                {
                    artistsAndAlbums[artistName] += 1;
                }
                else
                {
                    artistsAndAlbums.Add(artistName, 1);
                }
            }

            return artistsAndAlbums;
        }

        private static void PrintArtistsAndNumberOfAlbums(Dictionary<string, int> artistsList)
        {
            foreach (var artist in artistsList)
            {
                Console.WriteLine("{0}: {1} album(s)", artist.Key, artist.Value);
            }
        }
    }
}
