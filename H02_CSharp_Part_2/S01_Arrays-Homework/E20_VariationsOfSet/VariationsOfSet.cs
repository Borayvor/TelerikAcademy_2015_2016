namespace E20_VariationsOfSet
{
    using System;

    public class VariationsOfSet
    {       

        public static void Main(string[] args)
        {
            // Write a program that reads two numbers N and K and 
            // generates all the variations of K elements from the set [1..N].
            // Example:
            // N 	    K 	    result
            // 3 	    2 	    {1, 1}
            //                  {1, 2}
            //                  {1, 3}
            //                  {2, 1}
            //                  {2, 2}
            //                  {2, 3}
            //                  {3, 1}
            //                  {3, 2}
            //                  {3, 3}

            int n = 0;
            int k = 0;

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

            Variation(varArray, 0, n);

            Console.WriteLine();
        }


        private static void Variation(int[] array, int index, int n)
        {
            if (index == array.Length)
            {
                PrintResult(array);
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    array[index] = i;

                    Variation(array, index + 1, n);
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
