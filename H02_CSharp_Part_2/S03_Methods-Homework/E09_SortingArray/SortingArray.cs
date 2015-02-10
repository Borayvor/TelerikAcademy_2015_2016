namespace E09_SortingArray
{
    using System;

    public class SortingArray
    {
        public static void Main(string[] args)
        {
            // Write a method that return the maximal element in 
            // a portion of array of integers starting at given index.
            // Using it write another method that sorts an array 
            // in ascending / descending order.

            Random randomGenerator = new Random();

            int[] array = FillArray(randomGenerator);

            PrintArray(array);
            Console.WriteLine();

            int[] sortedArray = Sort(array, OrderChoice());
            Console.WriteLine();

            PrintArray(sortedArray);

            Console.WriteLine();
        }


        static bool OrderChoice()
        {
            int choice = -1;
            do
            {
                choice = GetNumber("make your choice :" + 
                    "\n1. Ascending order.\n2. Descending order.\n");
            } while (choice < 1 || choice > 2);

            if (choice == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            int savedNumber = array[i];
            array[i] = array[j];
            array[j] = savedNumber;
        }

        private static int GetMaximalElement(int[] array, int start, bool isAscending)
        {
            int maxElement = start;

            for (start++; start < array.Length; start++)
            {
                if (isAscending ? array[start] < array[maxElement] : array[maxElement] < array[start])
                {
                    maxElement = start;
                }
            }

            return maxElement;
        }
        
        private static int[] Sort(int[] array, bool isAscending)
        {
            for (int index = 0; index < array.Length; index++)
            {
                Swap(array, index, GetMaximalElement(array, index, isAscending));
            }

            return array;
        }

        private static int[] FillArray(Random randomGenerator)
        {            
            int length = int.MinValue;
            do
            {
                length = GetNumber("the length of the array (0 - 99)");
            }
            while (length < 0 || length > 99);

            int[] array = new int[length];

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = randomGenerator.Next(100);
            }

            return array;
        }

        private static int GetNumber(string name)
        {
            int number = int.MinValue;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = int.TryParse(Console.ReadLine(), out number);
            }
            while (isNumber == false);

            return number;
        }

        private static void PrintArray(int[] array)
        {
            string result = string.Join(", ", array);

            Console.WriteLine("{ " + result + " }");
        }
    }
}
