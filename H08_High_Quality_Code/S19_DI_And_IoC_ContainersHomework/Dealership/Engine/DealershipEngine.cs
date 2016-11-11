namespace Dealership.Engine
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Contracts.Parsers;
    using Contracts.Providers;

    public sealed class DealershipEngine : IEngine
    {
        private static readonly IEngine SingleInstance = new DealershipEngine();

        private DealershipEngine()
        {
        }

        public static IEngine Instance
        {
            get
            {
                return SingleInstance;
            }
        }

        public void Start(
            IReaderProvider reader,
            IWriterProvider writer,
            ICommandParser commandParser,
            IReportProvider reportProvider)
        {
            var commands = this.ReadCommands(reader, commandParser);
            var commandResult = reportProvider.GetReports(commands);
            this.PrintReports(writer, commandResult);
        }

        public void Reset(IWriterProvider writer)
        {
            ////this.dealershipFactory = new DealershipFactory();
            ////this.users = new List<IUser>();
            ////this.loggedUser = null;
            ////var commands = new List<ICollection<string>>();
            ////var commandResult = new List<string>();
            ////this.PrintReports(writer, commandResult);
        }


        private IEnumerable<IEnumerable<string>> ReadCommands(IReaderProvider reader, ICommandParser commandParser)
        {
            var commands = new List<IEnumerable<string>>();

            var currentLine = reader.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                var parsedCommand = commandParser.Parse(currentLine);

                commands.Add(parsedCommand);

                currentLine = reader.ReadLine();
            }

            return commands;
        }

        private void PrintReports(IWriterProvider writer, IEnumerable<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            writer.WriteLine(output.ToString().Trim());
        }
    }
}
