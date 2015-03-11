namespace E01_MoblePhones
{
    using System;
    using System.Collections.Generic;

    // 01. Define class:
    public class GSM
    {
        // 06. Static field:
        public static readonly GSM IPhone4S = new GSM("Iphone", "Apple", 1099);

        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;

        // 09. Call history:
        private ICollection<Call> callHistory;

        // 02. Constructors:
        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null)
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(model, manufacturer, price, owner, new Battery())
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery)
            : this(model, manufacturer, price, owner, battery, new Display())
        {
        }

        public GSM(string model, string manufacturer, decimal? price, string owner,
            Battery batteryInitial, Display displayInitial)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = batteryInitial;
            this.Display = displayInitial;
            this.CallHistory = new List<Call>();
        }

        // 05. Properties:
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                this.manufacturer = value;
            }
        }

        public decimal? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("The price can't be negative !");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {                                
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        // 10. Add/Delete calls:
        public ICollection<Call> CallHistory
        {
            get 
            {
                return new List<Call>(this.callHistory); 
            }

            private set
            {
                this.callHistory = value;
            }
        }

        public void AddCall(string dialedNumber, uint duration)
        {
            this.callHistory.Add(new Call(dialedNumber, duration));
        }

        public void DeleteCall(Call callToRemove)
        {
            if (!this.callHistory.Contains(callToRemove))
            {
                throw new ArgumentException("Invalid call input !");
            }

            this.callHistory.Remove(callToRemove);            
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        // 11. Call price:
        public decimal TotalPriceOfTheCalls(decimal pricePerMinute)
        {
            const uint Minute = 60;

            uint minutes = 0;
            uint reminder = 0;

            foreach (var call in this.CallHistory)
            {
                minutes += call.DurationSeconds / Minute;
                reminder = call.DurationSeconds % Minute;

                if (reminder != 0)
                {
                    minutes++;
                }
            }

            return minutes * pricePerMinute;
        }

        // 04. ToString:
        public override string ToString()
        {
            return string.Format("# GSM #\r\nModel: {0}\r\nManufacturer: {1}\r\nPrice: {2} $\r\n" +
                "Owner: {3}\r\nBattery: {4}\r\nDisplay: {5}", this.Model, this.Manufacturer,
                this.Price, this.Owner, this.Battery, this.Display);
        }
    }
}
