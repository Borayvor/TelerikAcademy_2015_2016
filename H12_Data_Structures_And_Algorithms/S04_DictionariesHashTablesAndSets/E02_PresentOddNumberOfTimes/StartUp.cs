namespace E02_PresentOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] testSequence = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            Console.WriteLine("The sequence is: {0}", string.Join(", ", testSequence));
            Console.WriteLine();

            var occurrences = GroupByOccurrence(testSequence);
            var result = occurrences.Where(kvp => kvp.Value % 2 != 0);

            Console.WriteLine(string.Join(" ", result));
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
