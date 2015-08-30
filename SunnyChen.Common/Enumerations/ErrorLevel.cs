using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Enumerations
{
    /// <summary>
    /// Error levels.
    /// </summary>
    public enum ErrorLevel
    {
        /// <summary>
        /// OK
        /// </summary>
        elOK,

        /// <summary>
        /// Warning
        /// </summary>
        elWarning,

        /// <summary>
        /// Error
        /// </summary>
        elError,

        /// <summary>
        /// Critical
        /// </summary>
        elCritical,

        /// <summary>
        /// Exception
        /// </summary>
        elException,

        /// <summary>
        /// Fatal
        /// </summary>
        elFatal
    }
}
