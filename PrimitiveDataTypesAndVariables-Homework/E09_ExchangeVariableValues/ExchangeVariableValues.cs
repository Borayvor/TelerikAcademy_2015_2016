namespace E09_ExchangeVariableValues
{
    using System;

    public class ExchangeVariableValues
    {
        public static void Main(string[] args)
        {
            // Declare two integer variables a and b and assign them with 5 and 10 and 
            // after that exchange their values by using some programming logic.
            // Print the variable values before and after the exchange.

            int a = 5;
            Console.WriteLine("a = {0}", a);
            int b = 10;
            Console.WriteLine("b = {0}", b);
            Console.WriteLine();

            int c = a;
            a = b;
            b = c;

            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.WriteLine();
        }
    }
}
