namespace Dealership.Engine.Commands
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Common.Enums;
    using Contracts;
    using Contracts.Factories;

    public class AddVehicle : Command
    {
        protected override bool CanExecute(string commandName)
        {
            var result = !string.IsNullOrWhiteSpace(commandName) &&
                commandName.ToLower() == Constants.AddVehicleCommandName.ToLower();

            return result;
        }

        protected override string StartExecute(
            IList<string> commandAsList,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser)
        {
            var typeAsString = commandAsList[1];
            var make = commandAsList[2];
            var model = commandAsList[3];
            var price = decimal.Parse(commandAsList[4]);
            var additionalInfo = commandAsList[5];

            var type = (VehicleType)Enum.Parse(typeof(VehicleType), typeAsString, true);

            IVehicle vehicle = vehicleFactory.CreateVehicle(type, make, model, price, additionalInfo);

            loggedUser[0].AddVehicle(vehicle);

            return string.Format(Constants.VehicleAddedSuccessfully, loggedUser[0].Username);
        }
    }
}
