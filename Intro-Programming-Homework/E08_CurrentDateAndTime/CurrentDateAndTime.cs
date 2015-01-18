namespace E08_CurrentDateAndTime
{
    using System;

    public class CurrentDateAndTime
    {
        public static void Main(string[] args)
        {
            // Create a console application that prints the current date and time. Find out how in Internet.

            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine("The current date and time are : {0}", currentDateTime);
        }
    }
}
