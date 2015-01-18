namespace E11_Bitwise_ExtractBit_3
{
    using System;

    public class Bitwise_ExtractBit_3
    {
        public static void Main(string[] args)
        {
            // Using bitwise operators, write an expression for finding 
            // the value of the bit #3 of a given unsigned integer.
            // The bits are counted from right to left, starting from bit #0.
            // The result of the expression should be either 1 or 0.
            // Examples:
            // 
            // n	    binary representation	bit #3
            // 5	    00000000 00000101	    0
            // 0	    00000000 00000000	    0
            // 15	    00000000 00001111	    1
            // 5343	    00010100 11011111	    1
            // 62241	11110011 00100001	    0

            Console.WriteLine("Find the value of the bit #3 of a given unsigned integer.");
            Console.Write("Enter an integer : ");
            int number = int.Parse(Console.ReadLine());

            int bitPosition = 3;

            int mask = 1 << bitPosition;
            int valueAndMask = number & mask;
            int bit = valueAndMask >> bitPosition;

            Console.WriteLine("bit #3 = {0}", bit);
        }
    }
}
