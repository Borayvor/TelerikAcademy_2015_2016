namespace Dealership.Engine.Commands
{
    using System.Collections.Generic;
    using Common;
    using Contracts;
    using Contracts.Factories;

    public class RemoveVehicle : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.RemoveVehicleCommandName.ToLower();

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

            Validator.ValidateIntRange(vehicleIndex, 0, loggedUser[0].Vehicles.Count, Constants.RemovedVehicleDoesNotExist);

            var vehicle = loggedUser[0].Vehicles[vehicleIndex];

            loggedUser[0].RemoveVehicle(vehicle);

            return string.Format(Constants.VehicleRemovedSuccessfully, loggedUser[0].Username);
        }
    }
}
