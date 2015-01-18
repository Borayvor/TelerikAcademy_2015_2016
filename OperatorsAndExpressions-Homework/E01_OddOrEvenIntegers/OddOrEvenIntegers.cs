namespace E01_OddOrEvenIntegers
{
    using System;

    public class OddOrEvenIntegers
    {
        public static void Main(string[] args)
        {
            // Write an expression that checks if given integer is odd or even.
            // Examples:
            // 
            // n	Odd?
            // 3	true
            // 2	false
            // -2	false
            // -1	true
            // 0	false

            int number;

            Console.Write("Enter number: ");

            number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("The number {0} is even.", number);
            }
            else
            {
                Console.WriteLine("The number {0} is odd.", number);
            }
        }
    }
}
