namespace E03_CirclePerimeterAndArea
{
    using System;

    public class CirclePerimeterAndArea
    {
        public static void Main(string[] args)
        {
            // Write a program that reads the radius r of a circle and 
            // prints its perimeter and area formatted with 2 digits 
            // after the decimal point.
            // Examples:
            // 
            // r	    perimeter	    area
            // 2	    12.57	        12.57
            // 3.5	    21.99	        38.48

            Console.WriteLine("Please, enter the radius of a circle !");
            Console.Write("r = ");
            double r = double.Parse(Console.ReadLine());

            double perimeter = 2 * Math.PI * r;
            double area = Math.PI * r * r;

            Console.WriteLine("The perimeter of the circle is : {0:0.00}", perimeter);
            Console.WriteLine("The area of the circle is : {0:f2}", area);
            Console.WriteLine();
        }
    }
}
