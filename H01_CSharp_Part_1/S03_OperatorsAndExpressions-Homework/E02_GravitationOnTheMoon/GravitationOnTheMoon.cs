namespace E02_GravitationOnTheMoon
{
    using System;

    public class GravitationOnTheMoon
    {
        public static void Main(string[] args)
        {
            // The gravitational field of the Moon is approximately 17% of that on the Earth.
            // Write a program that calculates the weight of a man on the moon by a given 
            // weight on the Earth.
            // Examples:
            // 
            // weight	weight on the Moon
            // 86	    14.62
            // 74.6	    12.682
            // 53.7	    9.129

            Console.WriteLine("Please, enter your weight !");
            Console.Write("weight = ");
            double weight = double.Parse(Console.ReadLine());

            double weightOnTheMoon = weight * 0.17;

            Console.WriteLine("Your weight on the Moon is {0} kg.", weightOnTheMoon);
            Console.WriteLine();
        }
    }
}
