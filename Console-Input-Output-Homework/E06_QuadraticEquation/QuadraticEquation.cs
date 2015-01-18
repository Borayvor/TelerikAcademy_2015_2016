namespace E06_QuadraticEquation
{
    using System;

    public class QuadraticEquation
    {
        public static void Main(string[] args)
        {
            // Write a program that reads the coefficients a, b and c 
            // of a quadratic equation ax2 + bx + c = 0 and solves 
            // it (prints its real roots).
            // Examples:
            // 
            // a	    b	    c	    roots
            // 2	    5	    -3	    x1=-3; x2=0.5
            // -1	    3	    0	    x1=3; x2=0
            // -0.5	    4	    -8	    x1=x2=4
            // 5	    2	    8	    no real roots

            Console.WriteLine("Please, enter a coefficients for \"ax2 + bx + c = 0\" !");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
                        
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            double D = (b * b) - (4 * a * c);

            if (D >= 0)
            {
                double x1 = (-b - Math.Sqrt(D)) / (2 * a);

                double x2 = (-b + Math.Sqrt(D)) / (2 * a);

                Console.WriteLine("The real roots are :");
                Console.WriteLine("x1 = {0}", x1);
                Console.WriteLine("x2 = {0}", x2);
            }
            else
            {
                Console.WriteLine("There are  no real roots.");
            }
        }
    }
}
