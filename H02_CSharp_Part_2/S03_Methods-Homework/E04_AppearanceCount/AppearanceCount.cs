namespace E04_AppearanceCount
{
    using System;

    public class AppearanceCount
    {
        public static void Main(string[] args)
        {
            // Write a method that counts how many times 
            // given number appears in given array.
            // Write a test program to check if the method 
            // is workings correctly.

            Random randomGenerator = new Random();
            int[] array = FillArray(randomGenerator);

            int selectedNumber = int.MinValue;
            do
            {
                selectedNumber = GetNumber("a number (0 - 9)");
            }
            while (selectedNumber < 0 || selectedNumber > 9);

            int count = CountNumber(array, selectedNumber);

            Console.WriteLine();
            Console.WriteLine("The number {0} appears {1} times.", selectedNumber, count);

            Console.WriteLine();
            PrintArray(array);
        }


        private static int CountNumber(int[] array, int number)
        {
            int count = 0;

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] == number)
                {
                    count++;
                }
            }

            return count;
        }

        private static int[] FillArray(Random randomGenerator)
        {
            // fill the array with random numbers from 0 to 99
            int length = int.MinValue;
            do
            {
                length = GetNumber("the length of the array (0 - 99)");
            }
            while (length < 0 || length > 99);

            int[] array = new int[length];

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = randomGenerator.Next(10);
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
