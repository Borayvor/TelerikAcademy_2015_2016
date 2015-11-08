namespace E01_OrderedPrint
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int CompareTo(Student other)
        {
            return (string.Compare(this.LastName, other.LastName) * 2) +
                   string.Compare(this.FirstName, other.LastName);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}