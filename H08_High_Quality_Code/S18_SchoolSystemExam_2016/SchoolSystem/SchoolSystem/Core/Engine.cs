namespace SchoolSystem.Core
{
    using System;
    using Common;
    using Contracts;

    public class Engine
    {
        private const string TerminationCommand = "End";

        private IInterfaceProvider interfaceProvider;
        private IParser parser;
        private IDataBase db;

        public Engine(IInterfaceProvider interfaceProvider, IParser parser, IDataBase db)
        {
            if (interfaceProvider == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NullProviders);
            }

            if (parser == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NullParsers);
            }

            this.interfaceProvider = interfaceProvider;
            this.parser = parser;
            this.db = db;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.interfaceProvider.ReadLine();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.interfaceProvider.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException(ExceptionMessages.NullOrEmptyCommand);
            }

            var command = this.parser.ParseCommand(commandAsString, this.db);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.interfaceProvider.WriteLine(executionResult);
        }
    }
}
