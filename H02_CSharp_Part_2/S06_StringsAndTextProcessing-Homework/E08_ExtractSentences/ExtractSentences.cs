namespace E08_ExtractSentences
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractSentences
    {
        public static void Main(string[] args)
        {
            // Write a program that extracts from a given text 
            // all sentences containing given word.
            // Example:
            // The word is: "in"
            // The text is: 
            // We are living in a yellow submarine. We don't have anything 
            // else. Inside the submarine is very tight. So we are drinking 
            // all the day. We will move out of it in 5 days.            
            // The expected result is: 
            // We are living in a yellow submarine. We will move out of it in 5 days.
            // 
            // Consider that the sentences are separated by . and the 
            // words – by non-letter symbols.

            string text = "We are living in a yellow submarine. We don't have anything " + 
                "else. Inside the submarine is very tight. So we are drinking all the " + 
                "day. We will move out of it in 5 days.";

            Console.WriteLine(text);

            string word = @"(?i)(\bin\b)"; // case insensitive
            string pattern = @"\s*([^\.]*" + word + @".*?\.)";

            MatchCollection matches = Regex.Matches(text, pattern);

            Console.WriteLine();
            Console.WriteLine("Result:");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }
    }
}
