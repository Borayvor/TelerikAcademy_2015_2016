namespace E18_GroupedByGroupNumber
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class GroupedByGroupNumber
    {
        public static void Main(string[] args)
        {
            // Create a program that extracts all students grouped by 
            // GroupNumber and then prints them to the console.
            // Use LINQ.

            Console.WriteLine("Homework 18:");
            Console.WriteLine();
            string[] departmentName = {
                                          "Mathematics",
                                          "Medicine",
                                          "Physics",
                                          "Chemistry",
                                          "Arts",
                                          "Biology",
                                      };


            foreach (var item in departmentName)
            {
                var studentsByGroupName =
                    from student in StudentsList.students
                    join grp in StudentsList.groups on student.GroupNumber equals grp.GroupNumber
                    where grp.DepartmentName == item
                    select student;

                Console.WriteLine();
                Console.WriteLine("{0} :", item);
                StudentsList.PrintList(studentsByGroupName);
            }

            Console.WriteLine();
        }
    }
}
