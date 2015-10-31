namespace E14_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Labyrinth
    {
        private static readonly ICollection<Coordinates> Directions = new Coordinates[]
        {
            new Coordinates(0,  1),
            new Coordinates(1,  0),
            new Coordinates(0, -1),
            new Coordinates(-1,  0),
        };

        public static void Main(string[] args)
        {
            string[,] labyrinth =
        {
            { "_", "_", "_", "x", "_", "x" },
            { "_", "x", "_", "x", "_", "x" },
            { "_", "*", "x", "_", "x", "_" },
            { "_", "x", "_", "_", "_", "_" },
            { "_", "_", "_", "x", "x", "_" },
            { "_", "_", "_", "x", "_", "x" },
        };

            var currentQueue = new Queue<Coordinates>();
            currentQueue.Enqueue(labyrinth.GetIndex("*"));

            int level = 0;

            while (currentQueue.Count != 0)
            {
                var nextQueue = new Queue<Coordinates>();

                level++;

                while (currentQueue.Count != 0)
                {
                    Coordinates currentCoordinates = currentQueue.Dequeue();

                    foreach (Coordinates currentDirection in Directions)
                    {
                        Coordinates nextCoordinates = currentCoordinates + currentDirection;

                        if (!labyrinth.IsInRange(nextCoordinates))
                        {
                            continue;
                        }

                        if (labyrinth[nextCoordinates.Row, nextCoordinates.Col] != "_")
                        {
                            continue;
                        }

                        labyrinth[nextCoordinates.Row, nextCoordinates.Col] = level.ToString();
                        nextQueue.Enqueue(nextCoordinates);
                    }
                }

                currentQueue = nextQueue;
            }

            Console.WriteLine(labyrinth.Replace("_", "u").AsString());
        }

        private static Coordinates GetIndex<T>(this T[,] matrix, T element)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(element))
                    {
                        return new Coordinates(row, col);
                    }
                }
            }

            throw new ArgumentException("Invalid element.");
        }

        private static bool IsInRange<T>(this T[,] matrix, Coordinates coordinates)
        {
            return (0 <= coordinates.Row) && (coordinates.Row < matrix.GetLength(0)) &&
                   (0 <= coordinates.Col) && (coordinates.Col < matrix.GetLength(1));
        }

        private static T[,] Replace<T>(this T[,] matrix, T oldValue, T newValue)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(oldValue))
                    {
                        matrix[row, col] = newValue;
                    }
                }
            }

            return matrix;
        }

        private static string AsString<T>(this T[,] matrix)
        {
            var result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.Append(matrix[row, col] +
                                  (col != matrix.GetUpperBound(1) ? " " : Environment.NewLine));
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
