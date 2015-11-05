namespace E01_NumberOfOccurrences
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var testSequence = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Console.WriteLine("The sequence is: {0}", string.Join(", ", testSequence));
            Console.WriteLine();

            var occurs = new Dictionary<double, int>();

            foreach (var value in testSequence)
            {
                if (occurs.ContainsKey(value))
                {
                    occurs[value]++;
                }
                else
                {
                    occurs.Add(value, 1);
                }
            }

            foreach (var pair in occurs)
            {
                Console.WriteLine("Number {0} --> {1} times.", pair.Key, pair.Value);
            }

            Console.WriteLine();
        }
    }
}
