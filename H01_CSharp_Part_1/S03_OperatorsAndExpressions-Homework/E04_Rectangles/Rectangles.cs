namespace E04_Rectangles
{
    using System;

    public class Rectangles
    {
        public static void Main(string[] args)
        {
            // Write an expression that calculates rectangle’s perimeter and area by given width and height.
            // Examples:
            // 
            // width    height	perimeter	area
            // 3	    4	    14	        12
            // 2.5	    3	    11	        7.5
            // 5	    5	    20	        25
                        
            Console.WriteLine("Calculate rectangle’s perimeter and area by given width and height.");
            Console.Write("Please, enter a width : ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Please, enter a height : ");
            double height = double.Parse(Console.ReadLine());

            decimal perimeter = (2 * (decimal)width) + (2 * (decimal)height);
            Console.WriteLine("The rectangle’s perimeter is : {0}", perimeter);

            decimal area = (decimal)width * (decimal)height;
            Console.WriteLine("The rectangle’s area is : {0}", area);
        }
    }
}
