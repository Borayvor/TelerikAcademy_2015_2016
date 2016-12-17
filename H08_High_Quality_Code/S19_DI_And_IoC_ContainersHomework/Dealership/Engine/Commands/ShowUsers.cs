namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Common.Enums;
    using Contracts;
    using Contracts.Factories;

    public class ShowUsers : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.ShowUsersCommandName.ToLower();

            return result;
        }

        protected override string StartExecute(
            IList<string> commandAsList,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            const string StartLineText = "--USERS--";

            if (loggedUser[0].Role != Role.Admin)
            {
                return Constants.YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine(StartLineText);

            var counter = 1;

            foreach (var user in users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
