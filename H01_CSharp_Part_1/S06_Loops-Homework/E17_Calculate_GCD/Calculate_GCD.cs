namespace E17_Calculate_GCD
{
    using System;

    public class Calculate_GCD
    {
        public static void Main(string[] args)
        {
            // Write a program that calculates the greatest common 
            // divisor (GCD) of given two integers a and b.
            // Use the Euclidean algorithm (find it in Internet).
            // Examples:
            // 
            // a	    b	        GCD(a, b)
            // 3	    2	        1
            // 60	    40	        20
            // 5	    -15	        5

            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(GCD(a, b));
        }

        private static int GCD(int a, int b)
        {
            if(a < b)
            {
                return GCD(b, a);
            }

            int divisor = a % b;

            while (divisor != 0)
            {
                a = b;
                b = divisor;
                divisor = a % b;                
            }

            return b;
        }
    }
}
