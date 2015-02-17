namespace E19_DatesFromTextInCanada
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public class DatesFromTextInCanada
    {
        public static void Main(string[] args)
        {
            // Write a program that extracts from a given text all 
            // dates that match the format DD.MM.YYYY.
            // Display them in the standard date format for Canada.

            string text = "Extracts from a given text all dates 12.10.2012, 50.13.2012";
            Console.WriteLine(text);
            Console.WriteLine();

            DateTime date;

            Console.Write("Standard date format for Canada : ");
            foreach (Match item in Regex.Matches(text, @"\b\d{2}.\d{2}.\d{4}\b"))
            {
                if (DateTime.TryParseExact(item.Value, 
                    "dd.MM.yyyy", 
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out date))
                {
                    Console.WriteLine(date
                        .ToString(CultureInfo.GetCultureInfo("en-CA")
                        .DateTimeFormat.ShortDatePattern));
                }
            }
        }
    }
}
