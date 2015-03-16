namespace E09_StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StudentGroups
    {
        public static void Main(string[] args)
        {
            // Create a class Student with properties FirstName, LastName, 
            // FN, Tel, Email, Marks (a List), GroupNumber.
            // Create a List<Student> with sample students. Select only 
            // the students that are from group number 2.
            // Use LINQ query. Order the students by FirstName.

            Console.WriteLine("Homework 09:");
            Console.WriteLine();
            var groupNumberTwo =
                          from student in StudentsList.students
                          where student.GroupNumber == 2
                          orderby student.FirstName
                          select student;


            StudentsList.PrintList(groupNumberTwo);  
        }
    }
}
