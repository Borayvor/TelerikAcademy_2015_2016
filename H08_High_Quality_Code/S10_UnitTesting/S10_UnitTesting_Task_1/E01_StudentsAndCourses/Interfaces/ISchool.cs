namespace E01_StudentsAndCourses.Interfaces
{
    using System.Collections.Generic;

    public interface ISchool
    {
        string SchoolName { get; }
        IList<ICourse> Courses { get; }

        void Add(ICourse course);
        void Remove(ICourse course);
    }
}
