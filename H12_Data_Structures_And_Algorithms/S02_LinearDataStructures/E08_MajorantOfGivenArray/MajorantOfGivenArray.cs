namespace E08_MajorantOfGivenArray
{
    using System;
    using System.Linq;
    using Utils;

    public class MajorantOfGivenArray
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var sequence = reader.ReadSequenceOfInt();

            var majorant = sequence.Cast<int?>()
                .FirstOrDefault(x => sequence.Count(y => y == x) >= (sequence.Count() / 2) + 1);

            if (majorant == null)
            {
                Console.WriteLine("There is no such element in the array !");
            }
            else
            {
                Console.WriteLine("Majorant of the array: {0}", majorant);
            }
        }
    }
}
