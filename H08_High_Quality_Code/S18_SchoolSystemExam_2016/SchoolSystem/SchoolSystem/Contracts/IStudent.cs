namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;
    using EnumTypes;

    public interface IStudent : IPerson
    {
        int Id { get; }

        GradeType Grade { get; }

        IList<IMark> Marks { get; }

        string GetMarksAsStringList();
    }
}
