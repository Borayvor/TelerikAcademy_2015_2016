namespace E02_GetLargestNumber
{
    using System;

    public class GetLargestNumber
    {
        public static void Main(string[] args)
        {
            // Write a method GetMax() with two parameters that 
            // returns the larger of two integers.
            // Write a program that reads 3 integers from the 
            // console and prints the largest of them using 
            // the method GetMax().

            int first = GetNumber("first number");
            int second = GetNumber("second number");
            int third = GetNumber("third number");

            Console.WriteLine();

            Console.WriteLine("\"{0}\" is the biggest number.", 
                GetMax(GetMax(first, second), third));
            Console.WriteLine();
        }


        private static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            else if (first < second)
            {
                return second;
            }
            else
            {
                return first;
            }
        }


        private static int GetNumber(string name)
        {
            int number = int.MinValue;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = int.TryParse(Console.ReadLine(), out number);
            }
            while (isNumber == false);

            return number;
        }
    }
}
