/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/19/2008
 * 
 * The utility class that runs the specified gulu.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using SunnyChen.Common.Windows;
using SunnyChen.Gulu.Gulus;
using SunnyChen.Gulu.Messaging;

namespace SunnyChen.Gulu.Environment
{
    /// <summary>
    /// The utility class that runs the specified gulu. The gulu can be created
    /// both within the plug-in manager and in the script defined by user.
    /// </summary>
    public static class GuluRunner
    {
        /// <summary>
        /// Runs the specified gulu.
        /// </summary>
        /// <param name="_gulu">The gulu that is going to run.</param>
        public static void Run(GuluBase _gulu)
        {
            if (_gulu != null)
            {
                Session.CurrentSession.SetGulu(_gulu);
                System.Threading.Thread.Sleep(1);
                Api.SendMessage(Session.CurrentSession.MDIParent.Handle.ToInt32(),
                    Convert.ToInt32(MessageHelper.Messages.RunGulu), 0, 0);
            }
        }
    }
}
