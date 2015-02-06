namespace E17_Subset_K_WithSum_S
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Subset_K_WithSum_S
    {
        static HashSet<string> subsets = new HashSet<string>(); 

        public static void Main(string[] args)
        {
            // Write a program that reads three integer numbers N, K and 
            // S and an array of N elements from the console.
            // Find in the array a subset of K elements that have sum 
            // S or indicate about its absence.
            // input array                  K       S       result
            // 2, 1, 2, 4, 3, 5, 2, 6       3       14      (3, 5, 6)

            int n, k, s;

            Console.WriteLine("Please, enter an array of integer numbers !");
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => int.Parse(ch.ToString()))
               .ToArray();
           
            //do
            //{
            //    n = GetNumber("array length N");
            //}
            //while (n < 3);
            
            //int[] array = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    array[i] = GetNumber("an integer");
            //}

            //do
            {
                k = GetNumber("number of elements K");
            }
            while (k < 2);

            s = GetNumber("size of sum S");

            Console.WriteLine();

            bool[] used = new bool[array.Length];
            int[] vector = new int[k];

            GetSubsets(array, 0, 0, s, used, vector);

            string result = String.Join("\n", subsets);

            Console.WriteLine(result);
            Console.WriteLine();
        }


        private static void GetSubsets(int[] array, int position, int start,
            int s, bool[] used, int[] vector)
        {
            if (position == vector.Length)
            {
                if (vector.Sum() == s)
                {
                    bool isSubset = true;

                    for (int i = 1; i < vector.Length; i++)
                    {
                        if (vector[i] < vector[i - 1])
                        {
                            isSubset = false;
                        }
                    }

                    if (isSubset)
                    {
                        subsets.Add(String.Format("({0})", String.Join(", ", vector)));
                    }
                }

                return;
            }


            for (int index = start; index < array.Length; index++)
            {
                if (!used[index])
                {
                    used[index] = true;
                    vector[position] = array[index];
                    GetSubsets(array, position + 1, index + 1, s, used, vector);
                    used[index] = false;
                }
            }
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
