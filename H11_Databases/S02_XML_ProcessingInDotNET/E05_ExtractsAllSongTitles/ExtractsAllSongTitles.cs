namespace E05_ExtractsAllSongTitles
{
    using System;
    using System.Xml;

    public class ExtractsAllSongTitles
    {
        public static void Main(string[] args)
        {
            XmlReader reader = new XmlTextReader("../../../E01_Create_XML_Catalogue/catalogue.xml");

            using (reader)
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        Console.WriteLine("Title: {0}", reader.ReadElementString());
                    }
                }
            }
        }
    }
}
