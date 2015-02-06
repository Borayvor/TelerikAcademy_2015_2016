namespace E11_BinarySearch
{
    using System;

    public class BinarySearch
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the index of given 
            // element in a sorted array of integers by using 
            // the Binary search algorithm.

            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Console.WriteLine("{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }");
            Console.WriteLine();

            int element = GetNumber("an integer (1 - 15)");
            Console.WriteLine();

            int position = BinarySearchGetPosition(array, element, 0, array.Length - 1);

            if (position == -1)
            {
                Console.WriteLine("Searched value is absent.");
            }
            else
            {
                Console.WriteLine("Searched value is on position: " + position);
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

        private static int BinarySearchGetPosition(int[] array, int value, int left, int right)
        {

            if (left > right) // Когато са обходени елементите на масива по описания по горе алгоритъм и 
            {                 // търсения елемент не е намерен. В този случай може да заключим, че търсеният елемент го няма в масива.
                return -1;
            }

            int middle = (left + right) / 2;

            if (array[middle] == value) // Взима средния елемент на масива.
            {                            // Ако средният елемент е търсената стойност, алгоритъма завършва.
                return middle;
            }
            else if (array[middle] > value) // Търсената стойност е по-малка от средният елемент. 
            {                               // В този случай стъпка 1 се повтаря с частта от масива преди средният елемент.
                return BinarySearchGetPosition(array, value, left, middle - 1);
            }
            else // Търсената стойност е по-голяма от средният елемент. 
            {    // В този случай стъпка 1 се повтаря с частта от масива след средният елемент.
                return BinarySearchGetPosition(array, value, middle + 1, right);
            }
        }
    }
}
