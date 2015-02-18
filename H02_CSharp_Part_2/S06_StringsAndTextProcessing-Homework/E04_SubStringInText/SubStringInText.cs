namespace E04_SubStringInText
{
    using System;
    using System.Text.RegularExpressions;

    public class SubStringInText
    {
        public static void Main(string[] args)
        {
            // Write a program that finds how many times a 
            // sub-string is contained in a given text 
            // (perform case insensitive search).
            // Example:
            // The target sub-string is: "in"
            // The text is as follows: 
            // We are living in an yellow submarine. We don't have anything 
            // else. inside the submarine is very tight. So we are drinking 
            // all the day. We will move out of it in 5 days.           
            // The result is: 9

            string text = "We are living in an yellow submarine. We don't have " + 
                "anything else. Inside the submarine is very tight. " + 
                "So we are drinking all the day. We will move out of it in 5 days.";
            Console.WriteLine(text);
            Console.WriteLine();

            string regText = @"in";
            MatchCollection match = Regex.Matches(text, regText, RegexOptions.IgnoreCase);

            Console.WriteLine("\"{0}\" is contained {1} times.", regText, match.Count);
        }
    }
}
