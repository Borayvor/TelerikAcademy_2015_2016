namespace E11_NumbersInIntervalDividableByGivenNumber
{
    using System;

    public class NumbersInIntervalDividableByGivenNumber
    {
        public static void Main(string[] args)
        {
            // Write a program that reads two positive integer numbers 
            // and prints how many numbers p exist between them such 
            // that the reminder of the division by 5 is 0.
            // Examples:
            // 
            // start	end	    p	    comments
            // 17	    25	    2	    20, 25
            // 5	    30	    6	    5, 10, 15, 20, 25, 30
            // 3	    33	    6	    5, 10, 15, 20, 25, 30
            // 3	    4	    0	    -
            // 99	    120	    5	    100, 105, 110, 115, 120
            // 107	    196	    18	    110, 115, 120, 125, 130, 135, 140, 145, 150, 155, 160, 165, 170, 175, 180, 185, 190, 195

            Console.WriteLine("Initialization of interval of numbers.");
            int startPoint = -1;
            int endPoint = -1;
            int count = 0;

            do
            {
                Console.Write("start = ");
                startPoint = int.Parse(Console.ReadLine());

                Console.Write("end = ");
                endPoint = int.Parse(Console.ReadLine());
            } 
            while (startPoint < 0 || endPoint < 0 || startPoint >= endPoint);

            for (int index = startPoint; index <= endPoint; index++)
            {
                if (index % 5 == 0)
                {
                    Console.Write("{0}, ", index);
                    count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("In the interval between {0} and {1} exist {2} numbers" +
                                " whos remainder of the division by 5 is 0.", 
                                startPoint, endPoint, count);
            Console.WriteLine();
        }
    }
}
