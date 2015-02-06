namespace E12_IndexOfLetters
{
    using System;

    public class IndexOfLetters
    {
        public static void Main(string[] args)
        {
            // Write a program that creates an array containing 
            // all letters from the alphabet (A-Z).
            // Read a word from the console and print the index 
            // of each of its letters in the array.

            char[] alphabet = new char[26];

            for (int symbol = 65, index = 0; index < alphabet.Length; symbol++, index++)
            {
                alphabet[index] = (char)symbol;
            }

            Console.Write("Please, enter a word : ");
            string word = Console.ReadLine().Trim().ToUpper();
            Console.WriteLine();

            for (int index = 0; index < word.Length; index++)
            {
                int symbolIndex = Array.BinarySearch(alphabet, word[index]);

                if (symbolIndex < 0)
                {
                    Console.WriteLine("Searched value is absent.");
                }
                else
                {
                    Console.WriteLine("{0} is on position: {1}", word[index], symbolIndex);
                }                
            }

            Console.WriteLine();
        }
    }
}
