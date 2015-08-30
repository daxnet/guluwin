/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/19/2008
 * 
 * The utility class that provides the interface to access the Error List.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Text;

using SunnyChen.Common.Enumerations;
using SunnyChen.Common.Windows;
using SunnyChen.Gulu.Messaging;

namespace SunnyChen.Gulu.Environment
{
    /// <summary>
    /// Provides the control interface for ErrorList. By using this utility
    /// class, it is easy to add error message to system Error List, to clear
    /// the existing error messages or to open the Error List.
    /// </summary>
    public static class ErrorList
    {
        #region Public Static Methods
        /// <summary>
        /// Adds an error message to the Error List.
        /// </summary>
        /// <param name="_level">Error level.</param>
        /// <param name="_errorCode">Error code.</param>
        /// <param name="_errorText">Error message text.</param>
        /// <param name="_lineNum">The source code line that raises the error message.</param>
        public static void Add(ErrorLevel _level, string _errorCode, string _errorText, int _lineNum)
        {
            OutputErrorMessage.Instance.Code = _errorCode;
            OutputErrorMessage.Instance.Level = _level;
            OutputErrorMessage.Instance.LineNum = _lineNum;
            OutputErrorMessage.Instance.Text = _errorText;
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.AddErrorMessage), 0, 0);
        }

        /// <summary>
        /// Clears all the messages in the Error List.
        /// </summary>
        public static void Clear()
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.ClearErrorMessage), 0, 0);
        }

        /// <summary>
        /// Opens the Error List.
        /// </summary>
        public static void Show()
        {
            Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                Convert.ToInt32(MessageHelper.Messages.ShowErrorList), 0, 0);
        }
        #endregion
    }
}
