namespace E02_BankAccounts
{
    using System;
    using System.Collections.Generic;

    public class Bank
    {        
        public List<Deposit> DepositAccountsList { get; set; }

        public List<Loan> LoanAccountsList { get; set; }

        public List<Mortgage> MortgageAccountsList { get; set; }
    }
}
