namespace E13_CheckABitAtGivenPosition
{
    using System;

    public class CheckABitAtGivenPosition
    {
        public static void Main(string[] args)
        {
            // Write a Boolean expression that returns if the bit at 
            // position p (counting from 0, starting from the right) in 
            // given integer number n, has value of 1.
            // Examples:
            // 
            // n	    binary representation of n	    p	    bit @ p == 1
            // 5	    00000000 00000101	            2	    true
            // 0	    00000000 00000000	            9	    false
            // 15	    00000000 00001111	            1	    true
            // 5343	    00010100 11011111	            7	    true
            // 62241	11110011 00100001	            11	    false

            Console.WriteLine("Return \"true\" if the bit at position p in given " + 
                "integer number n, has value of 1.");
            Console.Write("Enter an integer : ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter position of the bit : ");
            int bitPosition = int.Parse(Console.ReadLine());

            int mask = 1 << bitPosition;
            int valueAndMask = number & mask;
            int bit = valueAndMask >> bitPosition;

            if (bit == 1)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
