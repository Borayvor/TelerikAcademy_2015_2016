namespace E14_ModifyABitAtGivenPosition
{
    using System;

    public class ModifyABitAtGivenPosition
    {
        public static void Main(string[] args)
        {
            // We are given an integer number n, a bit value v (v=0 or 1) and a position p.
            // Write a sequence of operators (a few lines of C# code) that modifies n to 
            // hold the value v at the position p from the binary representation of n 
            // while preserving all other bits in n.
            // Examples:
            // 
            // n	    binary representation of n	p	v	binary result	    result
            // 5	    00000000 00000101	        2	0	00000000 00000001	1
            // 0	    00000000 00000000	        9	1	00000010 00000000	512
            // 15	    00000000 00001111	        1	1	00000000 00001111	15
            // 5343	    00010100 11011111	        7	0	00010100 01011111	5215
            // 62241	11110011 00100001	        11	0	11110011 00100001	62241

            Console.WriteLine("We are given an integer number n, a bit " + 
                "value v (v=0 or 1) and a position p.");
            Console.WriteLine("Modify n to hold the value v at the position p from the " + 
                "binary representation of n while preserving all other bits in n.");
            Console.Write("Enter an integer: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter position of the bit: ");
            int position = int.Parse(Console.ReadLine());

            int bitValue = 0;
            do
            {
                Console.Write("Enter value of the bit - 0 or 1: ");
                bitValue = int.Parse(Console.ReadLine());
            } 
            while (bitValue < 0 || bitValue > 1);


            Console.WriteLine(IntToBinaryAsString(number) + " = " + number);

            int mask;
            int numberAndMask;

            if (bitValue == 1)
            {
                mask = 1 << position;
                numberAndMask = number | mask;
            }
            else
            {
                mask = 1 << position;
                numberAndMask = number ^ mask;
            }

            Console.WriteLine(IntToBinaryAsString(numberAndMask) + " = " + numberAndMask);
        }


        private static string IntToBinaryAsString(int number)
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
