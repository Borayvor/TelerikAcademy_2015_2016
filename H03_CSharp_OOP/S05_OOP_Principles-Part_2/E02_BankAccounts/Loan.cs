namespace E02_BankAccounts
{    
    using System;

    using E02_BankAccounts.AbstractClasses;
    using E02_BankAccounts.Interfaces;

    public class Loan : Account, IDepositable
    {
        public Loan(Customer owner, decimal balance, 
            decimal monthlyInterestRate, ushort numberOfMonths)
            : base(owner, balance, monthlyInterestRate, numberOfMonths)
        {
        }

        public override decimal CalculateInterestAmount()
        {
            if (this.Owner is IndividualCustomer)
            {
                if (this.NumberOfMonths > 3)
                {
                    return base.CalculateInterestAmount() - 
                        (3 * this.MonthlyInterestRate * this.Balance);
                }

                return 0;
            }
            else if (this.Owner is CorporateCustomer)
            {
                if (this.NumberOfMonths > 2)
                {
                    return base.CalculateInterestAmount() - 
                        (2 * this.MonthlyInterestRate * this.Balance);
                }

                return 0;
            }
            else
            {
                throw new Exception("Invalid customer type!");
            }
        }
    }
}
