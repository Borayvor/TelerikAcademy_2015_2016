namespace E07_CountOfOccurences
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public class CountOfOccurences
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var dictionary = new SortedDictionary<int, int>();

            var sequence = reader.ReadSequenceOfInt();

            foreach (var number in sequence)
            {
                if (0 <= number && number <= 1000)
                {
                    if (dictionary.ContainsKey(number))
                    {
                        dictionary[number]++;
                    }
                    else
                    {
                        dictionary[number] = 1;
                    }
                }
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0} - {1} times", pair.Key, pair.Value);
            }
        }
    }
}
