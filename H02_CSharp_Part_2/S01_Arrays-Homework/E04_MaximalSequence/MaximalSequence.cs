namespace E04_MaximalSequence
{
    using System;
    using System.Linq;

    public class MaximalSequence
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the maximal sequence of 
            // equal elements in an array.
            // 
            // Example:
            // input 	                        result
            // 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 	2, 2, 2

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
                if (array[index] == array[lastPosition])
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

                Console.WriteLine("- is the maximal sequence of " +
                    "equal elements in the array.");
            }
            else
            {
                Console.WriteLine("There is no sequence of equal " +
                    "elements in the array.");
            }
        }
    }
}
