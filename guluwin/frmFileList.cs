/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/17/2008
 * 
 * The file searching and listing form.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SunnyChen.Common.Patterns;
using SunnyChen.Gulu.Filters;
using SunnyChen.Gulu.Win.Configuration;
using SunnyChen.Gulu.Win.EventArgs;
using SunnyChen.Gulu.Win.Helper;
using SunnyChen.Gulu.Win.NodeProperties;
using SunnyChen.Gulu.Win.Properties;

namespace SunnyChen.Gulu.Win
{
    /// <summary>
    /// The file searching and listing form. In this form, the files will be selected
    /// into the file list (the container) in a working thread according to the filter
    /// settings. Users can stop the searching at any time they like.
    /// </summary>
    public partial class frmFileList : frmDummy
    {
        #region Private Fields
        /// <summary>
        /// The parameterized thread start information
        /// </summary>
        private ParameterizedThreadStart threadStart__;

        /// <summary>
        /// The processing thread, it could be created for multiple times
        /// </summary>
        private volatile Thread processingThread__;

        /// <summary>
        /// List view items
        /// </summary>
        private List<ListViewItem> items__ = new List<ListViewItem>();

        /// <summary>
        /// Small image list for the list view
        /// </summary>
        private ImageList smallImageList__ = new ImageList();

        /// <summary>
        /// Large image list for the list view
        /// </summary>
        private ImageList largeImageList__ = new ImageList();

        /// <summary>
        /// The icon manager which responsible for the management of
        /// the icons that are extracted from a specific file type.
        /// </summary>
        private FilesIconListManager iconListManager__;

        /// <summary>
        /// Thread terminating flag
        /// </summary>
        private static volatile bool shouldStop__ = false;

        /// <summary>
        /// The thread array
        /// </summary>
        private List<Thread> threads__ = new List<Thread>();

        /// <summary>
        /// The filter manager
        /// </summary>
        private FilterManager filterManager__ = new FilterManager();

        /// <summary>
        /// A hash table that stores the file system watchers for each
        /// added path.
        /// </summary>
        private Hashtable watchersHash__ = new Hashtable();

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public frmFileList()
        {
            InitializeComponent();
            //Resources.Culture = Thread.CurrentThread.CurrentCulture;
        }

        /// <summary>
        /// The constructor which is used for applying the
        /// Extendable MDI design pattern
        /// </summary>
        /// <param name="_parent">The MDI parent form</param>
        public frmFileList(frmMain _parent)
            : base(_parent)
        {
            InitializeComponent();
            //Resources.Culture = Thread.CurrentThread.CurrentCulture;
        }
        #endregion

        #region Public Events and Delegates
        /// <summary>
        /// Represents the method that will handle the events that are with default arguments.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event argument.</param>
        public delegate void BeforeAddFolderDelegate(object sender, System.EventArgs e);
        /// <summary>
        /// Occurs before a folder is added to the file list.
        /// </summary>
        public event BeforeAddFolderDelegate BeforeAddFolder;
        /// <summary>
        /// Represents the method that will handle the events that carries the count of added
        /// files when the file has been added to the file list.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">The event argument that carries the count of added files.</param>
        public delegate void AfterAddFolderDelegate(object sender, FilesAddedEventArgs e);
        /// <summary>
        /// Occurs after the folder has been added to the file list.
        /// </summary>
        public event AfterAddFolderDelegate AfterAddFolder;
        /// <summary>
        /// Represents the method that will handle the events that carries the currently searching
        /// directory name and the directories searched.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">The event argument that carries the currently searching directory
        /// name and the directories searched.</param>
        public delegate void DirectorySearchingDelegate(object sender, DirectorySearchingEventArgs e);
        /// <summary>
        /// Occurs when the directory is being searched.
        /// </summary>
        public event DirectorySearchingDelegate DirectorySearching;
        /// <summary>
        /// Represents the method that has no parameters and return values.
        /// </summary>
        public delegate void ClearListDelegate();
        /// <summary>
        /// Occurs after the file list has been cleared.
        /// </summary>
        public event ClearListDelegate ListCleared;

        #endregion

        #region Private Delegates and Methods

        /// <summary>
        /// Delegated method of accessing UI elements in the threads
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="e">The FilesAddedEventArgs instance</param>
        private void Delegated_OnAfterAddFolder(object sender, FilesAddedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AfterAddFolderDelegate d = new AfterAddFolderDelegate(Delegated_OnAfterAddFolder);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                OnAfterAddFolder(sender, e);
            }
        }

