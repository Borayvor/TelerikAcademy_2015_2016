namespace E04_PrintFirstAndLastName
{
    using System;

    public class PrintFirstAndLastName
    {
        public static void Main(string[] args)
        {
            // Create console application that prints your first and last name, each at a separate line.

            Console.Write("Write your first name : ");
            var firstName = Console.ReadLine();
            Console.Write("Write your last name : ");
            var lastName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("My first name is : {0}\nMy last name is: {1}", firstName, lastName);
        }
    }
}
