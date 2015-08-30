using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Data;

using SunnyChen.Common.DataServices;
using SunnyChen.Common.Enumerations;

namespace SunnyChen.Common.Network
{
    /// <summary>
    /// Provides data communication and error response handling for SOCKET oriented connections.
    /// </summary>
    /// <example>
    /// Following example demonstrates the usage of NetworkCommunicator. In this demonstration, 
    /// the NetworkCommunicator sends a space-separated command string to the server and gets the 
    /// result which is encapsulated in a <see cref="SunnyChen.Common.Network.ResponseResultGeneric&lt;ResultType&gt;"/> object 
    /// from the server.
    /// <code>
    /// public ErrorLevel GetServerResponse(Socket _client, string _command, out string _result)
    /// {
    ///     NetworkCommunicator communicator = new NetworkCommunicator(_client);
    ///     communicator.Send(_command);
    ///     ResponseResultGeneric&lt;string&gt; result = communicator.ReceiveString();
    ///     _result = result.Result;
    ///     return result.ErrorLevel;
    /// }
    /// </code>
    /// </example>
    public class NetworkCommunicator
    {
        #region Private Fields

        /// <summary>
        /// 
        /// </summary>
        private Socket socket__ = null;
        /// <summary>
        /// 
        /// </summary>
        private ulong totalBytesSent__ = 0;
        /// <summary>
        /// 
        /// </summary>
        private ulong totalBytesRec__ = 0;


        private string name__ = string.Empty;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates the NetworkCommunicator instance with the specified Socket object. 
        /// </summary>
        /// <param name="_socket">The Socket object.</param>
        public NetworkCommunicator(Socket _socket)
        {
            socket__ = _socket;

            //socket__.SendBufferSize = 512 * 1024;
            //socket__.ReceiveBufferSize = 512 * 1024;

            //name__ = DataServices.DataUtility.GetRandomString(12);
        }

        /// <summary>
        /// Creates the named NetworkCommunicator instance with the specified Socket object.
        /// </summary>
        /// <param name="_socket">The Socket object.</param>
        /// <param name="_name">The name that gives to the NetworkCommunicator instance.</param>
        public NetworkCommunicator(Socket _socket, string _name)
        {
            socket__ = _socket;
            name__ = _name;
        }
        #endregion

        #region Public Delegates and Events

        /// <summary>
        /// Represents the method that will handle an event that has a <see cref="System.Exception"/> argument.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="SunnyChen.Common.ExceptionEventArgs"/> that contains the exception information.</param>
        public delegate void CommunicationExceptionEventHandler(object sender, ExceptionEventArgs e);

        /// <summary>
        /// Occurs when an exception raises during the network communication.
        /// </summary>
        public event CommunicationExceptionEventHandler CommunicationException;

        /// <summary>
        /// Occurs before the data is going to be sent.
        /// </summary>
        public event EventHandler BeforeSend;

        /// <summary>
        /// Occurs after the data has been sent.
        /// </summary>
        public event EventHandler AfterSend;

        /// <summary>
        /// Occurs before the data is going to be received.
        /// </summary>
        public event EventHandler BeforeReceive;

        /// <summary>
        /// Occurs after the data has been received.
        /// </summary>
        public event EventHandler AfterReceive;

        #endregion

        #region Protected Methods

        /// <summary>
        /// The internal event handler that handles the <see cref="CommunicationException"/> event.
        /// </summary>
        /// <param name="e">The source of the event.</param>
        protected virtual void OnCommunicationException(ExceptionEventArgs e)
        {
            if (CommunicationException != null)
            {
                CommunicationException(this, e);
            }
        }

        /// <summary>
        /// The internal event handler that handles the <see cref="BeforeSend"/> event.
        /// </summary>
        /// <param name="e">The source of the event.</param>
        protected virtual void OnBeforeSend(System.EventArgs e)
        {
            if (BeforeSend != null)
            {
                
                BeforeSend(this, e);
            }
        }

        /// <summary>
        /// The internal event handler that handles the <see cref="AfterSend"/> event.
        /// </summary>
        /// <param name="e">The source of the event.</param>
        protected virtual void OnAfterSend(System.EventArgs e)
        {
            if (AfterSend != null)
            {
                AfterSend(this, e);
            }
        }

