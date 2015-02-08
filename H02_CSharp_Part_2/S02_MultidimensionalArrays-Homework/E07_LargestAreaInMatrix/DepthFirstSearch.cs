namespace E07_LargestAreaInMatrix
{
    using System.Collections.Generic;

    public static class DepthFirstSearch
    {        
        private static Stack<int> branchingCellColPrivate;
        private static Stack<int> branchingCellRowPrivate;
        private static int[,] tablePrivate;
        private static bool[,] visitedCellsPrivate;
        private static int[,] neighborElementsPrivate;
        private static int[,] tempNeighborElementsPrivate;
        private static int rowsPrivate;
        private static int colsPrivate;
        private static int maxAreaSizePrivate;
        private static int currentAreaSizePrivate;

        public static int CheckMatrix(int[,] table, int cols, int rows)
        {
            Initialize(table, cols, rows);

            for (int row = 0; row < rowsPrivate; row++)
            {
                for (int col = 0; col < colsPrivate; col++)
                {
                    if (visitedCellsPrivate[row, col] == false && IsBranching(row, col) == true)
                    {
                        branchingCellColPrivate.Push(col);
                        branchingCellRowPrivate.Push(row);
                        Explore(col, row);
                    }
                }
            }

            return maxAreaSizePrivate;
        }

        public static int[,] LargestAreaEqNbEl()
        {
            return neighborElementsPrivate;
        }

        private static void Initialize(int[,] table, int cols, int rows)
        {
            branchingCellColPrivate = new Stack<int>();
            branchingCellRowPrivate = new Stack<int>();
            InitializeVisitedCells(cols, rows);
            tablePrivate = table;
            colsPrivate = cols;
            rowsPrivate = rows;
            maxAreaSizePrivate = 0;
            currentAreaSizePrivate = 0;
            neighborElementsPrivate = new int[rows, cols];
            tempNeighborElementsPrivate = new int[rows, cols];
        }
                
        private static void InitializeVisitedCells(int cols, int rows)
        {
            visitedCellsPrivate = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    visitedCellsPrivate[row, col] = false;
                }
            }
        }

        private static bool IsBranching(int row, int col)
        {
            int currentValue = tablePrivate[row, col];

            if (col - 1 >= 0 && tablePrivate[row, col - 1] == currentValue &&
                IsVisited(row, col - 1) == false) //left
            {
                return true;
            }
            else if (col + 1 < colsPrivate && tablePrivate[row, col + 1] == currentValue &&
                IsVisited(row, col + 1) == false)//right
            {
                return true;
            }
            else if (row - 1 >= 0 && tablePrivate[row - 1, col] == currentValue &&
                IsVisited(row - 1, col) == false)//up
            {
                return true;
            }
            else if (row + 1 < rowsPrivate && tablePrivate[row + 1, col] == currentValue &&
                IsVisited(row + 1, col) == false)//down
            {
                return true;
            }

            return false;
        }

        private static bool IsVisited(int row, int col)
        {
            return visitedCellsPrivate[row, col];
        }
                                
        private static void Explore(int col, int row)
        {
            int currentValue = tablePrivate[row, col];
            //_currentAreaSize++;
            while (branchingCellColPrivate.Count > 0 && branchingCellRowPrivate.Count > 0)
            {
                col = branchingCellColPrivate.Pop();
                row = branchingCellRowPrivate.Pop();

                int colTemp = col;
                int rowTemp = row;

                while (colTemp - 1 >= 0 && tablePrivate[rowTemp, colTemp - 1] == currentValue &&
                    IsVisited(rowTemp, colTemp - 1) == false) //left
                {
                    colTemp = colTemp - 1;
                    //rowTemp = rowTemp;
                    branchingCellColPrivate.Push(colTemp);
                    branchingCellRowPrivate.Push(rowTemp);
                    visitedCellsPrivate[rowTemp, colTemp] = true;
                    currentAreaSizePrivate++;
                    tempNeighborElementsPrivate[rowTemp, colTemp] = currentValue;
                }

                colTemp = col;
                rowTemp = row;

                while (colTemp + 1 < colsPrivate && tablePrivate[rowTemp, colTemp + 1] == currentValue &&
                    IsVisited(rowTemp, colTemp + 1) == false)//right
                {
                    colTemp = colTemp + 1;
                    //rowTemp = rowTemp;
                    branchingCellColPrivate.Push(colTemp);
                    branchingCellRowPrivate.Push(rowTemp);
                    visitedCellsPrivate[rowTemp, colTemp] = true;
                    currentAreaSizePrivate++;
                    tempNeighborElementsPrivate[rowTemp, colTemp] = currentValue;
                }

                colTemp = col;
                rowTemp = row;

                while (rowTemp - 1 >= 0 && tablePrivate[rowTemp - 1, colTemp] == currentValue &&
                   IsVisited(rowTemp - 1, colTemp) == false)//up
                {
                    //colTemp = colTemp;
                    rowTemp = rowTemp - 1;
                    branchingCellColPrivate.Push(colTemp);
                    branchingCellRowPrivate.Push(rowTemp);
                    visitedCellsPrivate[rowTemp, colTemp] = true;
                    currentAreaSizePrivate++;
                    tempNeighborElementsPrivate[rowTemp, colTemp] = currentValue;
                }

                colTemp = col;
                rowTemp = row;

                while (rowTemp + 1 < rowsPrivate && tablePrivate[rowTemp + 1, colTemp] == currentValue &&
                    IsVisited(rowTemp + 1, colTemp) == false)//down
                {
                    //colTemp = colTemp;
                    rowTemp = rowTemp + 1;
                    branchingCellColPrivate.Push(colTemp);
                    branchingCellRowPrivate.Push(rowTemp);
                    visitedCellsPrivate[rowTemp, colTemp] = true;
                    currentAreaSizePrivate++;
                    tempNeighborElementsPrivate[rowTemp, colTemp] = currentValue;
                }
            }

            if (currentAreaSizePrivate > maxAreaSizePrivate)
            {
                if (currentAreaSizePrivate >= maxAreaSizePrivate)
                {
                    for (int i = 0; i < neighborElementsPrivate.GetLength(0); i++)
                    {
                        for (int j = 0; j < neighborElementsPrivate.GetLength(1); j++)
                        {
                            if (tablePrivate[i, j] == currentValue && (IsVisited(i, j)))
                            {
                                neighborElementsPrivate[i, j] = tempNeighborElementsPrivate[i, j];
                            }
                            else
                            {
                                neighborElementsPrivate[i, j] = 0;
                            }
                        }
                    }
                }

                maxAreaSizePrivate = currentAreaSizePrivate;
            }

            for (int i = 0; i < tempNeighborElementsPrivate.GetLength(0); i++)
            {
                for (int j = 0; j < tempNeighborElementsPrivate.GetLength(1); j++)
                {
                    tempNeighborElementsPrivate[i, j] = 0;
                }
            }

            currentAreaSizePrivate = 0;
        }
    }
}
