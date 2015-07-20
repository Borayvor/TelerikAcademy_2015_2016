namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course, ICourse
    {
        private string lab;

        public LocalCourse(string courseNameInitial)
            : base(courseNameInitial)
        {
        }

        public LocalCourse(string courseNameInitial, string teacherNameInitial)
            : base(courseNameInitial, teacherNameInitial, new List<string>())
        {
        }

        public LocalCourse(string courseNameInitial, string teacherNameInitial, IList<string> studentsInitial)
            : base(courseNameInitial, teacherNameInitial, studentsInitial)
        {
            this.Lab = null;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {                
                this.lab = value;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();

            if(this.Lab != null)
            {
                result += string.Format("; Lab = {0}", this.Lab) + " }";
            }
            else
            {
                result += " }";
            }

            return result;
        }
    }
}