        /// <summary>
        /// The internal event handler that handles the <see cref="BeforeReceive"/> event.
        /// </summary>
        /// <param name="e">The source of the event.</param>
        protected virtual void OnBeforeReceive(System.EventArgs e)
        {
            if (BeforeReceive != null)
            {
                BeforeReceive(this, e);
            }
        }

        /// <summary>
        /// The internal event handler that handles the <see cref="AfterReceive"/> event.
        /// </summary>
        /// <param name="e">The source of the event.</param>
        protected virtual void OnAfterReceive(System.EventArgs e)
        {
            if (AfterReceive != null)
            {
                AfterReceive(this, e);
            }
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the bytes sent to the connected socket.
        /// </summary>
        public ulong BytesSent
        {
            get { return totalBytesSent__; }
        }

        /// <summary>
        /// Gets the bytes received from the connected socket.
        /// </summary>
        public ulong BytesReceived
        {
            get { return totalBytesRec__; }
        }

        /// <summary>
        /// Gets the remote connected endpoint.
        /// </summary>
        public EndPoint RemoteEndPoint
        {
            get { return socket__.RemoteEndPoint; }
        }

        /// <summary>
        /// Gets the local endpoint.
        /// </summary>
        public EndPoint LocalEndPoint
        {
            get { return socket__.LocalEndPoint; }
        }

        /// <summary>
        /// Gets the name of the communicator.
        /// </summary>
        public string Name
        {
            get { return name__; }
        }

        #endregion

        #region Public Static Methods
        /// <summary>
        /// The static method that sends specific bytes to a connected socket.
        /// </summary>
        /// <param name="socket">The connected socket to which the data is going to be sent.</param>
        /// <param name="buffer">The byte array in which the data is going to be sent.</param>
        /// <param name="offset">Zero-based index value. It determines from which byte of the array should be sent.</param>
        /// <param name="size">Number of bytes to send.</param>
        /// <param name="timeout">An integer timeout value.</param>
        public static void Send(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int sent = 0;  // how many bytes is already sent
            do
            {
                //if (timeout > 0)
                //{
                //    if (Environment.TickCount > startTickCount + timeout)
                //        throw new Exception("Timeout.");
                //}
                try
                {
                    sent += socket.Send(buffer, offset + sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably full, wait and try again
                        //System.Threading.Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurs
                }
            } while (sent < size);
        }

        /// <summary>
        /// The static method that receives specific bytes from a connected socket.
        /// </summary>
        /// <param name="socket">The connected socket from which the data is being received.</param>
        /// <param name="buffer">The byte array from which the data is being received.</param>
        /// <param name="offset">Zero-based index value. It determines from which byte of the array that the received data should be stored.</param>
        /// <param name="size">Number of bytes to receive.</param>
        /// <param name="timeout">An integer timeout value.</param>
        public static void Receive(Socket socket, byte[] buffer, int offset, int size, int timeout)
        {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received
            do
            {
                //if (timeout > 0)
                //{
                //    if (Environment.TickCount > startTickCount + timeout)
                //        throw new Exception("Timeout.");
                //}
                try
                {
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        // socket buffer is probably empty, wait and try again
                        //System.Threading.Thread.Sleep(30);
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            } while (received < size);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends a specified string with the error level information.
        /// </summary>
        /// <param name="_str">String to be sent.</param>
        /// <param name="_errorLevel">Error level information.</param>
        /// <returns>
        /// This function has the following return values.
        /// <list type="table">
        /// <listheader><term>Return Value</term><description>Description</description></listheader>
        /// <item><term>0</term><description>Succeeded</description></item>
        /// <item><term>-1</term><description>Exception occurred</description></item>
        /// </list>
        /// </returns>
        public int Send(string _str, ErrorLevel _errorLevel)
        {
            try
            {
                OnBeforeSend(null);
                DataPackage dp = new DataPackage();
                dp.Bytes = Encoding.ASCII.GetBytes(_str);
                dp.ActualBufferLength = _str.Length;
                dp.ErrorLevel = _errorLevel;
                dp.StreamType = StreamType.stString;

                byte[] serialized = DataPackage.Serialize((DataPackage)dp);

                int requestLen = serialized.Length;
                int requestLen_Host2NetworkOrder = IPAddress.HostToNetworkOrder(requestLen);
                byte[] requestLen_Host2NetworkOrder_Array = BitConverter.GetBytes(requestLen_Host2NetworkOrder);

                Send(socket__, requestLen_Host2NetworkOrder_Array, 0, 4, 0);

                Send(socket__, serialized, 0, requestLen, 0);

                return 0;
            }
            catch (Exception ex)
            {
                this.OnCommunicationException(new ExceptionEventArgs(ex));
                return -1;
            }
            finally
            {
                OnAfterSend(null);
            }
        }

        /// <summary>
        /// Sends a specified DataSet object with error level information.
        /// </summary>
        /// <param name="_dataSet">DataSet object to be sent.</param>
        /// <param name="_errorLevel">Error level information.</param>
        /// <returns>Zero on success.</returns>
        public int Send(DataSet _dataSet, ErrorLevel _errorLevel)
        {
            try
            {
                OnBeforeSend(null);
                DataPackage dp = new DataPackage();
                dp.Bytes = DataPackage.Serialize((DataSet)_dataSet);
                dp.ActualBufferLength = dp.Bytes.Length;
                dp.ErrorLevel = _errorLevel;
                dp.StreamType = StreamType.stDataSet;

                byte[] serialized = DataPackage.Serialize((DataPackage)dp);

                int requestLen = serialized.Length;
                int requestLen_Host2NetworkOrder = IPAddress.HostToNetworkOrder(requestLen);
                byte[] requestLen_Host2NetworkOrder_Array = BitConverter.GetBytes(requestLen_Host2NetworkOrder);

                Send(socket__, requestLen_Host2NetworkOrder_Array, 0, 4, 0);

                Send(socket__, serialized, 0, requestLen, 0);

                return 0;
            }
            catch (Exception ex)
            {
                this.OnCommunicationException(new ExceptionEventArgs(ex));
                return -1;
            }
            finally
            {
                OnAfterSend(null);
            }
        }

        /// <summary>
        /// Sends the specified bytes with error level information.
        /// </summary>
        /// <param name="_bytes">Bytes to be sent.</param>
        /// <param name="_errorLevel">Error level information.</param>
        /// <returns>Zero on success.</returns>
        public int Send(byte[] _bytes, ErrorLevel _errorLevel)
        {
            try
            {
                OnBeforeSend(null);
                DataPackage dp = new DataPackage();
                dp.Bytes = _bytes;
                dp.ActualBufferLength = _bytes.Length;
                dp.ErrorLevel = _errorLevel;
                dp.StreamType = StreamType.stByteArray;

                byte[] serialized = DataPackage.Serialize((DataPackage)dp);

                int requestLen = serialized.Length;
                int requestLen_Host2NetworkOrder = IPAddress.HostToNetworkOrder(requestLen);
                byte[] requestLen_Host2NetworkOrder_Array = BitConverter.GetBytes(requestLen_Host2NetworkOrder);

                Send(socket__, requestLen_Host2NetworkOrder_Array, 0, 4, 0);

                Send(socket__, serialized, 0, requestLen, 0);

                return 0;
            }
            catch (Exception ex)
            {
                this.OnCommunicationException(new ExceptionEventArgs(ex));
                return -1;
            }
            finally
            {
                OnAfterSend(null);
            }
        }


        /// <summary>
        /// Sends a specified string.
        /// </summary>
        /// <param name="_str">String to be sent.</param>
        /// <returns>Zero on success.</returns>
        public int Send(string _str)
        {
            return this.Send(_str, ErrorLevel.elOK);
        }

        /// <summary>
        /// Sends a specified DataSet object.
        /// </summary>
        /// <param name="_dataSet">DataSet object to be sent.</param>
        /// <returns>Zero on success.</returns>
        public int Send(DataSet _dataSet)
        {
            return this.Send(_dataSet, ErrorLevel.elOK);
        }

        /// <summary>
        /// Sends the specified bytes.
        /// </summary>
        /// <param name="_bytes">Bytes to be sent.</param>
        /// <returns>Zero on success.</returns>
        public int Send(byte[] _bytes)
        {
            return this.Send(_bytes, ErrorLevel.elOK);
        }

        /// <summary>
        /// Receives a string from remote.
        /// </summary>
        /// <returns>String received.</returns>
        public ResponseResultGeneric<string> ReceiveString()
        {
            try
            {
                OnBeforeReceive(null);
                byte[] requestLen_Host2NetworkOrder_Array = new byte[4];

                Receive(socket__, requestLen_Host2NetworkOrder_Array, 0, 4, 0);

                int requestLen_Host2NetworkOrder = BitConverter.ToInt32(requestLen_Host2NetworkOrder_Array, 0);

                int requestLen = IPAddress.NetworkToHostOrder(requestLen_Host2NetworkOrder);

                byte[] finalBytesReceive = new byte[requestLen];

                Receive(socket__, finalBytesReceive, 0, requestLen, 0);

                DataPackage dp = (DataPackage)DataPackage.Deserialize(finalBytesReceive);
                if (dp.StreamType == StreamType.stString)
                {
                    string ret = Encoding.ASCII.GetString(dp.Bytes, 0, dp.ActualBufferLength);
                    ResponseResultGeneric<string> result = new ResponseResultGeneric<string>();
                    result.Result = ret;
                    result.ErrorLevel = dp.ErrorLevel;
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                this.OnCommunicationException(new ExceptionEventArgs(ex));
                return null;
            }
            finally
            {
                OnAfterReceive(null);
            }
        }

        /// <summary>
        /// Receives a DataSet object from remote.
        /// </summary>
        /// <returns>Received DataSet object.</returns>
        public ResponseResultGeneric<DataSet> ReceiveDataSet()
        {
            try
            {
                OnBeforeReceive(null);
                byte[] requestLen_Host2NetworkOrder_Array = new byte[4];

                Receive(socket__, requestLen_Host2NetworkOrder_Array, 0, 4, 0);

                int requestLen_Host2NetworkOrder = BitConverter.ToInt32(requestLen_Host2NetworkOrder_Array, 0);

                int requestLen = IPAddress.NetworkToHostOrder(requestLen_Host2NetworkOrder);

                byte[] finalBytesReceive = new byte[requestLen];

                Receive(socket__, finalBytesReceive, 0, requestLen, 0);

                DataPackage dp = (DataPackage)DataPackage.Deserialize(finalBytesReceive);
                if (dp.StreamType == StreamType.stDataSet)
                {
                    ResponseResultGeneric<DataSet> result = new ResponseResultGeneric<DataSet>();
                    result.Result = (DataSet)DataPackage.Deserialize(dp.Bytes);
                    result.ErrorLevel = dp.ErrorLevel;
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                this.OnCommunicationException(new ExceptionEventArgs(ex));
                return null;
            }
            finally
            {
                OnAfterReceive(null);
            }
        }

        /// <summary>
        /// Receives the byte array from remote.
        /// </summary>
        /// <returns>Received bytes.</returns>
        public ResponseResultGeneric<byte[]> ReceiveByteArray()
        {
            try
            {
                OnBeforeReceive(null);
                byte[] requestLen_Host2NetworkOrder_Array = new byte[4];

                Receive(socket__, requestLen_Host2NetworkOrder_Array, 0, 4, 0);

                int requestLen_Host2NetworkOrder = BitConverter.ToInt32(requestLen_Host2NetworkOrder_Array, 0);

                int requestLen = IPAddress.NetworkToHostOrder(requestLen_Host2NetworkOrder);

                byte[] finalBytesReceive = new byte[requestLen];

                Receive(socket__, finalBytesReceive, 0, requestLen, 0);

                DataPackage dp = (DataPackage)DataPackage.Deserialize(finalBytesReceive);
                if (dp.StreamType == StreamType.stByteArray)
                {
                    ResponseResultGeneric<byte[]> result = new ResponseResultGeneric<byte[]>();
                    result.Result = dp.Bytes;
                    result.ErrorLevel = dp.ErrorLevel;
                    return result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                this.OnCommunicationException(new ExceptionEventArgs(ex));
                return null;
            }
            finally
            {
                OnAfterReceive(null);
            }
        }

        #endregion
    }
}
