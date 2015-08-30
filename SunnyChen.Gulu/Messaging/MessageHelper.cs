using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Messaging
{
    /// <summary>
    /// The message helper which provides the facilities for messaging.
    /// </summary>
    public class MessageHelper
    {
        /// <summary>
        /// Messages used by Gulu project.
        /// </summary>
        public enum Messages
        {
            /// <summary>
            /// The message of adding a line to the output.
            /// </summary>
            AddOutput = 0xFF00,
            /// <summary>
            /// The message of clearing all the lines in the output.
            /// </summary>
            ClearOutput = 0xFF01,
            /// <summary>
            /// The message of running a gulu.
            /// </summary>
            RunGulu = 0xFF02,
            /// <summary>
            /// The message of adding an error message to the Error List.
            /// </summary>
            AddErrorMessage = 0xFF03,
            /// <summary>
            /// The message of clearing all error messages in the Error List.
            /// </summary>
            ClearErrorMessage = 0xFF04,
            /// <summary>
            /// The message of showing the output.
            /// </summary>
            ShowOutput = 0xFF05,
            /// <summary>
            /// The message of showing the Error List.
            /// </summary>
            ShowErrorList = 0xFF06,
            /// <summary>
            /// The message of hiding the progress.
            /// </summary>
            HideProgress = 0xFF07,
            /// <summary>
            /// The message of showing the progress.
            /// </summary>
            ShowProgress = 0xFF08,
            /// <summary>
            /// The message of setting current and maximum value for the progress.
            /// </summary>
            SetProgress = 0xFF09,
            /// <summary>
            /// The message of showing the session status.
            /// </summary>
            ShowSessionStatus = 0xFF0A
        }
    }
}
