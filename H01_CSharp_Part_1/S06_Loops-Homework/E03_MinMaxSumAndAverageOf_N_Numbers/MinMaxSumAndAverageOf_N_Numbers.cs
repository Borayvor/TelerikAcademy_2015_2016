namespace E03_MinMaxSumAndAverageOf_N_Numbers
{
    using System;
    using System.Linq;

    public class MinMaxSumAndAverageOf_N_Numbers
    {
        public static void Main(string[] args)
        {
            // Write a program that reads from the console a sequence 
            // of n integer numbers and returns the minimal, the 
            // maximal number, the sum and the average of all numbers 
            // (displayed with 2 digits after the decimal point).
            // The input starts by the number n (alone in a line) 
            // followed by n lines, each holding an integer number.
            // The output is like in the examples below.
            // Example 1:
            // 
            // input	    output
            // 3	        min = 1
            // 2	        max = 5
            // 5	        sum = 8
            // 1	        
            //              avg = 2.67
            //
            // Example 2:           
            // input	    output
            // 2	        min = -1
            // -1	        max = 4
            // 4	        sum = 3
            //              avg = 1.50

            Console.WriteLine("Please, enter an integer !");
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());

            int[] sequence = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("number{0} = ", i + 1);
                sequence[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("min = {0}", sequence.Min());
            Console.WriteLine("min = {0}", sequence.Max());
            Console.WriteLine("min = {0}", sequence.Sum());
            Console.WriteLine("min = {0:f2}", sequence.Average());
            Console.WriteLine();
        }
    }
}
