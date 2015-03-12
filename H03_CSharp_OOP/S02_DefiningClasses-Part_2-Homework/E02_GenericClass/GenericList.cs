namespace E02_GenericClass
{
    using System;
    using System.Linq;
    using System.Text;

    // 05. Generic class
    // Write a generic class GenericList<T> that keeps a list of elements 
    // of some parametric type T. Keep the elements of the list in an array 
    // with fixed capacity which is given as parameter in the class constructor.
    // Implement methods for adding element, accessing element by index, removing 
    // element by index, inserting element at given position, clearing the list, 
    // finding element by its value and ToString().
    // Check all input parameters to avoid accessing elements at invalid positions.
    public class GenericList<T>
        where T : IComparable<T>, IComparable
    {
        private const int DefaultCapacity = 8;

        private T[] array;
        private int count;
        private int capacity;       

        public GenericList(int capacityInitial)
        {
            if (capacityInitial < 0)
            {
                throw new ArgumentException("Capacity cannot be negative number !");
            }

            if (capacityInitial < DefaultCapacity)
            {
                this.capacity = DefaultCapacity;
            }
            else
            {
                this.capacity = capacityInitial;
            }
                        
            this.array = new T[this.capacity];            
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        // 06. Auto-grow
        // Implement auto-grow functionality: when the internal array is full, 
        // create a new array of double size and move all elements to it.
        private void IncreaseCapacity()
        {
            T[] tempArray = new T[this.array.Length * 2];
            this.capacity = tempArray.Length;

            Array.Copy(this.array, tempArray, this.array.Length);
            this.array = tempArray;

        }

        private void DecreaseCapacity()
        {
            if (this.capacity < DefaultCapacity)
            {
                return;
            }

            T[] tempArray = new T[this.array.Length / 2];
            this.capacity = tempArray.Length;

            Array.Copy(this.array, tempArray, this.count);
            this.array = tempArray;
        }

        public void Add(T element)
        {
            if (this.count >= this.capacity - 1)
            {
                IncreaseCapacity();
            }

            this.array[count] = element;
            this.count++;
        }

        public T GetElement(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Index is out of range !");
            }

            return this.array[index];
        }

        public void InsertElementAtIndex(int index, T element)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Index is out of range !");
            }

            if (this.count >= this.capacity - 1)
            {
                IncreaseCapacity();
            }

            Array.Copy(this.array, index, this.array, index + 1, this.array.Length - index - 1);
            this.array[index] = element;

            this.count++;
        }

        public void RemoveElementAtIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Index is out of range !");
            }

            Array.Copy(this.array, index + 1, this.array, index, this.array.Length - index - 1);

            this.count--;

            if (this.count < this.capacity / 2)
            {
                DecreaseCapacity();
            }
        }

        public void Clear()
        {
            this.array = new T[DefaultCapacity];
            this.capacity = DefaultCapacity;
            this.count = 0;
        }

        public int FindByValue(T element)
        {
            int index = Array.IndexOf(this.array, element);

            return index;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.count; i++)
            {
                sb.AppendFormat("{0}, ", array.GetValue(i).ToString());
            }

            string trueString = string.Empty;

            if(sb.Length > 0)
            {
                trueString = sb.Remove(sb.Length - 2, 2).ToString();
            }            

            return trueString;
        }

        // 07. Min and Max
        // Create generic methods Min<T>() and Max<T>() for finding the minimal 
        // and maximal element in the GenericList<T>.
        // You may need to add a generic constraints for the type T.
        public T Min()           
        {
            dynamic min = this.array.Min();

            return min;
        }

        public T Max()            
        {
            dynamic max = this.array.Max();

            return max;
        }
    }
}
