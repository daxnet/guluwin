using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Servers
{
    /// <summary>
    /// Defines the attributes and methods for the server commands.
    /// </summary>
    public interface IServerCommand
    {
        /// <summary>
        /// Gets an integer identifier that identifies the current server command.
        /// </summary>
        int CommandIdentifier { get;}
        /// <summary>
        /// Executes the command by using the parameter.
        /// </summary>
        /// <param name="_parameter">The parameter to be used to execute the server command.</param>
        void Execute(CommandParameter _parameter);
    }
}
