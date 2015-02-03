namespace E15_HexadecimalToDecimalNumber
{
    using System;

    public class HexadecimalToDecimalNumber
    {
        public static void Main(string[] args)
        {
            // Using loops write a program that converts a hexadecimal 
            // integer number to its decimal form.
            // The input is entered as string. The output should be 
            // a variable of type long.
            // Do not use the built-in .NET functionality.
            // Examples:
            // 
            // hexadecimal	    decimal
            // FE	            254
            // 1AE3	            6883
            // 4ED528CBB4	    338583669684

            Console.WriteLine("Please, enter a hexadecimal number !");
            Console.Write("hex = ");
            string hex = Console.ReadLine().Trim();

            long decimalNumber = 0;
            long power = 1;

            for (int index = hex.Length - 1; index >= 0; index--)
            {
                int digit;

                switch (hex[index])
                {
                    case 'A': digit = 10;
                        break;
                    case 'B': digit = 11;
                        break;
                    case 'C': digit = 12;
                        break;
                    case 'D': digit = 13;
                        break;
                    case 'E': digit = 14;
                        break;
                    case 'F': digit = 15;
                        break;
                    default: digit = hex[index] - 48;
                        break;
                }

                decimalNumber += digit * power;
                power *= 16;
            }

            Console.WriteLine("decimal = {0}", decimalNumber);
        }
    }
}
