namespace E06_Maximal_K_Sum
{
    using System;

    public class Maximal_K_Sum
    {
        public static void Main(string[] args)
        {
            // Write a program that reads two integer numbers N 
            // and K and an array of N elements from the console.
            // Find in the array those K elements that have maximal sum.

            int n = 0;
            int k = 0;

            do
            {
                n = GetNumber("N");
                k = GetNumber("K");
            } 
            while (2 > k && k > n);
                        
            Console.WriteLine();
            int[] array = new int[n];

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = GetNumber("array[" + index + "]");
            }

            Array.Sort(array); 
            Console.WriteLine();

            Console.Write("| ");
            for (int index = array.Length - 1; index >= array.Length - k; index--)
            {
                Console.Write("{0} | ", array[index]);
            }
            
            Console.WriteLine("- are those elements that have maximal sum.");
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
