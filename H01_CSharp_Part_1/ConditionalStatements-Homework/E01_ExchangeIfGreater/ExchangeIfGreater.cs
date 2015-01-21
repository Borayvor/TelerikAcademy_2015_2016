namespace E01_ExchangeIfGreater
{
    using System;

    public class ExchangeIfGreater
    {
        public static void Main(string[] args)
        {
            // Write an if-statement that takes two double 
            // variables a and b and exchanges their values if the 
            // first one is greater than the second one. As a result 
            // print the values a and b, separated by a space.
            // Examples:
            // 
            // a	    b	    result
            // 5	    2	    2 5
            // 3	    4	    3 4
            // 5.5	    4.5	    4.5 5.5

            Console.WriteLine("Please, enter two numbers !");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            if(a > b)
            {
                double storedValue = a;
                a = b;
                b = storedValue;
            }

            Console.WriteLine("=====================");
            Console.WriteLine("a = {0}\nb = {1}", a, b);
        }
    }
}
