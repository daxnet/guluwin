using System;
using System.Collections.Generic;
using System.Text;

using SunnyChen.Common.Enumerations;

namespace SunnyChen.Common.Network
{
    /// <summary>
    /// Data response result.
    /// </summary>
    /// <typeparam name="ResultType">Type of the result.</typeparam>
    public class ResponseResultGeneric<ResultType>
    {
        private ResultType result__ = default(ResultType);
        private ErrorLevel errorLevel__ = ErrorLevel.elException;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// The ErrorLevel of the result will be default to Exception while using the default constructor 
        /// to create the instance of the class. Please see <see cref="SunnyChen.Common.Enumerations.ErrorLevel"/> for 
        /// the error levels.
        /// </remarks>
        public ResponseResultGeneric()
        {
        }

        /// <summary>
        /// Initializes the instance by the result and the error level.
        /// </summary>
        /// <param name="_result">The response result.</param>
        /// <param name="_errorLevel">The error level. Please see <see cref="SunnyChen.Common.Enumerations.ErrorLevel"/> for 
        /// the error levels.</param>
        public ResponseResultGeneric(ResultType _result, ErrorLevel _errorLevel)
        {
            result__ = _result;
            errorLevel__ = _errorLevel;
        }

        /// <summary>
        /// Gets the result of the response.
        /// </summary>
        public ResultType Result
        {
            get { return result__; }
            set { result__ = value; }
        }

        /// <summary>
        /// Gets the error level code of the response.
        /// </summary>
        public ErrorLevel ErrorLevel
        {
            get { return errorLevel__; }
            set { errorLevel__ = value; }
        }

    }
}
