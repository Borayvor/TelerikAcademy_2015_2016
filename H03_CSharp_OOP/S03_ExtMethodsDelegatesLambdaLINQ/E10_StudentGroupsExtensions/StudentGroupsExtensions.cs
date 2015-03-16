namespace E10_StudentGroupsExtensions
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class StudentGroupsExtensions
    {
        public static void Main(string[] args)
        {
            // Implement the previous using the same query expressed with extension methods.

            Console.WriteLine("Homework 10:");
            Console.WriteLine();
            var studentsFromGroup2Lambda = StudentsList
                .students.Where(x => x.GroupNumber == 2)
                .OrderBy(x => x.FirstName);

            StudentsList.PrintList(studentsFromGroup2Lambda);            
        }
    }
}
