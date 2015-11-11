namespace E05_AllVariationsFromSubset
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

            Console.Write("K=");
            k = int.Parse(Console.ReadLine());

            string[] array = new string[n];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Enter element in the set - [{0}]:", i);
                array[i] = Console.ReadLine();
                Console.WriteLine();
            }

            result = new string[k];

            Variations(array, 0);
        }

        private static void Variations(string[] array, int currentPosition)
        {
            if (currentPosition == k)
            {
                Print(result);
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                result[currentPosition] = array[i];
                Variations(array, currentPosition + 1);
            }
        }

        private static void Print(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }
    }
}
