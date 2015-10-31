namespace E01_SequenceOfPositiveIntegers
{
    using System;
    using System.Linq;
    using Utils;

    public class SequenceOfPositiveIntegers
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var sequence = reader.ReadSequenceOfInt();

            Console.WriteLine("The sum of the values in the sequence is : {0}", sequence.Sum());
            Console.WriteLine("The average of the values in the sequence is : {0}", sequence.Average());
        }
    }
}
