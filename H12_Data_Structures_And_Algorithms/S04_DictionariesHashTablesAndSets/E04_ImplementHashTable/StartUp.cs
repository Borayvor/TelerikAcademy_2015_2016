namespace E04_ImplementHashTable
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            HashTable<string, double> table = new HashTable<string, double>();

            table.Add("Pesho", 5);
            table.Add("Gosho", 6);
            table.Add("Stamat", 4.45);
            table.Add("Maria", 3.56);

            table.Remove("Pesho");

            table["Stamat"] = 5;

            foreach (var item in table)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
