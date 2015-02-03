namespace E14_DecimalToBinaryNumber
{
    using System;    
    using System.Text;

    public class DecimalToBinaryNumber
    {
        public static void Main(string[] args)
        {
            // Using loops write a program that converts an integer 
            // number to its binary representation.
            // The input is entered as long. The output should be 
            // a variable of type string.
            // Do not use the built-in .NET functionality.
            // Examples:
            // 
            // decimal	        binary
            // 0	            0
            // 3	            11
            // 43691	        1010101010101011
            // 236476736	    1110000110000101100101000000

            Console.WriteLine("Please, enter a number !");
            Console.Write("decimal = ");
            long decimalNumber = long.Parse(Console.ReadLine());

            StringBuilder binaryNumber = new StringBuilder();

            while (decimalNumber > 0)
            {
                binaryNumber.Append(decimalNumber & 1);
                decimalNumber = decimalNumber >> 1;
            }

            var binaryNumberArray = binaryNumber.ToString().ToCharArray();
            Array.Reverse(binaryNumberArray);

            Console.Write("binary = ");
            Console.WriteLine(binaryNumberArray);             
        }
    }
}
