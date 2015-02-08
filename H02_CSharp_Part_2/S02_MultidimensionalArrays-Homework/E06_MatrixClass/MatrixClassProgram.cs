namespace E06_MatrixClass
{
    using System;

    public class MatrixClassProgram
    {
        public static void Main(string[] args)
        {
            // Write a class Matrix, to hold a matrix of integers.
            // Overload the operators for adding, subtracting and 
            // multiplying of matrices, indexer for accessing 
            // the matrix content and ToString().

            Console.BufferHeight = 200;

            Matrix matrixOne = new Matrix(3, 3);
            Matrix matrixTwo = new Matrix(4, 5);
            Matrix matrixThree = new Matrix(3, 3);

            Random randomGenerator = new Random();
            matrixOne.FillMatrix(randomGenerator);
            matrixTwo.FillMatrix(randomGenerator);
            matrixThree.FillMatrix(randomGenerator);

            Console.WriteLine("Matrix one");
            Console.WriteLine(matrixOne);

            Console.WriteLine("Matrix two");
            Console.WriteLine(matrixTwo);

            Console.WriteLine("Matrix three");
            Console.WriteLine(matrixThree);

            Console.WriteLine("Matrix one + Matrix two");
            Console.WriteLine(matrixOne + matrixTwo);

            Console.WriteLine("Matrix one - Matrix three");
            Console.WriteLine(matrixOne - matrixThree);

            Console.WriteLine("Matrix one + Matrix three");
            Console.WriteLine(matrixOne + matrixThree);

            Console.WriteLine("Matrix one * Matrix three");
            Console.WriteLine(matrixOne * matrixThree);
        }
    }
}
