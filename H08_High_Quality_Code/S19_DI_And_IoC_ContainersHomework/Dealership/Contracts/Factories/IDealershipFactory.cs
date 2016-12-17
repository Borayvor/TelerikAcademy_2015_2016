namespace Dealership.Contracts.Factories
{
    public interface IDealershipFactory
    {
        IUser CreateUser(string username, string firstName, string lastName, string password, string role);

        IComment CreateComment(string content);
    }
}
