namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;
    using Contracts.Factories;

    public class RemoveComment : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.RemoveCommentCommandName.ToLower();

            return result;
        }

        protected override string StartExecute(
            IList<string> commandAsList,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            var vehicleIndex = int.Parse(commandAsList[1]) - 1;
            var commentIndex = int.Parse(commandAsList[2]) - 1;
            var username = commandAsList[3];

            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, username);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, Constants.RemovedVehicleDoesNotExist);
            Validator.ValidateIntRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, Constants.RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            loggedUser[0].RemoveComment(comment, vehicle);

            return string.Format(Constants.CommentRemovedSuccessfully, loggedUser[0].Username);
        }
    }
}
