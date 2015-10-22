namespace UniversitySystem.ConsoleCl
{
    using System;
    using Data;
    using Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            //// connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=UniversitySystem;Integrated Security=true;"

            var db = new UniversityDbContext();

            var student = new Student()
            {
                Name = "Pesho Peshev",
                Number = 123456789
            };

            db.Students.Add(student);
            db.SaveChanges();

            Console.WriteLine("Student was added to the database.");

            //var savedStudent = db.Students.First();
            //db.Students.Remove(savedStudent);
            //db.SaveChanges();
            //Console.WriteLine("Student was removed from the database.");
        }
    }
}
