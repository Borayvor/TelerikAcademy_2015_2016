namespace E18_TrailingZeroesInFactorialN
{
    using System;

    public class TrailingZeroesInFactorialN
    {
        public static void Main(string[] args)
        {
            // Write a program that calculates with how many zeroes 
            // the factorial of a given number n has at its end.
            // Your program should work well for very big numbers, 
            // e.g. n=100000.
            // Examples:
            // 
            // n	    trailing zeroes of n!	explaination
            // 10	    2	                    3628800
            // 20	    4	                    2432902008176640000
            // 100000	24999	                think why

            Console.WriteLine("Please, enter a positive integer number !");
            Console.Write("n = ");
            int number = int.Parse(Console.ReadLine().Trim());

            int zeroes = 0, product = 5;

            while (number >= product)
            {
                zeroes += number / product;
                product *= 5;
            }

            Console.WriteLine("There are {0} zeros in {1}!", zeroes, number);
        }
    }
}
