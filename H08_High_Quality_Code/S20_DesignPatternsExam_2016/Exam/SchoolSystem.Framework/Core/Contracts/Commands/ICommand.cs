﻿namespace SchoolSystem.Framework.Core.Contracts.Commands
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a command that can be loaded by the parser.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command with the passed parameters.
        /// </summary>
        /// <param name="parameters">Parameters to execute the command with.</param>
        /// <returns>Returns execution result message.</returns>
        string Execute(IList<string> parameters);
    }
}
