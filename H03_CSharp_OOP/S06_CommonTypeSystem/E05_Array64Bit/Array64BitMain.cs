namespace E05_Array64Bit
{
    using System;

    public class Array64BitMain
    {
        public static void Main(string[] args)
        {
            // Define a class BitArray64 to hold 64 bit values inside an ulong value.
            // Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

            ulong firstLong = 9223372035854775807;
            BitArray64 bitsFirst = new BitArray64(firstLong);

            foreach (var bit in bitsFirst.Bits)
            {
                Console.Write(bit);
            }

            Console.WriteLine();

            ulong secondLong = 9223372035854775808;
            BitArray64 bitsSecond = new BitArray64(secondLong);

            foreach (var bit in bitsSecond.Bits)
            {
                Console.Write(bit);
            }

            Console.WriteLine("\n");            

            Console.WriteLine("bitsFirst -->\n bit {0} = {1},\n bit {2} = {3}",
                (10), bitsFirst[63 - 10], (9), bitsFirst[63 - 9]);            
            Console.WriteLine();

            Console.WriteLine("bitsFirst != bitsSecond --> {0}", bitsFirst != bitsSecond);
            Console.WriteLine("bitsFirst == bitsSecond --> {0}", bitsFirst == bitsSecond);
            Console.WriteLine();

            Console.WriteLine("HashCode bitsFirst --> {0}", bitsFirst.GetHashCode());
            Console.WriteLine();
        }
    }
}
