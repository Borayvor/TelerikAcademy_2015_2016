namespace SchoolSystem.Framework.Core.Contracts.Factories
{
    using Models.Contracts;
    using Models.Enums;

    public interface ITeacherFactory
    {
        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);
    }
}
