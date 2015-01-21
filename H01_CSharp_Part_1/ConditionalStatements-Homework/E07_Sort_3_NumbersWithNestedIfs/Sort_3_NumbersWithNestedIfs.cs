namespace E07_Sort_3_NumbersWithNestedIfs
{
    using System;
    using System.Linq;
    
    public class Sort_3_NumbersWithNestedIfs
    {
        public static void Main(string[] args)
        {
            // Write a program that enters 3 real numbers and prints 
            // them sorted in descending order.
            // Use nested if statements.
            // Note: Don’t use arrays and the built-in sorting functionality.
            // 
            // Examples:
            // 
            // a	    b	    c	    result
            // 5	    1	    2	    5 2 1
            // -2	    -2	    1	    1 -2 -2
            // -2	    4	    3	    4 3 -2
            // 0	    -2.5	5	    5 0 -2.5
            // -1.1	    -0.5	-0.1	-0.1 -0.5 -1.1
            // 10	    20	    30	    30 20 10
            // 1	    1	    1	    1 1 1

            // SortWithoutNestedIfs();

            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            if (a >= b)
            {
                if (b > +c)
                {
                    Console.WriteLine("{0}  {1}  {2}", a, b, c);
                }
                else if (c >= a)
                {
                    Console.WriteLine("{0}  {1}  {2}", c, a, b);
                }
                else
                {
                    Console.WriteLine("{0}  {1}  {2}", a, c, b);
                }
            }
            else if (b >= a)
            {
                if (a >= c)
                {
                    Console.WriteLine("{0}  {1}  {2}", b, a, c);
                }
                else if (c >= b)
                {
                    Console.WriteLine("{0}  {1}  {2}", c, b, a);
                }
                else
                {
                    Console.WriteLine("{0}  {1}  {2}", b, c, a);
                }
            }
        }

        private static void SortWithoutNestedIfs()
        {
            double[] numbers = new double[3];

            Console.WriteLine("Please, enter 3 real numbers !");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0} = ", Convert.ToChar('a' + i));
                numbers[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            var sortedNumbers = numbers.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("{0} = {1}",
                    Convert.ToChar('a' + numbers.Length - i - 1), sortedNumbers[i]);
            }

            Console.WriteLine();
        }
    }
}
