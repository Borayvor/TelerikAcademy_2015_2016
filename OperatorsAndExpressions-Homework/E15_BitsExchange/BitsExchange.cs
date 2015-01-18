namespace E15_BitsExchange
{
    using System;

    public class BitsExchange
    {
        public static void Main(string[] args)
        {
            // Write a program that exchanges bits 3, 4 and 5 with 
            // bits 24, 25 and 26 of given 32-bit unsigned integer.
            // Examples:
            // 
            // n	        binary representation of n	            binary result	                        result
            // 1140867093	01000100 00000000 01000000 00010101	    01000010 00000000 01000000 00100101	    1107312677
            // 255406592	00001111 00111001 00110010 00000000	    00001000 00111001 00110010 00111000	    137966136
            // 4294901775	11111111 11111111 00000000 00001111	    11111001 11111111 00000000 00111111	    4194238527
            // 5351	        00000000 00000000 00010100 11100111	    00000100 00000000 00010100 11000111	    67114183
            // 2369124121	10001101 00110101 11110111 00011001	    10001011 00110101 11110111 00101001	    2335569705

            Console.WriteLine("Exchange bits 3, 4 and 5 with bits 24, 25 " + 
                "and 26 of given 32-bit unsigned integer.");
            Console.Write("Enter an integer: ");
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine(IntToBinaryAsString(number) + " = " + number);

            int position1 = 3;
            int position2 = 24;

            int mask1 = 7 << position1;
            int mask2 = 7 << position2;

            long firstSeq = number & mask1;
            Console.WriteLine(IntToBinaryAsString(firstSeq) + " - firstSeq");

            long seconSeq = number & mask2;
            Console.WriteLine(IntToBinaryAsString(seconSeq) + " - seconSeq");

            long change = (number & ~mask1) & ~mask2;
            Console.WriteLine(IntToBinaryAsString(change) + " - change");

            long mask3 = (firstSeq >> position1) << position2;
            Console.WriteLine(IntToBinaryAsString(mask3) + " - mask3");

            long mask4 = (seconSeq >> position2) << position1;
            Console.WriteLine(IntToBinaryAsString(mask4) + " - mask4");

            long result = (change | mask3) | mask4;
            Console.WriteLine(IntToBinaryAsString(result) + " = " + result);
        }


        private static string IntToBinaryAsString(long number)
        {
            char[] bit = new char[32];
            int position = 31;
            int index = 0;

            while (index < 32)
            {
                if ((number & (1 << index)) != 0)
                {
                    bit[position] = '1';
                }
                else
                {
                    bit[position] = '0';
                }

                position--;
                index++;
            }

            return new string(bit);
        }
    }
}
