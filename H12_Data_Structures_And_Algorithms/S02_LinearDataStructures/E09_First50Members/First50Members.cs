namespace E09_First50Members
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public class First50Members
    {
        public static void Main(string[] args)
        {
            const int QueueDefaultLength = 50;

            var reader = new ConsoleReader();
            var startNumber = reader.ReadSingleInt();

            var resultSequence = new List<int>();
            var queue = new Queue<int>();
            queue.Enqueue(startNumber);

            while (queue.Count < QueueDefaultLength)
            {
                var element = queue.Dequeue();

                resultSequence.Add(element);

                queue.Enqueue(element + 1);
                queue.Enqueue((2 * element) + 1);
                queue.Enqueue(element + 2);
            }

            while (resultSequence.Count < QueueDefaultLength)
            {
                resultSequence.Add(queue.Dequeue());
            }

            Console.WriteLine("First 50 members for given N : {0}", string.Join(", ", resultSequence));
        }
    }
}
