namespace E01_BinaryPasswords
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int baseOfNumeralSystem = 2;
            ulong count = 0;

            foreach (var symbol in input)
            {
                if (symbol == '0' || symbol == '1')
                {
                    continue;
                }

                count++;
            }

            ulong numberPossibleBinaryPasswords = (ulong)Math.Pow(baseOfNumeralSystem, count);

            Console.WriteLine(numberPossibleBinaryPasswords);
        }
    }
}
