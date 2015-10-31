namespace E13_ImplementQueueDynamic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> elements = new LinkedList<T>();

        public int Count
        {
            get { return this.elements.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Enqueue(T value)
        {
            this.elements.AddLast(value);
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.elements.First.Value;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var value = this.elements.First.Value;

            this.elements.RemoveFirst();

            return value;
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public override string ToString()
        {
            return string.Join(" ", this);
        }
    }
}