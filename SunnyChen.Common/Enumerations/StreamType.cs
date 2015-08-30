using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Enumerations
{
    /// <summary>
    /// Type of the stream.
    /// </summary>
    internal enum StreamType
    {
        /// <summary>
        /// String.
        /// </summary>
        stString,

        /// <summary>
        /// DataSet.
        /// </summary>
        stDataSet,

        /// <summary>
        /// Broadcast message.
        /// </summary>
        stBroadcast,

        /// <summary>
        /// Array of byte.
        /// </summary>
        stByteArray
    }
}
