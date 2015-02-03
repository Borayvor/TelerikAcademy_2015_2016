namespace E12_RandomizeTheNumbers_1ToN
{
    using System;
    using System.Linq;

    public class RandomizeTheNumbers_1ToN
    {
        public static void Main(string[] args)
        {
            // Write a program that enters in integer n and prints 
            // the numbers 1, 2, …, n in random order.
            // Examples:
            // 
            // n	randomized numbers 1…n
            // 3	2 1 3
            // 10	3 4 8 2 6 7 9 1 10 5
            // Note: The above output is just an example. Due to randomness,
            // your program most probably will produce different results. 
            // You might need to use arrays.

            Random randomGenerator = new Random();

            Console.WriteLine("Please, enter an integer !");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (i + 1);
            }
                        
            var nubersNewOrder = numbers
                .OrderBy(x => randomGenerator.Next())                
                .ToArray();

            Console.WriteLine("randomized numbers");

            for (int i = 0; i < nubersNewOrder.Length; i++)
            {
                Console.Write("{0} ", nubersNewOrder[i]);
            }

            Console.WriteLine();
        }
    }
}
