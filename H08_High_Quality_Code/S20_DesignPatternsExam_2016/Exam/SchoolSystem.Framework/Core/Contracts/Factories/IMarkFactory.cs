namespace SchoolSystem.Framework.Core.Contracts.Factories
{
    using Models.Contracts;
    using Models.Enums;

    public interface IMarkFactory
    {
        IMark CreateMark(Subject subject, float value);
    }
}
