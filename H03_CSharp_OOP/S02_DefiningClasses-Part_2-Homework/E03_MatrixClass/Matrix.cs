namespace E03_MatrixClass
{
    using System;
    using System.Text;

    // 08. Matrix
    // Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
    public class Matrix<T> 
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private const int DefaultSize = 1;

        private T[,] matrix;        

        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public int Size { get; private set; }

        public Matrix()
        {
            this.matrix = new T[DefaultSize, DefaultSize];
        }

        public Matrix(int size)
        {
            this.Rows = size;
            this.Cols = size;
            this.matrix = new T[Rows, Cols];
        }

        public Matrix(int row, int col)
        {
            this.Rows = row;
            this.Cols = col;
            this.matrix = new T[row, col];
        }

        public Matrix(T[,] matrix)
        {
            this.matrix = matrix;
            Rows = matrix.GetLength(0);
            Cols = matrix.GetLength(1);
        }

        // 09. Matrix indexer
        // Implement an indexer this[row, col] to access the inner matrix cells.
        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0 || row > this.Rows || col > this.Cols)
                {
                    throw new IndexOutOfRangeException("The cell is not in range !");
                }
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        // 10. Matrix operations
        // Implement the operators + and - (addition and subtraction of matrices 
        // of the same size) and * for matrix multiplication.
        // Throw an exception when the operation cannot be performed.
        // Implement the true operator (check for non-zero elements).
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> matrixNull = new Matrix<T>(1, 1);

            try
            {
                SizeEqual(m1, m2);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return matrixNull;
            }

            Matrix<T> matrixResult = new Matrix<T>(m1.Rows, m1.Cols);

            for (int row = 0; row < matrixResult.Rows; row++)
            {
                for (int col = 0; col < matrixResult.Cols; col++)
                {
                    checked
                    {
                        matrixResult[row, col] = (dynamic)m1[row, col] + m2[row, col];
                    }
                }
            }

            return matrixResult;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> matrixNull = new Matrix<T>(1, 1);

            try
            {
                SizeEqual(m1, m2);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return matrixNull;
            }

            Matrix<T> matrixResult = new Matrix<T>(m1.Rows, m1.Cols);

            for (int row = 0; row < matrixResult.Rows; row++)
            {
                for (int col = 0; col < matrixResult.Cols; col++)
                {
                    checked
                    {
                        matrixResult[row, col] = (dynamic)m1[row, col] - m2[row, col];
                    }
                }
            }

            return matrixResult;
        }
                
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> matrixNull = new Matrix<T>(1, 1);

            try
            {
                SizeEqual(m1, m2);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return matrixNull;
            }

            Matrix<T> matrixResult = new Matrix<T>(m1.Rows, m1.Cols);

            for (int row = 0; row < matrixResult.Rows; row++)
            {
                for (int col = 0; col < matrixResult.Cols; col++)
                {
                    for (int column = 0; column < m1.Cols; column++)
                    {
                        checked
                        {
                            matrixResult[row, col] += (dynamic)m1[row, column] * m2[column, col];
                        }
                    }
                }
            }

            return matrixResult;
        }
        
        private static void SizeEqual(Matrix<T> m1, Matrix<T> m2)
        {
            if ((m1.Rows != m2.Rows) || (m1.Cols != m2.Cols))
            {
                throw new FormatException("Matrixes must have same dimensions!");
            }
        }
                       
        public static Boolean operator true(Matrix<T> matrix)
        {
            int zero = 0;
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] == zero)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        public static Boolean operator false(Matrix<T> matrix)
        {
            int zero = 0;
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] == zero)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public override string ToString()
        {
            int max = (Convert.ToString(this.matrix[0, 0])).Length;
            foreach (var cell in this.matrix)
            {
                int cellLength = (Convert.ToString(cell)).Length;
                max = Math.Max(max, cellLength);
            }
            int cellSize = max + 3;

            string line = new string('-', (((max + 3) * matrix.GetLength(1)) + (matrix.GetLength(1) - 1)));
                        
            StringBuilder stringResult = new StringBuilder();
            stringResult.Append(string.Empty);

            Console.WriteLine(line + "-");

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    stringResult.Append(Convert.ToString("| " + this.matrix[i, j]).PadRight(cellSize, ' ') +
                                            (j != this.Cols - 1 ? " " : ("|\n" + line + "-" + "\n")));
                }
            }

            return stringResult.ToString();
        }
    }
}
