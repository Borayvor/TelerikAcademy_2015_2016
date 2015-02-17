namespace E02_ReverseString
{
    using System;
    using System.Linq;

    public class ReverseString
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a string, reverses it 
            // and prints the result at the console.
            // Example:
            // input 	output
            // sample 	elpmas

            Console.WriteLine("Enter a string :");
            string inputString = new string(Console.ReadLine()
                .Trim()
                .Reverse()
                .ToArray());   

            Console.WriteLine("Result: ");
            Console.WriteLine(inputString);
        }
    }
}
