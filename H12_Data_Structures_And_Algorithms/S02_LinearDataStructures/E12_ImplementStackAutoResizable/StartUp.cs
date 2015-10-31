namespace E12_ImplementStackAutoResizable
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            stack.Push(5);
            stack.Push(7);
            Console.WriteLine(stack.Peek());

            while (stack.Count > 0)
            {
                Console.Write("{0}, ", stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
