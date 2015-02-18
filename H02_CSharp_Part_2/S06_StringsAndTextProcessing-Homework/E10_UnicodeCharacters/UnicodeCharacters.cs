namespace E10_UnicodeCharacters
{
    using System;
    using System.Linq;

    public class UnicodeCharacters
    {
        public static void Main(string[] args)
        {
            // Write a program that converts a string to a 
            // sequence of C# Unicode character literals.
            // Use format strings.
            // Example:
            // input 	    output
            // Hi! 	        \u0048\u0069\u0021

            Console.WriteLine("Please, enter a string !");
            string text = string.Join("",
                Console.ReadLine()
                .Trim()
                .Select(ch => 0xffff)
                //.Select(ch => ("\\u" + ((int)ch).ToString("X4")))
                .ToArray());

            Console.WriteLine(text);
        }
    }
}
