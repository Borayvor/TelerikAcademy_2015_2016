namespace E05_SortByStringLength
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortByStringLength
    {
        public static void Main(string[] args)
        {
            // You are given an array of strings. Write a method 
            // that sorts the array by the length of its elements 
            // (the number of characters composing them).
            // Example:
            // Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            //
            // Result:
            // sit
            // amet
            // elit
            // Lorem
            // ipsum
            // dolor
            // adipiscing
            // consectetur

            Console.WriteLine("Please, enter an array of strings :");
            
            string[] words = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',', '.' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => ch.ToString())
               .ToArray();

            List<string> sortedWords = new List<string>();

            foreach (string word in SortByLength(words))
            {
                sortedWords.Add(word);
            }

            for (int index = 0; index < sortedWords.Count; index++)
            {
                Console.WriteLine("position {0}: {1}", index, sortedWords[index]);
            }
            Console.WriteLine();
        }


        private static IEnumerable<string> SortByLength(IEnumerable<string> wordsArray)
        {            
            var sorted = from word in wordsArray
                         orderby word.Length ascending
                         select word;

            return sorted;
        }
    }
}
