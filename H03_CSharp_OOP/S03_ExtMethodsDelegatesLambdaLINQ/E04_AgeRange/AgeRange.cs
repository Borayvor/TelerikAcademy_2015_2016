namespace E04_AgeRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using E03_FirstBeforeLast;

    public class AgeRange
    {
        public static void Main(string[] args)
        {
            // Write a LINQ query that finds the first name and last name of 
            // all students with age between 18 and 24.

            Console.WriteLine("FormEighteenToTwenty_four");
            FormEighteenToTwenty_four(StudentsList.students);
            Console.WriteLine();
        }


        public static void FormEighteenToTwenty_four(List<Student> students)
        {
            var newSudentsList =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;

            foreach (Student student in newSudentsList)
            {
                Console.WriteLine(student);
            }
        }
    }
}
