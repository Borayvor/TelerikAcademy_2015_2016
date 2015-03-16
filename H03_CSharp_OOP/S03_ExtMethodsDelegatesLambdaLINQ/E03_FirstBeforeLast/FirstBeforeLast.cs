namespace E03_FirstBeforeLast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FirstBeforeLast
    {
        public static void Main(string[] args)
        {
            // Write a method that from a given array of students finds all 
            // students whose first name is before its last name alphabetically.
            // Use LINQ query operators.
                        
            Console.WriteLine("FirstNameBeforeLastName");
            FirstNameBeforeLastName(StudentsList.students);
            Console.WriteLine();
        }


        public static void FirstNameBeforeLastName(List<Student> students)
        {
            var newSudentsList =
                from student in students
                where student.FirstName.CompareTo(student.LastName) == -1
                select student;

            foreach (Student student in newSudentsList)
            {
                Console.WriteLine(student);
            }
        }
    }
}
