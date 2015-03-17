namespace E02_StudentsAndWorkers.AbstractClasses
{
    using System.Collections;

    public abstract class Human
    {
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public virtual string Print()
        {
            return string.Format("First name : {0}\r\nLast Name : {1}\r\n", 
                this.FirstName, this.LastName);
        }
    }
}
