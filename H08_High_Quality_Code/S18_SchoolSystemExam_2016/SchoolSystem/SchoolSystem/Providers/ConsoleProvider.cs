namespace SchoolSystem.Providers
{
    using System;
    using Contracts;

    public class ConsoleProvider : IInterfaceProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
