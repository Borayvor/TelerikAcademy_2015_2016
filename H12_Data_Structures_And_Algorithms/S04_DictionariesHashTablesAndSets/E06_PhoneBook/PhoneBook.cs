namespace E06_PhoneBook
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class PhoneBook
    {
        private MultiDictionary<string, Entry> byName =
            new MultiDictionary<string, Entry>(true);

        private MultiDictionary<Tuple<string, string>, Entry> byNameAndTown =
            new MultiDictionary<Tuple<string, string>, Entry>(true);

        public void Add(string name, string town, string phone)
        {
            var entry = new Entry(name, town, phone);

            var nameAndTown = new Tuple<string, string>(entry.Name, entry.Town);

            byName.Add(name, entry);
            byNameAndTown.Add(nameAndTown, entry);
        }

        public IEnumerable<Entry> Find(string name)
        {
            return byName[name];
        }

        public IEnumerable<Entry> Find(string name, string town)
        {
            var nameAndTown = new Tuple<string, string>(name, town);

            return byNameAndTown[nameAndTown];
        }
    }
}
