namespace E07_CalculateNumberOfCombinations
{
    using System;

    public class CalculateNumberOfCombinations
    {
        public static void Main(string[] args)
        {
            // In combinatorics, the number of ways to choose k different 
            // members out of a group of n different elements (also known 
            // as the number of combinations) is calculated by the following 
            // formula: (N! / (K! * (N-K)!).For example, there are 2598960 
            // ways to withdraw 5 cards out of a standard deck of 52 cards.
            // Your task is to write a program that calculates n! / (k! * (n-k)!) 
            // for given n and k (1 < k < n < 100). Try to use only two loops.
            // Examples:
            // 
            // n	k	n! / (k! * (n-k)!)
            // 3	2	3
            // 4	2	6
            // 10	6	210
            // 52	5	2598960

            Console.WriteLine("Please, enter two positive integer numbers !");
            int n = -1;
            int k = -1;

            do
            {
                Console.Write("n = ");
                n = int.Parse(Console.ReadLine());
                Console.Write("k = ");
                k = int.Parse(Console.ReadLine());
            }
            while (!(1 < k && k < n && n < 100));

            Console.WriteLine("Result = {0:F0}", GetNumberOfCombinations(n, k));     
        }


        private static double GetNumberOfCombinations(int n, int k)
        {
            double result = 0;

            double factorialN = 1;
            double factorialK = 1;
            double factorial_N_Subtract_K = 1;

            for (int index = 1; index <= n; index++)
            {
                factorialN *= index;

                if (index <= k)
                {
                    factorialK *= index;
                }

                if (index <= (n - k))
                {
                    factorial_N_Subtract_K *= index;
                }
            }

            result = factorialN / (factorialK * factorial_N_Subtract_K);

            return result;
        }     
    }
}
