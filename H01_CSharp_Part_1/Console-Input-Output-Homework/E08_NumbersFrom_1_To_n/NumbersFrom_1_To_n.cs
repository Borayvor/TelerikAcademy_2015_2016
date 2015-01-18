namespace E08_NumbersFrom_1_To_n
{
    using System;

    public class NumbersFrom_1_To_n
    {
        public static void Main(string[] args)
        {
            // Write a program that reads an integer number n from 
            // the console and prints all the numbers in the 
            // interval [1..n], each on a single line.
            // Note: You may need to use a for-loop.
            // 
            // Examples:
            // 
            // input	output
            // 3	    1
            //          2
            //          3
            // 5	    1
            //          2
            //          3
            //          4
            //          5
            // 1	    1

            Console.WriteLine("Please, enter an integer number !");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
