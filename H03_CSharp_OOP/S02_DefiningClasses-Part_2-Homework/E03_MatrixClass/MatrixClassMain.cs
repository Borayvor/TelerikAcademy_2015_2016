namespace E03_MatrixClass
{
    using System;

    public class MatrixClassMain
    {
        public static void Main(string[] args)
        {
            //test Matrix
            Console.WriteLine("Test \"Matrix\"");
            Matrix<int> matrix = new Matrix<int>();
            Matrix<double> matrix1 = new Matrix<double>(4);
            Matrix<int> matrix2 = new Matrix<int>(3, 3);
            int[,] tempMatrix = new int[3, 3];
            Matrix<int> matrix3 = new Matrix<int>(tempMatrix);
            Matrix<int> matrix4 = new Matrix<int>(new int[4, 4]);

            Matrix<DateTime> matrix5 = new Matrix<DateTime>(3, 3);

            //Console.WriteLine (matrix5 + matrix5);

            double[,] matrixD = { 
                                { 0, 2, 3, 4.3 }, 
                                { 1, 2.5, 3, 4 }, 
                                { 1, 2, 3.2, 4 }, 
                                { 1.1, 2, 3, 4 } 
                                };

            Matrix<double> matrix6 = new Matrix<double>(matrixD);

            Console.WriteLine();
            // matrix1
            for (int row = 0; row < matrix1.Rows; row++)
            {
                for (int col = 0; col < matrix1.Cols; col++)
                {
                    matrix1[row, col] = 2;
                }
            }
            matrix1[1, 1] = 0;

            Console.WriteLine("m1 + m6 = ");
            Console.WriteLine(matrix1 + matrix6);
            Console.WriteLine("m1 - m6 = ");
            Console.WriteLine(matrix1 - matrix6);
            Console.WriteLine("m1 * m6 = ");
            Console.WriteLine(matrix1 * matrix6);

            Console.WriteLine("matrix1 - true or false");

            if (matrix1)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            Console.WriteLine();
        }
    }
}
