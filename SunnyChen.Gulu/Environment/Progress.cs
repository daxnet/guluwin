using System;
using System.Collections.Generic;
using System.Text;

using SunnyChen.Common.Windows;
using SunnyChen.Gulu.Messaging;

namespace SunnyChen.Gulu.Environment
{
    /// <summary>
    /// Provides methods and functions that handles the behaviors of the progress bar
    /// in the status panel of Gulu.
    /// </summary>
    public static class Progress
    {
        /// <summary>
        /// Hides the progress bar.
        /// </summary>
        public static void Hide()
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.HideProgress),
                0, 0);
        }
        /// <summary>
        /// Opens and shows the progress bar.
        /// </summary>
        public static void Show()
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.ShowProgress),
                0, 0);
        }

        /// <summary>
        /// Sets the value for the progress bar.
        /// </summary>
        /// <param name="_current">The current value of the progress.</param>
        /// <param name="_max">The maximum value.</param>
        public static void SetProgress(int _current, int _max)
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.SetProgress),
                _current, _max);
        }
    }
}
