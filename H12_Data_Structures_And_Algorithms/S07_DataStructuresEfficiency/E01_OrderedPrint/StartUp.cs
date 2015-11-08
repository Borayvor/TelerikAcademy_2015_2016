namespace E01_OrderedPrint
{
    using System;
    using System.IO;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class StartUp
    {
        private static OrderedMultiDictionary<string, Student> orderByCourse =
            new OrderedMultiDictionary<string, Student>(true);

        public static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("../../students.txt"));

            for (string line = null; (line = Console.ReadLine()) != null;)
            {
                var match = line.Split('|').Select(m => m.Trim()).ToArray();

                AddStudent(
                    firstName: match[0],
                    lastName: match[1],
                    course: match[2]);
            }

            Console.WriteLine(string.Join(
                Environment.NewLine,
                orderByCourse.Keys.Select(course =>
                        string.Format("{0}: {1}", course, FindStudentsByCourse(course)))));
        }

        private static string FindStudentsByCourse(string course)
        {
            var result = orderByCourse[course];

            if (!result.Any())
            {
                return "No students found !";
            }

            return string.Join(", ", result);
        }

        private static string AddStudent(string firstName, string lastName, string course)
        {
            var student = new Student(firstName, lastName);
            orderByCourse[course].Add(student);

            return "Student added !";
        }
    }
}
