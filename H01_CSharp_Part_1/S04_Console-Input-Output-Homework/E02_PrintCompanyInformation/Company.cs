namespace E02_PrintCompanyInformation
{
    using System;

    public class Company
    {
        private string name;
        private string address;
        private string phoneNumber;
        private string faxNumber;
        private string webSite;
        private Manager manager;

        public Company()
        {
            this.ManagerOfCompany = new Manager();
        }

        public string Name 
        { 
            get 
            {
                return this.name; 
            }

            private set 
            {
                this.name = value; 
            } 
        }

        public string Address 
        { 
            get 
            { 
                return this.address; 
            }

            private set 
            {
                this.address = value; 
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

        public string FaxNumber 
        { 
            get 
            { 
                return this.faxNumber; 
            } 
            
            private set 
            {
                this.faxNumber = value; 
            } 
        }

        public string WebSite 
        { 
            get 
            { 
                return this.webSite;
            }
            private set 
            {
                this.webSite = value; 
            } 
        }

        public Manager ManagerOfCompany 
        { 
            get 
            { 
                return this.manager; 
            }

            private set 
            {
                this.manager = value; 
            } 
        }

        public void SetInfo()
        {
            Console.Write("Company name: ");
            this.Name = Console.ReadLine().Trim();

            Console.Write("Address: ");
            this.Address = Console.ReadLine().Trim();

            Console.Write("Phone: ");
            this.PhoneNumber = Console.ReadLine().Trim();

            Console.Write("Fax: ");
            this.FaxNumber = Console.ReadLine().Trim();

            Console.Write("Web site: ");
            this.WebSite = Console.ReadLine().Trim();

            this.ManagerOfCompany.SetInfo();
        }

        public void GetInfo()
        {
            string info = string.Format("\n{0}\nAddress: {1}\nPhone: {2}" +
                   "\nFax number: {3}\nWeb site: {4}", this.Name, 
                   this.Address, this.PhoneNumber, 
                   string.IsNullOrWhiteSpace(this.FaxNumber) ? "(no fax)" : this.FaxNumber,
                   this.WebSite);

            Console.WriteLine(info); 
            this.ManagerOfCompany.GetInfo();
        }
    }
}
