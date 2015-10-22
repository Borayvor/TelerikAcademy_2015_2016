namespace E02_CreatingDAO
{
    using System;
    using System.Linq;
    using E01_NorthwindDbContext;

    public class NorthwindDao
    {
        public static void InsertNewCustomers(string customerId, string companyName,
            string contactName, string contactTitle, string address, string city,
            string postalCode, string country, string phone, string fax)
        {
            var newCustomer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            using (var db = new NorthwindEntities())
            {
                bool isInDb = IsInDataBase(db, customerId);

                if (!isInDb)
                {
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    Console.WriteLine("Added successful.");
                }
                else
                {
                    throw new ArgumentException("Such customer already exists !");
                }
            }
        }

        public static void ModifyCustomer(string customerId, string newContactName)
        {
            using (var db = new NorthwindEntities())
            {
                bool isInDb = IsInDataBase(db, customerId);

                if (!isInDb)
                {
                    throw new ArgumentException("No Such customer !");
                }

                var customer = db.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                customer.ContactName = newContactName;

                db.SaveChanges();
                Console.WriteLine("Customer is modified successful.");
            }
        }

        public static void DeleteCustomer(string customerId)
        {
            using (var db = new NorthwindEntities())
            {
                bool isInDb = IsInDataBase(db, customerId);

                if (!isInDb)
                {
                    throw new ArgumentException("No Such customer !");
                }

                var customer = db.Customers.FirstOrDefault(x => x.CustomerID == customerId);

                db.Customers.Remove(customer);
                db.SaveChanges();
                Console.WriteLine("Customer is deleted successful.");
            }
        }

        private static bool IsInDataBase(NorthwindEntities db, string id)
        {
            bool alreadyInDb = db.Customers.Any(a => a.CustomerID == id);

            return alreadyInDb;
        }
    }
}
