namespace Dealership
{
    using System.Collections.Generic;
    using Contracts;
    using Contracts.Factories;
    using Contracts.Parsers;
    using Contracts.Providers;
    using Engine;
    using Engine.Factories;
    using Engine.Parsers;
    using Providers;

    public class Startup
    {
        public static void Main()
        {
            IReaderProvider reader = new ConsoleReaderProvider();
            IWriterProvider writer = new ConsoleWriterProvider();
            ICommandParser commandParser = new CommandParser();

            IDealershipFactory dealershipFactory = new DealershipFactory();
            ICollection<IUser> users = new List<IUser>();
            IUser[] loggedUser = new IUser[1];

            IVehicleFactory vehicleFactory = new VehicleFactory();
            ICommandFactory commandFactory = new CommandFactory();
            IReportProvider reportProvider = new ReportProvider(
                commandFactory,
                vehicleFactory,
                dealershipFactory,
                users,
                loggedUser);

            DealershipEngine.Instance.Start(reader, writer, commandParser, reportProvider);
        }
    }
}
