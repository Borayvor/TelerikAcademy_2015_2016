namespace Dealership.Engine.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Enums;
    using Contracts;
    using Contracts.Factories;

    public class RegisterUser : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.RegisterUserCommandName.ToLower();

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
            var firstName = commandAsList[2];
            var lastName = commandAsList[3];
            var password = commandAsList[4];

            var role = Role.Normal;

            if (commandAsList.Count > 5)
            {
                role = (Role)Enum.Parse(typeof(Role), commandAsList[5]);
            }

            if (loggedUser[0] != null)
            {
                return string.Format(Constants.UserLoggedInAlready, loggedUser[0].Username);
            }

            if (users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                return string.Format(Constants.UserAlreadyExist, username);
            }

            var user = dealershipFactory.CreateUser(username, firstName, lastName, password, role.ToString());
            loggedUser[0] = user;
            users.Add(user);

            return string.Format(Constants.UserRegisterеd, username);
        }
    }
}
