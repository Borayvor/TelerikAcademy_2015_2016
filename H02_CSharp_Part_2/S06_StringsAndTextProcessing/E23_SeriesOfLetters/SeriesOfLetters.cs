namespace E23_SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfLetters
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a string from the console and 
            // replaces all series of consecutive identical letters 
            // with a single one.
            // Example:
            // input:
            // aaaaabbbbbcdddeeeeffggh
            // output:
            // abcdefgh

            string text = "aaaaabbbbbcdddeeeeffggh";

            Console.WriteLine(text);

            var pattern = @"(\w)\1+";
            var replacement = "$1";

            Console.WriteLine("Result:");
            Console.WriteLine(Regex.Replace(text, pattern, replacement));
        }
    }
}
