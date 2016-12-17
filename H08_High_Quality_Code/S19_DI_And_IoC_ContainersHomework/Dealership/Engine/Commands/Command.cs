namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;
    using Contracts.Commands;
    using Contracts.Factories;

    public abstract class Command : ICommand
    {
        private ICommand Successor { get; set; }

        public void SetSuccessor(Command successor)
        {
            this.Successor = successor;
        }

        public string Execute(
            IEnumerable<string> commandAsCollection,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            var commandAsList = commandAsCollection.ToList<string>();
            var commandName = commandAsList[0];

            if (!string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() != Constants.RegisterUserCommandName.ToLower() &&
                commandName.ToLower() != Constants.LoginCommandName.ToLower())
            {
                if (loggedUser[0] == null)
                {
                    return Constants.UserNotLogged;
                }
            }

            if (this.CanExecute(commandName))
            {
                return StartExecute(
                    commandAsList,
                    vehicleFactory,
                    dealershipFactory,
                    users,
                    loggedUser);
            }

            if (this.Successor != null)
            {
                return this.Successor.Execute(
                    commandAsList,
                    vehicleFactory,
                    dealershipFactory,
                    users,
                    loggedUser);
            }

            return string.Format(Constants.InvalidCommand, commandName);
        }

        protected abstract bool CanExecute(string commandName);

        protected abstract string StartExecute(
            IList<string> commandAsList,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser);
    }
}
