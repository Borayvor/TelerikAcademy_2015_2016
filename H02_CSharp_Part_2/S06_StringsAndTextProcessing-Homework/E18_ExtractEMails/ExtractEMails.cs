namespace E18_ExtractEMails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEMails
    {
        public static void Main(string[] args)
        {
            // Write a program for extracting all email addresses 
            // from given text. All sub-strings that match the format: 
            // <identifier>@<host>…<domain>
            // should be recognized as emails.

            string text = "Static void Main() nakov@telerik.com. using System,nakov@gmail.com return";

            Console.WriteLine(text);

            string pattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b";

            var matches = Regex.Matches(text, pattern);

            Console.WriteLine("All email addresses:");

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
