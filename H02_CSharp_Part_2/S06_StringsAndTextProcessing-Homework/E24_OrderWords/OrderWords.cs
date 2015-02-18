namespace E24_OrderWords
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class OrderWords
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a list of words, separated by 
            // spaces and prints the list in an alphabetical order.

            string text = "Write a program that reads a list of words, separated " + 
                "by spaces and prints the list in an alphabetical order.";

            Console.WriteLine(text);

            var words = new List<string>();
            var pattern = @"\w+";
            var matches = Regex.Matches(text, pattern);

            foreach (Match word in matches)
            {
                words.Add(word.Value);
            }

            words.Sort();

            Console.WriteLine();
            Console.WriteLine("Result:");

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
