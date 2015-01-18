namespace E12_ExtractBitFromInteger
{
    using System;

    public class ExtractBitFromInteger
    {
        public static void Main(string[] args)
        {
            // Write an expression that extracts from given integer n the 
            // value of given bit at index p.
            // Examples:
            // 
            // n	    binary representation	p	    bit @ p
            // 5	    00000000 00000101	    2	    1
            // 0	    00000000 00000000	    9	    0
            // 15	    00000000 00001111	    1	    1
            // 5343	    00010100 11011111	    7	    1
            // 62241	11110011 00100001	    11	    0

            Console.WriteLine("Extracts from given integer n the value of given bit at index p.");
            Console.Write("Enter an integer : ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter position of the bit : ");
            int bitPosition = int.Parse(Console.ReadLine());

            int mask = 1 << bitPosition;
            int valueAndMask = number & mask;
            int bit = valueAndMask >> bitPosition;

            Console.WriteLine("bit #{0} = {1}", bitPosition, bit);
        }
    }
}
