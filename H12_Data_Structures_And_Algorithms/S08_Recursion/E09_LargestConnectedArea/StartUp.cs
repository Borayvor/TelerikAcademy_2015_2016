namespace E09_LargestConnectedArea
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
            {"-", "-", "-", "-", "-", "-", "e"},
        };

        private static int[,] direction = new int[,]
        {
            { 1, 0 }, //down
            { 0, 1 }, //right
            { -1, 0 }, //up
            { 0, -1 } //left
        };

        private static int currentPathLenght = 1;
        private static int maxPathLength = 0;

        public static void Main(string[] args)
        {
            Point start = FindStart();

            FindAllPaths(start, 1);

            Console.WriteLine("Largest area of connected adjecent cells is {0}", maxPathLength);
        }

        static void FindAllPaths(Point currentPoint, int step)
        {
            for (int i = 0; i < direction.GetLength(0); i++)
            {
                int newRow = currentPoint.Row + direction[i, 0];
                int newCol = currentPoint.Col + direction[i, 1];

                if (InBouds(newRow, newCol))
                {
                    if (IsEnd(new Point(newRow, newCol)))
                    {
                        if (currentPathLenght > maxPathLength)
                        {
                            maxPathLength = currentPathLenght;
                        }

                        currentPathLenght = 1;
                    }

                    if (IsFree(newRow, newCol))
                    {
                        labyrinth[newRow, newCol] = step.ToString();
                        currentPathLenght++;
                        FindAllPaths(new Point(newRow, newCol), ++step);
                        labyrinth[newRow, newCol] = "-";
                        step--;
                    }
                }
            }
        }

        static Point FindStart()
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

        static bool IsEnd(Point point)
        {
            return labyrinth[point.Row, point.Col] == "e";
        }

        public static bool InBouds(int row, int col)
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

        public static bool IsFree(int row, int col)
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
    }
}
