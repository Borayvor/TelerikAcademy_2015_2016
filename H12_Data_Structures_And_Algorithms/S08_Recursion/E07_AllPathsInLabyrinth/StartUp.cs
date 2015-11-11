namespace E07_AllPathsInLabyrinth
{
    using System;

    public class StartUp
    {
        private static string[,] labyrinth = new string[,]
        {
            {"s", "-", "-", "*", "-", "-", "-"},
            {"*", "*", "-", "*", "-", "*", "-"},
            {"-", "-", "-", "-", "-", "-", "-"},
            {"-", "*", "*", "*", "*", "*", "-"},
            {"-", "-", "-", "-", "-", "-", "e"}
        };

        private static int[,] direction = new int[,]
        {
            { 1, 0 }, //down
            { 0, 1 }, //right
            { -1, 0 }, //up
            { 0, -1 } //left
        };

        public static void Main(string[] args)
        {
            Point start = FindStart();

            FindAllPaths(start, string.Empty, 1);
        }

        private static void FindAllPaths(Point currentPoint, string path, int step)
        {
            for (int i = 0; i < direction.GetLength(0); i++)
            {
                int newRow = currentPoint.Row + direction[i, 0];
                int newCol = currentPoint.Col + direction[i, 1];

                if (InBouds(newRow, newCol))
                {
                    if (IsEnd(new Point(newRow, newCol)))
                    {
                        Console.WriteLine("Path found: " + path);

                        PrintLabyrinth();
                    }

                    if (IsFree(newRow, newCol))
                    {
                        labyrinth[newRow, newCol] = step.ToString();
                        path += currentPoint.ToString();

                        FindAllPaths(new Point(newRow, newCol), path, ++step);
                        labyrinth[newRow, newCol] = "-";
                        step--;
                    }
                }
            }
        }

        private static Point FindStart()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "s")
                    {
                        return new Point(row, col);
                    }
                }
            }

            return new Point();
        }

        private static bool IsEnd(Point point)
        {
            return labyrinth[point.Row, point.Col] == "e";
        }

        private static bool InBouds(int row, int col)
        {
            if (row >= 0
                && col >= 0
                && row < labyrinth.GetLength(0)
                && col < labyrinth.GetLength(1)
                && labyrinth[row, col] != "*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsFree(int row, int col)
        {
            if (labyrinth[row, col] == "-")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void PrintLabyrinth()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write("{0}, ", labyrinth[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
