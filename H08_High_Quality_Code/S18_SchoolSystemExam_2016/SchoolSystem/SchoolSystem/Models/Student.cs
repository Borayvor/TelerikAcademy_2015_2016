namespace SchoolSystem.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;
    using EnumTypes;

    public class Student : Person, IStudent, IPerson
    {
        private const string NoMarksString = "This student has no marks.";
        private const string HasMarksString = "The student has these marks:";

        private static int id = -1;

        private GradeType grade;
        private IList<IMark> marks;

        public Student(string firstName, string lastName, GradeType grade)
            : base(firstName, lastName)
        {
            id++;
            this.Grade = grade;
            this.Marks = new List<IMark>();
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public GradeType Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                Validator.ValidateGradeValue((int)value);

                this.grade = value;
            }
        }

        public IList<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            private set
            {
                Validator.ValidateStidentMarksCount(value.Count);

                this.marks = value;
            }
        }

        public string GetMarksAsStringList()
        {
            var marks = this.Marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

            if (marks.Count() == 0)
            {
                return NoMarksString;
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(HasMarksString);
            stringBuilder.AppendLine(string.Join("\n", marks));

            return stringBuilder.ToString();
        }
    }
}
