namespace Dealership.Providers
{
    using System;
    using Contracts.Providers;

    public class ConsoleReaderProvider : IReaderProvider
    {
        public string ReadLine()
        {

            return Console.ReadLine();
        }
    }
}
