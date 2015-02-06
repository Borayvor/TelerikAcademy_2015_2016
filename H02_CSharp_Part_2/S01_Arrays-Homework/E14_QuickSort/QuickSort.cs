namespace E14_QuickSort
{
    using System;

    public class QuickSort
    {
        public static void Main(string[] args)
        {
            // Write a program that sorts an array of strings using 
            // the Quick sort algorithm (find it in Wikipedia).

            Random randomInt = new Random();
            int[] array = new int[20];

            Console.Write("Array : ");
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = randomInt.Next(0, 100);
                Console.Write("{0} ", array[index]);
            }

            Console.WriteLine();

            ArrayIntQuickSort(array, 0, array.Length - 1);

            Console.Write("Sorted Array : ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("{0} ", array[index]);
            }

            Console.WriteLine();
        }


        private static int GetPartitionsPivot(int[] array, int left, int right)
        {
            int indexSmallElement = left;
            int indexBigElement = right;            
            // Избира се "главен" елемент от списъка с елементи, които ще бъдат сортирани.
            int pivot = array[((left + right) / 2)];

            while (indexSmallElement <= indexBigElement)
            {   // Списъкът се пренарежда така, че всички елементи, които са 
                //по-малки от "главния" се поставят вляво от него,
                while (array[indexSmallElement] < pivot)
                {
                    indexSmallElement++;
                }

                while (array[indexBigElement] > pivot)
                {   // а всички, които са по-големи - вдясно от него.
                    indexBigElement--;
                }

                if (indexSmallElement <= indexBigElement)
                {
                    int savedElement = array[indexSmallElement];
                    array[indexSmallElement] = array[indexBigElement];
                    array[indexBigElement] = savedElement;

                    indexSmallElement++;
                    indexBigElement--;
                }
            };

            return indexSmallElement;
        }


        private static void ArrayIntQuickSort(int[] array, int left, int right)
        {   // Намираме списъците с по-малките и по-големите елементи, както 
            // и позицията на избрания главен елемент
            int index = GetPartitionsPivot(array, left, right);

            if (left < index - 1)
            {   // Рекурсивно сортираме елементите, по-малки от главния елемент
                ArrayIntQuickSort(array, left, index - 1);
            }
            if (index < right)
            {   // Рекурсивно сортираме елементите, по-малки или равни на главния елемент
                ArrayIntQuickSort(array, index, right);
            }
        }
    }
}
