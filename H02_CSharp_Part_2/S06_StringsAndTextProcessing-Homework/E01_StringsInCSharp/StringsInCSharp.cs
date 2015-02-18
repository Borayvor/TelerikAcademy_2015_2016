namespace E01_StringsInCSharp
{
    using System;

    public class StringsInCSharp
    {
        public static void Main(string[] args)
        {
            // Describe the strings in C#.
            // What is typical for the string data type?
            // Describe the most important methods of the String class.

            Console.WriteLine("Represents text as a series of Unicode characters.");
            Console.WriteLine("Clone - Returns a reference to this instance of String.");
            Console.WriteLine("Join(String, Object[]) - Concatenates the elements " + 
                "of an object array, using the specified separator between each element.");
            Console.WriteLine("Split(Char[]) - Returns a string array that contains the " + 
                "substrings in this instance that are delimited by elements of a " + 
                "specified Unicode character array.");
            Console.WriteLine("Trim() - Removes all leading and trailing white-space " + 
                "characters from the current String object.");
        }
    }
}
