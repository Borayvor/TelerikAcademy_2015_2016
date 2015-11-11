namespace E02_CombinationsWithDuplicates
{
    using System;

    public class StartUp
    {
        static int n = 0;
        static int k = 0;
        
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

            CombinationWithDuplicates(array);
        }
        
        private static void CombinationWithDuplicates(int[] array, int index = 1, int after = 1)
        {
            if (index > k)
            {
                return;
            }

            for (int j = after; j <= n; j++)
            {
                array[index - 1] = j;

                if (index == k)
                {
                    Print(array, index);
                }

                CombinationWithDuplicates(array, index + 1, j);
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
