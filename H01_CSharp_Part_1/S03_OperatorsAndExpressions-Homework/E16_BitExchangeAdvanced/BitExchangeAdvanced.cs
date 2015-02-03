namespace E16_BitExchangeAdvanced
{
    using System;

    public class BitExchangeAdvanced
    {
        public static void Main(string[] args)
        {
            // Write a program that exchanges bits {p, p+1, …, p+k-1} 
            // with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
            // The first and the second sequence of bits may not overlap.
            // Examples:
            // 
            // n	        p	q	k	binary representation of n	            binary result	                        result
            // 1140867093	3	24	3	01000100 00000000 01000000 00010101	    01000010 00000000 01000000 00100101	    1107312677
            // 4294901775	24	3	3	11111111 11111111 00000000 00001111	    11111001 11111111 00000000 00111111	    4194238527
            // 2369124121	2	22	10	10001101 00110101 11110111 00011001	    01110001 10110101 11111000 11010001	    1907751121
            // 987654321	2	8	11	-	     -        -        -            -	     -        -        -            overlapping
            // 123456789	26	0	7	-	     -        -        -            -	     -        -        -            out of range
            // 33333333333	-1	0	33	-	     -        -        -            -	     -        -        -            out of range

            Console.Write("Enter a number: ");
            long number = long.Parse(Console.ReadLine());

            Console.Write("Enter position of first bits \"p\" : ");
            int p = int.Parse(Console.ReadLine());

            Console.Write("Enter position of second bits \"q\" : ");
            int q = int.Parse(Console.ReadLine());

            Console.Write("Enter length of the bits sequence \"k\" : ");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(IntToBinaryAsString(number) + " = " + number + " --> Input");

            for (int i = p, j = q, l = 0; (i <= 32 && j <= 32) && l < k; i++, j++, l++)
            {
                if (i < 0 || j < 0 || i >= 32 || j >= 32)
                {
                    throw new ArgumentOutOfRangeException("Out of range !");
                }

                if (i == q)
                {
                    throw new ArgumentException("Overlapping !");
                }

                if (((number >> i) & 1) != ((number >> j) & 1))
                {
                    number = ChangeBits(number, i, j);
                }
            }

            Console.WriteLine(IntToBinaryAsString(number) + " = " + number + " --> Result");
        }


        private static long ChangeBits(long number, int firstPosition, int secondPosition)
        {
            long result = 0;
            int firstMask = (1 << firstPosition);
            int secondMask = (1 << secondPosition);

            number ^= firstMask;            

            if (secondMask < 0)
            {
                result = number ^ (secondMask * (long)(-1));
            }
            else
            {
                result = number ^ secondMask;
            }

            return result;
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
