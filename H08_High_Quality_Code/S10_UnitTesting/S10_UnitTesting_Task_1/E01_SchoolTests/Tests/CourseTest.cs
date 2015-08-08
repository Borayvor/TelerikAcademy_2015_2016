namespace E01_SchoolTests.Tests
{
    using System;
    using System.Collections.Generic;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using E01_StudentsAndCourses;
    

    [TestClass]
    public class CourseTest
    {
        private const int STUDENTS_COUNT_MAX = 30;

        private Course course;

        [TestInitialize]
        public void InitializeStudent()
        {
            this.course = new Course("Mathematics");

            course.Add(new Student("Gogo", "Petrov", 13154));
            course.Add(new Student("Ivan", "Ivanov", 13274));
            course.Add(new Student("Dimitar", "Asparuhov", 11334));
            course.Add(new Student("Gogo", "Petrov", 23164));
            course.Add(new Student("Ivan", "Ivanov", 23294));
            course.Add(new Student("Dimitar", "Asparuhov", 21314));
            course.Add(new Student("Gogo", "Petrov", 33124));
            course.Add(new Student("Ivan", "Ivanov", 33224));
            course.Add(new Student("Dimitar", "Asparuhov", 31354));
            course.Add(new Student("Gogo", "Petrov", 43154));
            course.Add(new Student("Ivan", "Ivanov", 43274));
            course.Add(new Student("Dimitar", "Asparuhov", 41334));
            course.Add(new Student("Gogo", "Petrov", 53154));
            course.Add(new Student("Ivan", "Ivanov", 53274));
            course.Add(new Student("Dimitar", "Asparuhov", 51334));
            course.Add(new Student("Gogo", "Petrov", 63154));
            course.Add(new Student("Ivan", "Ivanov", 63234));
            course.Add(new Student("Dimitar", "Asparuhov", 61334));
            course.Add(new Student("Gogo", "Petrov", 73154));
            course.Add(new Student("Ivan", "Ivanov", 73274));
            course.Add(new Student("Dimitar", "Asparuhov", 71334));
            //course.Add(new Student("Gogo", "Petrov", 84154));
            //course.Add(new Student("Ivan", "Ivanov", 85274));
            //course.Add(new Student("Dimitar", "Asparuhov", 81334));
            //course.Add(new Student("Gogo", "Petrov", 96154));
            //course.Add(new Student("Ivan", "Ivanov", 97274));
            //course.Add(new Student("Dimitar", "Asparuhov", 91394));
            //course.Add(new Student("Gogo", "Petrov", 11159));
            //course.Add(new Student("Ivan", "Ivanov", 11279));
            //course.Add(new Student("Dimitar", "Asparuhov", 91300));

            //course.Add(new Student("Gogo", "Petrov", 11111));    
            //course.Add(new Student("Dimitar", "Asparuhov", 91394));
        }

        [TestMethod]       
        public void CorseNameCannotBeNullEmptyOrWhiteSpace()
        {
            Assert.IsNotNull(this.course.CourseName);
        }

        [TestMethod]        
        public void TheNumberOfStudentsInTheCourseCannotBeGreaterThan()
        {
            Assert.IsFalse(this.course.Students.Count > STUDENTS_COUNT_MAX);
        }

        [TestMethod]
        public void TestAddStudentInCourse()
        {
            var pesho = new Student("Pesho", "Angelov", 98765);
            this.course.Add(pesho);

            Assert.ReferenceEquals(pesho, this.course.Students);
        }

        [TestMethod]        
        public void StudentsCannotHaveTheSameID()
        {
            for(int indexStudent = 0; indexStudent < this.course.Students.Count; indexStudent++)
            {
                for(int indexOther = 0; indexOther < this.course.Students.Count; indexOther++)
                {
                    if(indexStudent != indexOther)
                    {
                        Assert.AreNotEqual(this.course.Students[indexStudent].ID, this.course.Students[indexOther].ID);
                    }
                }
            }
        }
    }
}
