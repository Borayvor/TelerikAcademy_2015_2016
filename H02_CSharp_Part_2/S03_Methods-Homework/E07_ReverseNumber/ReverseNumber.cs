namespace E07_ReverseNumber
{
    using System;

    public class ReverseNumber
    {
        public static void Main(string[] args)
        {
            // Write a method that reverses the digits 
            // of given decimal number.
            // Example:
            // input 	                output
            // 256 	                    652
            // 2147483647               7463847412

            int decimalNumber = GetNumber("a number");

            long reverseNumber = Reverse(decimalNumber);

            Console.WriteLine("The reversed number is : {0}", reverseNumber);
        }


        public static long Reverse(int number)
        {
            long result = 0;

            while (number != 0)
            {
                result = result * 10 + (long)number % 10; 
                number /= 10;
            }

            return result;
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
