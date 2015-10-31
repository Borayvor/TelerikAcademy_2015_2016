namespace E03_SortSequenceIncreasingOrder
{
    using System;
    using Utils;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var sequence = reader.ReadSequenceOfInt();

            Console.WriteLine("Original Sequence : {0}", string.Join(", ", sequence));

            sequence.Sort();

            Console.WriteLine("Sorted Sequence : {0}", string.Join(", ", sequence));
        }
    }
}
