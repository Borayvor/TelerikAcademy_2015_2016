namespace E03_Sequence_N_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sequence_N_Matrix
    {
        static List<string> sequence = new List<string>();

        public static void Main(string[] args)
        {
            // We are given a matrix of strings of size N x M. 
            // Sequences in the matrix we define as sets of 
            // several neighbour elements located on the same 
            // line, column or diagonal.
            // Write a program that finds the longest sequence 
            // of equal strings in the matrix.
            // Example:
            // matrix 	                     result 
		    // 3
            // 4
            // ha   fifi   ho	 hi          ha, ha, ha     
            // fo   ha 	   hi	 xx                             
            // xxx  ho 	   ha	 xx                             
            // ============================================	
		    // 3
            // 3
            // s   qq  s                     s, s, s 
            // pp  pp  s
            // pp  qq  s

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

            string[,] matrix = new string[n, m];

            Console.WriteLine("Enter strings in the cells: ");

            //for (int vertikal = 0; vertikal < n; vertikal++)
            //{
            //    for (int horizontal = 0; horizontal < m; horizontal++)
            //    {
            //        Console.Write("array[" + vertikal + ", " + horizontal + "] = ");
            //        matrix[vertikal, horizontal] = Console.ReadLine();
            //    }
            //}

            for (int vertikal = 0; vertikal < n; vertikal++)
            {
                string[] array = Console.ReadLine()
               .Split(new char[] { ' ', '\t', ',' },
                        StringSplitOptions.RemoveEmptyEntries)
               .Select(ch => ch.ToString())
               .ToArray();

                for (int horizontal = 0; horizontal < m; horizontal++)
                {
                    matrix[vertikal, horizontal] = array[horizontal];
                }
            }

            Console.WriteLine();

            Console.WriteLine("Matrix {0} x {1}", n, m);
            PrintMatrix(matrix);
            Console.WriteLine();

            HorizontalSequence(matrix);
            VertikalSequence(matrix);
            DiagonalUpLRDownSequence(matrix);
            DiagonalDownLRUpSequence(matrix);

            Console.WriteLine("The longest sequence of equal strings in " +
                "the matrix has {0} elements.", sequence.Count);
            Console.Write("-->  |");
            for (int index = 0; index < sequence.Count; index++)
            {
                Console.Write(" {0} |", (sequence[index]));
            }

            Console.WriteLine("\n");
        }

        static void HorizontalSequence(string[,] matrix)
        {
            for (int vertikal = 0; vertikal < matrix.GetLength(0); vertikal++)
            {
                for (int horizontal = 0; horizontal < matrix.GetLength(1); horizontal++)
                {
                    int index = 0;

                    for (int horiz = horizontal; horiz < matrix.GetLength(1); horiz++)
                    {
                        if (matrix[vertikal, horizontal].Equals(matrix[vertikal, horiz]))
                        {
                            index++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if ((sequence.Count < index) && (index > 1))
                    {
                        sequence.Clear();

                        for (int horiz = horizontal; horiz < horizontal + index; horiz++)
                        {
                            sequence.Add(matrix[vertikal, horiz]);
                        }
                    }
                }
            }
        }

        static void VertikalSequence(string[,] matrix)
        {
            int horizontal = 0;

            while (horizontal < matrix.GetLength(1))
            {
                int vertikal = 0;

                for (vertikal = 0; vertikal < matrix.GetLength(0); vertikal++)
                {
                    int index = 0;

                    for (int vert = vertikal; vert < matrix.GetLength(0); vert++)
                    {
                        if (matrix[vertikal, horizontal].Equals(matrix[vert, horizontal]))
                        {
                            index++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if ((sequence.Count < index) && (index > 1))
                    {
                        sequence.Clear();

                        for (int vert = vertikal; vert < vertikal + index; vert++)
                        {
                            sequence.Add(matrix[vert, horizontal]);
                        }
                    }
                }

                horizontal++;
            }
        }

        private static void DiagonalUpLRDownSequence(string[,] matrix)
        {
            for (int vertikal = 0; vertikal < matrix.GetLength(0); vertikal++)
            {
                for (int horizontal = 0; horizontal < matrix.GetLength(1); horizontal++)
                {
                    int index = 0;
                    int vert = vertikal;
                    int horiz = horizontal;

                    while ((vert < matrix.GetLength(0)) && (horiz < matrix.GetLength(1)))
                    {
                        if ((matrix[vertikal, horizontal].Equals(matrix[vert, horiz])))
                        {
                            index++;
                        }
                        else
                        {
                            break;
                        }

                        vert++;
                        horiz++;
                    }

                    if ((sequence.Count < index) && (index > 1))
                    {
                        sequence.Clear();
                        vert = vertikal;
                        horiz = horizontal;

                        while (sequence.Count < index)
                        {
                            sequence.Add(matrix[vert, horiz]);
                            vert++;
                            horiz++;
                        }
                    }
                }
            }
        }

        private static void DiagonalDownLRUpSequence(string[,] matrix)
        {
            for (int vertikal = matrix.GetLength(0) - 1; vertikal >= 0; vertikal--)
            {
                for (int horizontal = 0; horizontal < matrix.GetLength(1); horizontal++)
                {
                    int index = 0;
                    int vert = vertikal;
                    int horiz = horizontal;

                    while ((vert >= 0) && (horiz < matrix.GetLength(1)))
                    {
                        if ((matrix[vertikal, horizontal].Equals(matrix[vert, horiz])))
                        {
                            index++;
                        }
                        else
                        {
                            break;
                        }

                        vert--;
                        horiz++;
                    }

                    if ((sequence.Count < index) && (index > 1))
                    {
                        sequence.Clear();
                        vert = vertikal;
                        horiz = horizontal;

                        while (sequence.Count < index)
                        {
                            sequence.Add(matrix[vert, horiz]);
                            vert--;
                            horiz++;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            string line = new string('-', (matrix.GetLength(1) * 11));

            for (int column = 0; column < matrix.GetLength(0); column++)
            {
                Console.WriteLine(line + "-");
                Console.Write("|");

                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    Console.Write(" {0,8} |", (matrix[column, row]));
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
