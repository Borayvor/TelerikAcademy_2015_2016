namespace E07__QuotesInStrings
{
    using System;

    public class QuotesInStrings
    {
        public static void Main(string[] args)
        {
            // Declare two string variables and assign them with following 
            // value: The "use" of quotations causes difficulties.
            // Do the above in two different ways - with and without using quoted strings.
            // Print the variables to ensure that their value was correctly defined.

            string firstValue = "The \"use\" of quotations causes difficulties.";            
            string secondValue = "The use of quotations causes difficulties.";

            Console.WriteLine(firstValue);
            Console.WriteLine(secondValue);
        }
    }
}
