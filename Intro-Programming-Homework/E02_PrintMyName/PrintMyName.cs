namespace E02_PrintMyName
{
    using System;

    public class PrintMyName
    {
        public static void Main(string[] args)
        {
            // Modify the previous application to print your name.
            // Ensure you have named the application well (e.g. “PrintMyName”).

            Console.Write("Write your name : ");
            var name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("My name is : {0}", name);
        }
    }
}
