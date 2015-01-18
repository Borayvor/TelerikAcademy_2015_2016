namespace E09_SumOf_n_Numbers
{
    using System;
    using System.Linq;

    public class SumOf_n_Numbers
    {
        public static void Main(string[] args)
        {
            // Write a program that enters a number n and after that 
            // enters more n numbers and calculates and prints 
            // their sum. Note: You may need to use a for-loop.
            // Examples:
            // 
            // numbers	    sum
            // 3	        90
            // 20	        
            // 60	        
            // 10	        
            // 5	        6.5
            // 2	        
            // -1	        
            // -0.5	        
            // 4	        
            // 2	        
            // 1	        1
            // 1	

            Console.Write("Please, enter the count of the numbers : n = ");
            int n = int.Parse(Console.ReadLine());

            double[] numbers = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("number{0} = ", i + 1);
                numbers[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("The sum of the numbers is : {0}", numbers.Sum());
        }
    }
}
