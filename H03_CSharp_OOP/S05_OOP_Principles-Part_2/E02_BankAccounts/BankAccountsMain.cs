namespace E02_BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    public class BankAccountsMain
    {
        public static void Main(string[] args)
        {
            // A bank holds different types of accounts for its customers: 
            // deposit accounts, loan accounts and mortgage accounts. 
            // Customers could be individuals or companies.
            // All accounts have customer, balance and interest rate (monthly based).
            // Deposit accounts are allowed to deposit and withdraw money.
            // Loan and mortgage accounts can only deposit money.
            // All accounts can calculate their interest amount for a given 
            // period (in months). In the common case its is calculated as 
            // follows: number_of_months * interest_rate.
            // Loan accounts have no interest for the first 3 months if are held 
            // by individuals and for the first 2 months if are held by a company.
            // Deposit accounts have no interest if their balance is positive 
            // and less than 1000.
            // Mortgage accounts have ½ interest for the first 12 months for 
            // companies and no interest for the first 6 months for individuals.
            // Your task is to write a program to model the bank system 
            // by classes and interfaces.
            // You should identify the classes, interfaces, base classes and 
            // abstract actions and implement the calculation of the interest 
            // functionality through overridden methods.

            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            var Dimitar = new IndividualCustomer(34334752, "Dimitar", "Petrov");
            var Pipi = new IndividualCustomer(97203, "Pipi", "Topcheva");
            var Gogo = new IndividualCustomer(34334752, "Gogo", "Petrov");
            var Gana = new IndividualCustomer(97203, "Gana", "Pamukova");
            var CorporateTroshikamak = new CorporateCustomer(891230, "Troshikamak Corporation");

            var depositIC_Dimitar = new Deposit(Dimitar, 2500M, 1.0825M, 12);
            var depositIC_Gogo = new Deposit(Gogo, 500M, 1.0825M, 12);

            var loanIC_Gogo = new Loan(Gogo, 500M, 1.0825M, 2);
            var loanCC_CorporateTroshikamak = 
                new Loan(CorporateTroshikamak, 1000000000M, 1.0931M, 36);

            var mortgageCC_CorporateTroshikamak = 
                new Mortgage(CorporateTroshikamak, 1000000000M, 1.0931M, 6);
            var mortgageIC_Gana = new Mortgage(Gana, 100000M, 1.0875M, 7);
            var mortgageIC_Pipi = new Mortgage(Pipi, 100000M, 1.0875M, 3);

            List<Deposit> D_L = new List<Deposit>();
            D_L.Add(depositIC_Dimitar);
            D_L.Add(depositIC_Gogo);

            List<Loan> L_L = new List<Loan>();
            L_L.Add(loanIC_Gogo);
            L_L.Add(loanCC_CorporateTroshikamak);

            List<Mortgage> M_L = new List<Mortgage>();
            M_L.Add(mortgageIC_Gana);
            M_L.Add(mortgageIC_Pipi);
            M_L.Add(mortgageCC_CorporateTroshikamak);

            Bank bank = new Bank();
            bank.DepositAccountsList = D_L;
            bank.LoanAccountsList = L_L;
            bank.MortgageAccountsList = M_L;

            foreach (var item in bank.DepositAccountsList)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            foreach (var item in bank.LoanAccountsList)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            foreach (var item in bank.MortgageAccountsList)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
    }
}
