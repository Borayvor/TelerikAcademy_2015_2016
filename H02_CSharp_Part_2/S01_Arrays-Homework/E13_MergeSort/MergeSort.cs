namespace E13_MergeSort
{
    using System;

    public class MergeSort
    {
        public static void Main(string[] args)
        {
            // Write a program that sorts an array of integers using 
            // the Merge sort algorithm (find it in Wikipedia).

            Random randomInt = new Random();
            int[] array = new int[20];
            
            Console.Write("Array : ");
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = randomInt.Next(0, 100);
                Console.Write("{0}, ", array[index]);
            }

            Console.WriteLine();

            int[] sortedArray = new int[20];
            sortedArray = Splits(array);

            Console.Write("Sorted Array : ");
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write("{0}, ", sortedArray[index]);
            }

            Console.WriteLine();
        }


        private static int[] Splits(int[] array)
        {
            if (array.Length == 1) // Ако дължината на масива стане равна на 1 елемент,
            {                    // тогава се връща този елемент и отиваме към другия метод
                return array;
            }
            // Инициализират се два масива с равен брой елемента спрямо подаденият масив(array).
            int middle = array.Length / 2;
            int[] leftArray = new int[middle];
            int[] rightArray = new int[array.Length - middle];
            // Слагаме в първия масив(left), половината от елементите 
            // на подадения масив (array).
            for (int index = 0; index < middle; index++)
            {
                leftArray[index] = array[index];
            }
            // Слагаме във втория масив(right), другата половината от елементи 
            // на подадения масив (array).
            for (int index = middle, j = 0; index < array.Length; index++, j++)
            {
                rightArray[j] = array[index];
            }

            leftArray = Splits(leftArray); // Вика се рекурсия на лявата половина, 
            // докато нейната дължина не стане равна на 1.
            rightArray = Splits(rightArray); // След като свършим изцяло с лявата половина 
            // на първоначално подадения масив, прави се същото и с дясната половина, 
            // докато не се изчерпят всички нейни стойности

            return Merge(leftArray, rightArray); //Когато в двата масива остане само 
            //по 1 елемент, викаме метода Merge, който ще ги слее, разпределени по големина                
        }


        private static int[] Merge(int[] left, int[] right)
        {
            // Първоначално се сравнява нулевия елемент на левия масив с нулевия 
            // елемент на десния.
            int leftIncrease = 0;
            int rightIncrease = 0;
            int[] array = new int[left.Length + right.Length];

            for (int index = 0; index < array.Length; index++)
            {
                // Ако левият елемент е по-малък, той се записва в масива (array) 
                // и се увеличава левия брояч (leftIncrease) с 1
                // Ако всички елементи в десния масив свършат, то се прехвърлят 
                // автоматично останалите елементи в левия масив.
                if (rightIncrease == right.Length || 
                    ((leftIncrease < left.Length) && 
                    (left[leftIncrease] <= right[rightIncrease])))
                {
                    array[index] = left[leftIncrease];
                    leftIncrease++;
                }
                else if (leftIncrease == left.Length || 
                    ((rightIncrease < right.Length) && 
                    (left[leftIncrease] >= right[rightIncrease])))
                {
                    array[index] = right[rightIncrease];
                    rightIncrease++;
                }
            }

            return array;
        }
    }
}
