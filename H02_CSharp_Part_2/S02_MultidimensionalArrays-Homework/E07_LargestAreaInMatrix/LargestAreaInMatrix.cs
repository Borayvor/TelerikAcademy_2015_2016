namespace E07_LargestAreaInMatrix
{
    using System;

    public class LargestAreaInMatrix
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the largest area of equal 
            // neighbour elements in a rectangular matrix and prints its size.
            // Example:
            // matrix 	                                result
            // 1 	3 	2 	2 	2 	4                   13
            // 3 	3 	3 	2 	4 	4
            // 4 	3 	1 	2 	3 	3
            // 4 	3 	1 	3 	3 	1
            // 4 	3 	3 	3 	1 	1
            // 	            
            // Hint: you can use the algorithm Depth-first search or 
            // Breadth-first search.

            Random randomGenerator = new Random();           
            int[,] matrix = new int[10, 10];

            FillMatrix(matrix, randomGenerator);

            Console.WriteLine("The matrix.");
            PrintMatrix(matrix);
            Console.WriteLine();

            int maxAreaSize = DepthFirstSearch.CheckMatrix(matrix, matrix.GetLength(0), matrix.GetLength(1));

            Console.WriteLine("The largest area of equal neighbor elements in a rectangular matrix");
            PrintMatrix(DepthFirstSearch.LargestAreaEqNbEl());

            Console.WriteLine("The size of equal neighbor elements is : {0}", maxAreaSize);
            Console.WriteLine();
        }


        private static int[,] FillMatrix(int[,] matrix, Random randomGenerator)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (randomGenerator.Next(4) + 1);

                }
            }

            return matrix;
        }


        private static void PrintMatrix(int[,] array)
        {
            string line = new string('-', (array.GetLength(1) * 6));

            for (int column = 0; column < array.GetLength(0); column++)
            {
                Console.WriteLine(line + "-");

                Console.Write("|");
                for (int row = 0; row < array.GetLength(1); row++)
                {                    
                    Console.Write(" {0,3} |", (array[column, row]));
                }

                Console.WriteLine();
            }

            Console.WriteLine(line + "-");
        }
    }
}
