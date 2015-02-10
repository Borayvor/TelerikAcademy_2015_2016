namespace E11_AddingPolynomials
{
    using System;

    public class AddingPolynomials
    {
        public static void Main(string[] args)
        {
            // Write a method that adds two polynomials.
            // Represent them as arrays of their coefficients.
            // Example:            
            // x2 + 5 => 1x2 + 0x + 5 => {5, 0, 1}   
            // polynomials                  result
            // 11x^2 + 20x^1 + 35           
            // 1x^3 + 24x + 5

            int[] firstPolinom = new int[] { 11, 20, 35 };
            Console.Write("First polinom coefficients : ");
            Print(firstPolinom);

            int[] secondPolinom = new int[] { 1, 0, 24, 5 };
            Console.Write("Second polinom coefficients : ");
            Print(secondPolinom);

            int[] result = AddPolynomials(firstPolinom, secondPolinom);
            Console.Write("Result : ");
            Print(result);
        }


        private static void Print(int[] array)
        {
            string result = string.Join(", ", array);
            Console.WriteLine("{ " + result + " }");
        }

        private static int[] AddPolynomials(int[] arrayOne, int[] arrayTwo)
        {
            int[] arrayResult = new int[Math.Max(arrayOne.Length, arrayTwo.Length)];

            Array.Reverse(arrayOne);
            Array.Reverse(arrayTwo);

            for (int index = 0; index < arrayResult.Length; index++)
            {
                int sum = ((index < arrayOne.Length ? arrayOne[index] : 0) +
                                        (index < arrayTwo.Length ? arrayTwo[index] : 0));

                arrayResult[index] = sum;
            }

            Array.Reverse(arrayResult);

            return arrayResult;
        }
    }
}
