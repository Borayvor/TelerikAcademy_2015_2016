namespace E01_Assertions
{
    using System;
    using System.Diagnostics;

    public class Assertions
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null !");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }

            for (int index = 0; index < arr.Length - 1; index++)
            {
                Debug.Assert(arr[index].CompareTo(arr[index + 1]) <= 0, "The array is not sorted !");
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null !");
            Debug.Assert(startIndex >= 0, "Start index is negative !");
            Debug.Assert(startIndex < arr.Length, "Start index is is larger, or equal than length of array !");
            Debug.Assert(startIndex <= endIndex, "Start index is is larger than end index !");
            Debug.Assert(endIndex < arr.Length, "End index is is larger, or equal than length of array !");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }
            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null !");
            Debug.Assert(value != null, "Searched value is null !");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                Debug.Assert(arr[index].CompareTo(arr[index + 1]) <= 0, "The array is not sorted !");
            }

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null !");
            Debug.Assert(startIndex >= 0, "Start index is negative !");
            Debug.Assert(startIndex < arr.Length, "Start index is is larger, or equal than length of array !");
            Debug.Assert(startIndex <= endIndex, "Start index is is larger than end index !");
            Debug.Assert(endIndex < arr.Length, "End index is is larger, or equal than length of array !");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    endIndex = midIndex - 1;
                }
            }

            return -1;
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0, 33 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));

            char[] array = new char[5];
            Console.WriteLine(array[2]);
            SelectionSort(array);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", array));
        }
    }
}
