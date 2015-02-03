namespace E11_RandomNumbersInGivenRange
{
    using System;

    public class RandomNumbersInGivenRange
    {
        public static void Main(string[] args)
        {
            // Write a program that enters 3 integers n, min and max 
            // (min != max) and prints n random numbers in the range [min...max].
            // Examples:
            // 
            // n	min	max	random numbers
            // 5	0	1	1 0 0 1 1
            // 10	10	15	12 14 12 15 10 12 14 13 13 11
            // Note: The above output is just an example. Due to randomness, 
            // your program most probably will produce different results.

            Random randomGenerator = new Random();

            Console.WriteLine("Please, enter 3 integers n, min and max (min < max) !");

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int min = int.MaxValue;
            int max = int.MinValue;
            do
            {
                Console.Write("min = ");
                min = int.Parse(Console.ReadLine());

                Console.Write("max = ");
                max = int.Parse(Console.ReadLine());
            }
            while (min >= max);

            Console.WriteLine("Random numbers:");

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", randomGenerator.Next(min, max + 1));
            }

            Console.WriteLine();
        }
    }
}
