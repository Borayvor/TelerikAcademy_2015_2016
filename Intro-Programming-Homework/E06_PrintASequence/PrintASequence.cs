namespace E06_PrintASequence
{
    using System;

    public class PrintASequence
    {
        public static void Main(string[] args)
        {
            // Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

            Console.WriteLine("The first 10 members of the sequence: ");

            for (int i = 2; i < 12; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write(i * (-1));
                }

                Console.Write(", ");
            }

            Console.WriteLine("...");
            Console.WriteLine();
        }
    }
}
