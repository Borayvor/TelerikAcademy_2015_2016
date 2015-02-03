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
            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 1; i <= n; i++)
            {
                int devider = i;

                while (devider % 5 == 0)
                {
                    counter++;
                    devider /= 5;
                    // Look at the example
                    // explaination -> zero is added on every fifth number 
                }
            }

            Console.WriteLine("There are {0} zeros in N!", counter);
        }
    }
}
