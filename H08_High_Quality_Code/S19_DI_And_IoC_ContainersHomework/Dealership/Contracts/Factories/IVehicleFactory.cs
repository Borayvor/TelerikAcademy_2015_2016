namespace Dealership.Contracts.Factories
{
    using Common.Enums;

    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(VehicleType type, string make, string model, decimal price, string additionalInfo);
    }
}
