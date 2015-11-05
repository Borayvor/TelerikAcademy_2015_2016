namespace E04_ImplementHashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private int count;
        private int capacity;

        private LinkedList<KeyValuePair<K, T>>[] list;

        public HashTable(int capacity = 16)
        {
            this.list = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public T this[K key]
        {
            get
            {
                T value = this.Find(key);
                return value;
            }

            set
            {
                var index = key.GetHashCode() % this.list.Length;
                index = Math.Abs(index);

                if (this.list[index] != null)
                {
                    var next = this.list[index].First;

                    while (next != null)
                    {
                        if (next.Value.Key.Equals(key))
                        {
                            next.Value = new KeyValuePair<K, T>(key, value);
                            break;
                        }

                        next = next.Next;
                    }
                }
                else
                {
                    this.list[index] = new LinkedList<KeyValuePair<K, T>>();
                    this.list[index].AddFirst(new LinkedListNode<KeyValuePair<K, T>>(new KeyValuePair<K, T>(key, value)));
                }

                this.count++;
            }
        }

        public void Add(K key, T value)
        {
            if (this.count >= this.capacity * 0.75)
            {
                this.DoubleCapacity();
            }

            int index = key.GetHashCode() % this.list.Length;
            index = Math.Abs(index);

            if (this.list[index] == null)
            {
                this.list[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            var next = this.list[index].First;

            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    throw new ArgumentException("There is already that key!");
                }

                next = next.Next;
            }

            this.list[index].AddLast(new KeyValuePair<K, T>(key, value));
            this.count++;
        }

        public T Find(K key)
        {
            int index = key.GetHashCode() % this.list.Length;

            if (this.list[index] != null)
            {
                var next = this.list[index].First;

                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        return next.Value.Value;
                    }

                    next = next.Next;
                }
            }

            throw new ArgumentException("There isn't element with this key!");
        }

        public void Remove(K key)
        {
            int index = key.GetHashCode() % this.list.Length;

            if (this.list[index] == null)
            {
                throw new ArgumentException("There isn't element with that key!");
            }

            bool isRemoved = false;
            var next = this.list[index].First;

            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    this.list[index].Remove(next);
                    isRemoved = true;

                    break;
                }

                next = next.Next;
            }

            if (!isRemoved)
            {
                throw new ArgumentException("There isn't element with that key !");
            }

            this.count--;
        }

        public void Clear()
        {
            this.list = new LinkedList<KeyValuePair<K, T>>[16];
            this.count = 0;
            this.capacity = this.list.Length;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                if (item != null)
                {
                    var next = item.First;

                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleCapacity()
        {
            LinkedList<KeyValuePair<K, T>>[] temporaryList = new LinkedList<KeyValuePair<K, T>>[this.capacity * 2];

            for (int i = 0; i < this.list.Length; i++)
            {
                temporaryList[i] = this.list[i];
            }

            this.list = temporaryList;
            this.capacity = temporaryList.Length;
        }
    }
}
