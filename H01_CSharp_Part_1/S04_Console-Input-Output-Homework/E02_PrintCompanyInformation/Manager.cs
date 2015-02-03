namespace E02_PrintCompanyInformation
{
    using System;

    public class Manager
    {
        private string firstName;
        private string lastName;
        private byte age;
        private string phoneNumber;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.lastName = value;
            }
        }

        public byte Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                this.age = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            private set
            {
                this.phoneNumber = value;
            }
        }

        public void SetInfo()
        {
            Console.Write("Manager first name: ");
            this.FirstName = Console.ReadLine().Trim();

            Console.Write("Manager last name: ");
            this.LastName = Console.ReadLine().Trim();

            Console.Write("Manager age: ");
            this.Age = byte.Parse(Console.ReadLine().Trim());

            Console.Write("Manager phone: ");
            this.PhoneNumber = Console.ReadLine().Trim();
        }
                
        public void GetInfo()
        {
            string info = string.Format("Manager: {0} {1} (age: {2} tel. {3})",
                this.FirstName, this.LastName, this.Age, this.PhoneNumber);

            Console.WriteLine(info);
        }
    }
}
