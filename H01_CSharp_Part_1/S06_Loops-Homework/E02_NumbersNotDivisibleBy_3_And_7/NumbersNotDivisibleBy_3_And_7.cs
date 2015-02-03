namespace E02_NumbersNotDivisibleBy_3_And_7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NumbersNotDivisibleBy_3_And_7
    {
        public static void Main(string[] args)
        {
            // Write a program that enters from the console 
            // a positive integer n and prints all the numbers 
            // from 1 to n not divisible by 3 and (or)? 7, on a single 
            // line, separated by a space.
            // Examples:
            // 
            // n	output
            // 3	1 2
            // 10	1 2 4 5 8 10

            Console.WriteLine("Please, enter a positive integer !");
            Console.Write("n = ");
            uint n = uint.Parse(Console.ReadLine());

            Console.Write("Result = ");
            for (int i = 1; i <= n; i++)
            {                
                if (i % 3 != 0 && i % 7 != 0)
                {
                    Console.Write(i);
                }

                if (i < n)
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine("\n");
        }
    }
}
