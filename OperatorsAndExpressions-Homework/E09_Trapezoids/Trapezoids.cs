namespace E09_Trapezoids
{
    using System;

    public class Trapezoids
    {
        public static void Main(string[] args)
        {
            // Write an expression that calculates trapezoid's area by 
            // given sides a and b and height h.
            // Examples:
            // 
            // a	    b	    h	    area
            // 5	    7	    12	    72
            // 2	    1	    33	    49.5
            // 8.5	    4.3	    2.7	    17.28
            // 100	    200	    300	    45000
            // 0.222	0.333	0.555	0.1540125

            Console.WriteLine("This expression calculates trapezoid's area by given sides a and b and height h.");

            Console.Write("Please enter side \"a\": ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Please enter side \"b\": ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Please enter height \"h\": ");
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine("The trapezoid's area is: {0}", (((a + b) * h) / 2));
        }
    }
}
