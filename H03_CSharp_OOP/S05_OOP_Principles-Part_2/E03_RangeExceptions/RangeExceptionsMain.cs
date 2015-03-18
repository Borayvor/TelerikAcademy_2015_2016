namespace E03_RangeExceptions
{
    using System;
    using System.Globalization;

    public class RangeExceptionsMain
    {
        private const string DATE_FORMAT = "d.M.yyyy";

        public static void Main(string[] args)
        {
            // Define a class InvalidRangeException<T> that holds 
            // information about an error condition related to 
            // invalid range. It should hold error message and 
            // a range definition [start … end].
            // Write a sample application that demonstrates the 
            // InvalidRangeException<int> and InvalidRangeException<DateTime> 
            // by entering numbers in the range [1..100] and dates
            // in the range [1.1.1980 … 31.12.2013].

            int start = 1;
            int end = 100;
            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31);

            try
            {
                int number = GetInteger(start, end);

                Console.WriteLine("Your number: " + number);
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine("{0}\nRange: [{1}...{2}]", 
                    ire.Message, ire.Start, ire.End);
            }

            try
            {
                DateTime date = GetDate(startDate, endDate);

                Console.WriteLine("Your date: " + date.ToString(DATE_FORMAT));
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine("{0}\nRange: [{1} - {2}]", 
                    ire.Message, ire.Start.ToString(DATE_FORMAT), ire.End.ToString(DATE_FORMAT));
            }

            Console.WriteLine();
        }

        private static int GetInteger(int start, int end)
        {
            int number;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter an integer in the range [{0}...{1}]: ", 
                    start, end);

                isNumber = int.TryParse(Console.ReadLine(), out number);
            } 
            while (isNumber == false);

            if (number < start || number > end)
            {
                throw new InvalidRangeException<int>("Input value " + 
                    "was not in the permissible range !", start, end);
            }

            return number;
        }

        private static DateTime GetDate(DateTime start, DateTime end)
        {
            DateTime date;
            bool isDate = false;

            do
            {
                Console.Write("Enter a date in the range [{0} - {1}]: ", 
                    start.ToString(DATE_FORMAT), end.ToString(DATE_FORMAT));

                isDate = DateTime.TryParseExact(Console.ReadLine(), "d.M.yyyy", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            } 
            while (isDate == false);

            if (date < start || date > end)
            {
                throw new InvalidRangeException<DateTime>("Input value " + 
                    "was not in the permissible range.", start, end);
            }

            return date;
        }
    }
}
