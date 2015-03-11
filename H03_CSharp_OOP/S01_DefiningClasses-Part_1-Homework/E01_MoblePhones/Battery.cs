namespace E01_MoblePhones
{
    using System;

    // 01. Define class:
    public class Battery
    {
        private decimal? hoursIdle;
        private decimal? hoursTalk;
        private BatteryType batteryType;        

        // 02. Constructors:
        internal Battery()
            :this(null)
        {
        }

        public Battery(decimal? hoursIdle)
            : this(hoursIdle, null)
        {
        }

        public Battery(decimal? hoursIdle, decimal? hoursTalk)
            : this(hoursIdle, hoursTalk, BatteryType.None)
        {
        }

        public Battery(decimal? hoursIdle, decimal? hoursTalk, BatteryType batteryType)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }


        // 05. Properties:
        public decimal? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {   
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Battery idle time must be a positive number !");
                }

                this.hoursIdle = value;
            }
        }

        public decimal? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentException("Battery talk time must be a positive number !");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                this.batteryType = value;
            }
        }

        // 04. ToString:
        public override string ToString()
        {
            return string.Format("\r\n\tHours Idle: {0}\r\n\tHours Talk: {1}" +
                "\r\n\tBattery Type: {2}", 
                this.HoursIdle, this.HoursTalk, this.BatteryType);
        }
    }
}
