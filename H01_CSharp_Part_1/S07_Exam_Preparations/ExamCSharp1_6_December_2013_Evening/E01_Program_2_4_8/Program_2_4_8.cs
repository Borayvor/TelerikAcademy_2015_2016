namespace E01_Program_2_4_8
{
    using System;

    public class Program_2_4_8
    {
        public static void Main(string[] args)
        {
            ulong a = ulong.Parse(Console.ReadLine());
            ulong b = ulong.Parse(Console.ReadLine());
            ulong c = ulong.Parse(Console.ReadLine());
            ulong r = 0;
           
            if(b == 2)
            {
                r = a % c;
            }

            if(b == 4)
            {
                r = a + c;
            }

            if (b == 8)
            {
                r = a * c;
            }

            ulong result = 0;

            if(r % 4 == 0 && r > 4)
            {
                result = r / 4;
            }
            else
            {
                result = r % 4;
            }

            Console.WriteLine(result);
            Console.WriteLine(r);
        }
    }
}
