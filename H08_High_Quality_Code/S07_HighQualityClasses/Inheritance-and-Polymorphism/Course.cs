namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course : ICourse
    {
        private string courseName;
        private string teacherName;
        private IList<string> students;

        protected Course(string courseNameInitial)
            : this(courseNameInitial, null)
        {
        }

        protected Course(string courseNameInitial, string teacherNameInitial)
            : this(courseNameInitial, teacherNameInitial, new List<string>())
        {           
        }

        protected Course(string courseNameInitial, string teacherNameInitial, 
            IList<string> studentsInitial)
        {
            this.CourseName = courseNameInitial;
            this.TeacherName = teacherNameInitial;
            this.Students = studentsInitial;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            private set
            {
                this.CheckValueForException(value, "CourseName");

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                
                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }

            set
            {
                this.students = value;
            }
        }
                
        private string GetStudentsAsString()
        {
            if(this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(" { Name = ");
            result.Append(this.CourseName);

            if(this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        protected void CheckValueForException(string value, string valueName)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(" " + valueName 
                    + " cannot be null, empty or white-space !");
            }
        }
    }
}
