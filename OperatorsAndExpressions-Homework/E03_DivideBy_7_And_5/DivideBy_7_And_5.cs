namespace E03_DivideBy_7_And_5
{
    using System;

    public class DivideBy_7_And_5
    {
        public static void Main(string[] args)
        {
            // Write a Boolean expression that checks for given integer if it 
            // can be divided (without remainder) by 7 and 5 at the same time.
            // Examples:
            // 
            // n	Divided by 7 and 5?
            // 3	false
            // 0	false
            // 5	false
            // 7	false
            // 35	true
            // 140	true

            Console.WriteLine("Please, enter a number !");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            if (n % 35 == 0 && n != 0)
            {
                Console.WriteLine("The number can be divided by 7 and 5 at the same time.");
            }
            else
            {
                Console.WriteLine("The number can not be divided by 7 and 5 at the same time.");
            }

            Console.WriteLine();
        }
    }
}
