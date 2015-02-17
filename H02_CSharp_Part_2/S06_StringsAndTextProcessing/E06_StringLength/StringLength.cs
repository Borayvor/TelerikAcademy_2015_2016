namespace E06_StringLength
{
    using System;

    public class StringLength
    {
        public static void Main(string[] args)
        {
            // Write a program that reads from the console a string 
            // of maximum 20 characters. If the length of the string 
            // is less than 20, the rest of the characters should 
            // be filled with '*'.
            // Print the result string into the console.
            // example:             result:
            // Print                Print***************

            const int MaxLength = 20;
            const int MinLength = 0;

            string text = string.Empty;

            do
            {
                Console.WriteLine("Please, enter a string of maximum 20 characters :");
                text = Console.ReadLine();
            }
            while (text.Length > MaxLength || text.Length == MinLength || text == null);

            string newText = text.PadRight(MaxLength, '*');

            Console.WriteLine(newText);
            Console.WriteLine();
        }
    }
}
