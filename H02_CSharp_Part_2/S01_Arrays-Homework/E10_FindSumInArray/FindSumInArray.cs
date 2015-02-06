namespace E10_FindSumInArray
{
    using System;
    using System.Collections.Generic;

    public class FindSumInArray
    {
        public static void Main(string[] args)
        {
            // Write a program that finds in given array of 
            // integers a sequence of given sum S (if present).
            // Example:
            // array 	                S 	    result
            // 4, 3, 1, 4, 2, 5, 8 	    11 	    4, 2, 5

            //Console.WriteLine("Please, enter an array of integer numbers !");
            //int[] array = Console.ReadLine()
            //   .Split(new char[] { ' ', '\t', ',' },
            //            StringSplitOptions.RemoveEmptyEntries)
            //   .Select(ch => int.Parse(ch.ToString()))
            //   .ToArray();
            
            Random randomInt = new Random();

            int[] array = new int[20];

            Console.Write("Array : ");
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = randomInt.Next(0, 21);
                Console.Write("{0} ", array[index]);
            }

            Console.WriteLine();

            int sumForFind = GetNumber("an integer for the sum S ");
            Console.WriteLine();

            int sum = int.MinValue;
            List<List<int>> allSequences = new List<List<int>>();

            for (int indexOne = 0; indexOne < array.Length - 1; indexOne++)
            {                
                List<int> sequence = new List<int>();

                sum = array[indexOne];

                for (int indexTwo = indexOne + 1; indexTwo < array.Length; indexTwo++)
                {
                    sum += array[indexTwo];

                    if (sum == sumForFind)
                    {
                        for (int index = indexOne; index <= indexTwo; index++)
                        {
                            sequence.Add(array[index]);
                        }

                        break;
                    }
                }

                if (sum == sumForFind)
                {
                    allSequences.Add(sequence);
                }
            }

            if (allSequences.Count != 0)
            {
                foreach (var sequence in allSequences)
                {
                    foreach (var value in sequence)
                    {
                        Console.Write("{0}, ", value);
                    }

                    Console.WriteLine("-> The sequence of given sum S.");
                }
            }
            else
            {
                Console.WriteLine("There is no sequence of given sum S.");
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
