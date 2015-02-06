namespace E01_AllocateArray
{
    using System;

    public class AllocateArray
    {
        public static void Main(string[] args)
        {
            // Write a program that allocates array of 20 integers 
            // and initializes each element by its index multiplied 
            // by 5.
            // Print the obtained array on the console.

            int[] array = new int[20];

            for (int index = 0; index < 20; index++)
            {
                array[index] = index * 5;

                Console.WriteLine("array[{0}] = {1}", index, array[index]);
            }
        }
    }
}
