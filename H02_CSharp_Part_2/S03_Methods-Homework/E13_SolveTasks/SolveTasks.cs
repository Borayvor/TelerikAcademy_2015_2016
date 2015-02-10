namespace E13_SolveTasks
{
    using System;
    using System.Linq;

    public class SolveTasks
    {
        public static void Main(string[] args)
        {
            // Write a program that can solve these tasks:
            // Reverses the digits of a number
            // Calculates the average of a sequence of integers
            // Solves a linear equation a * x + b = 0
            // Create appropriate methods.
            // Provide a simple text-based menu for the user to choose which task to solve.
            // Validate the input data:
            // The decimal number should be non-negative
            // The sequence should not be empty
            // 'a' should not be equal to 0

            Menu();
        }


        static void Menu()
        {
            Console.WriteLine("Please select the task you want to solve !");
            Console.WriteLine(" 1 : Reverses the digits of a number.");
            Console.WriteLine(" 2 : Calculates the average of a sequence of integers.");
            Console.WriteLine(" 3 : Solves a linear equation \"a * x + b = 0\".");
            Console.WriteLine(" 4 : Exit.");
            Console.WriteLine();

            int choice = int.MinValue;
            do
            {
                choice = GetNumber("your choice");
            } 
            while (choice < 1 || choice > 4);

            switch (choice)
            {
                case (1):
                    {
                        Reverse();
                        break;
                    }
                case (2):
                    {
                        Average();
                        break;
                    }
                case (3):
                    {
                        Equation();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            Console.WriteLine();

            Console.WriteLine("Thank you for using our application!");
        }


        static void Reverse()
        {
            int n = GetNumber("a number");

            if (n >= 0)
            {
                Console.WriteLine("The reversed number is: " + ReverseNumber(n));
            }
            else
            {
                Console.WriteLine("Number should be non-negative.");
            }
        }
        
        private static void Average()
        {
            int[] array = new int[GetNumber("array size")];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GetNumber("a number " + (i + 1) + " ");
            }

            PrintArray(array);            

            if (array.Length > 0)
            {
                Console.WriteLine("The average of the sequence of " + 
                    "integers is : {0}", GetAverageNumber(array));
            }
            else
            {
                Console.WriteLine("Array should have elements.");
            }
        }

        private static void Equation()
        {
            Console.WriteLine("Please, enter \"a\" and \"b\" to solve " + 
                "the linear equation \"a * x + b = 0\".");

            int a = GetNumber("\"a\"");
            int b = GetNumber("\"b\"");

            if (a != 0)
            {
                Console.WriteLine("The result is : x = {0}", EquationResult(a, b));
            }
            else
            {
                Console.WriteLine("Coefficient \"a\" should not be zero.");
            }
        }

        private static double EquationResult(int a, int b)
        {
            return ((double)-b / (double)a);
        }

        private static double GetAverageNumber(int[] array)
        {                        
            return array.Average();
        }
        
        private static long ReverseNumber(int number)
        {
            long result = 0;

            while (number != 0)
            {
                result = result * 10 + (long)number % 10; 

                number /= 10;
            }

            return result;
        }
        
        private static int GetNumber(string name)
        {                                  
            int number = int.MinValue;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = int.TryParse(Console.ReadLine(), out number);
            } 
            while (isNumber == false);

            return number;
        }

        private static void PrintArray(int[] array)
        {
            string result = string.Join(", ", array);

            Console.WriteLine("{ " + result + " }");
        }
    }
}
