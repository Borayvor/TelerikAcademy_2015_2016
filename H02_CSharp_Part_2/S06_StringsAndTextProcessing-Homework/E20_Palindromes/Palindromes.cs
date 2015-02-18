namespace E20_Palindromes
{
    using System;
    using System.Text.RegularExpressions;

    public class Palindromes
    {
        public static void Main(string[] args)
        {
            // Write a program that extracts from a given text 
            // all palindromes, e.g. ABBA, lamal, exe.

            string text = "Static void Main() ABBA, using System lamal, exe.";

            Console.WriteLine(text);
          
            string patten = @"\b(?<N>.)+.?(?<-N>\k<N>)+(?(N)(?!))\b";

            Console.WriteLine();
            Console.WriteLine("Result:");

            var matches = Regex.Matches(text, patten);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
