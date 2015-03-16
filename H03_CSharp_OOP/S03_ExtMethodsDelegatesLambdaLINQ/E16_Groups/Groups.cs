namespace E16_Groups
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class Groups
    {
        public static void Main(string[] args)
        {
            // Create a class Group with properties GroupNumber and DepartmentName.
            // Introduce a property GroupNumber in the Student class.
            // Extract all students from "Mathematics" department.
            // Use the Join operator.

            Console.WriteLine("Homework 16:");
            Console.WriteLine();

            var GroupMathematics =
                from student in StudentsList.students
                join grp in StudentsList.groups on student.GroupNumber equals grp.GroupNumber
                where grp.DepartmentName == "Mathematics"
                select student;


            StudentsList.PrintList(GroupMathematics);
        }
    }
}
