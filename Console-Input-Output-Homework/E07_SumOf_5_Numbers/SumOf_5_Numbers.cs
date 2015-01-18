namespace E07_SumOf_5_Numbers
{
    using System;
    using System.Linq;

    public class SumOf_5_Numbers
    {
        public static void Main(string[] args)
        {
            // Write a program that enters 5 numbers 
            // (given in a single line, separated by a space), 
            // calculates and prints their sum.
            // Examples:
            // 
            // numbers	            sum
            // 1 2 3 4 5	        15
            // 10 10 10 10 10	    50
            // 1.5 3.14 8.2 -1 0	11.84

            Console.WriteLine("Please, enter 5 numbers !");

            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .ToArray();

            Console.WriteLine("The sum of the numbers is : {0}", numbers.Sum());
        }
    }
}
