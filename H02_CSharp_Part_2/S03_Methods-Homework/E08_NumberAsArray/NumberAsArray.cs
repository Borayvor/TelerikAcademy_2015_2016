namespace E08_NumberAsArray
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    public class NumberAsArray
    {
        static Random randomGenerator = new Random();

        public static void Main(string[] args)
        {
            // Write a method that adds two positive integer 
            // numbers represented as arrays of digits 
            // (each array element arr[i] contains a digit; 
            // the last digit is kept in arr[0]).
            // Each of the numbers that will be added could 
            // have up to 10 000 digits.                       

            BigInteger firstNumber = FillNumberWithDigits(randomGenerator);
            Console.WriteLine(firstNumber.ToString());
            Console.WriteLine();

            BigInteger secondNumber = FillNumberWithDigits(randomGenerator);
            Console.WriteLine(secondNumber.ToString());
            Console.WriteLine();

            List<int> result = AddNumber(firstNumber, secondNumber);

            Console.WriteLine();
            Console.Write("     Result = ");
            for (int index = result.Count - 1; index >= 0; index--)
            {
                Console.Write(result[index]);
            }

            Console.WriteLine("\n");
        }


        private static List<int> AddNumber(BigInteger numberOne, BigInteger numberTwo)
        {
            List<int> arrayOne = GetDigits(numberOne);
            List<int> arrayTwo = GetDigits(numberTwo);
            List<int> arrayResult = new List<int>(Math.Max(arrayOne.Count, arrayTwo.Count));

            int remainingDigits = 0;

            for (int index = 0; index < arrayResult.Capacity; index++)
            {
                int sum = ((index < arrayOne.Count ? arrayOne[index] : 0) +
                                        (index < arrayTwo.Count ? arrayTwo[index] : 0) +
                                        remainingDigits);

                remainingDigits = (sum / 10);

                arrayResult.Add((sum % 10));
            }

            if (remainingDigits == 1)
            {
                arrayResult.Add(1);
            }

            return arrayResult;
        }

        private static List<int> GetDigits(BigInteger number)
        {
            List<int> result = new List<int>();

            while (number != 0)
            {
                result.Add((int)(number % 10));

                number /= 10;
            }

            return result;
        }

        private static int GetNumber(string name)
        {
            int number = 0;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = int.TryParse(Console.ReadLine(), out number);
            }
            while (isNumber == false);

            return number;
        }

        private static BigInteger FillNumberWithDigits(Random randomGenerator)
        {
            int length = int.MinValue;
            do
            {
                length = GetNumber("length of the number (0 - 10000)");
            }
            while (length < 0 || length > 10000);

            StringBuilder numberAsString = new StringBuilder();

            if (length > 0)
            {
                numberAsString.Append(randomGenerator.Next(1, 10));
            }
            else
            {
                numberAsString.Append(0);
            }

            for (int index = 1; index < length; index++)
            {
                numberAsString.Append(randomGenerator.Next(10));
            }

            return BigInteger.Parse(numberAsString.ToString());
        }
    }
}
