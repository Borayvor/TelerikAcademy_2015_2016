namespace Dealership.Contracts
{
    using Parsers;
    using Providers;

    public interface IEngine
    {
        void Start(IReaderProvider reader, IWriterProvider writer, ICommandParser commandParser, IReportProvider reportProvider);

        void Reset(IWriterProvider writer);
    }
}
