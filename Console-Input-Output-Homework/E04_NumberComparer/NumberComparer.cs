namespace E04_NumberComparer
{
    using System;

    public class NumberComparer
    {
        public static void Main(string[] args)
        {
            // Write a program that gets two numbers from the console 
            // and prints the greater of them.
            // Try to implement this without if statements.
            // Examples:
            // 
            // a	    b	    greater
            // 5	    6	    6
            // 10	    5	    10
            // 0	    0	    0
            // -5	    -2	    -2
            // 1.5	    1.6	    1.6
            
            Console.Write("Please, enter the first number : a = ");
            decimal a = decimal.Parse(Console.ReadLine());

            Console.Write("Please, enter the second number : b = ");
            decimal b = decimal.Parse(Console.ReadLine());

            Console.WriteLine("The greater number is : {0}", Math.Max(a, b));
        }
    }
}
