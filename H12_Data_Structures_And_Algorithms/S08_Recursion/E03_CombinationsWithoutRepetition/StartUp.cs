namespace E03_CombinationsWithoutRepetition
{
    using System;

    public class StartUp
    {
        static int n;
        static int k;

        public static void Main(string[] args)
        {
            Console.Write("N=");
            n = int.Parse(Console.ReadLine());

            do
            {
                Console.Write("K=");
                k = int.Parse(Console.ReadLine());
            }
            while (k > n);

            int[] array = new int[n];

            CombinationWithoutRepetition(array);
        }

        private static void CombinationWithoutRepetition(int[] array, int index = 1, int after = 0)
        {
            if (index > k)
            {
                return;
            }

            for (int j = after + 1; j <= n; j++)
            {
                array[index - 1] = j;

                if (index == k)
                {
                    Print(array, index);
                }

                CombinationWithoutRepetition(array, index + 1, j);
            }
        }

        private static void Print(int[] array, int length)
        {
            for (int j = 0; j < length; j++)
            {
                Console.Write("{0} ", array[j]);
            }

            Console.WriteLine();
        }
    }
}
