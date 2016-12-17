namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;
    using Contracts.Factories;

    public class ShowVehicles : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.ShowVehiclesCommandName.ToLower();

            return result;
        }

        protected override string StartExecute(
            IList<string> commandAsList,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            var username = commandAsList[1];

            var user = users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
