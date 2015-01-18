namespace E04_UnicodeCharacter
{
    using System;

    public class UnicodeCharacter
    {
        public static void Main(string[] args)
        {
            // Declare a character variable and assign it with the symbol that has 
            // Unicode code 42 (decimal) using the \u00XX syntax, and then print it.

            int decimalValue = 42;
            Console.WriteLine("decimalValue = {0}", decimalValue);

            string hexValue = decimalValue.ToString("X");
            Console.WriteLine("hexValue = {0}", hexValue);

            char charValue = Convert.ToChar(0x002A);
            Console.WriteLine("charValue = {0}", charValue);
        }
    }
}
