namespace E01_SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int minElement = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minElement]) < 0)
                    {
                        minElement = j;
                    }
                }

                if (minElement != i)
                {
                    T tmp = collection[minElement];
                    collection[minElement] = collection[i];
                    collection[i] = tmp;
                }
            }
        }
    }
}
