namespace E08_MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the sequence of maximal 
            // sum in given array.
            // Example:
            // input 	                            result
            // 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 	2, -1, 6, 4
            // 
            // Can you do it with only one loop (with single scan 
            // through the elements of the array)?

            Console.WriteLine("Please, enter an array of integer numbers !");
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => int.Parse(ch.ToString()))
               .ToArray();

            Console.WriteLine();

            int position = 0;
            int positionStart = 0;
            int positionEnd = 0;
            double sum = 0;
            double tempSum = 0;

            for (int index = 0; index < array.Length; index++)
            {
                tempSum += array[index];

                if (tempSum < 0)
                {
                    tempSum = 0;
                    position = index + 1;
                }

                if (sum < tempSum)
                {
                    sum = tempSum;
                    positionStart = position;
                    positionEnd = index;
                }
            }

            Console.Write("The sequence of maximal sum is : ");
            for (int index = positionStart; index <= positionEnd; index++)
            {
                Console.Write("{0}, ", array[index]);
            }

            Console.WriteLine();
            Console.WriteLine("The sum of elements is : {0}", sum);            
        }
    }
}
