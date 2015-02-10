namespace E12_SubtractingPolynomials
{
    using System;

    public class SubtractingPolynomials
    {
        public static void Main(string[] args)
        {
            // Extend the previous program to support also 
            // subtraction and multiplication of polynomials.

            int[] firstPolinom = new int[] { 11, 20, 35 };
            Console.Write("First polinom coefficients : ");
            Print(firstPolinom);

            int[] secondPolinom = new int[] { 1, 0, 24, 5 };
            Console.Write("Second polinom coefficients : ");
            Print(secondPolinom);

            int[] resultSubtract = SubtractPolynomials(firstPolinom, secondPolinom);
            Console.Write("Result SubtractPolynomials: ");
            Print(resultSubtract);

            Console.WriteLine();

            int[] resultMultiply = MultiplyPolynomials(firstPolinom, secondPolinom);
            Console.Write("Result MultiplyPolynomials: ");
            Print(resultMultiply);
        }


        private static void Print(int[] array)
        {
            string result = string.Join(", ", array);
            Console.WriteLine("{ " + result + " }");
        }

        private static int[] SubtractPolynomials(int[] arrayOne, int[] arrayTwo)
        {
            if (arrayTwo.Length > arrayOne.Length) 
            {
                return SubtractPolynomials(arrayTwo, arrayOne);
            }

            int[] arrayResult = new int[Math.Max(arrayOne.Length, arrayTwo.Length)];

            Array.Reverse(arrayOne);
            Array.Reverse(arrayTwo);

            for (int index = 0; index < arrayResult.Length; index++)
            {
                int sum = ((index < arrayOne.Length ? arrayOne[index] : 0) -
                                        (index < arrayTwo.Length ? arrayTwo[index] : 0));

                arrayResult[index] = sum;
            }

            Array.Reverse(arrayResult);

            return arrayResult;
        }

        private static int[] MultiplyPolynomials(int[] arrayOne, int[] arrayTwo)
        {
            Array.Reverse(arrayOne);
            Array.Reverse(arrayTwo);
            
            int[] result = new int[arrayOne.Length + arrayTwo.Length - 1];

            for (int i = 0; i < arrayOne.Length; i++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    result[i + j] += arrayOne[i] * arrayTwo[j];
                }
            }
            return result;
        }
    }
}
