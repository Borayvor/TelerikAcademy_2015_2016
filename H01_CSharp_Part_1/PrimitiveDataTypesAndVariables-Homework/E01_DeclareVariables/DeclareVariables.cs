namespace E01_DeclareVariables
{
    using System;

    public class DeclareVariables
    {
        public static void Main(string[] args)
        {
            // Declare five variables choosing for each of them the most appropriate of the types 
            // byte, sbyte, short, ushort, int, uint, long, ulong to represent the following 
            // values: 52130, -115, 4825932, 97, -10000.
            // Choose a large enough type for each number to ensure it will fit in it. Try to compile the code.

            sbyte a = -115;
            byte b = 97;
            short c = -10000;
            ushort d = 52130;
            int e = 4825932;
            uint f = 3294967295;
            long g = -5223372036854775808;
            ulong h = 18446744073709551615;

            Console.WriteLine("sbyte --> a = {0}", a);
            Console.WriteLine("byte --> b = {0}", b);
            Console.WriteLine("short --> c = {0}", c);
            Console.WriteLine("ushort --> d = {0}", d);
            Console.WriteLine("int --> e = {0}", e);
            Console.WriteLine("uint --> f = {0}", f);
            Console.WriteLine("long --> g = {0}", g);
            Console.WriteLine("ulong --> h = {0}", h);
            Console.WriteLine();
        }
    }
}
