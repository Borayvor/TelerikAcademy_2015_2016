namespace E02_ColoredRabits
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int rabitsCount = int.Parse(Console.ReadLine());

            int[] replies = new int[rabitsCount];

            for (int i = 0; i < rabitsCount; i++)
            {
                replies[i] = int.Parse(Console.ReadLine());
            }

            int answer = GetMinimumRabits(replies);

            Console.WriteLine(answer);
        }

        private static int GetMinimumRabits(int[] replies)
        {
            int[] cache = new int[1000002];

            for (int i = 0; i < replies.Length; i++)
            {
                cache[replies[i] + 1]++;
            }

            int minCount = 0;

            for (int i = 0; i < cache.Length; i++)
            {
                if (cache[i] == 0)
                {
                    continue;
                }

                if (cache[i] <= i)
                {
                    minCount += i;
                }
                else
                {
                    minCount += (int)Math.Ceiling((double)cache[i] / i) * i;
                }
            }

            return minCount;
        }
    }
}
