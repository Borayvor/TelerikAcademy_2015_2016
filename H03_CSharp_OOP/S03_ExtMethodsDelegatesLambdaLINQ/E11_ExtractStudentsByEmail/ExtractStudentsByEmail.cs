namespace E11_ExtractStudentsByEmail
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class ExtractStudentsByEmail
    {
        public static void Main(string[] args)
        {
            // Extract all students that have email in abv.bg.
            // Use string methods and LINQ.

            Console.WriteLine("Homework 11:");
            Console.WriteLine();
            var studentEmailAbv =
                from student in StudentsList.students
                where student.Email.EndsWith("@abv.bg")
                select student;

            StudentsList.PrintList(studentEmailAbv); 
        }
    }
}
