/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 5/28/2008
 * 
 * 
 * Provides the event argument which is used by files added event.
 * Files added event is fired once the directory searching is terminated
 * either normally or manually.
 * 
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Win.EventArgs
{
    public class FilesAddedEventArgs : System.EventArgs
    {
        private int filesAdded__ = 0;

        public FilesAddedEventArgs()
            : base()
        {
        }

        public FilesAddedEventArgs(int _filesAdded)
            : base()
        {
            filesAdded__ = _filesAdded;
        }

        public int FilesAdded
        {
            get { return filesAdded__; }
        }
    }
}
