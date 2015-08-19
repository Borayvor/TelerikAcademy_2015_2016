namespace MatrixProgram
{
    using System;

    public class Matrix
    {
        public static void ChangeWalkDirection(ref int dx, ref int dy)
        {
            int[] normalVectorsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] normalVectorsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            const int PosibleDirectionCount = 8;
            int currentNormalVectorIndex = 0;

            for (int count = 0; count < PosibleDirectionCount; count++)
            {
                if (normalVectorsX[count] == dx && normalVectorsY[count] == dy)
                {
                    currentNormalVectorIndex = count;
                    break;
                }
            }

            if (currentNormalVectorIndex == 7)
            {
                dx = normalVectorsX[0];
                dy = normalVectorsY[0];
            }
            else
            {
                dx = normalVectorsX[currentNormalVectorIndex + 1];
                dy = normalVectorsY[currentNormalVectorIndex + 1];
            }
        }

        public static bool IsAnyPosibleWalkDirection(int[,] matrix, int x, int y)
        {
            int[] normalVectorsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] normalVectorsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            const int PosibleDirectionCount = 8;

            for (int i = 0; i < PosibleDirectionCount; i++)
            {
                if (x + normalVectorsX[i] >= matrix.GetLength(0) || x + normalVectorsX[i] < 0)
                {
                    normalVectorsX[i] = 0;
                }

                if (y + normalVectorsY[i] >= matrix.GetLength(0) || y + normalVectorsY[i] < 0)
                {
                    normalVectorsY[i] = 0;
                }
            }

            for (int i = 0; i < PosibleDirectionCount; i++)
            {
                if (matrix[x + normalVectorsX[i], y + normalVectorsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool FindNotVisitedCell(int[,] matrix, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
