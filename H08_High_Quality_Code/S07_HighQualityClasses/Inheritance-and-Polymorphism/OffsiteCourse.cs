namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course, ICourse
    {
        private string town;

        public OffsiteCourse(string courseNameInitial)
            : base(courseNameInitial)
        {
        }

        public OffsiteCourse(string courseNameInitial, string teacherNameInitial)
            : base(courseNameInitial, teacherNameInitial, new List<string>())
        {
        }

        public OffsiteCourse(string courseNameInitial, string teacherNameInitial, IList<string> studentsInitial)
            : base(courseNameInitial, teacherNameInitial, studentsInitial)
        {
            this.Town = null;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {                
                this.town = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();

            if(this.Town != null)
            {
                result += string.Format("; Town = {0}", this.Town) + " }";
            }
            else
            {
                result += " }";
            }

            return result;
        }
    }
}
