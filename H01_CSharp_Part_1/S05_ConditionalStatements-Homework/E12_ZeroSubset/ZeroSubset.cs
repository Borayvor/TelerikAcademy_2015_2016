namespace E12_ZeroSubset
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ZeroSubset
    {
        public static void Main(string[] args)
        {
            // We are given 5 integer numbers. Write a program that 
            // finds all subsets of these numbers whose sum is 0.
            // Assume that repeating the same subset several times is 
            // not a problem.
            // Examples:
            // 
            // numbers	                    result
            // 3 -2 1 1 8	                -2 + 1 + 1 = 0
            // 3 1 -7 35 22	                no zero subset
            // 1 3 -4 -2 -1	                1 + -1 = 0
            //                              1 + 3 + -4 = 0
            //                              3 + -2 + -1 = 0
            // 1 1 1 -1 -1	                1 + -1 = 0
            //                              1 + 1 + -1 + -1 = 0
            // 0 0 0 0 0	                0 + 0 + 0 + 0 + 0 = 0
            // Hint: you may check for zero each of the 32 subsets 
            // with 32 if statements.

            List<int> allNumbers = new List<int>();
                       
            Console.WriteLine("Please, enter the numbers (You can copy and paste):");

            allNumbers = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList<int>();

            List<List<int>> posibleCombinations = GetPosibleCombinations(allNumbers);

            Console.WriteLine();
            Console.WriteLine("Result:");

            if (posibleCombinations.Count > 0)
            {
                foreach (var combination in posibleCombinations)
                {
                    for (int index = 0; index < combination.Count; index++)
                    {
                        Console.Write(combination[index]);

                        if (index < combination.Count - 1)
                        {
                            Console.Write(" + ");
                        }
                    }

                    Console.Write(" = " + combination.Sum());

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("no zero subset");
            }

            Console.WriteLine();
        }


        private static List<List<int>> GetPosibleCombinations(List<int> listOfNumbers)
        {
            List<List<int>> posibleCombinations = new List<List<int>>();

            double combinationsCount = Math.Pow(2, listOfNumbers.Count);

            for (int indexCombinations = 1; 
                indexCombinations <= combinationsCount - 1; indexCombinations++)
            {
                string str = Convert.ToString(indexCombinations, 2)
                    .PadLeft(listOfNumbers.Count, '0');

                List<int> subset = new List<int>();

                for (int indexSubset = 0; indexSubset < str.Length; indexSubset++)
                {
                    if (str[indexSubset] == '1')
                    {   
                        subset.Add(listOfNumbers[indexSubset]);
                    }
                }

                if (subset.Count > 1 && subset.Sum() == 0)
                {
                    var CombinationExist = posibleCombinations
                        .Exists(x => x.SequenceEqual(subset));

                    if (!CombinationExist)
                    {
                        posibleCombinations.Add(subset);
                    }                    
                }                
            }

            return posibleCombinations;
        }               
    }
}
