namespace E13_ExtractStudentsByMarks
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class ExtractStudentsByMarks
    {
        public static void Main(string[] args)
        {
            // Select all students that have at least one mark Excellent (6) 
            // into a new anonymous class that has properties – FullName and Marks.
            // Use LINQ.

            Console.WriteLine("Homework 13:");
            Console.WriteLine();
            var studentsWithAtLeastOne_Six =
                        from student in StudentsList.students
                        where student.Marks.Contains("6")
                        select new
                        {
                            FullName = student.FirstName + " " + student.LastName,
                            Marks = student.Marks
                        };

            foreach (var student in studentsWithAtLeastOne_Six)
            {
                Console.WriteLine(student.FullName + " --> marks: " + student.Marks);
            }
        }
    }
}
