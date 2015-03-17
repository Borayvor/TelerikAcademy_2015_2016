namespace E03_AnimalHierarchy
{    
    using System;
    using System.Linq;

    using E03_AnimalHierarchy.AbstractClasses;

    public class AnimalHierarchyMain
    {
        public static void Main(string[] args)
        {
            // Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define 
            // useful constructors and methods. Dogs, frogs and cats are Animals. 
            // All animals can produce sound (specified by the ISound interface).
            // Kittens and tomcats are cats. All animals are described by age, 
            // name and sex. Kittens can be only female and tomcats can be only 
            // male. Each animal produces a specific sound.
            // Create arrays of different kinds of animals and calculate the average 
            // age of each kind of animal using a static method (you may use LINQ).

            Frog[] frogs = new Frog[]
            {
                new Frog( 2, "Jabcho", 'M'),
                new Frog( 2.3, "Jabok", 'M'),
                new Frog( 3.1, "Jabka", 'F'),
                new Frog( 1.4, "Jabchocho", 'M')
            };

            Dog[] dogs = new Dog[]
            {
                new Dog( 1.4, "Balkan", 'M'),
                new Dog( 2, "Mecho", 'M'),
                new Dog( 5, "Sharo", 'M'),
                new Dog( 4, "Lassy", 'F')
            };

            Cat[] cats = new Cat[]
            {
                new Cat ( 2, "Missi" , 'F'),
                new Cat ( 3, "Mat", 'M'),
                new Kitten ( 0.9, "Pissi"),
                new Tomcat ( 1, "Lucky")
            };

            Print(frogs);
            Print(dogs);
            Print(cats);
        }


        private static void Print(Animal[] animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine("Average age : {0} years", (animals.Average(x => x.Age)));
            Console.WriteLine();
        }
    }
}
