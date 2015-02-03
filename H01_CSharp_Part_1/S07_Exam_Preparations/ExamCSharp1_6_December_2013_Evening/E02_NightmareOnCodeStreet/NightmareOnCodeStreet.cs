namespace E02_NightmareOnCodeStreet
{
    using System;

    public class NightmareOnCodeStreet
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();

            ulong sum = 0;
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if(i % 2 != 0)
                {
                    ulong result = 0;
                    if(ulong.TryParse(input[i].ToString(), out result))
                    {
                        sum += result;
                        count++;
                    }                    
                }
            }

            Console.WriteLine("{0} {1}", count, sum);
        }
    }
}
