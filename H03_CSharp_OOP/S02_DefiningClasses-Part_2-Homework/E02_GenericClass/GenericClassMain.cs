namespace E02_GenericClass
{
    using System;

    public class GenericClassMain
    {
        public static void Main(string[] args)
        {
            //test GenericList
            Console.WriteLine("Test \"GenericList\"");
            GenericList<int> list = new GenericList<int>(5);

            int length = list.Capacity;
            for (int i = 0; i < length; i++)
            {
                list.Add(i + 5);
            }

            Console.WriteLine("list -> element at index 1 = {0}", list.GetElement(1));
            Console.WriteLine();

            Console.WriteLine("list -> {0}", list);
            Console.WriteLine();

            list.InsertElementAtIndex(3, 7);
            list.InsertElementAtIndex(3, 7);
            list.InsertElementAtIndex(3, 7);
            list.InsertElementAtIndex(3, 7);
            list.InsertElementAtIndex(3, 7);
            list.InsertElementAtIndex(3, 7);
            list.InsertElementAtIndex(3, 7);

            Console.WriteLine("list -> {0}", list);
            Console.WriteLine();

            list.Add(7);

            Console.WriteLine("list -> {0}", list);
            Console.WriteLine();

            list.RemoveElementAtIndex(3);
            list.RemoveElementAtIndex(3);
            list.RemoveElementAtIndex(3);
            list.RemoveElementAtIndex(3);
            list.RemoveElementAtIndex(3);
            list.RemoveElementAtIndex(3);
            list.RemoveElementAtIndex(list.Count - 1);

            Console.WriteLine("list -> {0}", list);
            Console.WriteLine();

            Console.WriteLine("find index of value 4 -> {0}", list.FindByValue(4));
            Console.WriteLine("list -> {0}", list);
            Console.WriteLine();

            Console.WriteLine("list min-element -> {0}", list.Min());
            Console.WriteLine("list max-element -> {0}", list.Max());
            Console.WriteLine();

            Console.WriteLine("Clear list:");
            list.Clear();            

            Console.WriteLine("list -> {0}", list);
            Console.WriteLine();
        }
    }
}
