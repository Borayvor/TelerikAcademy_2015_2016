namespace E02_ReverseTheSequence
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public class ReverseTheSequence
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var stack = new Stack<int>();

            var sequence = reader.ReadSequenceOfInt();

            Console.WriteLine("Original Sequence: {0}", string.Join(", ", sequence));

            sequence.ForEach(x => stack.Push(x));
            sequence.Clear();

            sequence.AddRange(stack);

            Console.WriteLine("Reversed Sequence: {0}", string.Join(", ", sequence));
        }
    }
}
