namespace E01_Implement_PriorityQueue
{
    using System.Collections.Generic;

    public class MyComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
