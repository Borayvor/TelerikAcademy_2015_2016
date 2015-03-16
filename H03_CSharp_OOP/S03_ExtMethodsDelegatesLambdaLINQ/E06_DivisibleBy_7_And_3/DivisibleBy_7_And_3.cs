namespace E06_DivisibleBy_7_And_3
{
    using System;
    using System.Linq;

    public class DivisibleBy_7_And_3
    {
        public static void Main(string[] args)
        {
            // Write a program that prints from given array of integers all 
            // numbers that are divisible by 7 and 3. Use the built-in extension 
            // methods and lambda expressions. Rewrite the same with LINQ.

            int[] array = new int[] { 10, 22, 21, 42, 3, 5, 1, 20, 12, 72, 31, 51, 210 };

            // Lambda expression:
            int[] lambdaResult = array
                .Where(x => x % 21 == 0)
                .ToArray();

            Console.WriteLine("Lambda expression:");
            foreach (int item in lambdaResult)
            {
                Console.WriteLine("Divisible by 7 and 3 -> {0}", item);
            }

            Console.WriteLine();

            // LINQ:             
            int[] linqResult = (
                from number in array
                where number % 21 == 0
                select number
                ).ToArray();

            Console.WriteLine("LINQ:");
            foreach (int item in linqResult)
            {
                Console.WriteLine("Divisible by 7 and 3 -> {0}", item);
            }

            Console.WriteLine();
        }
    }
}
