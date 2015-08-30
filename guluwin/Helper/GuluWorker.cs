/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/17/2008
 * 
 * The definition for the gulu worker object.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System.IO;
using System.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Win.EventArgs;
using SunnyChen.Gulu.Win.Properties;

namespace SunnyChen.Gulu.Win.Helper
{
    /// <summary>
    /// The gulu worker object is used to define the thread procedure
    /// which is going to be used for running gulus.
    /// </summary>
    internal class GuluWorker
    {
        /// <summary>
        /// The private volatile variable which indicates if the worker thread
        /// should be terminated.
        /// </summary>
        private volatile bool shouldStop__ = false;
        /// <summary>
        /// Represents the method that has the event argument which carries the information
        /// of the running gulu and the way of terminating.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event argument which carries the information
        /// of the running gulu and the way of terminating (Whether finished normally or
        /// terminated by user).</param>
        public delegate void GuluWorkerFinishedDelegate(object sender, GuluWorkerFinishedEventArgs e);
        /// <summary>
        /// Occurs after the gulu worker thread has been finished.
        /// </summary>
        public event GuluWorkerFinishedDelegate Finished;
        /// <summary>
        /// Internal event handler which is invoked when the gulu worker 
        /// is finished or terminated.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event argument which carries the information
        /// of the running gulu and the way of terminating (Whether finished normally or
        /// terminated by user).</param>
        protected void OnGuluWorkerFinished(object sender, GuluWorkerFinishedEventArgs e)
        {
            // Hide the progress when the worker is interrupted or finished
            Progress.Hide();
            // Invokes the event
            if (Finished != null)
                Finished(sender, e);
        }

        /// <summary>
        /// Gets or sets a boolean value which indicates that the gulu worker thread
        /// should be stopped.
        /// </summary>
        public bool ShouldStop
        {
            get { return shouldStop__; }
            set { shouldStop__ = value; }
        }

        /// <summary>
        /// Gulu worker thread procedure.
        /// </summary>
        /// <param name="_param">The parameter of the type GuluWorkerParameter</param>
        public void WorkingThread(object _param)
        {
            Progress.Show();
            GuluWorkerParameter parameter = (GuluWorkerParameter)_param;
            shouldStop__ = false;
            /* Sunny Chen Added 2008/07/01 --> */
            BackupHelper backupHelper = new BackupHelper(parameter.ConfigurationReader.BackupDirectory);
            /* Sunny Chen Added 2008/07/01 <-- */

            // Initialize the current value
            int i = 0;
            // Gets the maximum count of the files that needs to be processed
            int max = parameter.Items.Count;

            foreach (ListViewItem listViewItem in parameter.Items)
            {
                // Sets the progress value
                Progress.SetProgress(i, max);
                i++;
                // If stop is required, just get out of the loop
                if (shouldStop__)
                    break;
                // Gets the full file name of for the current node. Full file name
                // is stored in the forth sub item of the list view item.
                string fileName = listViewItem.SubItems[3].Text;
                // If the file doesn't exist, prompt the error message and go on with
                // the next file
                if (!File.Exists(fileName))
                {
                    Output.Add(string.Format(Resources.TEXT_FILE_NOT_EXIST, fileName));
                    continue;
                }
                /* Sunny Chen Added 2008/07/01 --> */
                // Backup the files
                if (parameter.ConfigurationReader.BackupEnabled && parameter.Gulu.BackupRequired)
                {
                    bool result = backupHelper.Backup(fileName);
                    if (!result)
                    {
                        Output.Add(string.Format(Resources.TEXT_BACKUP_FAILED, fileName));
                        continue;
                    }
                }
                /* Sunny Chen Added 2008/07/01 <-- */
                // Runs the gulu to process the current file. If the gulu failed processing,
                // a FALSE value will be returned and the error message will be added to
                // the system output
                if (!parameter.Gulu.Execute(fileName))
                    Output.Add(string.Format(Resources.TEXT_FILE_OPER_FAILED, fileName));
            }
            /* Sunny Chen Added 2008/07/01 --> */
            // Generates the backup mapping list.
            if (parameter.ConfigurationReader.BackupEnabled && parameter.Gulu.BackupRequired)
                backupHelper.GenerateMappingList();
            /* Sunny Chen Added 2008/07/01 <-- */
            // If shouldStop__ is true, that means it is the user who stops the running
            // of the gulu worker thread, so it is INTERRUPTED by the user.
            bool interrupted = shouldStop__ == true;
            // Calls the worker finished event handler
            OnGuluWorkerFinished(this, new GuluWorkerFinishedEventArgs(parameter.Gulu, interrupted));
        }
    }
}
