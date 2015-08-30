using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Servers
{
    /// <summary>
    /// Defines the methods that handling the basic behaviors of a server.
    /// </summary>
    public interface IServer
    {
        /// <summary>
        /// Starts the server thread.
        /// </summary>
        /// <returns>Zero if it starts successfully, otherwise, false.</returns>
        int Start();

        /// <summary>
        /// Pauses the running server thread.
        /// </summary>
        /// <returns>Zero if the server has been paused successfully, otherwise, false.</returns>
        int Pause();

        /// <summary>
        /// Stops the running server thread.
        /// </summary>
        /// <returns>Zero if the server stops normally, otherwise, false.</returns>
        int Stop();

        /// <summary>
        /// Resumes the running server thread.
        /// </summary>
        /// <returns>Zero if the server has been resumed successfully, otherwise, false.</returns>
        int Resume();
    }
}
