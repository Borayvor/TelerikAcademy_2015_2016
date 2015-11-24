namespace E01_SortingAlgorithms
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 174, 0, 101, 174, 89 });
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("1. SelectionSorter result:");
            collection.Sort(new SelectionSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 174, 0, 101, 174, 89 });
            Console.WriteLine("2. Quicksorter result:");
            collection.Sort(new Quicksorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 174, 0, 101, 174, 89 });
            Console.WriteLine("3. MergeSorter result:");
            collection.Sort(new MergeSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("4. Linear search for 101:");
            Console.WriteLine(collection.LinearSearch(101));
            Console.WriteLine();

            Console.WriteLine("5. Binary search for 101:");
            Console.WriteLine(collection.BinarySearch(101));
            Console.WriteLine();

            Console.WriteLine("6. Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("6. Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }
    }
}
