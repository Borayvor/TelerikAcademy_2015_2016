namespace E22_WordsCount
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class WordsCount
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a string from the console and 
            // lists all different words in the string along with 
            // information how many times each word is found.

            string text = "Write a program that reads a string from the console and " + 
                "lists all different words in the string along with information how " + 
                "many times each word is found.";

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            var matches = Regex.Matches(text, @"\w+");

            foreach (Match word in matches)
            {
                dictionary[word.Value] = dictionary.ContainsKey(word.Value) 
                    ? dictionary[word.Value] + 1 
                    : 1;
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
}
