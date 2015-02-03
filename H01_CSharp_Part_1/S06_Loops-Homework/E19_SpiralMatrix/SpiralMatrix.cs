namespace E19_SpiralMatrix
{
    using System;

    public class SpiralMatrix
    {
        public static void Main(string[] args)
        {
            // Write a program that reads from the console a positive 
            // integer number n (1 = n = 20) and prints a matrix holding 
            // the numbers from 1 to n*n in the form of square spiral 
            // like in the examples below.
            // Examples:
            // 
            // n = 2   matrix      n = 3   matrix      n = 4   matrix
            //         1 2                 1 2 3               1  2  3  4
            //         4 3                 8 9 4               12 13 14 5
            //                             7 6 5               11 16 15 6
            //                                                 10 9  8  7

            Console.WriteLine("Please, enter a positive integer" +
                " \"n\" (1 <= n <= 20) !");

            int n = -1;
            do
            {
                Console.Write("n = ");
                n = int.Parse(Console.ReadLine());
            }
            while (!(1 <= n && n <= 20));
                        
            Console.WriteLine("matrix");
            GetSpiralMatrix(n);
        }


        private static void GetSpiralMatrix(int N)
        {
            int[,] matrix = new int[N, N];

            int index = 0;
            int start = 0;
            int end = N;
            int vertikal = 0;
            int horizontal = 0;

            while ((end - start) > 0)
            {
                for (horizontal = start; horizontal < end; horizontal++)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                horizontal--;

                for (vertikal = start + 1; vertikal < end; vertikal++)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                vertikal--;

                for (horizontal = end - 2; horizontal >= start; horizontal--)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                horizontal++;

                for (vertikal = end - 2; vertikal >= start + 1; vertikal--)
                {
                    index++;
                    matrix[vertikal, horizontal] = index;
                }

                vertikal++;
                start++;
                end--;
            }
                        
            for (int column = 0; column < matrix.GetLength(0); column++) 
            {                
                for (int row = 0; row < matrix.GetLength(1); row++)
                {    
                    Console.Write("{0,3} ", matrix[column, row]);                                        
                }
                Console.WriteLine();
            }           
        }
    }
}
