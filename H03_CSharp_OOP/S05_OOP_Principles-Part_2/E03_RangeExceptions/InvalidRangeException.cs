namespace E03_RangeExceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
        where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {        
        public InvalidRangeException(string msg, T start, T end)
            : base(msg)
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRangeException(string msg, T start, T end, Exception innerEx)
            : base(msg, innerEx)
        {
        }

        public T Start { get; private set; }

        public T End { get; private set; }
    }
}
