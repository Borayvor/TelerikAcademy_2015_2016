namespace E06_FirstLargerThanNeighbours
{
    using System;
    using System.Linq;

    public class FirstLargerThanNeighbours
    {
        public static void Main(string[] args)
        {
            // Write a method that returns the index of the first 
            // element in array that is larger than its neighbours, 
            // or -1, if there’s no such element.
            // Use the method from the previous exercise.

            Random randomGenerator = new Random();
            int[] array = FillArray(randomGenerator);
            Console.WriteLine();

            Console.WriteLine("Check for element in the array, bigger than its neighbors.");
            Console.WriteLine();
            Console.WriteLine("Position {0}", CheckElement(array));
            Console.WriteLine();

            PrintArray(array);
            Console.WriteLine();
        }


        public static int CheckElement(int[] array)
        {
            for (int index = 1; index < array.Length - 1; index++)
            {
                int neighborLeft = array[index - 1];
                int neighborRight = array[index + 1];
                int element = array[index];

                if (neighborLeft < element && element > neighborRight)
                {
                    Console.WriteLine("The first element bigger than its two neighbors :");
                    Console.WriteLine("{0} < {1} > {2}", neighborLeft, element, neighborRight);
                    return index;
                }
            }

            Console.WriteLine("There’s no such element.");
            return -1;
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
                array[index] = index;
            }

            var arrayRandomOrder = array
            .OrderBy(x => randomGenerator.Next())
            .ToArray();

            return arrayRandomOrder;
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
