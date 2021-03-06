﻿namespace Dealership.Models
{
    using Common;
    using Common.Enums;
    using Contracts;

    public class Truck : Vehicle, ITruck
    {
        private const string WeightCapacityPropery = "Weight capacity";

        private readonly int weightCapacity;

        public Truck(string make, string model, decimal price, string weightCapacity)
            : base(make, model, price, VehicleType.Truck)
        {
            this.weightCapacity = int.Parse(weightCapacity);

            this.ValidateFields();
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("  Weight Capacity: {0}t", this.WeightCapacity);
        }

        private void ValidateFields()
        {
            Validator.ValidateIntRange(this.weightCapacity, Constants.MinCapacity, Constants.MaxCapacity, string.Format(Constants.NumberMustBeBetweenMinAndMax, WeightCapacityPropery, Constants.MinCapacity, Constants.MaxCapacity));
        }
    }
}
