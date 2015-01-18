namespace E05_SquareRoot
{
    using System;

    public class SquareRoot
    {
        public static void Main(string[] args)
        {
            // Create a console application that calculates and prints the square root of the number 12345.
            // Find in Internet “how to calculate square root in C#”.

            var squareRoot = Math.Sqrt(12345);
            Console.WriteLine("Square Root from 12345 = {0}", squareRoot);
            Console.WriteLine();
        }
    }
}
