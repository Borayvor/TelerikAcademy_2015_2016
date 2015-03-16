namespace E14_ExtractStudentsWithTwoMarks
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class ExtractStudentsWithTwoMarks
    {
        public static void Main(string[] args)
        {
            // Write down a similar program that extracts the students 
            // with exactly two marks "2".
            // Use extension methods.

            Console.WriteLine("Homework 14:");
            Console.WriteLine();
            var students_Exactly_2Marks_2 =
                from student in StudentsList.students
                where student.Marks.Count(x => x.Equals('2')) == 2
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    Marks = student.Marks
                };

            foreach (var student in students_Exactly_2Marks_2)
            {
                Console.WriteLine(student.FullName + " --> marks: " + student.Marks);
            }
        }
    }
}
