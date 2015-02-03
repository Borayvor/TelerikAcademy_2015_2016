namespace E06_Calculate_NfactDivKfact
{
    using System;

    public class Calculate_NfactDivKfact
    {
        public static void Main(string[] args)
        {
            // Write a program that calculates n! / k! for 
            // given n and k (1 < k < n < 100).
            // Use only one loop.
            // Examples:
            // 
            // n	k	n! / k!
            // 5	2	60
            // 6	5	6
            // 8	3	6720

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

            Console.WriteLine("Result = {0:F0}", FactN_Div_FactK(n, k));     
        }


        private static double FactN_Div_FactK(int n, int k)
        {
            double result = 0;

            double factorialN = 1;
            double factorialK = 1;

            for (int index = 1; index <= n; index++)
            {
                factorialN *= index;

                if(index <= k)
                {
                    factorialK *= index;
                }
            }

            result = factorialN / factorialK;

            return result;
        }     
    }
}
