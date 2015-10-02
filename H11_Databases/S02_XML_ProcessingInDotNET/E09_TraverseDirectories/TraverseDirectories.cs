namespace E09_TraverseDirectories
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class TraverseDirectories
    {
        public static void Main(string[] args)
        {
            string folderLocation = "../../";
            string outpitFile = "../../directory.xml";

            DirectoryInfo currentDirectory = new DirectoryInfo(folderLocation);
            Encoding encoding = Encoding.GetEncoding("utf-8");

            XmlTextWriter writer = new XmlTextWriter(outpitFile, encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement(currentDirectory.Name);

                TraverseDir(writer, currentDirectory);

                writer.WriteEndDocument();
            }

            Console.WriteLine("Document directory.xml created.");
            Console.WriteLine();
        }

        private static void TraverseDir(XmlTextWriter writer, DirectoryInfo dir)
        {           
            var directories = dir.GetDirectories();

            foreach (var directory in directories)
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", directory.Name);

                TraverseDir(writer, directory);

                writer.WriteEndElement();                                
            }

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }
        }        
    }
}

