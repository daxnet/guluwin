using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SunnyChen.Common
{
    /// <summary>
    /// Throws when a plug-in encounters errors or exceptions.
    /// </summary>
    public class PluginException : Exception
    {
        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PluginException()
            : base()
        {
        }

        /// <summary>
        /// The constructor that holds the exception message.
        /// </summary>
        /// <param name="_message">The exception error message.</param>
        public PluginException(string _message)
            : base(_message)
        {
        }

        /// <summary>
        /// The constructor that holds the exception message
        /// and inner exception.
        /// </summary>
        /// <param name="_message">The exception error message.</param>
        /// <param name="_innerException">The instance of inner exception.</param>
        public PluginException(string _message, Exception _innerException)
           : base(_message, _innerException)
        {
        }

        /// <summary>
        /// The constructor which provides serialization facilities.
        /// </summary>
        /// <param name="_info">Serialization information.</param>
        /// <param name="_context">Streaming context.</param>
        public PluginException(SerializationInfo _info, StreamingContext _context)
            : base(_info, _context)
        {
        }
        #endregion
    }
}
