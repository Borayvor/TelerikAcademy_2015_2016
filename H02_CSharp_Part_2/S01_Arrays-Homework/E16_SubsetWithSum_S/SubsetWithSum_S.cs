namespace E16_SubsetWithSum_S
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetWithSum_S
    {
        static HashSet<string> subsets = new HashSet<string>();        

        public static void Main(string[] args)
        {
            // We are given an array of integers and a number S.
            // Write a program to find if there exists a subset of 
            // the elements of the array that has a sum S.
            // Example:
            // input array 	                S 	    result
            // 2, 1, 2, 4, 3, 5, 2, 6 	    14 	    yes         (1, 2, 5, 6)

            Console.WriteLine("Please, enter an array of integer numbers !");
            int[] array = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => int.Parse(ch.ToString()))
               .ToArray();

            Console.WriteLine();

            int s = GetNumber("number S");

            for (int count = 1; count <= array.Length; count++)
            {
                bool[] used = new bool[array.Length];
                int[] vector = new int[count];

                GetSubsets(array, 0, 0, s, used, vector);
                
            }

            string result = String.Join("\n", subsets);

            Console.WriteLine(result);
            Console.WriteLine();
        }

               
        private static void GetSubsets(int[] array, int currentPosition, int start,
            int s, bool[] used, int[] vector)
        {
            if (currentPosition == vector.Length)
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
                    vector[currentPosition] = array[index];
                    GetSubsets(array, currentPosition + 1, index + 1, s, used, vector);
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
