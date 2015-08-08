namespace E01_StudentsAndCourses
{
    using System;    

    public class SchoolProgram
    {
        public static void Main()
        {            
            var course = new Course("Mathematics");

            course.Add(new Student("Gogo", "Petrov", 13154));
            course.Add(new Student("Ivan", "Ivanov", 13274));
            course.Add(new Student("Dimitar", "Asparuhov", 11334));

            Console.WriteLine();
        }
    }
}
