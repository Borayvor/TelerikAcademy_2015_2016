namespace SchoolSystem.Framework.Core.Providers
{
    using System;
    using Contracts.Providers;

    public class ConsoleWriterProvider : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
