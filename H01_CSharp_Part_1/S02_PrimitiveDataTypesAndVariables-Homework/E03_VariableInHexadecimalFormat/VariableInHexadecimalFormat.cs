namespace E03_VariableInHexadecimalFormat
{
    using System;

    public class VariableInHexadecimalFormat
    {
        public static void Main(string[] args)
        {
            // Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##).
            // Use Windows Calculator to find its hexadecimal representation.
            // Print the variable and ensure that the result is 254.

            int decimalValue = 254;
            Console.WriteLine("decimalValue = {0}", decimalValue);

            string hexValue = decimalValue.ToString("X");
            Console.WriteLine("hexValue = {0}", hexValue);
        }
    }
}
