namespace E11_BankAccountData
{
    using System;

    public class BankAccountData
    {
        public static void Main(string[] args)
        {
            // A bank account has a holder name (first name, middle name and last name), 
            // available amount of money (balance), bank name, IBAN, 3 credit card 
            // numbers associated with the account.
            // Declare the variables needed to keep the information for a single bank 
            // account using the appropriate data types and descriptive names.

            String firstName;
            String middleName;
            String familyName;
            decimal balance;
            String bankName;
            String iban;            
            ulong creditCardOneNumber;
            ulong creditCardTwoNumber;
            ulong creditCardThreeNumber;

            firstName = "Dimitar";
            middleName = "Ivanov";
            familyName = "Petrov";
            balance = 1844674407370955161;
            bankName = "\"Swiss National Bank\"";
            iban = "CH93 0076 2011 6238 5295 7";            
            creditCardOneNumber = 4000080706200002;
            creditCardTwoNumber = 5588320123456789;
            creditCardThreeNumber = 2937816296739723;

            Console.Write("Full name: {0} {1} {2}\n", firstName, middleName, familyName);
            Console.WriteLine("Balance: {0} $", balance);
            Console.WriteLine("Bank name: {0}", bankName);
            Console.WriteLine("IBAN: {0}", iban);            
            Console.WriteLine("First credit card: {0}", creditCardOneNumber);
            Console.WriteLine("Second credit card: {0}", creditCardTwoNumber);
            Console.WriteLine("Third credit card: {0}", creditCardThreeNumber);
        }
    }
}
