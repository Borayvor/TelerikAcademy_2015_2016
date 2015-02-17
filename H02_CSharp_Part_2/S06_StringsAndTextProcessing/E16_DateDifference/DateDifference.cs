namespace E16_DateDifference
{
    using System;
    using System.Globalization;

    public class DateDifference
    {
        public static void Main(string[] args)
        {
            // Write a program that reads two dates in the format: 
            // day.month.year and calculates the number of days between them.
            // Example:
            // Enter the first date: 27.02.2006
            // Enter the second date: 3.03.2006
            // Distance: 4 days

            Console.WriteLine("Date format -> dd.MM.yyyy");
            DateTime startDate = GetDate("start date");

            DateTime endDate = GetDate("end date");

            Console.WriteLine("Result is : {0} day/s", (endDate - startDate).TotalDays);
        }


        private static DateTime GetDate(string name)
        {                                    
            DateTime date = DateTime.MinValue;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = DateTime.TryParseExact(Console.ReadLine().Trim(), 
                    "d.M.yyyy", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            } 
            while (isNumber == false);

            return date;
        }
    }
}
