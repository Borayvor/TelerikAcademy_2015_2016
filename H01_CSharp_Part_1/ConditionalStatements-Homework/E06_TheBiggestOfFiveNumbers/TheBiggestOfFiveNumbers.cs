namespace E06_TheBiggestOfFiveNumbers
{
    using System;

    public class TheBiggestOfFiveNumbers
    {
        public static void Main(string[] args)
        {
            // Write a program that finds the biggest of five numbers 
            // by using only five if statements.
            // Examples:
            // 
            // a	 b	     c	    d	   e	    biggest
            // 5	 2	     2	    4	   1	    5
            // -2	 -22	 1	    0	   0	    1
            // -2	 4	     3	    2	   0	    4
            // 0	 -2.5	 0	    5	   5	    5
            // -3	 -0.5	 -1.1	-2	   -0.1	    -0.1

            double firstVariable = GetNumber("First variable");
            double secondVariable = GetNumber("Second variable");
            double thirdVariable = GetNumber("Third variable");
            double fourthVariable = GetNumber("Fourth variable");
            double fifthVariable = GetNumber("Fifth variable");

            double biggest = 0;
            biggest = GetBiggest(biggest, firstVariable);
            biggest = GetBiggest(biggest, secondVariable);
            biggest = GetBiggest(biggest, thirdVariable);
            biggest = GetBiggest(biggest, fourthVariable);
            biggest = GetBiggest(biggest, fifthVariable);

            Console.WriteLine();
            Console.WriteLine("The greatest of given 5 variables is : {0}", biggest);
            Console.WriteLine();
        }

        static double GetBiggest(double first, double second) 
        {
            return Math.Max(first, second);
        }


        static double GetNumber(string variableName) 
        {
            double number;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0} = ", variableName);
                isNumber = double.TryParse(Console.ReadLine(), out number);
            } 
            while (isNumber == false);

            return number;
        }
    }
}
