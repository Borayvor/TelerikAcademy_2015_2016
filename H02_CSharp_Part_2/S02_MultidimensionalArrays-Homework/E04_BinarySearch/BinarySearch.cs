namespace E04_BinarySearch
{
    using System;

    public class BinarySearch
    {
        public static void Main(string[] args)
        {
            // Write a program, that reads from the console an 
            // array of N integers and an integer K, sorts the 
            // array and using the method Array.BinSearch() 
            // finds the largest number in the array which is ≤ K. 

            Random randomGenerator = new Random();

            int n = 0;
            do
            {
                n = GetNumber("size of array, N");
            }
            while (n < 3);

            int k = GetNumber("an integer K");                       

            int[] array = new int[n];

            for (int index = 0; index < n; index++)
            {
                // array[index] = GetNumber("array[" + index + "]");
                array[index] = randomGenerator.Next(1, 21);
            }
            Console.WriteLine();

            PrintArray(array);
            Console.WriteLine();

            Array.Sort(array);

            int result = Array.BinarySearch(array, k);            

            Console.Write("The largest number in the array which is <= {0} is: ", k);
            if (result < 0)
            {
                Console.WriteLine("There is no such element.");
            }
            else
            {
                Console.WriteLine(array[result]);
            }

            Console.WriteLine();
        }

        private static void PrintArray(int[] array)
        {
            Console.Write("|");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write(" {0} |", (array[index]));
            }

            Console.WriteLine();
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
