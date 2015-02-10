namespace E03_EnglishDigit
{
    using System;

    public class EnglishDigit
    {
        public static void Main(string[] args)
        {
            // Write a method that returns the last digit of 
            // given integer as an English word.
            // Examples:
            // input 	        output
            // 512 	            two
            // 1024 	        four
            // 12309 	        nine

            int varNumber = GetNumber("a number");

            Console.WriteLine("The last digit of number is : {0}", 
                GetLastDigitAsWord(varNumber));
            Console.WriteLine();
        }


        private static string GetLastDigitAsWord(int number)
        {
            string digit = null;

            int lastDigit = number % 10;

            switch (lastDigit)
            {
                case 1:
                    digit = "One";
                    break;
                case 2:
                    digit = "two";
                    break;
                case 3:
                    digit = "three";
                    break;
                case 4:
                    digit = "four";
                    break;
                case 5:
                    digit = "five";
                    break;
                case 6:
                    digit = "six";
                    break;
                case 7:
                    digit = "seven";
                    break;
                case 8:
                    digit = "eight";
                    break;
                case 9:
                    digit = "nine";
                    break;
                default:
                    digit = "zero";
                    break;
            }

            return digit;
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
