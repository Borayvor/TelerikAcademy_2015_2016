namespace SchoolSystem.Contracts
{
    using EnumTypes;

    public interface ITeacher : IPerson
    {
        int Id { get; }

        SubjectType Subject { get; }

        void AddMarkToStudent(IStudent student, IMark mark);
    }
}
