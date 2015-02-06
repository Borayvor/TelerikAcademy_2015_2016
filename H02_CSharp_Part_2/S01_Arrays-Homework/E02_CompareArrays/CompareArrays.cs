namespace E02_CompareArrays
{
    using System;

    public class CompareArrays
    {
        public static void Main(string[] args)
        {
            // Write a program that reads two integer arrays from 
            // the console and compares them element by element.            

            Console.Write("Please, enter size for the first array : ");
            int firstLength = int.Parse(Console.ReadLine());
            string[] arrayOne = new string[firstLength];

            Console.Write("Please, enter size for the second array : ");
            int secondLength = int.Parse(Console.ReadLine());
            string[] arrayTwo = new string[secondLength];

            for (int index = 0; index < firstLength; index++)
            {
                Console.Write("Please enter a value for arrayOne[{0}]: ", index);
                arrayOne[index] = Console.ReadLine();
            }

            Console.WriteLine();

            for (int index = 0; index < secondLength; index++)
            {
                Console.Write("Please enter a value for arrayTwo[{0}]: ", index);
                arrayTwo[index] = Console.ReadLine();
            }

            Console.WriteLine();
            bool equal = false;            

            if (firstLength == secondLength)
            {
                equal = true;
            }

            if (equal)
            {
                for (int index = 0; index < firstLength; index++)
                {
                    int rezult = arrayOne[index].CompareTo(arrayTwo[index]);

                    if (rezult != 0)
                    {
                        equal = false;
                        break;
                    }  
                }
            }

            if (equal)
            {
                Console.WriteLine("Arrays are equal !");                
            }
            else
            {
                Console.WriteLine("Arrays are not equal !");
            }
        }
    }
}
