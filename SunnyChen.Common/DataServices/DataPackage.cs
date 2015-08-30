using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using SunnyChen.Common.Enumerations;

namespace SunnyChen.Common.DataServices
{
    /// <summary>
    /// Data package definition.
    /// </summary>
    [Serializable]
    internal sealed class DataPackage
    {
        #region Private Fields

        private StreamType streamType__ = StreamType.stString;
        private byte[] bytes__ = null;
        private ErrorLevel errorLevel__ = ErrorLevel.elOK;
        private int actualBufferLen__ = -1;

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataPackage()
        {
        }
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the type of stream.
        /// </summary>
        public StreamType StreamType
        {
            get { return streamType__; }
            set { streamType__ = value; }
        }

        /// <summary>
        /// Gets or sets the data package buffer.
        /// </summary>
        public byte[] Bytes
        {
            get { return bytes__; }
            set { bytes__ = value; }
        }

        /// <summary>
        /// Gets or sets the error level information.
        /// </summary>
        public ErrorLevel ErrorLevel
        {
            get { return errorLevel__; }
            set { errorLevel__ = value; }
        }

        /// <summary>
        /// Gets or sets the actual length of buffer to be sent or received.
        /// </summary>
        public int ActualBufferLength
        {
            get { return actualBufferLen__; }
            set { actualBufferLen__ = value; }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Serialize the specified object.
        /// </summary>
        /// <param name="_object">Object to be serialized.</param>
        /// <returns></returns>
        public static byte[] Serialize(object _object)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, _object);
            return memoryStream.GetBuffer();
        }

        /// <summary>
        /// Deserialize the specified object.
        /// </summary>
        /// <param name="_bytes">Bytes to be used for deserializing.</param>
        /// <returns></returns>
        public static object Deserialize(byte[] _bytes)
        {
            MemoryStream memoryStream = new MemoryStream(_bytes);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(memoryStream);
        }

        #endregion
    }
}
