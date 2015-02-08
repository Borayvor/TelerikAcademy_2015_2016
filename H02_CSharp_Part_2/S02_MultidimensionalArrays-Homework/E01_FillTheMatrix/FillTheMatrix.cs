namespace E01_FillTheMatrix
{
    using System;

    public class FillTheMatrix
    {
        static int n;

        public static void Main(string[] args)
        {
            // Write a program that fills and prints a matrix of 
            // size (n, n) as shown below:
            // Example for  n = 4:
            // a) 	                b) 	        
            // 1  5   9   13        1  8   9   16
            // 2  6   10  14        2  7   10  15
            // 3  7   11  15        3  6   11  14
            // 4  8   12  16        4  5   12  13
            // 	         
            // c) 	                d)*
            // 7  11  14  16        1  12  11  10
            // 4  8   12  15        2  13  16  9
            // 2  5   9   13        3  14  15  8
            // 1  3   6   10	    4  5   6   7    

            do
            {
                n = GetNumber("array length N");
            }
            while (n < 3 || n > 20);

            VertikalAlignmentMatrix(n);

            VertikalZigZagAlignmentMatrix(n);

            DiagonalAlignmentMatrix(n);

            SpiralAlignmentMatrix(n);
        }


        private static void VertikalAlignmentMatrix(int size)
        {
            Console.WriteLine("A)");

            int[,] matrix = new int[size, size];

            int index;

            for (int vertikal = 0; vertikal < size; vertikal++)
            {
                index = vertikal + 1;

                for (int horizontal = 0; horizontal < size; horizontal++)
                {
                    matrix[vertikal, horizontal] = index;
                    index += size;
                }
            }

            PrintMatrix(matrix);

            Console.WriteLine();
        }
        
        private static void VertikalZigZagAlignmentMatrix(int size)
        {
            Console.WriteLine("B)");

            int[,] matrix = new int[size, size];

            int index = 0;
            int horizontal = 0;

            while (horizontal < size)
            {
                if ((horizontal % 2) == 0)
                {
                    for (int vertikal = 0; vertikal < size; vertikal++)
                    {
                        index++;
                        matrix[vertikal, horizontal] = index;
                    }
                }
                else
                {
                    for (int vertikal = size - 1; vertikal >= 0; vertikal--)
                    {
                        index++;
                        matrix[vertikal, horizontal] = index;
                    }
                }

                horizontal++;
            }

            PrintMatrix(matrix);

            Console.WriteLine();
        }
        
        private static void DiagonalAlignmentMatrix(int size)
        {
            Console.WriteLine("C)");

            int[,] matrix = new int[size, size];

            int index = 1;

            for (int vertikal = 0; vertikal <= size - 1; vertikal++)
            {
                for (int horizontal = 0; horizontal <= vertikal; horizontal++)
                {
                    matrix[size - vertikal + horizontal - 1, horizontal] = index++;
                }
            }

            for (int vertikal = size - 2; vertikal >= 0; vertikal--)
            {
                for (int horizontal = vertikal; horizontal >= 0; horizontal--)
                {
                    matrix[vertikal - horizontal, size - horizontal - 1] = index++;
                }
            }

            PrintMatrix(matrix);

            Console.WriteLine();
        }
        
        private static void SpiralAlignmentMatrix(int size)
        {
            Console.WriteLine("D)");

            int[,] matrix = new int[size, size];

            int index = 0;
            int start = 0;
            int end = size;
            int vertikal = 0;
            int horizontal = 0;

            while ((end - start) > 0)
            {

                for (vertikal = start; vertikal < end; vertikal++)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                vertikal--;

                for (horizontal = start + 1; horizontal < end; horizontal++)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                horizontal--;

                for (vertikal = end - 2; vertikal >= start; vertikal--)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                vertikal++;

                for (horizontal = end - 2; horizontal >= start + 1; horizontal--)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                horizontal++;
                start++;
                end--;
            }

            PrintMatrix(matrix);

            Console.WriteLine();
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
