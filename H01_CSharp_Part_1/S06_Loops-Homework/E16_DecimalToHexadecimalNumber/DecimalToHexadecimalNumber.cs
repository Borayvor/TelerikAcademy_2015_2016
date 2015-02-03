namespace E16_DecimalToHexadecimalNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DecimalToHexadecimalNumber
    {
        public static void Main(string[] args)
        {
            // Using loops write a program that converts an integer 
            // number to its hexadecimal representation.
            // The input is entered as long. The output should be 
            // a variable of type string.
            // Do not use the built-in .NET functionality.
            // Examples:
            // 
            // decimal	        hexadecimal
            // 254	            FE
            // 6883	            1AE3
            // 338583669684	    4ED528CBB4

            Console.WriteLine("Please, enter an integer number !");
            Console.Write("decimal = ");
            long decimalNumber = long.Parse(Console.ReadLine());

            StringBuilder reversedHexNumber = new StringBuilder();

            while(decimalNumber > 0)
            {
                long remainder = decimalNumber % 16;                

                switch (remainder)
                {
                    case 10: reversedHexNumber.Append('A');
                        break;
                    case 11: reversedHexNumber.Append('B');
                        break;
                    case 12: reversedHexNumber.Append('C');
                        break;
                    case 13: reversedHexNumber.Append('D');
                        break;
                    case 14: reversedHexNumber.Append('E');
                        break;
                    case 15: reversedHexNumber.Append('F');
                        break;
                    default: reversedHexNumber.Append(remainder);
                        break;
                }

                decimalNumber /= 16;
            }

            var hexNumber = reversedHexNumber.ToString().ToCharArray();
            Array.Reverse(hexNumber);

            Console.Write("hex = ");
            Console.WriteLine(hexNumber);
        }
    }
}
