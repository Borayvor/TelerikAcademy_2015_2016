namespace SchoolSystem.Contracts
{
    using EnumTypes;

    public interface IMark
    {
        SubjectType Subject { get; }

        float Value { get; }
    }
}
