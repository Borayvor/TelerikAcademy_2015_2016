﻿namespace E02_MinimumEditDistance
{
    using System;
    using System.Text;

    public class Startup
    {
        private const double ReplaceCost = 1;
        private const double DeleteCost = 0.9;
        private const double InsertCost = 0.8;

        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the initial word:");
            string initialWord = Console.ReadLine();

            Console.WriteLine("Please enter the target word:");
            string targetWord = Console.ReadLine();
            Console.WriteLine();

            int[,] matrixOfLcs = BuildMatrixOfLongestCommonSet(targetWord, initialWord);

            Console.WriteLine("LcsMatrix:");
            PrintLcsMatrix(matrixOfLcs, targetWord, initialWord);

            double transformCost = CalcTransformCost(matrixOfLcs, targetWord, initialWord);

            Console.WriteLine("The transformation cost is: {0}", transformCost);
            Console.WriteLine();
        }

        private static void PrintLcsMatrix(int[,] matrixOfLcs, string targetWord, string initialWord)
        {
            var matrixToPrint = new StringBuilder();

            matrixToPrint.Append("      ");

            for (int i = 0; i < initialWord.Length; i++)
            {
                matrixToPrint.Append(initialWord[i] + ", ");
            }

            matrixToPrint.Length -= 2;
            matrixToPrint.AppendLine();

            for (int i = 0; i < matrixOfLcs.GetLength(0); i++)
            {
                if (i > 0)
                {
                    matrixToPrint.Append(targetWord[i - 1] + ": ");
                }
                else
                {
                    matrixToPrint.Append("   ");
                }

                for (int j = 0; j < matrixOfLcs.GetLength(1); j++)
                {
                    matrixToPrint.Append(matrixOfLcs[i, j] + ", ");
                }

                matrixToPrint.Length -= 2;
                matrixToPrint.AppendLine();
            }

            Console.WriteLine(matrixToPrint.ToString());
        }

        private static double CalcTransformCost(int[,] matrixOfLcs, string targetWord, string initialWord)
        {
            double transformCost = 0;

            int currentX = matrixOfLcs.GetLength(0) - 1;
            int currentY = matrixOfLcs.GetLength(1) - 1;

            while (currentX != 0 && currentY != 0)
            {
                if (targetWord[currentX - 1] == initialWord[currentY - 1])
                {
                    currentX--;
                    currentY--;
                }
                else if (matrixOfLcs[currentX - 1, currentY] == matrixOfLcs[currentX, currentY - 1])
                {
                    transformCost += ReplaceCost;
                    currentX--;
                    currentY--;
                }
                else if (matrixOfLcs[currentX - 1, currentY] > matrixOfLcs[currentX, currentY - 1])
                {
                    transformCost += InsertCost;
                    currentX--;
                }
                else
                {
                    transformCost += DeleteCost;
                    currentY--;
                }
            }

            if (currentX > 0)
            {
                transformCost += currentX * InsertCost;
            }

            if (currentY > 0)
            {
                transformCost += currentY * DeleteCost;
            }

            return transformCost;
        }

        private static int[,] BuildMatrixOfLongestCommonSet(string targetWord, string initialWord)
        {
            int[,] matrixOfLcs = new int[targetWord.Length + 1, initialWord.Length + 1];

            for (int i = 1; i <= targetWord.Length; i++)
            {
                bool letterMatched = false;
                for (int j = 1; j <= initialWord.Length; j++)
                {
                    if ((!letterMatched) && (targetWord[i - 1] == initialWord[j - 1]))
                    {
                        matrixOfLcs[i, j] = matrixOfLcs[i, j - 1] + 1;
                        letterMatched = true;
                    }
                    else
                    {
                        matrixOfLcs[i, j] = Math.Max(matrixOfLcs[i - 1, j], matrixOfLcs[i, j - 1]);
                    }
                }
            }

            return matrixOfLcs;
        }
    }
}
