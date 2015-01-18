namespace E09_AgeAfter_10_Years
{
    using System;
    using System.Globalization;

    public class AgeAfter_10_Years
    {
        public static void Main(string[] args)
        {
            // Write a program to read your birthday from the console and print how old 
            // you are now and how old you will be after 10 years.

            Console.Write("Please, enter the date (dd.MM.yyyy) of your birthday ! --> ");
                
            string birthday = Console.ReadLine();

            DateTime birthdate;
            DateTime currentDate = DateTime.Now;

            if (DateTime.TryParseExact(birthday, "dd.MM.yyyy", CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out birthdate))
            {                
                var yearsOld = (currentDate - birthdate).Days / 365;

                Console.WriteLine("You are {0} years old now.", yearsOld);
                Console.WriteLine("After 10 years you will be {0} years old.", yearsOld + 10);
            }
        }
    }
}
