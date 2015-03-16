namespace E05_OrderStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using E03_FirstBeforeLast;

    public class OrderStudents
    {
        public static void Main(string[] args)
        {
            // Using the extension methods OrderBy() and ThenBy() with lambda 
            // expressions sort the students by first name and last name in 
            // descending order.
            // Rewrite the same with LINQ.

            Console.WriteLine("LINQ => DescendingSort:");
            DescendingSortLINQ(StudentsList.students);
            Console.WriteLine();

            Console.WriteLine("Lambda expression => DescendingSort:");
            DescendingSortLambda(StudentsList.students);
            Console.WriteLine();
        }

        public static void DescendingSortLambda(List<Student> students)
        {
            var newSudentsList = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName);

            foreach (var student in newSudentsList)
            {
                Console.WriteLine(student);
            }
        }


        public static void DescendingSortLINQ(List<Student> students)
        {
            var newSudentsList =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            foreach (Student student in newSudentsList)
            {
                Console.WriteLine(student);
            }
        }
    }
}
