namespace E05_MaximalIncreasingSequence
{
    using System;
    using System.Linq;

    public class MaximalIncreasingSequence
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the maximal increasing 
            // sequence in an array.
            // Example:
            // input 	                            result
            // 3, 2, 3, 4, 2, 2, 4, 5, 8, 5 	    2, 4, 5, 8

            Console.WriteLine("Please, enter a sequence of integer numbers !");
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => int.Parse(ch.ToString()))
               .ToArray();

            int countEquals = 1;
            int startPosition = 0;
            int lastPosition = 0;
            int sequenceMaxLength = 0;

            for (int index = 1; index < array.Length; index++)
            {
                if (array[index] > array[index - 1])
                {
                    countEquals++;

                    if (sequenceMaxLength < countEquals)
                    {
                        sequenceMaxLength = countEquals;
                        startPosition = lastPosition;
                    }
                }
                else
                {
                    lastPosition = index;
                    countEquals = 1;
                }
            }

            if (sequenceMaxLength != 0)
            {
                for (int index = startPosition;
                    index < (startPosition + sequenceMaxLength); index++)
                {
                    Console.Write("{0}, ", array[index]);
                }

                Console.WriteLine("- is the maximal increasing sequence" + 
                    " in the array.");
            }
            else
            {
                Console.WriteLine("There is no maximal increasing sequence" +
                    " in the array.");
            }
        }
    }
}
