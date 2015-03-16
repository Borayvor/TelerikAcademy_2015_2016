namespace E19_GroupedByGroupNameExtensions
{
    using System;
    using System.Linq;

    using E09_StudentGroups;

    public class GroupedByGroupNameExtensions
    {
        public static void Main(string[] args)
        {
            // Rewrite the previous using extension methods.
                        
            Console.WriteLine("Extension methods: ");
            Console.WriteLine();
            var selectStudentsExtension = StudentsList
                .students
                .OrderBy(st => StudentsList
                    .groups[st.GroupNumber]
                    .DepartmentName);

            foreach (var student in selectStudentsExtension)
            {
                Console.WriteLine(string.Join(" - ", student.FullName, 
                    StudentsList.groups[student.GroupNumber].DepartmentName));
            }

            Console.WriteLine();
        }
    }
}
