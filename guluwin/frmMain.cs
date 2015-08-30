/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 5/28/2008
 * 
 * Main GUI of GuluWin
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.VisualBasic.FileIO;
using SunnyChen.Common.CodeDom;
using SunnyChen.Common.Enumerations;
using SunnyChen.Common.Patterns;
using SunnyChen.Common.Patterns.ExtendableMDI;
using SunnyChen.Common.Patterns.ExtendableMDI.Attributes;
using SunnyChen.Common.Windows;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Common.Windows.ShellApi;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Gulus;
using SunnyChen.Gulu.Messaging;
using SunnyChen.Gulu.Win.Configuration;
using SunnyChen.Gulu.Win.EventArgs;
using SunnyChen.Gulu.Win.Helper;
using SunnyChen.Gulu.Win.NodeProperties;

namespace SunnyChen.Gulu.Win
{
    public partial class frmMain : MainFormBase
    {
        #region Private Fields
        /// <summary>
        /// The special root node of the file treeview
        /// </summary>
        private TreeNode fileTreeViewSpecialRoot__ = null;
        /// <summary>
        /// Key value for the special root node
        /// </summary>
        private const string KEY_FILETREEVIEW_SPECIAL_ROOT = @"ROOT_SPECIAL";
        /// <summary>
        /// The general root node of the file treeview
        /// </summary>
        private TreeNode fileTreeViewGeneralRoot__ = null;
        /// <summary>
        /// Key value for the general root node
        /// </summary>
        private const string KEY_FILETREEVIEW_GENERAL_ROOT = @"ROOT_GENERAL";
        /// <summary>
        /// Gulu manager, handles the Gulu management
        /// </summary>
        private GuluManager guluManager__ = new GuluManager();
        /// <summary>
        /// The collection for handling all the gulu worker threads
        /// </summary>
        private IList<Thread> guluWorkerThreads__ = new List<Thread>();
        /// <summary>
        /// The worker object of the gulu
        /// </summary>
        private GuluWorker worker__ = new GuluWorker();
        /// <summary>
        /// The gulu worker thread
        /// </summary>
        private Thread workerThread__;
        /// <summary>
        /// The CodeDom Compiler
        /// </summary>
        private Compiler compiler__;
        /// <summary>
        /// The flag which determines whether the gulu worker is working
        /// </summary>
        private bool guluWorkerRunning__ = false;
        /// <summary>
        /// The error list which might be used for displaying the error messages
        /// </summary>
        private DataTable errorList__ = new DataTable();
        /// <summary>
        /// The global-scoped configuration reader, it will be shared between
        /// main form, script manager, gulu runner and the code editor
        /// </summary>
        /// <remarks>
        /// This global configuration reader ensures that some configuration settings
        /// can just take effect after the program restarts. frmMain will handle this
        /// // global configuration reader instance.
        /// </remarks>
        private ConfigReader globalConfigReader__ = new ConfigReader();
        /// <summary>
        /// These tree nodes are used for displaying the session status
        /// </summary>
        private IList<TreeNode> sessionStatusNodes__ = new List<TreeNode>();
        #endregion

        #region Constructors
        
