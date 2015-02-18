namespace E06_SumIntegers
{
    using System;
    using System.Linq;

    public class SumIntegers
    {
        public static void Main(string[] args)
        {
            // You are given a sequence of positive integer values 
            // written into a string, separated by spaces.
            // Write a function that reads these values from given 
            // string and calculates their sum.
            // Example:
            // input 	                    output
            // 43 68 9 23 318 	            461

            Console.Write("Please, enter a sequence of positive " + 
                "integer values, separated by spaces : ");

            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new char[] { ' ', '\t', ',' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int sumOfNumbers = numbers.Sum();

            Console.WriteLine("The sum of these values is : {0}", sumOfNumbers);
        }
    }
}
