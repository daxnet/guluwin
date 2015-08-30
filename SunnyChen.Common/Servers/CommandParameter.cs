using System;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Servers
{
    /// <summary>
    /// The declaration and definition for the default command parameters that can be recognized by
    /// the server application which was implementing the <see cref="SunnyChen.Common.Servers.ConcurrencyServerBase"/> class.
    /// </summary>
    public class CommandParameter
    {
        #region Protected Fields
        /// <summary>
        /// The command string that is going to be interpreted by the server application.
        /// </summary>
        protected string commandString__;
        /// <summary>
        /// The client socket which was connected to the server application.
        /// </summary>
        protected Socket currentSocket__;
        /// <summary>
        /// The running thread that handles the working logic for the current connected client.
        /// </summary>
        protected Thread currentThread__;
        /// <summary>
        /// The loggging writer.
        /// </summary>
        [Obsolete("This field is now obsolete. Using logging functionality that was provided by Microsoft Patterns & Practices.")]
        protected object logWriter__;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor that constructs a instance of <see cref="SunnyChen.Common.Servers.CommandParameter"/>.
        /// </summary>
        public CommandParameter()
        {
        }

        /// <summary>
        /// Parameterized constructor which initializes the field by specific parameters.
        /// </summary>
        /// <param name="_commandString">The command string that is going to be interpreted by the server application.</param>
        /// <param name="_currentSocket">The client socket which was connected to the server application.</param>
        /// <param name="_currentThread">The running thread that handles the working logic for the current connected client.</param>
        /// <param name="_logWriter">The loggging writer.</param>
        /// <remarks>
        /// The last parameter _logWriter is obsolete, but you still need to pass an object to this parameter.
        /// Use null here if you don't need to create an instance.
        /// </remarks>
        public CommandParameter(string _commandString,
            Socket _currentSocket,
            Thread _currentThread,
            object _logWriter)
        {
            commandString__ = _commandString;
            currentSocket__ = _currentSocket;
            currentThread__ = _currentThread;
            logWriter__ = _logWriter;
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the command string that is going to be interpreted by the server application.
        /// </summary>
        public string CommandString
        {
            get { return commandString__; }
            set { commandString__ = value; }
        }

        /// <summary>
        /// Gets the client socket which was connected to the server application.
        /// </summary>
        public Socket CurrentSocket
        {
            get { return currentSocket__; }
            set { currentSocket__ = value; }
        }

        /// <summary>
        /// Gets the running thread that handles the working logic for the current connected client.
        /// </summary>
        public Thread CurrentThread
        {
            get { return currentThread__; }
            set { currentThread__ = value; }
        }

        /// <summary>
        /// Gets the loggging writer.
        /// </summary>
        [Obsolete("This field is now obsolete. Using logging functionality that was provided by Microsoft Patterns & Practices.")]
        public object LogWriter
        {
            get { return logWriter__; }
            set { logWriter__ = value; }
        }

        #endregion
    }
}
