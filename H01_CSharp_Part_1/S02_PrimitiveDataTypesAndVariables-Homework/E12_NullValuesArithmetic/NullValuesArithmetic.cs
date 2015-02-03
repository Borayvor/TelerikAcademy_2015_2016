namespace E12_NullValuesArithmetic
{
    using System;

    public class NullValuesArithmetic
    {
        public static void Main(string[] args)
        {
            // Create a program that assigns null values to an integer and to a double variable.
            // Try to print these variables at the console.
            // Try to add some number or the null literal to these variables and print the result.

            int? intVar = null;
            double? doubleVar = null;

            Console.WriteLine("intVar = {0}", intVar);
            Console.WriteLine("doubleVar = {0}", doubleVar);

            intVar += 2;
            doubleVar += (3.45 + null);

            Console.WriteLine("intVar + 2 = {0}", intVar);
            Console.WriteLine("doubleVar + (3.45 + null) = {0}", doubleVar);
        }
    }
}
