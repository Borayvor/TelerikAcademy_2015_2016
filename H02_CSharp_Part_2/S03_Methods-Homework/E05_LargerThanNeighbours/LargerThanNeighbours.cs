namespace E05_LargerThanNeighbours
{
    using System;
    using System.Linq;

    public class LargerThanNeighbours
    {
        public static void Main(string[] args)
        {
            // Write a method that checks if the element at given 
            // position in given array of integers is larger than 
            // its two neighbours (when such exist).

            Random randomGenerator = new Random();
            int[] array = FillArray(randomGenerator);            

            int position = int.MinValue;
            do
            {
                position = GetNumber("the position of the element (0 - " + (array.Length - 1) + ")");
            } 
            while (position < 0 || position > (array.Length - 1));
            Console.WriteLine();

            CheckElement(array, position);
            Console.WriteLine();

            PrintArray(array);
            Console.WriteLine();
        }


        private static void CheckElement(int[] array, int position) 
        {
            if (position > 0 && position < (array.Length - 1))
            {
                int neighborLeft = array[position - 1];
                int neighborRight = array[position + 1];

                if (neighborLeft < array[position] && array[position] > neighborRight)
                {
                    Console.WriteLine("The element at position {0} is bigger " + 
                        "than its two neighbors.", position);
                    Console.WriteLine("{0} < {1} > {2}", 
                        neighborLeft, array[position], neighborRight);
                }
                else if (neighborLeft > array[position] && array[position] > neighborRight)
                {
                    Console.WriteLine("The element at position {0} is smaler " + 
                        "than left side neighbor and is bigger than right side " + 
                        "neighbor.", position);
                    Console.WriteLine("{0} > {1} > {2}", 
                        neighborLeft, array[position], neighborRight);
                }
                else if (neighborLeft > array[position] && array[position] < neighborRight)
                {
                    Console.WriteLine("The element at position {0} is smaler " +
                        "than right side neighbor nd is bigger than left side " + 
                        "neighbor.", position);
                    Console.WriteLine("{0} > {1} < {2}", 
                        neighborLeft, array[position], neighborRight);
                }
                else
                {
                    Console.WriteLine("The element at position {0} is smaler " + 
                        "than its neighbors.", position);
                    Console.WriteLine("{0} > {1} < {2}", 
                        neighborLeft, array[position], neighborRight);
                }

            }
            else
            {
                Console.WriteLine("One of neighbors does not exist !");
            }
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
