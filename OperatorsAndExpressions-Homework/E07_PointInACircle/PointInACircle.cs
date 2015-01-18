namespace E07_PointInACircle
{
    using System;

    public class PointInACircle
    {
        public static void Main(string[] args)
        {
            // Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
            // Examples:
            // 
            // x	    y	    inside
            // 0	    1	    true
            // -2	    0	    true
            // -1	    2	    false
            // 1.5	    -1	    true
            // -1.5	    -1.5	false
            // 100	    -30	    false
            // 0	    0	    true
            // 0.2	    -0.8	true
            // 0.9	    -1.93	false
            // 1	    1.655	true

            Console.WriteLine("Is point (x, y) inside a circle K({0, 0}, 2) ?");

            Console.Write("Enter coordinate \"x\": ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Enter coordinate \"y\": ");
            double y = double.Parse(Console.ReadLine());

            if (((x * x) + (y * y)) <= 4)  //// a^2 + b^2 = c^2
            {
                Console.WriteLine("The point is within the circle K(0, 2).");
            }
            else
            {
                Console.WriteLine("The point is out of the circle K(0, 2).");
            }
        }
    }
}
