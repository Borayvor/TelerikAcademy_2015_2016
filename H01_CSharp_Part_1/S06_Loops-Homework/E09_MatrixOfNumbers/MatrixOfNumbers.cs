﻿namespace E09_MatrixOfNumbers
{
    using System;

    public class MatrixOfNumbers
    {
        public static void Main(string[] args)
        {
            // Write a program that reads from the console a positive 
            // integer number n (1 <= n <= 20) and prints a matrix like 
            // in the examples below. Use two nested loops.
            // Examples:
            // 
            // n = 2   matrix      n = 3   matrix      n = 4   matrix
            //         1 2                 1 2 3               1 2 3 4
            //         2 3                 2 3 4               2 3 4 5
            //                             3 4 5               3 4 5 6
            //                                                 4 5 6 7

            Console.WriteLine("Please, enter a positive integer" +
                " \"n\" (1 <= n <= 20) !");

            int n = -1;
            do
            {
                Console.Write("n = ");
                n = int.Parse(Console.ReadLine());
            }
            while (!(1 <= n && n <= 20));

            Console.WriteLine();

            Console.WriteLine("matrix");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0} ",row + col + 1);
                }

                Console.WriteLine();
            }
        }
    }
}
