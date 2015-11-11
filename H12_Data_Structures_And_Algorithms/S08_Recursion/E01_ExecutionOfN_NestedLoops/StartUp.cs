namespace E01_ExecutionOfN_NestedLoops
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter the number of loops < 10 : ");
            uint n = uint.Parse(Console.ReadLine());

            NestedLoop((int)n);
        }

        static void NestedLoop(int n)
        {
            int[] array = new int[n];

            RecursiveLoop(array);
        }

        private static void RecursiveLoop(int[] array, int position = 0)
        {
            if (position == array.Length)
            {
                Print(array);
                return;
            }

            for (int i = 1; i <= array.Length; i++)
            {
                array[position] = i;

                RecursiveLoop(array, position + 1);
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
