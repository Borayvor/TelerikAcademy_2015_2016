namespace E02_BankAccounts
{    
    using System;

    using E02_BankAccounts.AbstractClasses;
    using E02_BankAccounts.Interfaces;

    public class Mortgage : Account, IDepositable
    {
        public Mortgage(Customer owner, decimal balance, 
            decimal monthlyInterestRate, ushort numberOfMonths)
            : base(owner, balance, monthlyInterestRate, numberOfMonths)
        {
        }

        public override decimal CalculateInterestAmount()
        {
            if (this.Owner is IndividualCustomer)
            {
                if (this.NumberOfMonths > 6)
                {
                    return base.CalculateInterestAmount() - 
                        (6 * this.MonthlyInterestRate * this.Balance);
                }

                return 0;
            }
            else if (this.Owner is CorporateCustomer)
            {
                if (this.NumberOfMonths > 12)
                {
                    return base.CalculateInterestAmount() - 
                        ((12 * this.MonthlyInterestRate * this.Balance) / 2);
                }

                return (this.NumberOfMonths * this.MonthlyInterestRate * this.Balance) / 2;
            }
            else
            {
                throw new Exception("Invalid customer type!");
            }
        }
    }
}
