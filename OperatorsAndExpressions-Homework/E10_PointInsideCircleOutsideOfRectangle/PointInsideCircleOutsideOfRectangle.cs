namespace E10_PointInsideCircleOutsideOfRectangle
{
    using System;

    public class PointInsideCircleOutsideOfRectangle
    {
        private const double CX = 1;
        private const double CY = 1;
        private const double CR = 1.5;

        public static void Main(string[] args)
        {
            // Write an expression that checks for given point (x, y) 
            // if it is within the circle K({1, 1}, 1.5) and out of the 
            // rectangle R(top=1, left=-1, width=6, height=2).
            // Examples:
            // 
            // x	    y	    inside K & outside of R
            // 1	    2	    yes
            // 2.5	    2	    no
            // 0	    1	    no
            // 2.5	    1	    no
            // 2	    0	    no
            // 4	    0	    no
            // 2.5	    1.5	    no
            // 2	    1.5	    yes
            // 1	    2.5	    yes
            // -100	    -100	no            

            Console.WriteLine("Check for given point (x, y) if it is within the " +
                "circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).");

            Console.Write("Enter coordinate \"x\": ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Enter coordinate \"y\": ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine();

            if (IsInCircle(x, y) && IsOutOfRectangle(x, y))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

            Console.WriteLine();
        }


        private static bool IsInCircle(double x, double y)
        {
            double a2 = (x - CX) * (x - CX);
            double b2 = (y - CY) * (y - CY);
            double c2 = (CR * CR);

            if((a2 + b2) <= c2)
            {
                return true;
            }

            return false;
        }

        private static bool IsOutOfRectangle(double x, double y)
        {
            double x1 = -1, x2 = 5;
            double y1 = 1, y2 = -1;

            if ((x < x1 || x > x2 || y > y1 || y < y2))
            {
                return true;
            }

            return false;
        }
    }
}
