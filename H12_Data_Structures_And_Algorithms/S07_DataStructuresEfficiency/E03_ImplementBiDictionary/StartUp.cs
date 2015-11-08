namespace E03_ImplementBiDictionary
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var bidictionary = new BiDictionary<string, int, string>(true);

            bidictionary.Add("pesho", 1, "JavaScript");
            bidictionary.Add("gosho", 2, "Java");
            bidictionary.Add("tosho", 3, "C#");
            bidictionary.Add("tosho", 3, "C#");
            bidictionary.Add("gosho", 3, "Coffee");
            bidictionary.Add("tosho", 1, "Python");

            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstKey("tosho")));
            Console.WriteLine(string.Join(" ", bidictionary.GetBySecondKey(3)));
            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstAndSecondKey("tosho", 3)));
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstKey("gosho");
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveBySecondKey(3);
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstAndSecondKey("tosho", 1);
            Console.WriteLine(bidictionary.Count);
        }
    }
}
