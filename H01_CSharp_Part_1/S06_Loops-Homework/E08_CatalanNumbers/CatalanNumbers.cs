namespace E08_CatalanNumbers
{
    using System;

    public class CatalanNumbers
    {
        public static void Main(string[] args)
        {
            // In combinatorics, the Catalan numbers are 
            // calculated by the following formula: 
            // Cn = ( (2 * n)! / ((n + 1)! * n!) )  for n >= 0
            // Write a program to calculate the nth Catalan number 
            // by given n (1 <= n <= 100).
            // Examples:
            // 
            // n	Catalan(n)
            // 0	1
            // 5	42
            // 10	16796
            // 15	9694845

            Console.WriteLine("Please, enter a positive integer" +
                " \"n\" (1 <= n <= 100) !");

            int n = -1;
            do
            {
                Console.Write("n = ");
                n = int.Parse(Console.ReadLine());
            }
            while (!(1 <= n && n <= 100));

            Console.WriteLine("Result = {0:F0}", GetCatalanNumber(n));
        }


        private static double GetCatalanNumber(int n)
        {
            double result = 0;

            double factorialN = 1;
            double factorialNPlus1 = 1;
            double factorial2MultipliedN = 1;

            for (int index = 1; index <= (n * 2); index++)
            {
                if (index <= n)
                {
                    factorialN *= index;
                }

                if (index <= (n + 1))
                {
                    factorialNPlus1 *= index;
                }
                
                factorial2MultipliedN *= index;
            }

            result = factorial2MultipliedN / (factorialNPlus1 * factorialN);

            return result;
        }
    }
}
