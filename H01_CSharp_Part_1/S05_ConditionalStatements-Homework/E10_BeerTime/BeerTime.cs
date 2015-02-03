namespace E10_BeerTime
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BeerTime
    {
        public static void Main(string[] args)
        {
            // A beer time is after 1:00 PM and before 3:00 AM.
            // Write a program that enters a time in format “hh:mm tt” 
            // (an hour in range [01...12], a minute in range [00…59] 
            // and AM / PM designator) and prints beer time or 
            // non-beer time according to the definition above or 
            // invalid time if the time cannot be parsed. Note: You 
            // may need to learn how to parse dates and times.
            // Examples:
            // 
            // time	        result
            // 1:00 PM	    beer time
            // 4:30 PM	    beer time
            // 10:57 PM	    beer time
            // 8:30 AM	    non-beer time
            // 02:59 AM	    beer time
            // 03:00 AM	    non-beer time
            // 03:26 AM	    non-beer time

            Console.WriteLine("Please, enter a time in format \"hh:mm tt\" !");
            Console.Write("time = ");
            DateTime dateTime = DateTime.ParseExact(Console.ReadLine().Trim(), "h:mm tt", 
                CultureInfo.InvariantCulture);
            TimeSpan time = dateTime.TimeOfDay; 
                       
            TimeSpan threeAM = new TimeSpan(3, 00, 00);
            TimeSpan onePM = new TimeSpan(13, 00, 00);

            string result = null;

            if(time <= threeAM || time >= onePM)
            {
                result = "beer time";
            }
            else
            {
                result = "non-beer time";
            }

            Console.WriteLine();
            Console.WriteLine("result --> {0}", result);
            Console.WriteLine();
        }
    }
}
