namespace SchoolSystem.Framework.Core.Providers
{
    using System;
    using Contracts.Providers;

    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
