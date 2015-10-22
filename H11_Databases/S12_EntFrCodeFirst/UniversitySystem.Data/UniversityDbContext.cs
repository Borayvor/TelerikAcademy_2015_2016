namespace UniversitySystem.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
            : base("UniversityDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversityDbContext, Configuration>());
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}
