namespace E04_UnicodeCharacter
{
    using System;

    public class UnicodeCharacter
    {
        public static void Main(string[] args)
        {
            // Declare a character variable and assign it with the symbol that has 
            // Unicode code 42 (decimal) using the \u00XX syntax, and then print it.
                        
            char charValue = '\u002A';
            Console.WriteLine("Char value of 42 = {0}", charValue);
        }
    }
}
