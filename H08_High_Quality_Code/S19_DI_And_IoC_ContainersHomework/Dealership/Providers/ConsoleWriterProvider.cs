namespace Dealership.Providers
{
    using System;
    using Contracts.Providers;

    public class ConsoleWriterProvider : IWriterProvider
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
