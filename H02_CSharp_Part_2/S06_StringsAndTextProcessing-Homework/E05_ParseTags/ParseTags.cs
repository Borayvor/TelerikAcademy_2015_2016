namespace E05_ParseTags
{
    using System;
    using System.Text.RegularExpressions;

    public class ParseTags
    {
        public static void Main(string[] args)
        {
            // You are given a text. Write a program that changes 
            // the text in all regions surrounded by the tags 
            // <upcase> and </upcase> to upper-case.
            // The tags cannot be nested.
            // Example: 
            // We are living in a <upcase>yellow submarine</upcase>. 
            // We don't have <upcase>anything</upcase> else.
            // The expected result: 
            // We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

            string text = "We are living in a <upcase>yellow submarine</upcase>. " + 
                "We don't have <upcase>anything</upcase> else.";
            Console.WriteLine(text);
            Console.WriteLine();

            string regText = @"<upcase>(.*?)</upcase>";

            string newText = Regex.Replace(text, regText, m => m.Groups[1].Value.ToUpper());

            Console.WriteLine(newText);
        }
    }
}
