using System;
using System.Collections.Generic;
using System.Text;
using SunnyChen.Common.Windows;
using SunnyChen.Gulu.Messaging;

namespace SunnyChen.Gulu.Environment
{
    /// <summary>
    /// Provides facilities for session status.
    /// </summary>
    public static class SessionStatus
    {
        /// <summary>
        /// Opens and shows the session status on the main form.
        /// </summary>
        public static void Show()
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.ShowSessionStatus), 0, 0);
        }
    }
}
