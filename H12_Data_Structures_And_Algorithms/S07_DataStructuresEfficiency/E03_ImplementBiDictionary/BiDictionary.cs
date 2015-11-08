namespace E03_ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private readonly MultiDictionary<TKey1, Entry> orderByKey1 = null;

        private readonly MultiDictionary<TKey2, Entry> orderByKey2 = null;

        private readonly MultiDictionary<Tuple<TKey1, TKey2>, Entry> orderByKey1Key2 = null;

        public BiDictionary(bool allowDuplicateValues)
        {
            this.orderByKey1 = new MultiDictionary<TKey1, Entry>(allowDuplicateValues);
            this.orderByKey2 = new MultiDictionary<TKey2, Entry>(allowDuplicateValues);
            this.orderByKey1Key2 = new MultiDictionary<Tuple<TKey1, TKey2>, Entry>(allowDuplicateValues);
        }

        public int Count
        {
            get
            {
                return this.orderByKey1Key2.KeyValuePairs.Count;
            }
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            var entry = new Entry(key1, key2, value);

            this.orderByKey1.Add(key1, entry);
            this.orderByKey2.Add(key2, entry);

            var key1Key2 = new Tuple<TKey1, TKey2>(key1, key2);

            this.orderByKey1Key2.Add(key1Key2, entry);
        }

        public ICollection<TValue> GetByFirstKey(TKey1 key1)
        {
            return this.orderByKey1[key1].Select(entry => entry.Value).ToArray();
        }

        public void RemoveByFirstKey(TKey1 key1)
        {
            var entries = this.orderByKey1[key1];

            foreach (var entry in entries)
            {
                this.orderByKey2.Remove(entry.Key2, entry);

                var key1Key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);

                this.orderByKey1Key2.Remove(key1Key2, entry);
            }

            this.orderByKey1.Remove(key1);
        }

        public ICollection<TValue> GetBySecondKey(TKey2 key2)
        {
            return this.orderByKey2[key2].Select(entry => entry.Value).ToArray();
        }

        public void RemoveBySecondKey(TKey2 key2)
        {
            var entries = this.orderByKey2[key2];

            foreach (var entry in entries)
            {
                this.orderByKey1.Remove(entry.Key1, entry);

                var key1Key2 = new Tuple<TKey1, TKey2>(entry.Key1, entry.Key2);

                this.orderByKey1Key2.Remove(key1Key2, entry);
            }

            this.orderByKey2.Remove(key2);
        }

        public ICollection<TValue> GetByFirstAndSecondKey(TKey1 key1, TKey2 key2)
        {
            var key1Key2 = new Tuple<TKey1, TKey2>(key1, key2);

            return this.orderByKey1Key2[key1Key2].Select(entry => entry.Value).ToArray();
        }

        public void RemoveByFirstAndSecondKey(TKey1 key1, TKey2 key2)
        {
            var key1Key2 = new Tuple<TKey1, TKey2>(key1, key2);
            var entries = this.orderByKey1Key2[key1Key2];

            foreach (var entry in entries)
            {
                this.orderByKey1.Remove(entry.Key1, entry);
                this.orderByKey2.Remove(entry.Key2, entry);
            }

            this.orderByKey1Key2.Remove(key1Key2);
        }

        private class Entry : IEquatable<Entry>
        {
            public Entry(TKey1 key1, TKey2 key2, TValue value)
            {
                this.Key1 = key1;
                this.Key2 = key2;
                this.Value = value;
            }

            public TKey1 Key1 { get; private set; }

            public TKey2 Key2 { get; private set; }

            public TValue Value { get; private set; }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Entry);
            }

            public bool Equals(Entry other)
            {
                return other != null
                    && this.Key1.Equals(other.Key1)
                    && this.Key2.Equals(other.Key2)
                    && this.Value.Equals(other.Value);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 0;

                    hashCode = (hashCode * 397) ^ this.Key1.GetHashCode();
                    hashCode = (hashCode * 397) ^ this.Key2.GetHashCode();
                    hashCode = (hashCode * 397) ^ this.Value.GetHashCode();

                    return hashCode;
                }
            }
        }
    }
}