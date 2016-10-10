namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for processing commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Process and execute command.
        /// </summary>
        /// <param name="parameters">Command parameters</param>
        /// <returns>Info for executed command as string.</returns>
        string Execute(IList<string> parameters);
    }
}
