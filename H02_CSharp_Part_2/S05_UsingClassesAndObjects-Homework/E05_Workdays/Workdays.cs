namespace E05_Workdays
{
    using System;

    public class Workdays
    {
        public static void Main(string[] args)
        {
            // Write a method that calculates the number of 
            // workdays between today and given date, passed 
            // as parameter.
            // Consider that workdays are all days from Monday 
            // to Friday except a fixed list of public holidays 
            // specified preliminary as array.
            // example:
            // date                         workdays
            // 31/12/2015                   221

            CalculateWorkdays();
        }


        private static void CalculateWorkdays()
        {
            Console.WriteLine("Calculate the number of workdays " + 
                "between today and given date in 2015.");
            DateTime startDate = DateTime.Today;
            Console.WriteLine("Today is : {0:dd/MM/yyyy}", startDate);

            DateTime endDate = new DateTime();

            endDate = GetDate("date you want");
            Console.WriteLine();

            int workdays = (int)(endDate - startDate).TotalDays;

            if (workdays < 0)
            {
                workdays *= -1;
            }

            workdays += 1; // add the current day
            workdays -= FilterWeekend(startDate, endDate);
            workdays -= FilterHolidays(startDate, endDate);

            Console.WriteLine("The business days in this interval are : {0}", workdays);
        }

        private static int FilterWeekend(DateTime start, DateTime end)
        {
            if (end < start) return FilterWeekend(end, start);

            int result = 0;

            for (DateTime weekend = start; weekend <= end; weekend = weekend.AddDays(1))
            {
                if (weekend.DayOfWeek == DayOfWeek.Saturday || 
                    weekend.DayOfWeek == DayOfWeek.Sunday)
                {
                    result++;
                }
            }

            return result;
        }


        private static int FilterHolidays(DateTime start, DateTime end)
        {
            if (end < start) return FilterHolidays(end, start);

            int result = 0;
            DateTime[] holidays = { new DateTime(2015, 01, 01), new DateTime(2015, 03, 03), 
                                      new DateTime(2015, 04, 10), new DateTime(2015, 04, 13), 
                                      new DateTime(2015, 05, 01), new DateTime(2015, 05, 06), 
                                      new DateTime(2015, 05, 24), new DateTime(2015, 09, 06), 
                                      new DateTime(2015, 09, 22), new DateTime(2015, 12, 24), 
                                      new DateTime(2015, 12, 25), 
                                  };

            foreach (DateTime holiday in holidays)
            {
                if (start < holiday && holiday < end &&
                    !(holiday.DayOfWeek == DayOfWeek.Saturday || 
                    holiday.DayOfWeek == DayOfWeek.Sunday))
                {
                    result++;
                }
            }

            return result;
        }        
        
        private static DateTime GetDate(string name) 
        {                                   
            DateTime date = DateTime.MinValue;
            bool isDate = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isDate = DateTime.TryParse(Console.ReadLine(), out date);
            } 
            while (isDate == false);

            return date;
        }
    }
}
