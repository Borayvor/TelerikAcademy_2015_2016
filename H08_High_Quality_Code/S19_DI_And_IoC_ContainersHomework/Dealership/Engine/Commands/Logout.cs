namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using Common;
    using Contracts;
    using Contracts.Factories;

    public class Logout : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.LogoutCommandName.ToLower();

            return result;
        }

        protected override string StartExecute(
            IList<string> commandAsList,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            loggedUser[0] = null;

            return Constants.UserLoggedOut;
        }
    }
}
