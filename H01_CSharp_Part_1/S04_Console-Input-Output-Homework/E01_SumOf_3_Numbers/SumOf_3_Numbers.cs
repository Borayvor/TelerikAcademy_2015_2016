namespace E01_SumOf_3_Numbers
{
    using System;

    public class SumOf_3_Numbers
    {
        public static void Main(string[] args)
        {
            // Write a program that reads 3 real numbers from the 
            // console and prints their sum.
            // Examples:
            // 
            // a	    b	    c	    sum
            // 3	    4	    11	    18
            // -2	    0	    3	    1
            // 5.5	    4.5	    20.1	30.1

            Console.Write("Please, enter value for -> a = ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Please, enter value for -> b = ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Please, enter value for -> c = ");
            double c = double.Parse(Console.ReadLine());

            double sum = a + b + c;
            Console.WriteLine("The sum of the numbers is : sum = {0}", sum);
            Console.WriteLine();
        }
    }
}
