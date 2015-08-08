namespace E01_StudentsAndCourses
{    
    using System;
    using System.Collections.Generic;

    using E01_StudentsAndCourses.Interfaces;

    public class Course : ICourse
    {        
        private const byte STUDENTS_COUNT_MAX = 30;

        private string courseName;        
        private IList<IStudent> students;

        public Course(string nameInitial)
        {
            this.CourseName = nameInitial;           

            this.students = new List<IStudent>();
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be null, empty or white-space !");
                }

                this.courseName = value;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                return new List<IStudent>(this.students);
            }
        }


        public void Add(IStudent student)
        {
            if(this.Students.Count >= STUDENTS_COUNT_MAX)
            {
                throw new ArgumentOutOfRangeException("The number of students in the course cannot be greater than " +
                    STUDENTS_COUNT_MAX + ".");
            }

            foreach(var oldStudent in this.Students)
            {
                if(oldStudent.ID.Equals(student.ID))
                {
                    throw new ArgumentException("Students cannot have the same ID !");
                }
            }

            this.students.Add(student);            
        }

        public void Remove(IStudent student)
        {
            if(this.students.Contains(student))
            {
                this.students.Remove(student);                
            }            
        }               
    }
}
