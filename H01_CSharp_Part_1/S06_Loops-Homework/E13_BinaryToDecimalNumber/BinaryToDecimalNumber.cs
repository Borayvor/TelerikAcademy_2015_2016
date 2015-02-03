namespace E13_BinaryToDecimalNumber
{
    using System;

    public class BinaryToDecimalNumber
    {
        public static void Main(string[] args)
        {
            // Using loops write a program that converts a binary 
            // integer number to its decimal form.
            // The input is entered as string. The output should be 
            // a variable of type long.
            // Do not use the built-in .NET functionality.
            // Examples:
            // 
            // binary	                        decimal
            // 0	                            0
            // 11	                            3
            // 1010101010101011	                43691
            // 1110000110000101100101000000	    236476736

            Console.WriteLine("Please, enter a binary integer number !");
            string binaryNumber = Console.ReadLine();

            long decimalNumber = 0;

            for (int i = 0; i < binaryNumber.Length; i++)
            {                
                decimalNumber = (decimalNumber << 1) + (binaryNumber[i] == '1' ? 1 : 0);                
            }

            Console.WriteLine("decimal = {0}", decimalNumber);
        }
    }
}
