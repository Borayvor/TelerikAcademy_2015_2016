namespace E10_TraverseDirectoriesWith_X
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class TraverseDirectoriesWith_X
    {
        public static void Main(string[] args)
        {
            string folderLocation = "../../";
            string outpitFile = "../../directory.xml";

            DirectoryInfo currentDirectory = new DirectoryInfo(folderLocation);

            var doc = new XDocument(TraverseDir(currentDirectory));
            doc.Save(outpitFile);

            Console.WriteLine("Document directory.xml created.");
            Console.WriteLine();
        }

        private static XElement TraverseDir(DirectoryInfo dir)
        {
            var element = new XElement("dir", new XAttribute("name", dir.Name));
            var directories = dir.GetDirectories();

            foreach (var directory in directories)
            {
                element.Add(TraverseDir(directory));
            }

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                element.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            return element;
        }
    }
}
