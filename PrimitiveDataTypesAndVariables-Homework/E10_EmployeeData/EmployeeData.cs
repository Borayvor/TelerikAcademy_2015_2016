namespace E10_EmployeeData
{
    using System;

    public class EmployeeData
    {
        public static void Main(string[] args)
        {
            // A marketing company wants to keep record of its employees. 
            // Each record would have the following characteristics:
            // First name
            // Last name
            // Age (0...100)
            // Gender (m or f)
            // Personal ID number (e.g. 8306112507)
            // Unique employee number (27560000…27569999)
            // Declare the variables needed to keep the information for a single 
            // employee using appropriate primitive data types. Use descriptive names. 
            // Print the data at the console.

            String firstName;
            String familyName;
            byte age;
            char gender;
            ulong IDnumber;
            uint uniqueEmplNumber;

            firstName = "Gosho";
            familyName = "Goshev";
            age = 14;
            gender = 'm';
            IDnumber = 6523054544;
            uniqueEmplNumber = 27560328;

            Console.WriteLine("First name: {0}\nFamily name: {1}", firstName, familyName);
            Console.WriteLine("Age: {0}\nGender: {1}", age, gender);
            Console.WriteLine("IDnumber: {0}\nUnique employee number: {1}", IDnumber, uniqueEmplNumber);
        }
    }
}
