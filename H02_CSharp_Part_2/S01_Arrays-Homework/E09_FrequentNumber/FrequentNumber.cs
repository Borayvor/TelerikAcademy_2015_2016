namespace E09_FrequentNumber
{
    using System;
    using System.Linq;

    public class FrequentNumber
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the most frequent number 
            // in an array.
            // Example:
            // input 	                                    result
            // 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 	    4 (5 times)

            Console.WriteLine("Please, enter an array of integer numbers !");
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => int.Parse(ch.ToString()))
               .ToArray();

            Console.WriteLine();

            var number = (from numbers in array
                          group numbers by numbers into sortedGroup
                          orderby sortedGroup.Count() descending
                          select new { Number = sortedGroup.Key, 
                              Frequency = sortedGroup.Count() }).First();

            Console.WriteLine("The most frequent number is {0} ({1} times)",
                    number.Number, number.Frequency);
        }
    }
}