        /// <summary>
        /// Delegated method of accessing UI elements in the threads
        /// </summary>
        private void Delegated_ClearList()
        {
            if (this.InvokeRequired)
            {
                ClearListDelegate d = new ClearListDelegate(Delegated_ClearList);
                this.Invoke(d);
            }
            else
            {
                ClearList();
            }
        }

        /// <summary>
        /// Delegated method of accessing UI elements in the threads
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">The DirectorySearchingEventArgs instance</param>
        private void Delegated_DirectorySearching(object sender, DirectorySearchingEventArgs e)
        {
            if (this.InvokeRequired)
            {
                DirectorySearchingDelegate d = new DirectorySearchingDelegate(Delegated_DirectorySearching);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                OnDirectorySearching(sender, e);
            }
        }

        /// <summary>
        /// Clears the file list and sets the properties for UI controls.
        /// </summary>
        private void ClearList()
        {
            fileList.Items.Clear();

            fileList.VirtualListSize = 0;

            items__.Clear();
            iconListManager__.ClearLists();
            toolbarsManager.Tools["mnuClearList"].SharedProps.Enabled = false;
            toolbarsManager.Tools["mnuCheckAll"].SharedProps.Enabled = false;
            toolbarsManager.Tools["mnuUncheckAll"].SharedProps.Enabled = false;

            // Fires the ListCleared event
            OnClearList();
        }
        #endregion

        #region Protected Event Processors

        /// <summary>
        /// Event fired before the file list is being populated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnBeforeAddFolder(object sender, System.EventArgs e)
        {
            if (BeforeAddFolder != null)
            {
                BeforeAddFolder(sender, e);
            }

            toolbarsManager.Tools["mnuStopSearch"].SharedProps.Enabled = true;
        }

        /// <summary>
        /// Event just fired after the file list has been populated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnAfterAddFolder(object sender, FilesAddedEventArgs e)
        {
            fileList.VirtualListSize = items__.Count;

            toolbarsManager.Tools["mnuStopSearch"].SharedProps.Enabled = false;

            if (fileList.VirtualListSize > 0 && items__.Count > 0)
            {
                toolbarsManager.Tools["mnuClearList"].SharedProps.Enabled = true;
                toolbarsManager.Tools["mnuCheckAll"].SharedProps.Enabled = true;
                toolbarsManager.Tools["mnuUncheckAll"].SharedProps.Enabled = true;
            }

            if (AfterAddFolder != null)
            {
                AfterAddFolder(sender, e);
            }
        }

        /// <summary>
        /// Event handling procedure which was called when the directories are being searching.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e"></param>
        protected void OnDirectorySearching(object sender, DirectorySearchingEventArgs e)
        {
            if (DirectorySearching != null)
            {
                DirectorySearching(sender, e);
            }
        }

        protected void OnClearList()
        {
            if (ListCleared != null)
            {
                ListCleared();
            }
        }

        #endregion

        #region Private Methods
        private void ThreadProc(object _parm)
        {
            Queue<string> queue = new Queue<string>();
            string rootPath = (string)_parm;
            string curPath = string.Empty;
            ConfigReader configReader = new ConfigReader();
            
            queue.Enqueue(rootPath);

            while (queue.Count > 0 && !shouldStop__)
            {
                try
                {
                    curPath = queue.Dequeue();
                    
                    // Fires the DirectorySearching event
                    Delegated_DirectorySearching(Thread.CurrentThread, new DirectorySearchingEventArgs(curPath, items__.Count));

                    DirectoryInfo directoryInfo = new DirectoryInfo(curPath);
                    DirectoryInfo[] directories = directoryInfo.GetDirectories();
                    FileInfo[] files = directoryInfo.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        if (shouldStop__) break;
                        
                        if (!configReader.FileTreeShowHidden && ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                            continue;

                        if (!configReader.FileTreeShowSystem && ((file.Attributes & FileAttributes.System) == FileAttributes.System))
                            continue;

                        if (File.Exists(file.FullName) && filterManager__.Validate(file.FullName))
                        {
                            ListViewItem item = new ListViewItem(file.Name, iconListManager__.AddFileIcon(file.FullName));
                            item.SubItems.Add(string.Format("{0:#,0} KB", (file.Length / 1024)));
                            item.SubItems.Add(file.DirectoryName);
                            item.SubItems.Add(file.FullName);
                            

                            item.Checked = true;
                            items__.Add(item);
                        }
                    }

                    if (shouldStop__) break;

                    if (configReader.SearchRecursivly)
                    {
                        foreach (DirectoryInfo directory in directories)
                        {
                            if (shouldStop__) break;
                            if (!directory.Name.Equals(".") && !directory.Name.Equals(".."))
                                queue.Enqueue(directory.FullName);
                        }
                    }
                }
                catch (ThreadAbortException)
                {
                    break;
                }
                catch
                {
                    continue;
                }
            }
            Delegated_OnAfterAddFolder(this, new FilesAddedEventArgs(items__.Count));
        }

