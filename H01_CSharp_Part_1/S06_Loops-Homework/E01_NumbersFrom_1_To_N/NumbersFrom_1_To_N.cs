namespace E01_NumbersFrom_1_To_N
{
    using System;

    public class NumbersFrom_1_To_N
    {
        public static void Main(string[] args)
        {
            // Write a program that enters from the console 
            // a positive integer n and prints all the numbers 
            // from 1 to n, on a single line, separated by a space.
            // Examples:
            // 
            // n	output
            // 3	1 2 3
            // 5	1 2 3 4 5

            Console.WriteLine("Please, enter a positive integer !");
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());

            Console.Write("Result = ");
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i);

                if(i < n)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine("\n");
        }
    }
}
