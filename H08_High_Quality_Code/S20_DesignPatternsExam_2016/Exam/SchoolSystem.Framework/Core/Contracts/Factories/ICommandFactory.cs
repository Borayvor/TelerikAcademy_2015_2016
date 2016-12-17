namespace SchoolSystem.Framework.Core.Contracts.Factories
{
    using System;
    using Commands;

    public interface ICommandFactory
    {
        ICommand GetCommand(Type type);
    }
}
