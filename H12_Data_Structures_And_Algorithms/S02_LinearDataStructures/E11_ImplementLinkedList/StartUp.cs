namespace E11_ImplementLinkedList
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            linkedList.FirstElement = new ListItem<int>(1);
            linkedList.FirstElement.NextItem = new ListItem<int>(2);
            linkedList.FirstElement.NextItem.NextItem = new ListItem<int>(3);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
