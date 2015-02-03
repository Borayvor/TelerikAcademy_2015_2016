namespace E05_CalculateFactorialSum
{
    using System;    

    public class CalculateFactorialSum
    {
        public static void Main(string[] args)
        {
            // Write a program that, for a given two integer 
            // numbers n and x, calculates the 
            // sum S = 1 + 1!/x + 2!/x2 + … + n!/x^n.
            // Use only one loop. Print the result with 5 digits 
            // after the decimal point.
            // Examples:
            // 
            // n	x	S
            // 3	2	2.75000
            // 4	3	2.07407
            // 5	-4	0.75781

            Console.WriteLine("Please, enter two integer numbers !");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());
                        
            double result = 1;
            double factorial = 1;
            int xAtpowerN = 1;
                        
            for (int index = 1; index <= n; index++)
            {
                factorial *= index;
                xAtpowerN *= x;
                result += factorial / xAtpowerN;                
            }

            Console.WriteLine("Result = {0}", result);
        }       
    }
}
