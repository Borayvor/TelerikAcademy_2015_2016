namespace Dealership.Engine.Factories
{
    using Common.Enums;
    using Contracts;
    using Contracts.Factories;
    using Models;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(
            VehicleType type,
            string make,
            string model,
            decimal price,
            string additionalInfo)
        {
            if (type == VehicleType.Car)
            {
                return new Car(make, model, price, additionalInfo);
            }
            else if (type == VehicleType.Motorcycle)
            {
                return new Motorcycle(make, model, price, additionalInfo);
            }
            else if (type == VehicleType.Truck)
            {
                return new Truck(make, model, price, additionalInfo);
            }

            return null;
        }
    }
}
