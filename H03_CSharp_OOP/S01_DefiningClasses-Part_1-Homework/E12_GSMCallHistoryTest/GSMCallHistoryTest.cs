namespace E12_GSMCallHistoryTest
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using E01_MoblePhones;

    public class GSMCallHistoryTest
    {
        public static void Main(string[] args)
        {
            // 12. Call history test:
            // Write a class GSMCallHistoryTest to test the call history functionality 
            // of the GSM class.
            // - Create an instance of the GSM class.
            // - Add few calls.
            // - Display the information about the calls.
            // - Assuming that the price per minute is 0.37 calculate and print the total 
            // price of the calls in the history.
            // - Remove the longest call from the history and calculate the total price again.
            // - Finally clear the call history and print it.

            const decimal priceForMinute = 0.37M;

            GSM mobilePhone = new GSM("Lumia 720", "Nokia", null, "Pesho I. Petrov");

            Console.ForegroundColor = ConsoleColor.White;            
            mobilePhone.AddCall("0888 888 888", 37);
            mobilePhone.AddCall("0999 999 999", 79);
            mobilePhone.AddCall("0111 222 222", 189);
            mobilePhone.AddCall("0222 222 222", 163);
            mobilePhone.AddCall("0333 333 333", 245);

            foreach (var call in mobilePhone.CallHistory)
            {
                Console.WriteLine(call);
            }            

            Console.WriteLine("The total price is: {0}", 
                mobilePhone.TotalPriceOfTheCalls(priceForMinute));

            var longestCall = mobilePhone
                .CallHistory
                .OrderByDescending(x => x.DurationSeconds)
                .FirstOrDefault();

            mobilePhone.DeleteCall(longestCall);

            Console.WriteLine("The total price without longest call is: {0}",
                                    mobilePhone.TotalPriceOfTheCalls(priceForMinute));

            mobilePhone.ClearCallHistory();

            Console.WriteLine();
            Console.WriteLine("Prints all calls to show that history is empty.");

            foreach (var call in mobilePhone.CallHistory)
            {
                Console.WriteLine(call);
            }

            Console.WriteLine();
        }
    }
}
