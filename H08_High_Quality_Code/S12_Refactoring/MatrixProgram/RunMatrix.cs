namespace MatrixProgram
{
    using System;

    public class RunMatrix
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number:");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number in [1, 100]");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[n, n];
            int currentNumber = 1;
            int row = 0, col = 0;

            while (Matrix.FindNotVisitedCell(matrix, out row, out col))
            {
                int dx = 1;
                int dy = 1;
                while (true)
                {
                    matrix[row, col] = currentNumber;
                    currentNumber++;

                    if (Matrix.IsAnyPosibleWalkDirection(matrix, row, col))
                    {
                        while (row + dx >= n || row + dx < 0 || col + dy >= n || col + dy < 0 || matrix[row + dx, col + dy] != 0)
                        {
                            Matrix.ChangeWalkDirection(ref dx, ref dy);
                        }
                    }
                    else
                    {
                        break;
                    }

                    row += dx;
                    col += dy;
                }
            }

            PrintMatrix(matrix);         
        }


        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
