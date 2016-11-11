namespace Dealership.Contracts.Factories
{
    using Commands;

    public interface ICommandFactory
    {
        ICommand CreateCommands();
    }
}
