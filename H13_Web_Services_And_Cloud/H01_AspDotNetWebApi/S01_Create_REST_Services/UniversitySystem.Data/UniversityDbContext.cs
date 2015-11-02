namespace UniversitySystem.Data
{
    using System.Data.Entity;
    using Models;

    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
            : base("UniversityDatabase")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public static UniversityDbContext Create()
        {
            return new UniversityDbContext();
        }
    }
}
