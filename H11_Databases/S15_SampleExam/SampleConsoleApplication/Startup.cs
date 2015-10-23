namespace SampleConsoleApplication
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
