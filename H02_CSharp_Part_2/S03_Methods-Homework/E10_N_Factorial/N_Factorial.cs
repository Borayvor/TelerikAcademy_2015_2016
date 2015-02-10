namespace E10_N_Factorial
{
    using System;
    using System.Numerics;

    public class N_Factorial
    {
        public static void Main(string[] args)
        {
            // Write a program to calculate n! for 
            // each n in the range [1..100].
            // Hint: Implement first a method that multiplies 
            // a number represented as array of digits 
            // by given integer number.

            int range = 100;

            for (int index = 1; index <= range; index++)
            {
                Console.WriteLine("    {0}! = {1}\n", index, Factorial(index));
            }
        }


        private static BigInteger Factorial(int number)
        {
            if(number < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            BigInteger factorial = 1;

            for (int index = number; index > 1; index--)
            {
                factorial *= index;
            }

            return factorial;
        }
    }
}
