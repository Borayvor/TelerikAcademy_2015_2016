namespace E07_OneSystemToAnyOther
{
    using System;

    public class OneSystemToAnyOther
    {
        public static void Main(string[] args)
        {
            // Write a program to convert from any numeral system 
            // of given base s to any other numeral system of 
            // base d (2 ≤ s, d ≤ 16).

            string number = "ABC";

            Console.WriteLine("Convert number:");

            Console.Write("Oct to Dec -> ");
            string resultOne = NumberConverter.Covert(number, 8, 10);
            Console.WriteLine(resultOne);

            Console.Write("Hex to Oct -> ");
            string resultTwo = NumberConverter.Covert(number, 16, 8);
            Console.WriteLine(resultTwo);

            Console.Write("Hex to Bin -> ");
            string resultThree = NumberConverter.Covert(number, 16, 2);
            Console.WriteLine(resultThree);

            Console.Write("Hex to Dec -> ");
            string resultFour = NumberConverter.Covert(number, 16, 10);
            Console.WriteLine(resultFour);

            Console.Write("Dec to Hex -> ");
            string resultFive = NumberConverter.Covert(resultFour, 10, 16);
            Console.WriteLine(resultFive);
        }
    }
}
