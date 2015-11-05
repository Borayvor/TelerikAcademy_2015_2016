namespace E03_HowManyTimesAppears
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string FileNameAndPath = "../../words.txt";

            using (var inputStream = new StreamReader(FileNameAndPath))
            {
                var words = new List<string>();

                while (!inputStream.EndOfStream)
                {
                    var line = inputStream.ReadLine();

                    Console.WriteLine(line);

                    var currentWords = Regex
                        .Matches(line, @"\w+")
                        .Cast<Match>()
                        .Select(match => match.Value)
                        .ToArray();

                    words.AddRange(currentWords
                        .Select(word => word.ToLower()));
                }

                Console.WriteLine();

                var orderedGroups = GroupByOccurrence(words)
                    .OrderBy(kvp => kvp.Value);

                Console.WriteLine(string.Join(" ", orderedGroups));
            }

            Console.WriteLine();
        }

        private static IDictionary<T, int> GroupByOccurrence<T>(IEnumerable<T> elements)
        {
            var groupedElements = elements
                .GroupBy(el => el)
                .ToDictionary(group => group.Key, group => group.Count());

            return groupedElements;
        }
    }
}
