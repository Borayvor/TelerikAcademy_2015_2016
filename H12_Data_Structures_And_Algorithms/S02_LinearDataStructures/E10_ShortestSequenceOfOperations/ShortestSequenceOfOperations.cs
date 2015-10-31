namespace E10_ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public class ShortestSequenceOfOperations
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var n = 0;
            var m = 0;

            do
            {
                Console.WriteLine("For \"n\" :");
                n = reader.ReadSingleInt();

                Console.WriteLine("For \"m\" :");
                m = reader.ReadSingleInt();

                Console.WriteLine();
            }
            while (n >= m || n < 1);

            Console.WriteLine(
                "The shortest sequence of operations is : {0}",
                string.Join(" -> ", GetShortestSequenceOfOperations(n, m)));
        }

        private static List<int> GetShortestSequenceOfOperations(int startNumber, int endNumber)
        {
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            stack.Push(endNumber);

            while (endNumber > startNumber)
            {
                if (endNumber / 2 >= startNumber && endNumber % 2 == 0)
                {
                    endNumber = endNumber / 2;
                    stack.Push(endNumber);
                }
                else if (endNumber - 2 >= startNumber && endNumber % 2 == 0)
                {
                    endNumber = endNumber - 2;
                    stack.Push(endNumber);
                }
                else
                {
                    endNumber = endNumber - 1;
                    stack.Push(endNumber);
                }
            }

            while (stack.Count > 0)
            {
                result.Add(stack.Pop());
            }

            return result;
        }
    }
}
