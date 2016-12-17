namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Interface for Person model.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// First name of the person.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Last name of the person.
        /// </summary>
        string LastName { get; }
    }
}
