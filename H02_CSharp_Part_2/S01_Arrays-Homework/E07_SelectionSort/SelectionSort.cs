namespace E07_SelectionSort
{
    using System;
    using System.Linq;

    public class SelectionSort
    {
        public static void Main(string[] args)
        {
            // Sorting an array means to arrange its elements in 
            // increasing order. Write a program to sort an array.
            // Use the Selection sort algorithm: Find the smallest 
            // element, move it at the first position, find the smallest 
            // from the rest, move it at the second position, etc.
            //
            // 4, 3, 34, 87, 1, 11, 32, 5, 9, 7, 4

            Console.WriteLine("Please, enter an array of integer numbers !");
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => int.Parse(ch.ToString()))
               .ToArray();

            Console.WriteLine();

            int indexMinValue = 0;

            for (int index = 0; index < array.Length - 1; index++)
            {
                indexMinValue = index;

                for (int indexNext = index + 1; indexNext < array.Length; indexNext++)
                {
                    if (array[indexNext] < array[indexMinValue])
                    {
                        indexMinValue = indexNext;
                    }
                }

                if (indexMinValue != index)
                {
                    int previous = array[index];
                    array[index] = array[indexMinValue];
                    array[indexMinValue] = previous;
                }
            }

            Console.WriteLine("Result:");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("{0}, ", array[index]);
            }

            Console.WriteLine();
        }
    }
}
