namespace E01_StudentsAndCourses
{
    using System;   
    using System.Collections.Generic;

    using E01_StudentsAndCourses.Interfaces;

    public class School : ISchool
    {
        private string schoolName;
        private IList<ICourse> courses;

        public School(string schoolNameInitial)
        {
            this.SchoolName = schoolNameInitial;

            this.courses = new List<ICourse>();
        }

        public string SchoolName
        {
            get
            {
                return this.schoolName;
            }

            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("School name cannot be null, empty or white-space !");
                }

                this.schoolName = value;
            }
        }

        public IList<ICourse> Courses
        {
            get
            {
                return new List<ICourse>(this.courses);
            }
        }

        public void Add(ICourse course)
        {
            this.courses.Add(course);      
        }

        public void Remove(ICourse course)
        {
            if(this.courses.Contains(course))
            {
                this.courses.Remove(course);
            }           
        }
    }
}
