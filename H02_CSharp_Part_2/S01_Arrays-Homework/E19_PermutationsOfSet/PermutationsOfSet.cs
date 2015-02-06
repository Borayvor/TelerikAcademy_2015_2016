namespace E19_PermutationsOfSet
{
    using System;

    public class PermutationsOfSet
    {
        static int[] array;

        public static void Main(string[] args)
        {
            // Write a program that reads a number N and generates and 
            // prints all the permutations of the numbers [1 … N].
            // Example:
            // N 	            result
            // 3 	            {1, 2, 3}
            //                  {1, 3, 2}
            //                  {2, 1, 3}
            //                  {2, 3, 1}
            //                  {3, 1, 2}
            //                  {3, 2, 1}

            int n, fact = 1;

            do
            {
                n = GetNumber("array length N");
            }
            while (n < 1);

            for (int element = 1; element <= n; element++)
            {
                fact = fact * element;
            }

            array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            Console.WriteLine();

            Permute(array, 0, array.Length - 1);

            Console.WriteLine();
            Console.WriteLine(fact + " permutations.");
        }


        private static void Swap(int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }


        private static void Permute(int[] array, int current, int length)
        {
            if (current == length)
            {
                PrintResult(array);                
            }
            else
            {
                for (int i = current; i <= length; i++)
                {
                    Swap(i, current);
                    Permute(array, current + 1, length);
                    Swap(i, current);
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
