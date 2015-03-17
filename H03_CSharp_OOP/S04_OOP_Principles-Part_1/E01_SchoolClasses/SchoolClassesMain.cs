namespace E01_SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class SchoolClassesMain
    {
        public static void Main(string[] args)
        {
            // We are given a school. In the school there are classes of 
            // students. Each class has a set of teachers. Each teacher 
            // teaches a set of disciplines. Students have name and 
            // unique class number. Classes have unique text identifier. 
            // Teachers have name. Disciplines have name, number of lectures 
            // and number of exercises. Both teachers and students are people. 
            // Students, classes, teachers and disciplines could have 
            // optional comments (free text block).
            // Your task is to identify the classes (in terms of OOP) and 
            // their attributes and operations, encapsulate their fields, 
            // define the class hierarchy and create a class diagram with Visual Studio.

            var gogo = new Student("Gogo", 23);
            var vania = new Student("Vania", 24);
            var math = new Discipline("Mathematic", 4, 10);
            var phys = new Discipline("Physics", 5, 8);
            var med = new Discipline("Medicine", 2, 18);

            var LDkiro = new List<Discipline>() { math, phys };
            var LDpesho = new List<Discipline>() { math, phys, med };

            var techerPesho = new Teacher("Pesho", LDpesho);
            var techerKiro = new Teacher("Kiro", LDkiro);

            techerPesho.Comment = "Imalo edno wreme.";
            gogo.Comment = "brrrrr";

            Console.WriteLine("Teacher Pesho coment : {0}", techerPesho.Comment);
            Console.WriteLine("Student gogo coment : {0}", gogo.Comment);
            Console.WriteLine();
            Console.WriteLine("Gogo class number : {0}", gogo.ClassNumber);
            Console.WriteLine();
            Console.WriteLine("Teacher Pesho disciplines:");

            foreach (var discipline in techerPesho.DisciplinesList)
            {
                Console.WriteLine(discipline.Identifier);
            }

            Console.WriteLine();

            var sudentsListA1 = new List<Student>();
            sudentsListA1.Add(gogo);
            sudentsListA1.Add(vania);

            var TeachersListA1 = new List<Teacher>();
            TeachersListA1.Add(techerPesho);

            var A1 = new SchoolClass("A1", sudentsListA1, TeachersListA1);

            var listOfClasses = new List<SchoolClass>();
            listOfClasses.Add(A1);

            var profIvanov = new School(listOfClasses);

            Console.WriteLine("Students of Professor Ivanov:");

            foreach (var student in profIvanov.SchoolClassList[0].StudentsList)
            {
                Console.WriteLine(student.Identifier);
            }

            Console.WriteLine();
        }
    }
}
