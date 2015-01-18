namespace E05_Is_7_ThirdDigit
{
    using System;

    public class Is_7_ThirdDigit
    {
        public static void Main(string[] args)
        {
            // Write an expression that checks for given integer if its third 
            // digit from right-to-left is 7.
            // Examples:
            // 
            // n	        Third digit 7?
            // 5	        false
            // 701	        true
            // 9703	        true
            // 877	        false
            // 777877	    false
            // 9999799	    true

            Console.WriteLine("Please enter a integer to check if its third digit (right-to-left) is 7 !");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int number = n / 100;

            int result = number % 10;

            if (result == 7)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
