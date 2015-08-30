using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu
{
    /// <summary>
    /// Defines the exception that can be thrown when it fails on validating the plug-in settings.
    /// </summary>
    public class InvalidSettingValueException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public InvalidSettingValueException()
            : base()
        {
        }

        /// <summary>
        /// The constructor that holds the exception message.
        /// </summary>
        /// <param name="_message">The exception error message.</param>
        public InvalidSettingValueException(string _message)
            : base(_message)
        {
        }

        /// <summary>
        /// The constructor that holds the exception message
        /// and inner exception.
        /// </summary>
        /// <param name="_message">The exception error message.</param>
        /// <param name="_innerException">The instance of inner exception.</param>
        public InvalidSettingValueException(string _message, Exception _innerException)
           : base(_message, _innerException)
        {
        }

        /// <summary>
        /// The constructor which provides serialization facilities.
        /// </summary>
        /// <param name="_info">Serialization information.</param>
        /// <param name="_context">Streaming context.</param>
        public InvalidSettingValueException(SerializationInfo _info, StreamingContext _context)
            : base(_info, _context)
        {
        }
    }
}
