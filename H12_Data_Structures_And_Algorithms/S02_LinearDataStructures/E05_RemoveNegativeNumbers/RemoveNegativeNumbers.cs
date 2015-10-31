namespace E05_RemoveNegativeNumbers
{
    using System;
    using System.Linq;
    using Utils;

    public class RemoveNegativeNumbers
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var sequence = reader.ReadSequenceOfInt();

            Console.WriteLine("Original Sequence: {0}", string.Join(", ", sequence));

            var newSequence = sequence
                .Where(x => x >= 0)
                .ToList();

            Console.WriteLine("Sequence without negative numbers: {0}", string.Join(", ", newSequence));
        }
    }
}
