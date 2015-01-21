namespace E04_MultiplicationSign
{
    using System;

    public class MultiplicationSign
    {
        public static void Main(string[] args)
        {
            // Write a program that shows the sign (+, - or 0) of the 
            // product of three real numbers, without calculating it.
            // Use a sequence of if operators.
            // Examples:
            // 
            // a	    b	    c	    result
            // 5	    2	    2	    +
            // -2	    -2	    1	    +
            // -2	    4	    3	    -
            // 0	    -2.5	4	    0
            // -1	    -0.5	-5.1	-

            Console.Write("Please, enter first number : ");
            double firstNumber = double.Parse(Console.ReadLine());

            Console.Write("Please, enter second number : ");
            double secondNumber = double.Parse(Console.ReadLine());

            Console.Write("Please, enter thrid number : ");
            double thirdNumber = double.Parse(Console.ReadLine());

            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("The product is : \"{0}\"", 0);
            }
            else
            {
                bool positive = true;

                if (firstNumber < 0)
                {
                    positive = !positive;
                }
                if (secondNumber < 0)
                {
                    positive = !positive;
                }
                if (thirdNumber < 0)
                {
                    positive = !positive;
                }
                
                Console.WriteLine("The product is : \"{0}\"", positive ? "+" : "-");
            }

            Console.WriteLine();
        }
    }
}
