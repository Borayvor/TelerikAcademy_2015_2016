namespace E02_BankAccounts
{
    using E02_BankAccounts.AbstractClasses;
    using E02_BankAccounts.Interfaces;

    public class Deposit : Account, IDepositable, IWithdrawable
    {
        public Deposit(Customer owner, decimal balance, 
            decimal monthlyInterestRate, ushort numberOfMonths)
            : base(owner, balance, monthlyInterestRate, numberOfMonths)
        {
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterestAmount()
        {
            if (this.Balance >= 0 && this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterestAmount();
        }
    }
}
