using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common
{
    /// <summary>
    /// <para>The event argument that carries the exception information.</para>
    /// </summary>
    public class ExceptionEventArgs : System.EventArgs
    {
        #region Private Fields
        /// <summary>
        /// <para>The exception which is encapsulated within the argument.</para>
        /// </summary>
        private Exception exception__;
        #endregion
        #region Constructors
        /// <summary>
        /// <para>Default constructor.</para>
        /// </summary>
        public ExceptionEventArgs()
        {

        }
        /// <summary>
        /// <para>Parameterized constructor that handles the exception instance.</para>
        /// </summary>
        /// <param name="_exception">The exception instance that is going to be
        /// encapsulated within the event argument.</param>
        public ExceptionEventArgs(Exception _exception)
        {
            exception__ = _exception;
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// <para>Gets the exception instance that is going to be
        /// encapsulated within the event argument.</para>
        /// </summary>
        public Exception Exception
        {
            get { return exception__; }
        }
        #endregion
    }
}
