namespace E02_FloatOrDouble
{
    using System;

    public class FloatOrDouble
    {
        public static void Main(string[] args)
        {
            // Which of the following values can be assigned to a variable of type float and 
            // which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
            // Write a program to assign the numbers in variables and print them to ensure no precision is lost.

            float a = 12.345f;
            float b = 3456.091f;
            double c = 34.567839023;
            double d = 8923.1234857;

            Console.WriteLine("float --> a = {0}", a);
            Console.WriteLine("float --> b = {0}", b);
            Console.WriteLine("double --> c = {0}", c);
            Console.WriteLine("double --> d = {0}", d);
        }
    }
}
