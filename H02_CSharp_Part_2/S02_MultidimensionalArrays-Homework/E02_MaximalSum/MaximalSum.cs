namespace E02_MaximalSum
{
    using System;

    public class MaximalSum
    {
        static int[,] subMatrix3x3 = new int[3, 3];
        static int value = 0;

        public static void Main(string[] args)
        {
            // Write a program that reads a rectangular matrix of
            // size N x M and finds in it the square 3 x 3 that 
            // has maximal sum of its elements.
            // Example for  n = m = 4:
            // matrix:                  subMatrix:
            // 1  12  11  10            12  11  10
            // 2  13  16  9             13  16  9
            // 3  14  15  8             14  15  8   
            // 4  5   6   7 

            int n = 0;
            do
            {
                n = GetNumber("vertical array length N");
            }
            while (n < 3);

            int m = 0;
            do
            {
                m = GetNumber("horizontal array length M");
            }
            while (m < 3);

            Console.WriteLine();

            int[,] array = new int[n, m];

            Console.WriteLine("Enter numbers in the cells: ");

            for (int vertikal = 0; vertikal < n; vertikal++)
            {
                for (int horizontal = 0; horizontal < m; horizontal++)
                {
                    array[vertikal, horizontal] = GetNumber("array[" + vertikal + 
                        ", " + horizontal + "]");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Matrix {0} x {1}", n, m);
            PrintMatrix(array);

            Console.WriteLine();

            for (int vertikal = 0; vertikal < n - 2; vertikal++)
            {
                for (int horizontal = 0; horizontal < m - 2; horizontal++)
                {
                    GetSubMatrixSum(array, vertikal, horizontal);
                }
            }

            Console.WriteLine("The square 3 x 3 that has maximal sum of its elements:");
            PrintMatrix(subMatrix3x3);

            Console.WriteLine();
            Console.WriteLine("Sum of elements: {0}", value);
        }


        private static void GetSubMatrixSum(int[,] array, int row, int column)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += array[row + (i % 3), column + (i / 3)];
            }
            if (sum >= value)
            {
                for (int i = 0; i < 9; i++)
                {
                    subMatrix3x3[i % 3, i / 3] = array[row + (i % 3), column + (i / 3)];
                }
                value = sum;
            }
        }

        private static void PrintMatrix(int[,] array)
        {
            string line = new string('-', (array.GetLength(0) * 6));

            for (int column = 0; column < array.GetLength(0); column++)
            {

                Console.WriteLine(line + "-");
                Console.Write("|");

                for (int row = 0; row < array.GetLength(1); row++)
                {
                    if ((array[column, row]) < 10)
                    {
                        Console.Write("  ");
                    }
                    else if ((array[column, row]) < 100)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(" {0} |", (array[column, row]));
                }

                Console.WriteLine();
            }

            Console.WriteLine(line + "-");
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
