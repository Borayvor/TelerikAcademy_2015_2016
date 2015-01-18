namespace E10_FibonacciNumbers
{
    using System;

    public class FibonacciNumbers
    {
        public static void Main(string[] args)
        {
            // Write a program that reads a number n and prints 
            // on the console the first n members of the Fibonacci 
            // sequence (at a single line, separated by comma and 
            // space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
            // Note: You may need to learn how to use loops.
            // 
            // Examples:
            // 
            // n	comments
            // 1	0
            // 3	0 1 1
            // 10	0 1 1 2 3 5 8 13 21 34

            Console.WriteLine("Please, enter the count of members of the Fibonacci !");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            Fibonacci(n);            
        }


        public static void Fibonacci(int n)
        {
            ulong firstNumber = 0, secondNumber = 1;

            for (ulong index = 0; index < (ulong)n; index++)
            {
                Console.Write("{0}, ", firstNumber);

                ulong savePrevios = firstNumber;
                firstNumber = secondNumber;
                secondNumber = savePrevios + secondNumber;                
            }

            Console.WriteLine();
        }
    }
}
