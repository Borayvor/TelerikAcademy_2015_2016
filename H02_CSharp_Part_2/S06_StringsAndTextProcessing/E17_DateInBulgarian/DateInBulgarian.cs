namespace E17_DateInBulgarian
{
    using System;
    using System.Globalization;

    public class DateInBulgarian
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a date and time given in the 
            // format: day.month.year hour:minute:second and prints the 
            // date and time after 6 hours and 30 minutes (in the same format) 
            // along with the day of week in Bulgarian.

            Console.WriteLine("dd.MM.yyyy HH:mm:ss");

            //DateTime date = GetDate("a date");
            DateTime date = DateTime.Now;

            Console.WriteLine("Date = {0}", date);

            date = date.AddHours(6.5);

            Console.WriteLine("Result:");
            Console.WriteLine("{0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date);
        }


        static DateTime GetDate(string name)
        {                                 
            DateTime date;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = DateTime.TryParseExact(Console.ReadLine(), 
                    "d.M.yyyy HH:mm:ss", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            } while (isNumber == false);

            return date;
        }
    }
}
