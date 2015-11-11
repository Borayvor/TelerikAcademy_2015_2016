namespace E10_LargestEmptyCellsArea
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const int MatrixRows = 8;
        private const int MatrixCols = 8;

        private static int[,] matrix = new int[MatrixRows, MatrixCols];

        private static int finalLongest = 0;
        private static HashSet<Tuple<int, int>> finalAnswer = new HashSet<Tuple<int, int>>();

        private static Random randomGenerator = new Random();

        public static void Main(string[] args)
        {
            GenerateRandomNonPassableTerain();

            for (int i = 0; i < MatrixRows; i++)
            {
                for (int j = 0; j < MatrixCols; j++)
                {
                    if (matrix[i, j] == 0)
                    {

                        Solve(i, j, 0);

                    }
                }
            }

            Console.WriteLine(finalLongest);

            PrintMatrix();
        }

        private static void Solve(int row, int col, int current)
        {
            if (row < 0 || col < 0 || row >= MatrixRows || col >= MatrixCols)
            {
                return;
            }

            if (matrix[row, col] == 0)
            {
                finalAnswer.Add(new Tuple<int, int>(row, col));
                finalLongest++;
                matrix[row, col] = 1;

                Solve(row + 1, col, current + 1);
                Solve(row - 1, col, current + 1);
                Solve(row, col + 1, current + 1);
                Solve(row, col - 1, current + 1);
            }
        }

        static void GenerateRandomNonPassableTerain()
        {
            int decideHelper = MatrixRows * MatrixCols;
            int count = randomGenerator.Next(decideHelper / 4, decideHelper - decideHelper / 4 + 1);

            for (int i = 0; i < count; i++)
            {
                matrix[randomGenerator.Next(0, MatrixRows), randomGenerator.Next(0, MatrixCols)] = 1;
            }
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < MatrixRows; i++)
            {
                for (int j = 0; j < MatrixCols; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    if (finalAnswer.Contains(new Tuple<int, int>(i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        matrix[i, j]--;
                    }

                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
