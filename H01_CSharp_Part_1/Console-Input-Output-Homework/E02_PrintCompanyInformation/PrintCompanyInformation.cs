namespace E02_PrintCompanyInformation
{
    using System;

    public class PrintCompanyInformation
    {
        public static void Main(string[] args)
        {
            // A company has name, address, phone number, fax number, 
            // web site and manager. The manager has first name, last name, 
            // age and a phone number.
            // Write a program that reads the information about a company 
            // and its manager and prints it back on the console.
            // Example input:
            // 
            // program	            user
            //
            // Company name:	    Telerik Academy
            // Company address:	    31 Al. Malinov, Sofia
            // Phone number:	    +359 888 55 55 555
            // Fax number:	        2
            // Web site:	        http://telerikacademy.com/
            // Manager first name:	Nikolay
            // Manager last name:	Kostov
            // Manager age:	        25
            // Manager phone:	    +359 2 981 981
            //
            // Example output:
            // 
            // Telerik Academy
            // Address: 231 Al. Malinov, Sofia
            // Tel. +359 888 55 55 555
            // Fax: (no fax)
            // Web site: http://telerikacademy.com/
            // Manager: Nikolay Kostov (age: 25, tel. +359 2 981 981) 

            Company company = new Company();

            Console.WriteLine();
            Console.WriteLine("With \"alt\" + left mouse button you can mark " + 
                "user info, copy and then paste.");
            Console.WriteLine();

            company.SetInfo();
            Console.WriteLine();
                        
            company.GetInfo();
            Console.WriteLine();
        }
    }
}
