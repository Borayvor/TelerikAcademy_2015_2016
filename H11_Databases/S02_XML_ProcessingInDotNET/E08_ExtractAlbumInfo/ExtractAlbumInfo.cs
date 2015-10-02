namespace E08_ExtractAlbumInfo
{
    using System;
    using System.Text;
    using System.Xml;

    public class ExtractAlbumInfo
    {
        public static void Main(string[] args)
        {
            XmlTextWriter writer = new XmlTextWriter("../../albums.xml", Encoding.UTF8);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                XmlReader reader = XmlReader.Create("../../../E01_Create_XML_Catalogue/catalogue.xml");

                using (reader)
                {
                    string albumName = string.Empty;

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "name")
                            {
                                albumName = reader.ReadElementString();                                
                            }
                            else if (reader.Name == "artist")
                            {
                                string artist = reader.ReadElementString();

                                WriteAlbum(writer, albumName, artist);                                
                            }
                        }
                    }
                }

                writer.WriteEndDocument();
            }

            Console.WriteLine("Document albums.xml was created.");           
        }

        private static void WriteAlbum(XmlWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}
