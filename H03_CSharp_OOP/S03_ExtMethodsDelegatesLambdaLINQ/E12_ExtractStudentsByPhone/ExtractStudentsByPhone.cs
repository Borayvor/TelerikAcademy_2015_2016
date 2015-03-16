namespace E12_ExtractStudentsByPhone
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class ExtractStudentsByPhone
    {
        public static void Main(string[] args)
        {
            // Extract all students with phones in Sofia.
            // Use LINQ.

            Console.WriteLine("Homework 12:");
            Console.WriteLine();
            var studentsSofiaPhoneNumbers =
                from student in StudentsList.students
                where student.Tel.StartsWith("02")
                select student;

            StudentsList.PrintList(studentsSofiaPhoneNumbers);
        }
    }
}
