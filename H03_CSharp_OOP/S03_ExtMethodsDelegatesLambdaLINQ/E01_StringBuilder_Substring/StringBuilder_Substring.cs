namespace E01_StringBuilder_Substring
{
    using System;
    using System.Text;

    public class StringBuilder_Substring
    {
        public static void Main(string[] args)
        {
            // Implement an extension method Substring(int index, int length) 
            // for the class StringBuilder that returns new StringBuilder and 
            // has the same functionality as Substring in the class String.

            StringBuilder sbTest = new StringBuilder();

            sbTest.Append("Implement an extension method Substring(int index, int length)");

            StringBuilder newSbTest = sbTest.Substring(10, 12);

            Console.WriteLine("Original : {0}", sbTest.ToString());
            Console.WriteLine();
            Console.WriteLine("Substring(10, 12) : {0}", newSbTest.ToString());
            Console.WriteLine();

            string a = " asdf"; a.Substring(0);
        }
    }
}
