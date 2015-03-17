namespace E02_StudentsAndWorkers
{
    using E02_StudentsAndWorkers.AbstractClasses;

    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                this.grade = value;
            }
        }

        public override string Print()
        {
            return base.Print() + string.Format("Garde : {0}\r\n", this.Grade);
        }
    }
}
