namespace E06_PhoneBook
{
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var phoneBook = new PhoneBook();
            var input = new StreamReader("../../commands.txt");

            using (input)
            {
                for (string line = null; (line = input.ReadLine()) != null;)
                {
                    var parts = line
                        .Split(new[] { Entry.Separator }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(entry => entry.Trim())
                        .ToArray();

                    phoneBook.Add(parts[0], parts[1], parts[2]);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, phoneBook.Find("Bat Gancho")));

            Console.WriteLine();

            Console.WriteLine(string.Join(Environment.NewLine, phoneBook.Find("Bat Gancho", "Sofia")));
        }
    }
}
