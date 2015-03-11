namespace E01_MoblePhones
{
    using System;

    // 08. Calls:
    public class Call
    {
        private DateTime date;
        private string time;
        private string dialedPhoneNumber;
        private uint durationSeconds;

        public Call()
            : this(null, 0)
        {
        }

        public Call(string dialedPhoneNumber, uint durationSeconds)
        {
            this.date = DateTime.Now;
            string time = this.date.Hour + " : " + this.date.Minute + " : " + this.date.Second;
            this.time = time;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.durationSeconds = durationSeconds;
        }

        public uint DurationSeconds
        {
            get
            {
                return this.durationSeconds;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
        }

        // 04. ToString:
        public override string ToString()
        {
            return string.Format("\r\n\t# Call #\r\n\tDate: {0:dd.MM.yyyy}\r\n\tTime: {1}" +
                "\r\n\tDialed Number: {2}\r\n\tDuration: {3} sec\r\n", this.date,
                 this.time, this.dialedPhoneNumber, this.durationSeconds);
        }
    }
}
