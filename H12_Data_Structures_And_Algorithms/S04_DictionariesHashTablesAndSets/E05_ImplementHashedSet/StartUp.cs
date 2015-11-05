namespace Е05_ImplementHashedSet
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashSet<string> persons = new HashSet<string>();

            persons.Add("Pesho");
            persons.Add("Gosho");
            persons.Add("Stamat");
            persons.Add("Maria");

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            persons.Remove("Maria");
            Console.WriteLine();
            Console.WriteLine("Count after removal: {0}", persons.Count);
            Console.WriteLine();

            Console.WriteLine("Is there maria in persons --> {0}", persons.Contains("Maria"));

            HashSet<string> secondPersons = new HashSet<string>();

            secondPersons.Add("Gogo");
            secondPersons.Add("Mitko");
            secondPersons.Add("Ivailo");
            secondPersons.Add("Stoian");

            Console.WriteLine("\nUnion: ");
            Console.WriteLine("========================");

            persons.Union(secondPersons);

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();

            Console.WriteLine("\nIntersection: ");
            Console.WriteLine("========================");

            persons.Intersect(secondPersons);

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine();
        }
    }
}
