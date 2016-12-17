namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for a Parser provider
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses a command from string to derivable of ICommand.
        /// </summary>
        /// <param name="fullCommand">The command to parse.</param>
        /// <param name="db">The data bese instance.</param>
        /// <returns>Returns new instance of the given command.</returns>
        ICommand ParseCommand(string fullCommand, IDataBase db);

        /// <summary>
        /// Parses the parameters of a command.
        /// </summary>
        /// <param name="fullCommand">The command to parse.</param>
        /// <returns>Returns an IList<string> collection of parameters.</returns>
        IList<string> ParseParameters(string fullCommand);
    }
}
