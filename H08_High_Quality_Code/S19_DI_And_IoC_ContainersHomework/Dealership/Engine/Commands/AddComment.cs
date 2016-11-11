namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;
    using Contracts.Factories;

    public class AddComment : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.AddCommentCommandName.ToLower();

            return result;
        }

        protected override string StartExecute(
            IList<string> commandAsList,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            var content = commandAsList[1];
            var author = commandAsList[2];

            var vehicleIndex = int.Parse(commandAsList[3]) - 1;

            var comment = dealershipFactory.CreateComment(content);
            comment.Author = loggedUser[0].Username;

            var user = users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(Constants.NoSuchUser, author);
            }

            Validator.ValidateIntRange(vehicleIndex, 0, user.Vehicles.Count, Constants.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            loggedUser[0].AddComment(comment, vehicle);

            return string.Format(Constants.CommentAddedSuccessfully, loggedUser[0].Username);
        }
    }
}
