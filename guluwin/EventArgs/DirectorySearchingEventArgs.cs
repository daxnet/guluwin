/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 5/28/2008
 * 
 * Provides the event arguments which is used by the directory searching event.
 * The directory searching event is fired each time a directory is going to be
 * searched.
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
    /// <summary>
    /// Provides the event argument for DirectorySearching event.
    /// </summary>
    public class DirectorySearchingEventArgs : System.EventArgs
    {
        #region Private Fields
        /// <summary>
        /// The directory which is currently be searched.
        /// </summary>
        private string directory__ = string.Empty;

        /// <summary>
        /// Files added currently, which fulfills all the filters.
        /// </summary>
        private int currentlyAdded__ = 0;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectorySearchingEventArgs()
            : base()
        {
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="_directory">The directory which is currently be searched.</param>
        /// <param name="_currentlyAdded">Files added currently, which fulfills all the filters.</param>
        public DirectorySearchingEventArgs(string _directory, int _currentlyAdded)
            : base()
        {
            directory__ = _directory;
            currentlyAdded__ = _currentlyAdded;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The directory which is currently be searched.
        /// </summary>
        public string Directory
        {
            get { return directory__; }
        }

        /// <summary>
        /// Files added currently, which fulfills all the filters.
        /// </summary>
        public int CurrentlyAdded
        {
            get { return currentlyAdded__; }
        }
        #endregion
    }
}
