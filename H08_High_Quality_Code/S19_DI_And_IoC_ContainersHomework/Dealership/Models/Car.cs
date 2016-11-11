namespace Dealership.Models
{
    using Common;
    using Common.Enums;
    using Contracts;

    public class Car : Vehicle, ICar
    {
        private const string SeatsProperty = "Seats";

        private readonly int seats;

        public Car(string make, string model, decimal price, string seats)
            : base(make, model, price, VehicleType.Car)
        {
            this.seats = int.Parse(seats);

            this.ValidateFields();
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("  {0}: {1}", SeatsProperty, this.Seats);
        }

        private void ValidateFields()
        {
            Validator.ValidateIntRange(this.seats, Constants.MinSeats, Constants.MaxSeats, string.Format(Constants.NumberMustBeBetweenMinAndMax, SeatsProperty, Constants.MinSeats, Constants.MaxSeats));
        }
    }
}
