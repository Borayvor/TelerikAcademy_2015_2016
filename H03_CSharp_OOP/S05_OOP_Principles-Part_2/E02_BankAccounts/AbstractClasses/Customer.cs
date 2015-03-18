namespace E02_BankAccounts.AbstractClasses
{
    using System;

    public abstract class Customer
    {
        private ulong id;
        private string name;

        protected Customer(ulong id, string name)
        {
            this.Id = id;

            this.Name = name;
        }

        public ulong Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot " + 
                        "be null, empty or white-space !");
                }
                this.name = value;
            }
        }
    }
}
