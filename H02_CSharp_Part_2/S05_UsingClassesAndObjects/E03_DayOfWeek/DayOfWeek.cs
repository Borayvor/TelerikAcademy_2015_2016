namespace E03_DayOfWeek
{
    using System;

    public class DayOfWeek
    {
        public static void Main(string[] args)
        {
            // Write a program that prints to the console 
            // which day of the week is today.
            // Use System.DateTime.

            DateTime day = DateTime.Today;

            Console.WriteLine("Today is {0}.", day.DayOfWeek);
        }
    }
}
