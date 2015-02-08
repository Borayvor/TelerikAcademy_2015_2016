namespace E06_MatrixClass
{
    using System;
    using System.Text;

    public class Matrix
    {
        private int row;
        private int col;
        private int[,] matrix;

        public Matrix(int[,] matrix)
        {
            this.Value = (int[,])matrix.Clone();
        }

        public Matrix(int rows, int cols)
            : this(new int[rows, cols])
        {
        }

        public int Row
        {
            get
            {
                return this.row;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
        }

        public int[,] Value
        {
            get
            {
                return this.matrix;
            }

            set
            {
                this.matrix = value;
                this.row = value.GetLength(0);
                this.col = value.GetLength(1);
            }
        }

        public int this[int row, int col]
        {
            get
            {
                return this.Value[row, col];
            }
            set
            {
                if(row < 0 || row >= this.matrix.Length ||
                    col < 0 || col >= this.matrix.Length)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range !");
                }

                this.Value[row, col] = value;
            }
        }

        public static Matrix operator +(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix mNull = new Matrix(1, 1);

            try
            {
                SizeEqual(matrixOne, matrixTwo);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return mNull;
            }

            Matrix matrixResult = new Matrix(matrixOne.Row, matrixOne.Col);

            for (int row = 0; row < matrixResult.Row; row++)
            {
                for (int col = 0; col < matrixResult.Col; col++)
                {
                    matrixResult[row, col] = matrixOne[row, col] + matrixTwo[row, col];
                }
            }

            return matrixResult;
        }

        public static Matrix operator -(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix mNull = new Matrix(1, 1);

            try
            {
                SizeEqual(matrixOne, matrixTwo);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return mNull;
            }

            Matrix matrixResult = new Matrix(matrixOne.Row, matrixOne.Col);

            for (int row = 0; row < matrixResult.Row; row++)
            {
                for (int col = 0; col < matrixResult.Col; col++)
                {
                    matrixResult[row, col] = matrixOne[row, col] - matrixTwo[row, col];
                }
            }

            return matrixResult;
        }

        public static Matrix operator *(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix mNull = new Matrix(1, 1);

            try
            {
                SizeEqual(matrixOne, matrixTwo);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return mNull;
            }

            Matrix matrixResult = new Matrix(matrixOne.Row, matrixOne.Col);

            for (int row = 0; row < matrixResult.Row; row++)
            {
                for (int col = 0; col < matrixResult.Col; col++)
                {
                    for (int rowCol = 0; rowCol < matrixOne.col; rowCol++)
                    {
                        matrixResult[row, col] += matrixOne[row, rowCol] * matrixTwo[rowCol, col];
                    }
                }
            }

            return matrixResult;
        }

        public void FillMatrix()
        {
            for (int row = 0; row < this.Row; row++)
            {
                for (int col = 0; col < this.Col; col++)
                {
                    Console.Write("matrix[{0}, {1}] = ", row, col);
                    this[row, col] = int.Parse(Console.ReadLine());

                }
            }
        }

        public void FillMatrix(Random randomGenerator)
        {
            for (int row = 0; row < this.Row; row++)
            {
                for (int col = 0; col < this.Col; col++)
                {
                    this[row, col] = randomGenerator.Next(20);
                }
            }
        }

        public override string ToString()
        {
            const int cellBorderBuffer = 3;

            int max = (Convert.ToString(this.matrix[0, 0])).Length;

            foreach (var cell in this.matrix)
            {
                int cellLength = (Convert.ToString(cell)).Length;
                max = Math.Max(max, cellLength);
            }

            int cellSize = max + cellBorderBuffer;

            string line = new string('-', ((cellSize * matrix.GetLength(1)) +
                (matrix.GetLength(1) - 1)));

            StringBuilder result = new StringBuilder();

            Console.WriteLine(line + "-");

            for (int row = 0; row < this.Row; row++)
            {
                for (int col = 0; col < this.Col; col++)
                {
                    result.Append(Convert
                        .ToString("| " + this.matrix[row, col])
                        .PadRight(cellSize, ' ') + 
                        (col != this.col - 1 ? " " : ("|\n" + line + "-" + "\n")));
                }
            }

            return result.ToString(); ;
        }

        private static void SizeEqual(Matrix m1, Matrix m2)
        {
            if ((m1.Row != m2.Row) || (m1.Col != m2.Col))
            {
                throw new FormatException("Matrixes must have same dimensions!");
            }
        }
    }
}
