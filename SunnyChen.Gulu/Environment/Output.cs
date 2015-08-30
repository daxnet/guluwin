using System;
using System.Threading;

using SunnyChen.Common.Windows;
using SunnyChen.Gulu.Messaging;


namespace SunnyChen.Gulu.Environment
{
    /// <summary>
    /// Provides facilities for message output.
    /// </summary>
    public static class Output
    {
        #region Public Static Methods
        /// <summary>
        /// Adds an empty line.
        /// </summary>
        public static void Add()
        {
            Add(string.Empty);
        }
        /// <summary>
        /// Adds an output string to the system output.
        /// </summary>
        /// <param name="_output">The string to be added.</param>
        public static void Add(string _output)
        {
            Add(_output, false);
        }

        /// <summary>
        /// Adds an output string to the system output with or without time information.
        /// </summary>
        /// <param name="_output">The string to be added.</param>
        /// <param name="_displayDateTime">True indicates the time information should be included.</param>
        public static void Add(string _output, bool _displayDateTime)
        {
            if (_displayDateTime)
            {
                OutputMessage.Instance.Message = string.Format("[{0}] - {1}", DateTime.Now.ToString(), _output);
            }
            else
            {
                OutputMessage.Instance.Message = _output;
            }
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.AddOutput), 0, 0);
        }

        /// <summary>
        /// Clears the content of system output.
        /// </summary>
        public static void Clear()
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.ClearOutput), 0, 0);
        }

        /// <summary>
        /// Opens and shows the system output.
        /// </summary>
        public static void Show()
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.ShowOutput), 0, 0);
        }

        #endregion
    }
}
