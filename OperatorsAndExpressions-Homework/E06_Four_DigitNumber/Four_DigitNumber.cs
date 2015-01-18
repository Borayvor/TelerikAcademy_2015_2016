namespace E06_Four_DigitNumber
{
    using System;
    using System.Linq;

    public class Four_DigitNumber
    {
        public static void Main(string[] args)
        {
            // Write a program that takes as input a four-digit number in format 
            // abcd (e.g. 2011) and performs the following:
            // Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4).
            // Prints on the console the number in reversed order: dcba (in our example 1102).
            // Puts the last digit in the first position: dabc (in our example 1201).
            // Exchanges the second and the third digits: acbd (in our example 2101).
            // The number has always exactly 4 digits and cannot start with 0.
            // 
            // Examples:
            // 
            // n	  sum of digits	 reversed	last digit in front	  second and third digits exchanged
            // 2011	  4	             1102	    1201	              2101
            // 3333	  12	         3333	    3333	              3333
            // 9876	  30	         6789	    6987	              9786
              
            string number = GetNumber();

            Console.WriteLine();
            Console.WriteLine("Sum of digits : {0}", SumDigits(number));
            Console.WriteLine("Reversed digits : {0}", ReverseDigits(number));
            Console.WriteLine("Last digit in front : {0}", LastDigitFirst(number));
            Console.WriteLine("Second and third digits exchanged : {0}", SwapSecondAndThird(number));
            Console.WriteLine();
        }

        private static string GetNumber() 
        {                      
            int number = 0;
            bool isNumber = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Please, enter a four-digit number in format \"abcd\" !");
                Console.WriteLine("The number must be exactly 4 digits and cannot start with 0.");
                Console.Write("Please, enter a number: ");

                isNumber = int.TryParse(Console.ReadLine(), out number);
            } 
            while (isNumber == false || number < 1000 || number > 9999);

            return number.ToString();
        }

        private static int SumDigits(string number)
        {
            int sum = 0;

            foreach (var digit in number)
            {
                sum += int.Parse(digit.ToString());
            }

            return sum;
        }

        private static string ReverseDigits(string number)
        {
            string reversedDigits = string.Join("", number.Reverse());

            return reversedDigits;
        }

        private static string LastDigitFirst(string number)
        {
            string lastDigitFirst = "" + number[number.Length - 1];

            for (int i = 0; i < number.Length - 1; i++)
            {
                lastDigitFirst += number[i];
            }

            return lastDigitFirst;
        }

        private static string SwapSecondAndThird(string number)
        {
            return number[0].ToString() + number[2] + number[1] + number[3];
        }
    }
}
