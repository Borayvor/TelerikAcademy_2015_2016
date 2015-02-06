namespace E03_CompareCharArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CompareCharArrays
    {
        public static void Main(string[] args)
        {
            // Write a program that compares two char arrays 
            // lexicographically (letter by letter).
            //
            // first  : aAbcdefgh
            // second : aabcdefgh

            Console.Write("Please, enter the first array : ");            
            string arrayOne = Console.ReadLine().Trim();

            Console.Write("Please, enter the second array : ");            
            string arrayTwo = Console.ReadLine().Trim();
            
            Console.WriteLine();
            bool equal = false;

            if (arrayOne.Length == arrayTwo.Length)
            {
                equal = true;
            }

            if (equal)
            {
                for (int index = 0; index < arrayOne.Length; index++)
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
