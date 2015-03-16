namespace E02_IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    public class IEnumerableExtensions
    {
        public static void Main(string[] args)
        {
            // Implement a set of extension methods for IEnumerable<T> that 
            // implement the following group functions: sum, product, min, 
            // max, average.

            List<int> enumerable_1 = new List<int>() { -1, -5, 32 };
            Console.WriteLine("Sum<int> : {0}", enumerable_1.Sum());
            Console.WriteLine();

            List<double> enumerable_2 = new List<double>() { -1, -5.54, 32.67 };
            Console.WriteLine("Sum<double> : {0}", enumerable_2.Sum());
            Console.WriteLine();

            List<sbyte> enumerable_3 = new List<sbyte>() { -1, -5, 32 };
            Console.WriteLine("Sum<sbyte> : {0}", enumerable_3.Sum());
            Console.WriteLine();

            List<sbyte> enumerable_4 = new List<sbyte>() { -1, 15, 22 };
            Console.WriteLine("Product<sbyte> : {0}", enumerable_4.Product());
            Console.WriteLine();

            List<double> enumerable_5 = new List<double>() { -1, -5.54, 32.67 };
            Console.WriteLine("Product<double> : {0}", enumerable_5.Product());
            Console.WriteLine();

            List<int> enumerable_6 = new List<int>() { -1, -15, 39 };
            Console.WriteLine("Average<int> : {0}", enumerable_6.Average());
            Console.WriteLine();

            List<int> enumerable_7 = new List<int>() { -1, -15, 39 };
            Console.WriteLine("Min<int> : {0}", enumerable_7.Min());
            Console.WriteLine();

            List<int> enumerable_8 = new List<int>() { -1, -15, 39 };
            Console.WriteLine("Max<int> : {0}", enumerable_8.Max());
            Console.WriteLine();

            List<int> enumerable_9 = new List<int>();
            Console.WriteLine("Min<int> : {0}", enumerable_9.Min());
            Console.WriteLine();
        }
    }
}
