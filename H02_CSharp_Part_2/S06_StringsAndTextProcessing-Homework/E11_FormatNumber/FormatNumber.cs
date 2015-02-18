namespace E11_FormatNumber
{
    using System;

    public class FormatNumber
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a number and prints it as a 
            // decimal number, hexadecimal number, percentage and 
            // in scientific notation.
            // Format the output aligned right in 15 symbols.

            Console.Write("number = ");
            int number = int.Parse(Console.ReadLine().Trim());

            Console.WriteLine();
            Console.WriteLine("{0,20} : {1,15}", "Decimal", number);
            Console.WriteLine("{0,20} : {1,15:X}", "Hexadecimal", number);
            Console.WriteLine("{0,20} : {1,15:P}", "Percentage", number);
            Console.WriteLine("{0,20} : {1,15:E}", 
                "Scientific notation", number);
            Console.WriteLine();
        }
    }
}