        private void EventHandler_StopSearch(object sender, System.EventArgs e)
        {
            using (new LengthyOperation(this.parent__))
            {
                if (processingThread__ != null && processingThread__.IsAlive)
                {
                    shouldStop__ = true;
                    processingThread__.Abort();
                    processingThread__.Join();
                }

                this.OnAfterAddFolder(sender, new FilesAddedEventArgs(items__.Count));
            }

        }

        private void EventHandler_ClearList(object sender, System.EventArgs e)
        {
            try
            {
                if (items__.Count > 0 && fileList.VirtualListSize > 0)
                {
                    if (MessageBox.Show(Resources.TEXT_CONFIRM_CLEARLIST, 
                        Resources.TEXT_CONFIRMATION, 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question) == DialogResult.Yes)
                        ClearList();
                }
                
            }
            catch
            {
                throw;
            }
        }

        private void EventHandler_CheckAll(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in items__)
                item.Checked = true;
            fileList.Invalidate();
        }

        private void EventHandler_UncheckAll(object sender, System.EventArgs e)
        {
            foreach (ListViewItem item in items__)
                item.Checked = false;
            fileList.Invalidate();
        }
        #endregion
        
        #region Public Methods
        public void AddFolder(string _root)
        {
            //ClearList();

            // Load filters
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
            FileInfo[] filterFiles = directoryInfo.GetFiles("*.dll");
            filterManager__.Clear();
            if (filterFiles != null)
            {
                foreach (FileInfo fileInfo in filterFiles)
                {
                    try
                    {
                        filterManager__.Load(fileInfo.FullName);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            this.OnBeforeAddFolder(this, null);

            threadStart__ = new ParameterizedThreadStart(this.ThreadProc);
            processingThread__ = new Thread(threadStart__);
            processingThread__.Priority = ThreadPriority.Lowest;
            
            shouldStop__ = false;
            processingThread__.Start(_root);
            threads__.Add(processingThread__);

            if (!watchersHash__.Contains(_root))
            {
                FileSystemWatcher watcher = new FileSystemWatcher(_root);
                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;
                watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
                watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
                watchersHash__.Add(_root, watcher);
            }

            this.BringToFront();
        }
        #endregion

        #region Generated Event Handlers
        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            ListViewItem matched = items__.Find(
                delegate(ListViewItem i)
                {
                    return i.SubItems[3].Text.Equals(e.OldFullPath);
                });
            if (matched != null)
            {
                matched.ImageIndex = iconListManager__.AddFileIcon(e.FullPath);
                matched.Text = Path.GetFileName(e.FullPath);
                matched.SubItems[3].Text = e.FullPath;
            }
            fileList.Invalidate();
        }

        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            ListViewItem matched = items__.Find(
                delegate(ListViewItem i)
                {
                    return i.SubItems[3].Text.Equals(e.FullPath);
                });
            if (matched != null)
            {
                matched.Checked = false;
                matched.Font = new Font(matched.Font, FontStyle.Strikeout);
                matched.ForeColor = Color.Silver;
            }
            fileList.Invalidate();
        }

        private void frmFileList_Load(object sender, System.EventArgs e)
        {
            ListView.CheckForIllegalCrossThreadCalls = false;

            toolbarsManager.Tools["mnuStopSearch"].SharedProps.Enabled = false;
            toolbarsManager.Tools["mnuClearList"].SharedProps.Enabled = false;
            toolbarsManager.Tools["mnuCheckAll"].SharedProps.Enabled = false;
            toolbarsManager.Tools["mnuUncheckAll"].SharedProps.Enabled = false;

            // Prepare Icon manager and image list for different file types.
            smallImageList__.ColorDepth = ColorDepth.Depth32Bit;
            largeImageList__.ColorDepth = ColorDepth.Depth32Bit;
            smallImageList__.ImageSize = new Size(16, 16);
            largeImageList__.ImageSize = new Size(32, 32);
            iconListManager__ = new FilesIconListManager(smallImageList__, largeImageList__);
            fileList.SmallImageList = smallImageList__;
            fileList.LargeImageList = largeImageList__;

            //CanSave = true;
        }

        private void frmFileList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.EventHandler_StopSearch(sender, (System.EventArgs)e);
            foreach (Thread thread in threads__)
            {
                if (thread != null)
                {
                    thread.Abort();
                    thread.Join();
                }
            }
            GC.Collect();
        }

        private void toolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "mnuStopSearch":
                    if (MessageBox.Show(Resources.TEXT_CONFIRM_INTERRUPT_SEARCHING, Resources.TEXT_CONFIRMATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        this.EventHandler_StopSearch(sender, e);
                    break;
                case "mnuClearList":
                    this.EventHandler_ClearList(sender, e);
                    break;
                case "mnuCheckAll":
                    this.EventHandler_CheckAll(sender, e);
                    break;
                case "mnuUncheckAll":
                    this.EventHandler_UncheckAll(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node;
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                FileTreeNodeProperty prop = (FileTreeNodeProperty)node.Tag;

                if (prop != null)
                {
                    if (prop.Type == FileTreeNodeType.Folder ||
                        prop.Type == FileTreeNodeType.Drive ||
                        prop.Type == FileTreeNodeType.Desktop ||
                        prop.Type == FileTreeNodeType.MyDocuments)
                    {
                        this.AddFolder(prop.FullPath);
                    }
                    else if (prop.Type == FileTreeNodeType.File)
                    {
                        if (File.Exists(prop.FullPath))
                        {
                            FileInfo file = new FileInfo(prop.FullPath);

                            ListViewItem item = new ListViewItem(file.Name, iconListManager__.AddFileIcon(file.FullName));
                            item.SubItems.Add(string.Format("{0:#,0} KB", (file.Length / 1024)));
                            item.SubItems.Add(file.DirectoryName);
                            item.SubItems.Add(file.FullName);

                            item.Checked = true;
                            items__.Add(item);
                            fileList.VirtualListSize = items__.Count;
                            if (fileList.VirtualListSize > 0 && items__.Count > 0)
                            {
                                toolbarsManager.Tools["mnuClearList"].SharedProps.Enabled = true;
                                toolbarsManager.Tools["mnuCheckAll"].SharedProps.Enabled = true;
                                toolbarsManager.Tools["mnuUncheckAll"].SharedProps.Enabled = true;
                            }

                            if (!watchersHash__.Contains(Path.GetDirectoryName(prop.FullPath)))
                            {
                                FileSystemWatcher watcher = new FileSystemWatcher(Path.GetDirectoryName(prop.FullPath));
                                watcher.EnableRaisingEvents = true;
                                watcher.IncludeSubdirectories = true;
                                watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
                                watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
                                watchersHash__.Add(Path.GetDirectoryName(prop.FullPath), watcher);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Resources.TEXT_INFO_NODETYPE_NOT_SUPPORTED,
                            Resources.TEXT_INFORMATION,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(Resources.TEXT_INFO_INVALID_NODE,
                        Resources.TEXT_INFORMATION,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void fileList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
             e.Item = items__[e.ItemIndex];
        }

        private void fileList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
            //if (!e.Item.Checked)
            //{
            //    e.Item.Checked = true;
            //    e.Item.Checked = false;
            //}
        }

        private void fileList_MouseClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            ListViewItem listViewItem = listView.GetItemAt(e.X, e.Y);
            if (listViewItem != null)
            {
                if (e.X < (listViewItem.Bounds.Left + 16))
                {
                    listViewItem.Checked = !listViewItem.Checked;
                    listView.Invalidate(listViewItem.Bounds);
                }
            }
        }

        private void fileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            ListViewItem listViewItem = listView.GetItemAt(e.X, e.Y);
            if (listViewItem != null)
                listView.Invalidate(listViewItem.Bounds);
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the selected items from the list.
        /// </summary>
        public IList<ListViewItem> SelectedItems
        {
            get
            {
                if (items__.Count == 0)
                    return null;

                IList<ListViewItem> selected = items__.FindAll(
                    delegate(ListViewItem item)
                        {
                            return item.Checked == true;
                        }
                    );

                if (selected.Count > 0)
                    return selected;
                else
                    return null;
            }
        }
        #endregion
    }
}