        /// <summary>
        /// The default constructor
        /// </summary>
        public frmMain()
        {
            frmSplash splash = new frmSplash();
            splash.Show();
            //splash.TopMost = true;
            
            // Initialize components
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_COMPONENTS;
            InitializeComponent();
            errorList__.Clear();
            errorList__.Columns.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_COL_ERRORLEVEL, typeof(Image));
            errorList__.Columns.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_COL_ERRORCODE, typeof(string));
            errorList__.Columns.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_COL_ERRORTEXT, typeof(string));
            errorList__.Columns.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_COL_ERRORLINE, typeof(int));
            errorListGrid.DataSource = errorList__;
            errorListGrid.Columns[0].Resizable = DataGridViewTriState.False;
            errorListGrid.Columns[0].Width = 45;
            errorListGrid.Columns[1].Width = 125;
            errorListGrid.Columns[2].Width = 525;
            errorListGrid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            errorListGrid.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ResourceCustomizer rc = Infragistics.Win.UltraWinToolbars.Resources.Customizer;
            rc.SetCustomizedString("MdiCommandCascade", SunnyChen.Gulu.Win.Properties.Resources.TEXT_CASCADE);
            rc.SetCustomizedString("MdiCommandArrangeIcons", SunnyChen.Gulu.Win.Properties.Resources.TEXT_ARRANGE_ICONS);
            rc.SetCustomizedString("MdiCommandCloseWindows", SunnyChen.Gulu.Win.Properties.Resources.TEXT_CLOSE_ALL_WINDOWS);
            rc.SetCustomizedString("MdiCommandMinimizeWindows", SunnyChen.Gulu.Win.Properties.Resources.TEXT_MIN_ALL_WINDOWS);
            rc.SetCustomizedString("MdiCommandTileHorizontal", SunnyChen.Gulu.Win.Properties.Resources.TEXT_TILE_HORI);
            rc.SetCustomizedString("MdiCommandTileVertical", SunnyChen.Gulu.Win.Properties.Resources.TEXT_TILE_VERT);
            rc.SetCustomizedString("AddRemoveButtons", SunnyChen.Gulu.Win.Properties.Resources.TEXT_ADD_REMOVE_BTNS);
            rc.SetCustomizedString("Customize", SunnyChen.Gulu.Win.Properties.Resources.TEXT_CUSTOMIZE);
            rc = Infragistics.Win.UltraWinExplorerBar.Resources.Customizer;
            rc.SetCustomizedString("NavigationQuickCustomizeMenu_ShowMoreButtons", SunnyChen.Gulu.Win.Properties.Resources.TEXT_SHOW_MORE_BTNS);
            rc.SetCustomizedString("NavigationQuickCustomizeMenu_ShowFewerButtons", SunnyChen.Gulu.Win.Properties.Resources.TEXT_SHOW_FEWER_BTNS);
            rc.SetCustomizedString("NavigationQuickCustomizeMenu_AddOrRemoveButtons", SunnyChen.Gulu.Win.Properties.Resources.TEXT_ADD_REMOVE_BTNS);
            rc.SetCustomizedString("NavigationQuickCustomizeMenu_NavigationPaneOptions", SunnyChen.Gulu.Win.Properties.Resources.TEXT_NAV_PANE_OPTIONS);
            statusBar.Panels["AutoStatusText"].Text = SunnyChen.Gulu.Win.Properties.Resources.TEXT_READY;

            // Set event handlers
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_SETEVENTHANDLERS;
            worker__.Finished += new GuluWorker.GuluWorkerFinishedDelegate(worker___Finished);

            // Initialize tree view
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_TREEVIEW;
            this.InitializeFileTreeView();

            // Initialize gulu manager
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_GULUMANAGER;
            this.InitializeGuluManager();

            // Initialize compiler
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_COMPILER;
            Type compilerType = Type.GetType(globalConfigReader__.CompilerTypeName);
            compiler__ = Compiler.CreateCompiler(compilerType);
            compiler__.AddSystemReferences();
            compiler__.AddReference("SunnyChen.Common.dll");
            compiler__.AddReference("SunnyChen.Gulu.dll");

            // Initialize session, update session status
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_SETSESSIONPARAM;
            Session.CurrentSession.SetParameter(Process.GetCurrentProcess().ProcessName, 
                this, 
                compilerType);
            this.InitializeSessionStatusTreeView();

            // Initialize control status
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_CONTROLSTATES;
            GetTool("mnuStop").SharedProps.Enabled = false;
            Progress.Hide();

            // Update UI elements
            splash.StatusText = SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_UPDATEELEMENTS;
            this.UpdateElements();

            splash.TopMost = false;
            splash.Close();
        }

        #endregion

        #region Private Delegates
        /// <summary>
        /// The delegate which classified for some method
        /// that has no argument and has no return value.
        /// </summary>
        private delegate void VoidVoid();

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the File TreeView control.
        /// </summary>
        private void InitializeFileTreeView()
        {
            fileTreeView.Nodes.Clear();

            // Creates root node for special places.
            fileTreeViewSpecialRoot__ = fileTreeView.Nodes.Add(KEY_FILETREEVIEW_SPECIAL_ROOT,
                SunnyChen.Gulu.Win.Properties.Resources.TEXT_SPECIAL_ROOT,
                0);
            fileTreeViewSpecialRoot__.Tag = new FileTreeNodeProperty(KEY_FILETREEVIEW_SPECIAL_ROOT,
                FileTreeNodeType.Root,
                @"");
            
            // Creates root node for general places.
            fileTreeViewGeneralRoot__ = fileTreeView.Nodes.Add(KEY_FILETREEVIEW_GENERAL_ROOT,
                SunnyChen.Gulu.Win.Properties.Resources.TEXT_GENERAL_ROOT,
                0);
            fileTreeViewGeneralRoot__.Tag = new FileTreeNodeProperty(KEY_FILETREEVIEW_GENERAL_ROOT,
                FileTreeNodeType.Root,
                @"");

            // Creates special places under special root.
            this.InitializeSpecialFolders();

            // Creates drive list (general places) under general root.
            this.InitializeDriveList();

            // Set focus
            fileTreeView.Focus();
        }

        /// <summary>
        /// Initializes the Gulu Manager
        /// </summary>
        private void InitializeGuluManager()
        {
            // Gets the path for gulus and check the existence.
            string gulusPath = Directories.GuluPath;//Path.Combine(Application.StartupPath, GuluManager.GULUS_PATH);
            if (!Directory.Exists(gulusPath))
            {
                Directory.CreateDirectory(gulusPath);
                return;
            }

            DirectoryInfo gulusDirectory = new DirectoryInfo(gulusPath);
            FileInfo[] assemblyFiles = gulusDirectory.GetFiles("*.dll", System.IO.SearchOption.AllDirectories);
            Hashtable hash = new Hashtable();

            if (assemblyFiles != null && assemblyFiles.Length != 0)
            {
                taskManager.Groups.Clear();
                guluManager__.Clear();

                foreach (FileInfo assemblyFile in assemblyFiles)
                {
                    try
                    {
                        guluManager__.Load(assemblyFile.FullName, true);
                    }
                    catch
                    {
                        continue;
                    }
                }

                foreach (GuluBase gulu in guluManager__.Items)
                {
                    if (gulu.Enabled)
                    {
                        if (hash.Contains(gulu.Identifier))
                        {
                            MessageBox.Show(string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_WARN_GULU_ALREADY_EXIST, gulu.ToString()),
                                SunnyChen.Gulu.Win.Properties.Resources.TEXT_WARNING,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            continue;
                        }

                        hash[gulu.Identifier] = true;

                        if (taskManager.Groups.Exists(gulu.Category))
                        {
                            UltraExplorerBarItem item = taskManager.Groups[gulu.Category].Items.Add(gulu.Identifier, gulu.Name);
                            item.ToolTipText = gulu.Description;
                            item.Tag = gulu;
                            if (gulu.Image != null)
                                item.Settings.AppearancesSmall.Appearance.Image = gulu.Image;
                            else
                                item.Settings.AppearancesSmall.Appearance.Image = SunnyChen.Gulu.Win.Properties.Resources.BMP_GULU;
                        }
                        else
                        {
                            UltraExplorerBarGroup group = taskManager.Groups.Add(gulu.Category, gulu.Category);
                            UltraExplorerBarItem item = group.Items.Add(gulu.Identifier, gulu.Name);
                            item.ToolTipText = gulu.Description;
                            item.Tag = gulu;
                            if (gulu.Image != null)
                                item.Settings.AppearancesSmall.Appearance.Image = gulu.Image;
                            else
                                item.Settings.AppearancesSmall.Appearance.Image = SunnyChen.Gulu.Win.Properties.Resources.BMP_GULU;
                        } // else - the group doesn't exist
                    } // If gulu enabled
                }
                
                Session.CurrentSession.SetLoadedGulus(guluManager__.Gulus);
            }
        }

        private void InitializeSessionStatusTreeView()
        {
            string pmtSessionName = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_PROMPT_SESSION_NAME,
                Session.CurrentSession.SessionName);
            tvSessionStatus.Nodes.Add("SessionName", pmtSessionName, "SessionName", "SessionName");

            string pmtLoadedGulus = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_PROMPT_LOADED_GULUS,
                Session.CurrentSession.LoadedGulus.Count);
            tvSessionStatus.Nodes.Add("LoadedGulus", pmtLoadedGulus, "LoadedGulus", "LoadedGulus");

            string pmtCompilerType = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_PROMPT_COMPILER_TYPE,
                Session.CurrentSession.CompilerType.FullName);
            tvSessionStatus.Nodes.Add("CompilerType", pmtCompilerType, "CompilerType", "CompilerType");

            string pmtTimeElapsed = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_PROMPT_TIME_ELAPSED,
                Session.CurrentSession.TimeElapsed.ToString());
            tvSessionStatus.Nodes.Add("TimeElapsed", pmtTimeElapsed, "TimeElapsed", "TimeElapsed");
        }

        /// <summary>
        /// Initialize drive list
        /// </summary>
        private void InitializeDriveList()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string imageKey = string.Empty;

            foreach (DriveInfo drive in drives)
            {
                switch (drive.DriveType)
                {
                    case DriveType.Fixed:
                        imageKey = "FixedDrive";
                        break;
                    case DriveType.Removable:
                        imageKey = "RemovableDrive";
                        break;
                    case DriveType.CDRom:
                        imageKey = "CDROM";
                        break;
                    default:
                        imageKey = "Directory";
                        break;
                }
                TreeNode node = fileTreeViewGeneralRoot__.Nodes.Add(drive.Name, drive.Name, imageKey, imageKey);
                node.Nodes.Add(string.Empty);

                node.Tag = new FileTreeNodeProperty(drive.Name, FileTreeNodeType.Drive, drive.Name);
            }
        }

        /// <summary>
        /// Initialize special folders
        /// </summary>
        private void InitializeSpecialFolders()
        {
            TreeNode nodeDesktop = fileTreeViewSpecialRoot__.Nodes.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_DESKTOP,
                SunnyChen.Gulu.Win.Properties.Resources.TEXT_DESKTOP, "Desktop", "Desktop");
            nodeDesktop.Tag = new FileTreeNodeProperty(SunnyChen.Gulu.Win.Properties.Resources.TEXT_DESKTOP, 
                FileTreeNodeType.Desktop, SpecialDirectories.Desktop);
            nodeDesktop.Nodes.Add(string.Empty);

            TreeNode nodeMyDocuments = fileTreeViewSpecialRoot__.Nodes.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_MYDOCUMENT,
                SunnyChen.Gulu.Win.Properties.Resources.TEXT_MYDOCUMENT, "MyDocuments", "MyDocuments");
            nodeMyDocuments.Tag = new FileTreeNodeProperty(SunnyChen.Gulu.Win.Properties.Resources.TEXT_MYDOCUMENT, 
                FileTreeNodeType.MyDocuments, SpecialDirectories.MyDocuments);
            nodeMyDocuments.Nodes.Add(string.Empty);
        }

        /// <summary>
        /// Enumerates directories and files under a specific tree node
        /// </summary>
        /// <param name="_current">The tree node to enumerate</param>
        private void EnumerateChildrenElements(TreeNode _current)
        {
            try
            {
                ConfigReader configReader = new ConfigReader();
                FileTreeNodeProperty prop = (FileTreeNodeProperty)_current.Tag;
                if (prop.Type == FileTreeNodeType.Root)
                    return;

                DirectoryInfo root = new DirectoryInfo(prop.FullPath);
                _current.Nodes.Clear();

                // Enumerate directories
                foreach (DirectoryInfo directory in root.GetDirectories())
                {
                    if (!configReader.FileTreeShowHidden && ((directory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                        continue;
                    
                    if (!configReader.FileTreeShowSystem && ((directory.Attributes & FileAttributes.System) == FileAttributes.System))
                        continue;

                    TreeNode nodeDirectory = _current.Nodes.Add(directory.Name, directory.Name, 3, 3);
                    
                    nodeDirectory.Tag = new FileTreeNodeProperty(directory.Name, 
                        FileTreeNodeType.Folder, 
                        directory.FullName, 
                        directory.Attributes);

                    if ((directory.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly || 
                        (directory.Attributes & FileAttributes.System) == FileAttributes.System)
                        nodeDirectory.ForeColor = Color.Silver;

                    nodeDirectory.Nodes.Add(string.Empty);
                }

                if (configReader.FileTreeShowFiles)
                {
                    // Enumerate files
                    foreach (FileInfo file in root.GetFiles())
                    {
                        if (!configReader.FileTreeShowHidden && ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                            continue;

                        if (!configReader.FileTreeShowSystem && ((file.Attributes & FileAttributes.System) == FileAttributes.System))
                            continue;

                        TreeNode nodeFile = _current.Nodes.Add(file.Name, file.Name, 5, 5);

                        nodeFile.Tag = new FileTreeNodeProperty(file.Name,
                            FileTreeNodeType.File,
                            file.FullName,
                            file.Attributes);

                        if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly ||
                            (file.Attributes & FileAttributes.System) == FileAttributes.System)
                            nodeFile.ForeColor = Color.Silver;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionMessageBox.ShowDialog(ex, true);
            }
        }

        private void AddOutput()
        {
            string message = OutputMessage.Instance.Message;
            outputBox.Items.Add(message);
            outputBox.SelectedIndex = outputBox.Items.Count - 1;
        }

        private void Delegated_AddOutput()
        {
            if (this.InvokeRequired)
            {
                VoidVoid d = new VoidVoid(Delegated_AddOutput);
                this.Invoke(d);
            }
            else
                AddOutput();
        }

        private void AddErrorList()
        {
            OutputErrorMessage errorMessage = OutputErrorMessage.Instance;
            Bitmap bmp;
            switch (errorMessage.Level)
            {
                case ErrorLevel.elOK:
                    bmp = SunnyChen.Gulu.Win.Properties.Resources.ICO_INFO.ToBitmap();
                    break;
                case ErrorLevel.elWarning:
                    bmp = SunnyChen.Gulu.Win.Properties.Resources.ICO_WARNING.ToBitmap();
                    break;
                default:
                    bmp = SunnyChen.Gulu.Win.Properties.Resources.ICO_ERROR.ToBitmap();
                    break;
            }
            errorList__.Rows.Add(new object[] { bmp, errorMessage.Code, errorMessage.Text, errorMessage.LineNum });
            //errorListGrid.DataSource = errorList__;
        }

        private void Delegated_AddErrorList()
        {
            if (this.InvokeRequired)
            {
                VoidVoid d = new VoidVoid(Delegated_AddErrorList);
                this.Invoke(d);
            }
            else
                AddErrorList();
        }

        private void ClearOutput()
        {
            if (dockManager.ControlPanes["mainTab"].Closed)
                dockManager.ControlPanes["mainTab"].Closed = false;

            dockManager.ControlPanes["mainTab"].Activate();
            outputBox.Items.Clear();
        }

        private void Delegated_ClearOutput()
        {
            if (this.InvokeRequired)
            {
                VoidVoid d = new VoidVoid(Delegated_ClearOutput);
                this.Invoke(d);
            }
            else
                ClearOutput();
        }

        private void ClearErrorList()
        {
            errorList__.Rows.Clear();
            //errorListGrid.DataSource = errorList__;
        }

        private void Delegated_ClearErrorList()
        {
            if (this.InvokeRequired)
            {
                VoidVoid d = new VoidVoid(Delegated_ClearErrorList);
                this.Invoke(d);
            }
            else
                ClearErrorList();
        }

        private void ShowOutput()
        {
            if (dockManager.ControlPanes["mainTab"].Closed)
            {
                dockManager.ControlPanes["mainTab"].Closed = false;
            }
            dockManager.ControlPanes["mainTab"].Activate();
            mainTab.SelectedTab = mainTab.Tabs["tbOutput"];
        }

        private void Delegated_ShowOutput()
        {
            if (this.InvokeRequired)
            {
                VoidVoid d = new VoidVoid(Delegated_ShowOutput);
                this.Invoke(d);
            }
            else
                ShowOutput();
        }

        private void ShowErrorList()
        {
            if (dockManager.ControlPanes["mainTab"].Closed)
            {
                dockManager.ControlPanes["mainTab"].Closed = false;
            }
            dockManager.ControlPanes["mainTab"].Activate();
            mainTab.SelectedTab = mainTab.Tabs["tbErrorList"];
        }

        private void Delegated_ShowErrorList()
        {
            if (this.InvokeRequired)
            {
                VoidVoid d = new VoidVoid(Delegated_ShowErrorList);
                this.Invoke(d);
            }
            else
                ShowErrorList();
        }

        private ToolBase GetTool(string _key)
        {
            return toolbarsManager.Tools[_key];
        }

        private void RunGulu(GuluBase _gulu)
        {
            if (guluWorkerRunning__)
            {
                MessageBox.Show("Running...");
                return;
            }
            frmFileList fileListForm = null;

            foreach (frmDummy child in this.MdiChildren)
            {
                if (child is frmFileList)
                {
                    fileListForm = (child as frmFileList);
                    break;
                }
            }

            if (fileListForm != null)
            {
                IList<ListViewItem> selectedItems = fileListForm.SelectedItems;

                if (selectedItems != null && _gulu != null)
                {
                    Output.Clear();

                    Output.Add(string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_INIT_GULU, _gulu.ToString()));

                    if (_gulu.Init())
                    {
                        if (dockManager.ControlPanes["mainTab"].Closed)
                        {
                            dockManager.ControlPanes["mainTab"].Closed = false;
                            dockManager.ControlPanes["mainTab"].Activate();
                        }

                        GuluWorkerParameter parameter = new GuluWorkerParameter(_gulu, selectedItems
                            /* Sunny Chen Added 2008/07/01 --> */
                            , globalConfigReader__
                            /* Sunny Chen Added 2008/07/01 <-- */
                            );
                        ParameterizedThreadStart threadStart = new ParameterizedThreadStart(worker__.WorkingThread);

                        workerThread__ = new Thread(threadStart);
                        workerThread__.Priority = ThreadPriority.BelowNormal;

                        guluWorkerThreads__.Add(workerThread__);
                        guluWorkerRunning__ = true;
                        workerThread__.Start(parameter);

                        GetTool("mnuStop").SharedProps.Enabled = true;

                        taskManager.Enabled = false;
                        fileTreeView.Enabled = false;
                    }
                    else
                        Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_GULU_INIT_FAILED);
                }
                else
                    MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_INFO_NOITEM,
                        SunnyChen.Gulu.Win.Properties.Resources.TEXT_INFORMATION,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_INFO_FILELIST_NOT_OPEN,
                        SunnyChen.Gulu.Win.Properties.Resources.TEXT_INFORMATION,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }

        #endregion

        #region Private User-Defined Event Handlers

        private void EventHandler_RefreshFileTreeViewCurrentNode(object sender, System.EventArgs e)
        {
            if (fileTreeView.SelectedNode != null)
                this.EnumerateChildrenElements(fileTreeView.SelectedNode);
        }

        private void EventHandler_OpenConfiguration(object sender, System.EventArgs e)
        {
            frmConfiguration configurationForm = new frmConfiguration();
            if (configurationForm.ShowDialog() == DialogResult.OK)
                this.EventHandler_RefreshFileTreeViewEntireTree(sender, e);
        }

        private void EventHandler_RefreshFileTreeViewEntireTree(object sender, System.EventArgs e)
        {
            this.InitializeFileTreeView();
        }

        private void EventHandler_ViewFileTreeNodeProperty(object sender, System.EventArgs e)
        {
            if (fileTreeView.SelectedNode != null)
                PropertyEditor.ShowInMDI(this,
                    string.Format(SunnyChen.Gulu.Win.Properties.Resources.FORMAT_PROPERTY_EDITOR_TITLE, fileTreeView.SelectedNode.Text), 
                    fileTreeView.SelectedNode.Tag);
        }

        private void EventHandler_OpenFilterSettings(object sender, System.EventArgs e)
        {
            frmFilters filterSettingsForm = new frmFilters();
            filterSettingsForm.ShowDialog();
        }

        private void EventHandler_OpenAboutDialogBox(object sender, System.EventArgs e)
        {
            frmAbout aboutForm = new frmAbout();
            aboutForm.ShowDialog();
        }

        private void EventHandler_OpenFileList(object sender, System.EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is frmFileList)
                {
                    form.BringToFront();
                    return;
                }
            }
            frmFileList selectedFilesAndFoldersForm = new frmFileList(this);

            #region Event Handlers
            selectedFilesAndFoldersForm.BeforeAddFolder += new frmFileList.BeforeAddFolderDelegate(selectedFilesAndFoldersForm_BeforeAddFolder);
            selectedFilesAndFoldersForm.AfterAddFolder += new frmFileList.AfterAddFolderDelegate(selectedFilesAndFoldersForm_AfterAddFolder);
            selectedFilesAndFoldersForm.DirectorySearching += new frmFileList.DirectorySearchingDelegate(selectedFilesAndFoldersForm_DirectorySearching);
            selectedFilesAndFoldersForm.FormClosed += new FormClosedEventHandler(selectedFilesAndFoldersForm_FormClosed);
            selectedFilesAndFoldersForm.ListCleared += new frmFileList.ClearListDelegate(selectedFilesAndFoldersForm_ListCleared);
            #endregion

            selectedFilesAndFoldersForm.Show();
        }

        
        #region SelectedFilesAndFoldersForm Event Handlers
        
        private void selectedFilesAndFoldersForm_ListCleared()
        {
            statusBar.Panels["ApplicationInformationCaption"].Text = string.Empty;
            statusBar.Panels["ApplicationInformation"].Text = string.Empty;
        }

        private void selectedFilesAndFoldersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            statusBar.Panels["ApplicationInformationCaption"].Text = string.Empty;
            statusBar.Panels["ApplicationInformation"].Text = string.Empty;
        }
        
        private void selectedFilesAndFoldersForm_DirectorySearching(object sender, DirectorySearchingEventArgs e)
        {
            statusBar.Panels["ApplicationInformation"].Text = e.Directory;
            statusBar.Panels["ApplicationInformationCaption"].Text = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_SEARCHING_DIRECTORY, e.CurrentlyAdded);
        }

        private void selectedFilesAndFoldersForm_BeforeAddFolder(object sender, System.EventArgs e)
        {
            GetTool("mnuRefreshFileTreeViewCurrentNode").SharedProps.Enabled = false;
            GetTool("mnuRefreshFileTree").SharedProps.Enabled = false;
            GetTool("mnuRefreshFileTreeViewEntireTree").SharedProps.Enabled = false;
            GetTool("mnuFileTreeNodeProperty").SharedProps.Enabled = false;
            fileTreeView.Enabled = false;
            taskManager.Enabled = false;
        }

        private void selectedFilesAndFoldersForm_AfterAddFolder(object sender, FilesAddedEventArgs e)
        {

            GetTool("mnuRefreshFileTreeViewCurrentNode").SharedProps.Enabled = true;
            GetTool("mnuRefreshFileTree").SharedProps.Enabled = true;
            GetTool("mnuRefreshFileTreeViewEntireTree").SharedProps.Enabled = true;
            GetTool("mnuFileTreeNodeProperty").SharedProps.Enabled = true;
            fileTreeView.Enabled = true;
            taskManager.Enabled = true;

            statusBar.Panels["ApplicationInformationCaption"].Text = SunnyChen.Gulu.Win.Properties.Resources.TEXT_SEARCH_COMPLETED;
            statusBar.Panels["ApplicationInformation"].Text = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_SEARCH_RESULT, e.FilesAdded);
            statusBar.Refresh();
            statusBar.Invalidate();
        }

        #endregion

        private void EventHandler_AddOutput(object sender, System.EventArgs e)
        {
            this.AddOutput();
        }

        private void EventHandler_ClearOutput(object sender, System.EventArgs e)
        {
            this.ClearOutput();
        }

        private void EventHandler_AddErrorList(object sender, System.EventArgs e)
        {
            this.AddErrorList();
        }

        private void EventHandler_ClearErrorList(object sender, System.EventArgs e)
        {
            this.ClearErrorList();
        }

        private void EventHandler_ShowOutput(object sender, System.EventArgs e)
        {
            this.ShowOutput();
        }

        private void EventHandler_ShowErrorList(object sender, System.EventArgs e)
        {
            this.ShowErrorList();
        }

        private void EventHandler_StopGuluWorker(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_CONFIRM_INTERRUPT, 
                SunnyChen.Gulu.Win.Properties.Resources.TEXT_CONFIRMATION, 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
                worker__.ShouldStop = true;
        }

        private void EventHandler_OpenGScriptManager(object sender, System.EventArgs e)
        {
            foreach (Form form in MdiChildren)
            {
                if (form is frmGScriptManager)
                {
                    form.BringToFront();
                    return;
                }
            }
            frmGScriptManager gscriptManagerForm = new frmGScriptManager(this, compiler__, globalConfigReader__);
            gscriptManagerForm.Show();
        }

        private void EventHandler_OpenDynamicHelp(object sender, System.EventArgs e)
        {
            frmDynamicHelp dynamicHelpForm = new frmDynamicHelp(this);
            dynamicHelpForm.Show();
        }

        private void EventHandler_OpenSystemCalculator(object sender, System.EventArgs e)
        {
            ShellApi.ShellExecute(this.Handle, 
                ShellExecute.OpenFile, 
                "calc.exe", 
                null, 
                null, 
                Convert.ToInt32(ShellExecute.ShowWindowCommands.SW_SHOW));
        }

        private void EventHandler_OpenUserGuide(object sender, System.EventArgs e)
        {
            if (!File.Exists(Directories.UserGuideFileName))
            {
                MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_USERGUIDE_NOT_FOUND,
                    SunnyChen.Gulu.Win.Properties.Resources.TEXT_WARNING,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ShellApi.ShellExecute(this.Handle,
                ShellExecute.OpenFile,
                Directories.UserGuideFileName,
                null,
                null,
                Convert.ToInt32(ShellExecute.ShowWindowCommands.SW_SHOW));
        }

        private void EventHandler_OpenDeveloperManual(object sender, System.EventArgs e)
        {
            if (!File.Exists(Directories.DevelopManualFileName))
            {
                MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_DEVELOPERMANUAL_NOT_FOUND,
                    SunnyChen.Gulu.Win.Properties.Resources.TEXT_WARNING,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ShellApi.ShellExecute(this.Handle,
                ShellExecute.OpenFile,
                Directories.DevelopManualFileName,
                null,
                null,
                Convert.ToInt32(ShellExecute.ShowWindowCommands.SW_SHOW));
        }

        private void EventHandler_OpenCommonLibraryHelp(object sender, System.EventArgs e)
        {
            if (!File.Exists(Directories.CommonClassLibraryFileName))
            {
                MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_DEVELOPERMANUAL_NOT_FOUND,
                    SunnyChen.Gulu.Win.Properties.Resources.TEXT_WARNING,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ShellApi.ShellExecute(this.Handle,
                ShellExecute.OpenFile,
                Directories.CommonClassLibraryFileName,
                null,
                null,
                Convert.ToInt32(ShellExecute.ShowWindowCommands.SW_SHOW));
        }

        private void EventHandler_OpenGuluLibraryHelp(object sender, System.EventArgs e)
        {
            if (!File.Exists(Directories.GuluClassLibraryFileName))
            {
                MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_DEVELOPERMANUAL_NOT_FOUND,
                    SunnyChen.Gulu.Win.Properties.Resources.TEXT_WARNING,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            ShellApi.ShellExecute(this.Handle,
                ShellExecute.OpenFile,
                Directories.GuluClassLibraryFileName,
                null,
                null,
                Convert.ToInt32(ShellExecute.ShowWindowCommands.SW_SHOW));
        }

        private void EventHandler_ShowSessionStatus(object sender, System.EventArgs e)
        {
            mainTab.SelectedTab = mainTab.Tabs["tbSessionStatus"];
            dockManager.ControlPanes["mainTab"].Activate();
            dockManager.ControlPanes["mainTab"].Closed = false;
        }

        private void EventHandler_OpenFileTreeView(object sender, System.EventArgs e)
        {
            DockableControlPane fileTreeViewPane = dockManager.ControlPanes["fileTreeView"];
            if (fileTreeViewPane != null)
            {
                fileTreeViewPane.Activate();
                if (fileTreeViewPane.Closed)
                    fileTreeViewPane.Closed = false;
            }
        }

        private void EventHandler_OpenGuluManager(object sender, System.EventArgs e)
        {
            DockableControlPane guluManagerPane = dockManager.ControlPanes["guluManager"];
            if (guluManagerPane != null)
            {
                guluManagerPane.Activate();
                if (guluManagerPane.Closed)
                    guluManagerPane.Closed = false;
            }
        }

        private void EventHandler_OpenStatusAndInformation(object sender, System.EventArgs e)
        {
            DockableControlPane mainTabPane = dockManager.ControlPanes["mainTab"];
            if (mainTabPane != null)
            {
                mainTabPane.Activate();
                if (mainTabPane.Closed)
                    mainTabPane.Closed = false;
                mainTabPane.Unpin();
            }
        }
        #endregion

        #region Overrided Methods

        protected override void WndProc(ref Message m)
        {
            MessageHelper.Messages message = (MessageHelper.Messages)m.Msg;
            switch (message)
            {
                case MessageHelper.Messages.AddOutput:
                    EventHandler_AddOutput(this, null);
                    break;
                case MessageHelper.Messages.ClearOutput:
                    EventHandler_ClearOutput(this, null);
                    break;
                case MessageHelper.Messages.RunGulu:
                    GuluBase gulu = Session.CurrentSession.Gulu;
                    this.RunGulu(gulu);
                    break;
                case MessageHelper.Messages.AddErrorMessage:
                    EventHandler_AddErrorList(this, null);
                    break;
                case MessageHelper.Messages.ClearErrorMessage:
                    EventHandler_ClearErrorList(this, null);
                    break;
                case MessageHelper.Messages.ShowErrorList:
                    EventHandler_ShowErrorList(this, null);
                    break;
                case MessageHelper.Messages.ShowOutput:
                    EventHandler_ShowOutput(this, null);
                    break;
                case MessageHelper.Messages.HideProgress:
                    statusBar.Panels["Progress"].Visible = false;
                    break;
                case MessageHelper.Messages.ShowProgress:
                    statusBar.Panels["Progress"].Visible = true;
                    break;
                case MessageHelper.Messages.SetProgress:
                    int current = m.WParam.ToInt32();
                    int max = m.LParam.ToInt32();
                    statusBar.Panels["Progress"].ProgressBarInfo.Maximum = max;
                    statusBar.Panels["Progress"].ProgressBarInfo.Value = current;
                    break;
                case MessageHelper.Messages.ShowSessionStatus:
                    EventHandler_ShowSessionStatus(this, null);
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        public override void UpdateElements()
        {
            if (this.MdiChildren.Length > 0 && (this.ActiveMdiChild is frmDummy))
            {
                frmDummy child = (this.ActiveMdiChild as frmDummy);
                GetTool("mnuNew").SharedProps.Enabled = child.CanNew;
                GetTool("mnuOpen").SharedProps.Enabled = child.CanOpen;
                GetTool("mnuSave").SharedProps.Enabled = child.CanSave;
            }
            else
            {
                GetTool("mnuNew").SharedProps.Enabled = false;
                GetTool("mnuOpen").SharedProps.Enabled = false;
                GetTool("mnuSave").SharedProps.Enabled = false;
            }
        }
        #endregion

        #region Generated Event Handlers

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            

        }

        private void fileTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text.Equals(string.Empty))
            {
                FileTreeNodeProperty prop = (FileTreeNodeProperty)e.Node.Tag;
                this.EnumerateChildrenElements(e.Node);
            }
        }

        private void fileTreeView_DoubleClick(object sender, System.EventArgs e)
        {
            if (fileTreeView.SelectedNode != null)
            {
                FileTreeNodeProperty prop = (FileTreeNodeProperty)fileTreeView.SelectedNode.Tag;
                if (prop != null && prop.Type == FileTreeNodeType.File)
                {
                    ShellExecute shellExecute = new ShellExecute(this.Handle, prop.FullPath);
                    shellExecute.Execute();
                }
            }
        }

        private void fileTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode treeNode = fileTreeView.GetNodeAt(e.X, e.Y);
            if (treeNode != null)
                fileTreeView.SelectedNode = treeNode;
        }

        private void toolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            using (new LengthyOperation(this))
            {
                switch (e.Tool.Key)
                {
                    case "mnuNew":
                        this.InvokeAction<frmMain, NewActionAttribute>();
                        break;
                    case "mnuOpen":
                        this.InvokeAction<frmMain, OpenActionAttribute>();
                        break;
                    case "mnuSave":
                        this.InvokeAction<frmMain, SaveActionAttribute>();
                        break;
                    case "mnuRefreshFileTreeViewCurrentNode":
                    case "mnuRefreshFileTree":
                        this.EventHandler_RefreshFileTreeViewCurrentNode(sender, e);
                        break;
                    case "mnuRefreshFileTreeViewEntireTree":
                        this.EventHandler_RefreshFileTreeViewEntireTree(sender, e);
                        break;
                    case "mnuFileTreeNodeProperty":
                        this.EventHandler_ViewFileTreeNodeProperty(sender, e);
                        break;
                    case "mnuFilterSettings":
                        this.EventHandler_OpenFilterSettings(sender, e);
                        break;
                    case "mnuAbout":
                        this.EventHandler_OpenAboutDialogBox(sender, e);
                        break;
                    case "mnuFileList":
                        this.EventHandler_OpenFileList(sender, e);
                        break;
                    case "mnuStop":
                        this.EventHandler_StopGuluWorker(sender, e);
                        break;
                    case "mnuGScriptManager":
                        this.EventHandler_OpenGScriptManager(sender, e);
                        break;
                    case "mnuConfiguration":
                        this.EventHandler_OpenConfiguration(sender, e);
                        break;
                    case "mnuDynamicHelp":
                        this.EventHandler_OpenDynamicHelp(sender, e);
                        break;
                    case "mnuSystemCalculator":
                        this.EventHandler_OpenSystemCalculator(sender, e);
                        break;
                    case "mnuUserGuide":
                        this.EventHandler_OpenUserGuide(sender, e);
                        break;
                    case "mnuDeveloperManual":
                        this.EventHandler_OpenDeveloperManual(sender, e);
                        break;
                    case "mnuSessionStatus":
                        this.EventHandler_ShowSessionStatus(sender, e);
                        break;
                    case "mnuShowOutputWindow":
                        this.EventHandler_ShowOutput(sender, e);
                        break;
                    case "mnuClearOutputWindow":
                        this.EventHandler_ClearOutput(sender, e);
                        break;
                    case "mnuShowErrorList":
                        this.EventHandler_ShowErrorList(sender, e);
                        break;
                    case "mnuClearErrorList":
                        this.EventHandler_ClearErrorList(sender, e);
                        break;
                    case "mnuFileTree":
                        this.EventHandler_OpenFileTreeView(sender, e);
                        break;
                    case "mnuGuluManager":
                        this.EventHandler_OpenGuluManager(sender, e);
                        break;
                    case "mnuStatusAndInformation":
                        this.EventHandler_OpenStatusAndInformation(sender, e);
                        break;
                    case "mnuCommonClassLibrary":
                        this.EventHandler_OpenCommonLibraryHelp(sender, e);
                        break;
                    case "mnuGuluClassLibrary":
                        this.EventHandler_OpenGuluLibraryHelp(sender, e);
                        break;
                    case "mnuExit":
                        Close();
                        break;
                    default:
                        break;
                }
            }
        }

        private void fileTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Link);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            guluWorkerRunning__ = false;
            worker__.ShouldStop = true;

            foreach (Thread thread in guluWorkerThreads__)
            {
                if (thread != null)
                {
                    thread.Abort();
                    thread.Join();
                }
            }
            GC.Collect();
        }

        /// <summary>
        /// Fires when an item on the task manager is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskManager_ItemClick(object sender, ItemEventArgs e)
        {
            GuluBase gulu = (GuluBase)e.Item.Tag;
            Session.CurrentSession.SetGulu(gulu);
            this.RunGulu(gulu);
        }

        /// <summary>
        /// Fires when the gulu worker is finished
        /// </summary>
        /// <param name="sender">Finisher</param>
        /// <param name="e">The finishing event parameter, includes the current gulu and the finishing method.</param>
        private void worker___Finished(object sender, GuluWorkerFinishedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                GuluWorker.GuluWorkerFinishedDelegate d = new GuluWorker.GuluWorkerFinishedDelegate(worker___Finished);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                
                Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_DONE_GULU);
                e.Gulu.Done();

                if (e.Interrupted)
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_TERMINATED_USER);
                else
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_TERMINATED_NORMALLY);

                toolbarsManager.Tools["mnuStop"].SharedProps.Enabled = false;
                taskManager.Enabled = true;
                fileTreeView.Enabled = true;
                guluWorkerRunning__ = false;
            }
        }

        private void frmMain_Shown(object sender, System.EventArgs e)
        {
            // Brings the main form to the top
            Api.SetForegroundWindow(this.Handle.ToInt32());
            this.Focus();
        }

        private void tmrUpdateSessionStatus_Tick(object sender, System.EventArgs e)
        {
            TreeNode node = tvSessionStatus.Nodes["TimeElapsed"];
            if (node != null)
            {
                node.Text = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_PROMPT_TIME_ELAPSED,
                    Session.CurrentSession.TimeElapsed.ToString());
            }
        }
        #endregion
    }
}
