namespace Dealership.Contracts.Commands
{
    using System.Collections.Generic;
    using Factories;

    public interface ICommand
    {
        string Execute(
            IEnumerable<string> commandAsCollection,
            IVehicleFactory vehicleFactory,
            IDealershipFactory dealershipFactory,
            ICollection<IUser> users,
            IUser[] loggedUser);
    }
}
