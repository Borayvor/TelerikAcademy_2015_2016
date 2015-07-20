namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string CourseName { get; }

        string TeacherName { get; set; }

        IList<string> Students { get; set; }
    }
}
