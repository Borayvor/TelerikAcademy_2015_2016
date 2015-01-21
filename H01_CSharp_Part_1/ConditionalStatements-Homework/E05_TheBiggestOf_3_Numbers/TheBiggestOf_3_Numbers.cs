namespace E05_TheBiggestOf_3_Numbers
{
    using System;

    public class TheBiggestOf_3_Numbers
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the biggest of three numbers.
            // Examples:
            // 
            // a	    b	    c	    biggest
            // 5	    2	    2	    5
            // -2	    -2	    1	    1
            // -2	    4	    3	    4
            // 0	    -2.5	5	    5
            // -0.1	    -0.5	-1.1	-0.1

            Console.Write("Please, enter sirst number : ");
            double firstNumber = double.Parse(Console.ReadLine());

            Console.Write("Please, enter second number : ");
            double secondNumber = double.Parse(Console.ReadLine());

            Console.Write("Please, enter thrid number : ");
            double thirdNumber = double.Parse(Console.ReadLine());

            if ((firstNumber == secondNumber) && (secondNumber == thirdNumber))
            {
                Console.WriteLine("All numbers are equal.");
            }
            else
            {
                double biggestNumber = 0;
                
                if ((firstNumber > secondNumber) && (firstNumber > thirdNumber))
                {
                    biggestNumber = firstNumber;
                }
                if ((secondNumber > firstNumber) && (secondNumber > thirdNumber))
                {
                    biggestNumber = secondNumber;
                }
                if ((thirdNumber > firstNumber) && (thirdNumber > secondNumber))
                {
                    biggestNumber = thirdNumber;
                }
                
                Console.WriteLine("The biggest of these three numbers is : {0}", biggestNumber);
            }
        }
    }
}
