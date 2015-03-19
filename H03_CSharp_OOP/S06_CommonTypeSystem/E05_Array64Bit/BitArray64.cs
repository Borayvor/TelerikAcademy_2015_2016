namespace E05_Array64Bit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        private readonly ulong number;

        public BitArray64()
            : this(0)
        {
        }

        private int[] ConvertToBits()
        {
            int[] bits = new int[64];

            for (int i = 0; i < bits.Length; i++)
            {
                int bit = (int)((this.number >> i) & 1);

                bits[63 - i] = bit;
            }

            return bits;
        }

        public BitArray64(ulong number)
        {
            this.number = number;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bits = this.ConvertToBits();

            for (int i = 0; i < bits.Length; i++)
            {
                yield return bits[i];
            }
        }

        public int[] Bits
        {
            get
            {
                return this.ConvertToBits();
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException();
                }

                int[] bits = this.ConvertToBits();

                return bits[index];
            }
        }
        
        public override bool Equals(object obj)
        {
            BitArray64 tempObj = obj as BitArray64;

            if (tempObj == null)
            {
                return false;
            }

            if (!(Object.Equals(this.number, tempObj.number)))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
        
        public override int GetHashCode()
        {
            return this.number.GetHashCode() ^ this.Bits.GetHashCode();
        }
    }
}
