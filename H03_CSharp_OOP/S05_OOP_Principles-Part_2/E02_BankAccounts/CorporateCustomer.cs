namespace E02_BankAccounts
{
    using E02_BankAccounts.AbstractClasses;

    public class CorporateCustomer : Customer
    {
        public CorporateCustomer(ulong id, string Name)
            : base(id, Name)
        {
        }
    }
}
