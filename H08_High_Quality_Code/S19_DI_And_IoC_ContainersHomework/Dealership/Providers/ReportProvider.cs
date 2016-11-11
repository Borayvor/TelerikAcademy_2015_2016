namespace Dealership.Providers
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Contracts.Commands;
    using Contracts.Factories;
    using Contracts.Providers;

    public class ReportProvider : IReportProvider
    {
        private ICommand command;
        private IVehicleFactory vehicleFactory;
        private IDealershipFactory dealershipFactory;
        private ICollection<IUser> users;
        private IUser[] loggedUser;


        public ReportProvider(
            ICommandFactory commandFactory,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            this.command = commandFactory.CreateCommands();
            this.vehicleFactory = vehicleFactory;
            this.dealershipFactory = dealershipFactory;
            this.users = users;
            this.loggedUser = loggedUser;
        }

        public IEnumerable<string> GetReports(IEnumerable<IEnumerable<string>> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {

                    var report = this.command.Execute(
                        command,
                        this.vehicleFactory,
                        this.dealershipFactory,
                        this.users,
                        this.loggedUser);

                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }
    }
}
