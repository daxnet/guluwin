using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Servers
{
    /// <summary>
    /// The base class for concurrency servers.
    /// </summary>
    /// <remarks>
    /// All the SOCKET-based concurrency server implementations should inherit from this ConcurrencyServerBase class.
    /// Concurrency servers are very suitable for small-scaled server application implementation, however for large
    /// mission critical server applications it is not recommend use the concurrency servers. For more information about
    /// concurrency servers and server implementations please refer to POSA volume 2, "Patterns for Concurrency and Network Objects".
    /// </remarks>
    /// <example>
    /// Following code illustrates an implementation of the file server.
    /// <code>
    /// public class FileServer : ConcurrencyServerBase
    /// {
    ///     public FileServer(int _port)
    ///         : base(_port, Assembly.GetExecutingAssembly())
    ///     {
    ///         
    ///     }
    ///     
    ///     public FileServer(int _port, Assembly _assembly)
    ///         : base(_port, _assembly)
    ///     {
    ///     
    ///     }
    ///     
    ///     public override int Start()
    ///     {
    ///         // Put server starting code here.
    ///         return 0;
    ///     }
    ///     
    ///     public override int Stop()
    ///     {
    ///         // Put server stopping code here.
    ///         return 0;
    ///     }
    ///     
    ///     protected override void WorkerThread(object parameters)
    ///     {
    ///         // Put worker thread processing logic here.
    ///     }
    ///     
    ///     protected override ThreadPriority WorkerThreadPriority
    ///     {
    ///         get { return ThreadPriority.Normal; }
    ///     }
    /// }
    /// </code>
    /// </example>
    public abstract class ConcurrencyServerBase : IServer, IDisposable
    {
        #region Private Fields

        private bool alreadyDisposed__ = false;
        private Hashtable serverCommands__ = new Hashtable();
        private IList<Socket> connectedClients__ = new List<Socket>();
        private IList<Thread> workerThreads__ = new List<Thread>();
        private Thread serverThread__;
        private IPEndPoint endpoint__;
        private TcpListener listener__;
        private Assembly commandAssembly__;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the concurrency server by specified TCP connection port and the
        /// assembly that contains the definition for the server commands.
        /// </summary>
        /// <param name="_port">The TCP connection port to which the server listens.</param>
        /// <param name="_commandAssembly">The assembly that contains the definition for the server commands.</param>
        public ConcurrencyServerBase(int _port, Assembly _commandAssembly)
        {
            //endpoint__ = new IPEndPoint(Dns.GetHostAddresses("localhost")[0], _port);
            endpoint__ = new IPEndPoint(IPAddress.Any, _port);
            listener__ = new TcpListener(endpoint__);
            commandAssembly__ = _commandAssembly;
        }
        /// <summary>
        /// Destructor which disposes the concurrency server.
        /// </summary>
        ~ConcurrencyServerBase()
        {
            Dispose(true);
        }
        #endregion

        #region Protected Properties

        /// <summary>
        /// Gets the registered server commands.
        /// </summary>
        protected Hashtable ServerCommands
        {
            get { return serverCommands__; }
        }

        /// <summary>
        /// Gets the connected clients.
        /// </summary>
        protected IList<Socket> ConnectedClients
        {
            get { return connectedClients__; }
        }

        /// <summary>
        /// Gets the worker thread pool.
        /// </summary>
        protected IList<Thread> WorkerThreads
        {
            get { return workerThreads__; }
        }

        /// <summary>
        /// Gets the running server thread.
        /// </summary>
        protected Thread ServerThread
        {
            get { return serverThread__; }
        }

        /// <summary>
        /// Gets the server end point
        /// </summary>
        protected IPEndPoint ServerEndPoint
        {
            get { return endpoint__; }
        }

        /// <summary>
        /// Gets the listener.
        /// </summary>
        protected TcpListener ServerListener
        {
            get { return listener__; }
        }

        /// <summary>
        /// Gets the assembly that holds the server commands.
        /// </summary>
        protected Assembly CommandAssembly
        {
            get { return commandAssembly__; }
        }

        /// <summary>
        /// Gets the priority of the worker thread.
        /// </summary>
        protected abstract ThreadPriority WorkerThreadPriority { get;}

        #endregion

        #region Delegates and Events
        /// <summary>
        /// Occurs before the server starts.
        /// </summary>
        public event EventHandler BeforeStart;
        /// <summary>
        /// Occurs after the server has started.
        /// </summary>
        public event EventHandler AfterStart;
        /// <summary>
        /// Occurs before the server stops.
        /// </summary>
        public event EventHandler BeforeStop;
        /// <summary>
        /// Occurs after the server has stopped.
        /// </summary>
        public event EventHandler AfterStop;

        #endregion

        #region Private Methods

        /// <summary>
        /// Register all the server commands existing in the specified assembly.
        /// </summary>
        private void RegisterServerCommands()
        {
            // Clear the registered command for it
            // will raise exception if we are going
            // to register the command more than once.
            serverCommands__.Clear();

            // Finds all the commands in the specified assembly
            // and registers them in the hashtable.
            foreach (Type type in commandAssembly__.GetTypes())
            {
                if (type.IsClass && type.GetInterface("SunnyChen.Common.Servers.IServerCommand") != null)
                {
                    IServerCommand command = (IServerCommand)Activator.CreateInstance(type);
                    serverCommands__.Add(command.CommandIdentifier, command);
                }
            }
        }

        /// <summary>
        /// Main server thread.
        /// </summary>
        private void ServerThreadProc()
        {
            try
            {
                ParameterizedThreadStart threadStart = new ParameterizedThreadStart(WorkerThread);

                listener__.Start();

                while (true)
                {
                    // Accept the client socket
                    Socket clientSocket = listener__.AcceptSocket();
                    //clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    //clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                    //clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.DontLinger, true);

                    // Registers the connected client socket in the pool
                    connectedClients__.Add(clientSocket);

                    // Starts the worker thread for further processing
                    // and registers the thread in the list
                    Thread thread = new Thread(threadStart);
                    workerThreads__.Add(thread);

                    thread.Priority = this.WorkerThreadPriority;

                    thread.Start(clientSocket);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Protected Methods
        /// <summary>
        /// Worker thread to do the further processing on the connection (abstract).
        /// </summary>
        /// <param name="parameters">The parameter, always the type of <see cref="System.Sockets.Socket"/>.</param>
        protected abstract void WorkerThread(object parameters);
        /// <summary>
        /// The disposing procedure that stops the running server and releases the resources.
        /// </summary>
        /// <param name="isDisposing">true to release both managed and unmanaged resources; false to release only
        /// unmanaged resources.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (alreadyDisposed__)
                return;
            if (isDisposing)
            {
                this.Stop();
            }
            alreadyDisposed__ = true;
        }

        #region Protected Event Handlers

        /// <summary>
        /// Called before the server starts.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected virtual void OnBeforeStart(System.EventArgs e)
        {
            if (BeforeStart != null)
            {
                this.BeforeStart(this, e);
            }
        }

        /// <summary>
        /// Called after the server has started.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected virtual void OnAfterStart(System.EventArgs e)
        {
            if (AfterStart != null)
            {
                this.AfterStart(this, e);
            }
        }

        /// <summary>
        /// Called before the server stops.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected virtual void OnBeforeStop(System.EventArgs e)
        {
            if (BeforeStop != null)
            {
                this.BeforeStop(this, e);
            }
        }

        /// <summary>
        /// Called after the server has stopped.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected virtual void OnAfterStop(System.EventArgs e)
        {
            if (AfterStop != null)
            {
                this.AfterStop(this, e);
            }
        }
        #endregion

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Gets the identifier of the command.
        /// </summary>
        /// <param name="_commandString">The command string.</param>
        /// <returns>Identifier of the command.</returns>
        public static int GetCommandIdentifier(string _commandString)
        {
            try
            {
                return Convert.ToInt32(_commandString.Split(' ')[0]);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Formats a command with the identifier and its parts.
        /// </summary>
        /// <param name="_commandIdentifier">Command identifier.</param>
        /// <param name="_commandParts">Command parts.</param>
        /// <returns>The formatted command string.</returns>
        public static string FormatCommand(int _commandIdentifier, params string[] _commandParts)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string commandPart in _commandParts)
            {
                sb.Append(" ");
                sb.Append(commandPart);
            }
            return string.Format("{0}{1}", _commandIdentifier, sb.ToString());
        }

        /// <summary>
        /// Formats a command with the identifier and its body.
        /// </summary>
        /// <param name="_commandIdentifier">Command identifier.</param>
        /// <param name="_commandString">Command body.</param>
        /// <returns>The formatted command string.</returns>
        public static string FormatCommand(int _commandIdentifier, string _commandString)
        {
            return string.Format("{0} {1}", _commandIdentifier, _commandString);
        }

        #endregion

        #region IServer Members

        /// <summary>
        /// Starts the server thread.
        /// </summary>
        /// <returns>Zero if it starts successfully, otherwise, false.</returns>
        public virtual int Start()
        {
            try
            {
                this.OnBeforeStart(System.EventArgs.Empty);

                this.RegisterServerCommands();
                serverThread__ = new Thread(ServerThreadProc);
                serverThread__.Start();

                this.OnAfterStart(System.EventArgs.Empty);

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Pauses the running server thread.
        /// </summary>
        /// <returns>Zero if the server has been paused successfully, otherwise, false.</returns>
        [Obsolete("Do not use the Pause method on the server, it has not been implemented yet.", true)]
        public virtual int Pause()
        {
            serverThread__.Suspend();
            return 0;
        }

        /// <summary>
        /// Stops the running server thread.
        /// </summary>
        /// <returns>Zero if the server stops normally, otherwise, false.</returns>
        public virtual int Stop()
        {
            try
            {
                this.OnBeforeStop(System.EventArgs.Empty);

                for (int i = 0; i < connectedClients__.Count; i++)
                {
                    Socket socket = connectedClients__[i];
                    if (socket != null)
                    {
                        if (socket.Connected)
                        {
                            socket.Shutdown(SocketShutdown.Both);
                            socket.Disconnect(true);
                        }
                        socket.Close();
                        socket = null;
                    }
                }

                for (int i = 0; i < workerThreads__.Count; i++)
                {
                    Thread workerThread = workerThreads__[i];
                    if (workerThread != null)
                    {
                        if (workerThread.ThreadState != ThreadState.Aborted &&
                            workerThread.ThreadState != ThreadState.AbortRequested &&
                            workerThread.ThreadState != ThreadState.Unstarted)
                        {
                            workerThread.Abort();
                        }
                        workerThread = null;
                    }
                }

                if (serverThread__ != null)
                {
                    serverThread__.Abort();
                    serverThread__ = null;
                }

                connectedClients__.Clear();
                workerThreads__.Clear();

                listener__.Stop();

                this.OnAfterStop(System.EventArgs.Empty);

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Resumes the running server thread.
        /// </summary>
        /// <returns>Zero if the server has been resumed successfully, otherwise, false.</returns>
        [Obsolete("Do not use the Resume method on the server, it has not been implemented yet.", true)]
        public virtual int Resume()
        {
            serverThread__.Resume();
            return 0;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
