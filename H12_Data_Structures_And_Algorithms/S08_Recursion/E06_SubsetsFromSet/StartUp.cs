namespace E06_SubsetsFromSet
{
    using System;

    public class StartUp
    {
        static int n;
        static int k;
        static string[] result;

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

            string[] array = new string[n];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Element in the set - [{0}]:", i);
                array[i] = Console.ReadLine();

                Console.WriteLine();
            }

            result = new string[n];

            Variations(array, 1, 0);
        }

        private static void Variations(string[] array, int index, int after)
        {
            if (index > k)
            {
                return;
            }

            for (int j = after + 1; j <= n; j++)
            {
                result[index - 1] = array[j - 1];

                if (index == k)
                {
                    Print(result, index);
                }

                Variations(array, index + 1, j);
            }
        }

        private static void Print(string[] array, int length)
        {
            for (int j = 0; j < length; j++)
            {
                Console.Write("{0} ", array[j]);
            }

            Console.WriteLine();
        }
    }
}
