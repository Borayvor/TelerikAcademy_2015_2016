namespace E07_ConvertTextToXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class ConvertTextToXml
    {
        public static void Main(string[] args)
        {
            var person = new Person();

            var fileDataToRows = GetFileData("../../phonebook.txt").Split('\n').ToArray();

            person.Name = fileDataToRows[0];
            person.City = fileDataToRows[1];
            person.PhoneNumber = fileDataToRows[2];

            var personElement = new XElement("person",
               new XElement("name", person.Name),
               new XElement("address", person.City),
               new XElement("phone", person.PhoneNumber));

            Console.WriteLine("Saved as person.xml");
            personElement.Save("../../person.xml");
        }

        private static string GetFileData(string fullPath)
        {
            string data;
            var reader = new StreamReader(fullPath);

            using (reader)
            {
                data = reader.ReadToEnd();
            }

            return data;
        }
    }
}
