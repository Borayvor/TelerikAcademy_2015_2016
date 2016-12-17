namespace SchoolSystem.Models
{
    using Contracts;
    using EnumTypes;

    public class Teacher : Person, ITeacher, IPerson
    {
        private static int id = -1;
        private SubjectType subject;

        public Teacher(string firstName, string lastName, SubjectType subject)
            : base(firstName, lastName)
        {
            id++;
            this.Subject = subject;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public SubjectType Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.subject = value;
            }
        }

        public void AddMarkToStudent(IStudent student, IMark mark)
        {
            student.Marks.Add(mark);
        }
    }
}
