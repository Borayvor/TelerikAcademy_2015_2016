namespace E10_OddAndEvenProduct
{
    using System;
    using System.Linq;

    public class OddAndEvenProduct
    {
        public static void Main(string[] args)
        {
            // You are given n integers (given in a single line, 
            // separated by a space).
            // Write a program that checks whether the product of the odd 
            // elements is equal to the product of the even elements.
            // Elements are counted from 1 to n, so the first element is 
            // odd, the second is even, etc.
            // Examples:
            // 
            // numbers	                result
            // 2 1 1 6 3	            yes
            // product = 6	
            // 3 10 4 6 5 1	            yes
            // product = 60	
            // 4 3 2 5 2	            no
            // odd_product = 16	
            // even_product = 15	

            Console.WriteLine("Please, enter a few integer numbers !");
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(number => int.Parse(number))
                .ToArray();

            int odd_product = 1;
            int even_product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(i % 2 == 0)
                {
                    odd_product *= numbers[i];
                }
                else
                {
                    even_product *= numbers[i];
                }
            }

            Console.WriteLine("Result = {0}", 
                odd_product == even_product ? "yes" : "no");
        }
    }
}
