namespace E01_LeapYear
{
    using System;

    public class LeapYear
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a year from the 
            // console and checks whether it is a leap one.
            // Use System.DateTime.

            CheckYear();
        }


        private static void CheckYear()
        {
            int year = GetNumber("year you want to check whether it is a leap");

            bool isLeapYear = DateTime.IsLeapYear(year);

            if (isLeapYear)
            {
                Console.WriteLine("{0} is leap-year.", year);
            }
            else
            {
                Console.WriteLine("{0} is ordinary year.", year);
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
            while (isNumber == false && (number < 0 || number > 3000));

            return number;
        }
    }
}
