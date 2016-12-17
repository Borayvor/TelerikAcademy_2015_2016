namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;
    using Contracts.Factories;

    public class Login : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.LoginCommandName.ToLower();

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
            var password = commandAsList[2];

            if (loggedUser[0] != null)
            {
                return string.Format(Constants.UserLoggedInAlready, loggedUser[0].Username);
            }

            var userFound = users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (userFound != null && userFound.Password == password)
            {
                loggedUser[0] = userFound;
                return string.Format(Constants.UserLoggedIn, username);
            }

            return Constants.WrongUsernameOrPassword;
        }
    }
}
