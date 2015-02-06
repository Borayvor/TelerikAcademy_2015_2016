namespace E21_CombinationsOfSet
{
    using System;

    public class CombinationsOfSet
    {
        public static void Main(string[] args)
        {
            // Write a program that reads two numbers N and K and 
            // generates all the combinations of K distinct elements 
            // from the set [1..N].
            // Example:
            // N 	    K 	    result
            // 5 	    2 	    {1, 2}
            //                  {1, 3}
            //                  {1, 4}
            //                  {1, 5}
            //                  {2, 3}
            //                  {2, 4}
            //                  {2, 5}
            //                  {3, 4}
            //                  {3, 5}
            //                  {4, 5}

            int n, k;
            do
            {
                n = GetNumber("array length N");
            }
            while (n < 3);

            do
            {
                k = GetNumber("number of elements K");
            }
            while (k < 2);

            int[] varArray = new int[k];

            Console.WriteLine();

            Combination(varArray, 0, 1, n);

            Console.WriteLine();
        }


        private static void Combination(int[] array, int position, int start, int end)
        {
            if (position >= array.Length)
            {
                PrintResult(array);
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    array[position] = i;

                    Combination(array, position + 1, i + 1, end);
                }
            }
        }

        private static void PrintResult(int[] result)
        {
            Console.Write("{");

            for (int i = 1; i < result.Length; i++)
            {
                Console.Write(result[i] + ", ");
            }

            Console.WriteLine(result[0] + "}");
        }

        private static int GetNumber(string name)
        {
            int number;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = int.TryParse(Console.ReadLine(), out number);
            }
            while (isNumber == false);

            return number;
        }
    }
}
