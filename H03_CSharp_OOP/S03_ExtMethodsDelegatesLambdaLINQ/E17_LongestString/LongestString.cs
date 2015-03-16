namespace E17_LongestString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LongestString
    {        
        public static void Main(string[] args)
        {
            // Write a program to return the string with maximum length 
            // from an array of strings.
            // Use LINQ.

            Random randomGenerator = new Random();

            Console.WriteLine("Homework 17:");
            Console.WriteLine();
            string[] stringArray = GenerateRandomStrings(randomGenerator);

            Console.WriteLine("Array of strings:");
            foreach (var item in stringArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            string longest = (
                from text in stringArray 
                orderby text.Length descending 
                select text
                ).ElementAt(0);

            Console.WriteLine("The string with maximum length:");
            Console.WriteLine(longest);
        }


        private static string[] GenerateRandomStrings(Random rnd)
        {
            string[] array = new string[7];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string((char)rnd.Next(65, 94), rnd.Next(5, 50));
            }

            return array;
        }
    }
}
