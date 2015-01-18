namespace E05_BooleanVariable
{
    using System;

    public class BooleanVariable
    {
        public static void Main(string[] args)
        {
            // Declare a Boolean variable called isFemale and assign an appropriate 
            // value corresponding to your gender.
            // Print it on the console.

            bool isFemale;

            Console.WriteLine("Is female your gender ?");
            Console.WriteLine("(true or false)");

            isFemale = bool.Parse(Console.ReadLine());
            Console.WriteLine("isFemale --> {0}", isFemale);
        }
    }
}
