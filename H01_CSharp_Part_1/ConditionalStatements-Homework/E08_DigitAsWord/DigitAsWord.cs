namespace E08_DigitAsWord
{
    using System;

    public class DigitAsWord
    {
        public static void Main(string[] args)
        {
            // Write a program that asks for a digit (0-9), and 
            // depending on the input, shows the digit as a word (in English).
            // Print “not a digit” in case of invalid input.
            // Use a switch statement.
            // Examples:
            // 
            // d	    result
            // 2	    two
            // 1	    one
            // 0	    zero
            // 5	    five
            // -0.1	    not a digit
            // hi	    not a digit
            // 9	    nine
            // 10	    not a digit

            Console.Write("Please enter a digit in the diapason of 0-9 : ");
            string digit = Console.ReadLine().Trim();

            String digitAsString = "";

            switch (digit)
            {
                case "0":
                    digitAsString = "Zero";
                    break;
                case "1":
                    digitAsString = "One";
                    break;
                case "2":
                    digitAsString = "Two";
                    break;
                case "3":
                    digitAsString = "Three";
                    break;
                case "4":
                    digitAsString = "Four";
                    break;
                case "5":
                    digitAsString = "Five";
                    break;
                case "6":
                    digitAsString = "Six";
                    break;
                case "7":
                    digitAsString = "Seven";
                    break;
                case "8":
                    digitAsString = "Eight";
                    break;
                case "9":
                    digitAsString = "Nine";
                    break;
                default:
                    digitAsString = "not a digit";
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Result --> {0}",digitAsString);
            Console.WriteLine();
        }
    }
}
