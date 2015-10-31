namespace E06_RemoveNumbersThatOccurOddNumberOfTimes
{
    using System;
    using System.Linq;
    using Utils;

    public class RemoveNumbersThatOccurOddNumberOfTimes
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var sequence = reader.ReadSequenceOfInt();

            Console.WriteLine("Original Sequence: {0}", string.Join(", ", sequence));

            var newSequence = sequence
                .Where(x => sequence.Count(y => y == x) % 2 == 0)
                .ToList();

            Console.WriteLine(
                "Sequence without ll numbers that occur odd number of times: {0}", 
                string.Join(", ", newSequence));
        }
    }
}
