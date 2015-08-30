namespace SunnyChen.Gulu.Win
{
    partial class frmGScriptManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGScriptManager));
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("GScript manager menu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuGScript");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar4 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("GScript");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCompile");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuRun");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuDelete");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuGScript");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCompile");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuRun");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuDelete");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCompile");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuRun");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.treeViewList = new System.Windows.Forms.ImageList(this.components);
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.toolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.frmGScriptManager_Fill_Panel = new System.Windows.Forms.Panel();
            this.gscriptTreeView = new System.Windows.Forms.TreeView();
            this._frmGScriptManager_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmGScriptManager_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmGScriptManager_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarsManager)).BeginInit();
            this.frmGScriptManager_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewList
            // 
            this.treeViewList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewList.ImageStream")));
            this.treeViewList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.treeViewList.Images.SetKeyName(0, "GScriptRoot");
            this.treeViewList.Images.SetKeyName(1, "SimpleScriptRoot");
            this.treeViewList.Images.SetKeyName(2, "Script");
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.Filter = "*.gs";
            this.fileSystemWatcher.IncludeSubdirectories = true;
            this.fileSystemWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher_Renamed);
            this.fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Deleted);
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Created);
            // 
            // toolbarsManager
            // 
            this.toolbarsManager.DesignerFlags = 1;
            this.toolbarsManager.DockWithinContainer = this;
            this.toolbarsManager.DockWithinContainerBaseType = typeof(SunnyChen.Gulu.Win.frmDummy);
            this.toolbarsManager.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolbarsManager.ShowFullMenusDelay = 500;
            this.toolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar3.DockedColumn = 0;
            ultraToolbar3.DockedRow = 0;
            ultraToolbar3.IsMainMenuBar = true;
            ultraToolbar3.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3});
            ultraToolbar4.DockedColumn = 0;
            ultraToolbar4.DockedRow = 1;
            buttonTool12.InstanceProps.IsFirstInGroup = true;
            ultraToolbar4.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10,
            buttonTool11,
            buttonTool12});
            this.toolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar3,
            ultraToolbar4});
            popupMenuTool4.SharedProps.Caption = resources.GetString("resource.Caption");
            popupMenuTool4.SharedProps.MergeOrder = 210;
            popupMenuTool4.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText");
            buttonTool15.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool13,
            buttonTool14,
            buttonTool15});
            appearance4.Image = global::SunnyChen.Gulu.Win.Properties.Resources.BMP_DELETE;
            resources.ApplyResources(appearance4, "appearance4");
            buttonTool16.SharedProps.AppearancesSmall.Appearance = appearance4;
            buttonTool16.SharedProps.Caption = resources.GetString("resource.Caption1");
            buttonTool16.SharedProps.Shortcut = System.Windows.Forms.Shortcut.ShiftDel;
            buttonTool16.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText1");
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            resources.ApplyResources(appearance5, "appearance5");
            buttonTool17.SharedProps.AppearancesSmall.Appearance = appearance5;
            buttonTool17.SharedProps.Caption = resources.GetString("resource.Caption2");
            buttonTool17.SharedProps.Shortcut = System.Windows.Forms.Shortcut.CtrlF9;
            buttonTool17.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText2");
            appearance6.Image = global::SunnyChen.Gulu.Win.Properties.Resources.BMP_RUN;
            resources.ApplyResources(appearance6, "appearance6");
            buttonTool18.SharedProps.AppearancesSmall.Appearance = appearance6;
            buttonTool18.SharedProps.Caption = resources.GetString("resource.Caption3");
            buttonTool18.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            buttonTool18.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText3");
            this.toolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            buttonTool16,
            buttonTool17,
            buttonTool18});
            this.toolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.toolbarsManager_ToolClick);
            // 
            // frmGScriptManager_Fill_Panel
            // 
            this.frmGScriptManager_Fill_Panel.AccessibleDescription = null;
            this.frmGScriptManager_Fill_Panel.AccessibleName = null;
            resources.ApplyResources(this.frmGScriptManager_Fill_Panel, "frmGScriptManager_Fill_Panel");
            this.frmGScriptManager_Fill_Panel.BackgroundImage = null;
            this.frmGScriptManager_Fill_Panel.Controls.Add(this.gscriptTreeView);
            this.frmGScriptManager_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmGScriptManager_Fill_Panel.Font = null;
            this.frmGScriptManager_Fill_Panel.Name = "frmGScriptManager_Fill_Panel";
            // 
            // gscriptTreeView
            // 
            this.gscriptTreeView.AccessibleDescription = null;
            this.gscriptTreeView.AccessibleName = null;
            resources.ApplyResources(this.gscriptTreeView, "gscriptTreeView");
            this.gscriptTreeView.BackgroundImage = null;
            this.gscriptTreeView.Font = null;
            this.gscriptTreeView.HideSelection = false;
            this.gscriptTreeView.ImageList = this.treeViewList;
            this.gscriptTreeView.Name = "gscriptTreeView";
            this.gscriptTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gscriptTreeView_MouseClick);
            this.gscriptTreeView.DoubleClick += new System.EventHandler(this.gscriptTreeView_DoubleClick);
            this.gscriptTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.gscriptTreeView_AfterSelect);
            // 
            // _frmGScriptManager_Toolbars_Dock_Area_Left
            // 
            this._frmGScriptManager_Toolbars_Dock_Area_Left.AccessibleDescription = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Left.AccessibleName = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmGScriptManager_Toolbars_Dock_Area_Left, "_frmGScriptManager_Toolbars_Dock_Area_Left");
            this._frmGScriptManager_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmGScriptManager_Toolbars_Dock_Area_Left.BackgroundImage = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmGScriptManager_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGScriptManager_Toolbars_Dock_Area_Left.Name = "_frmGScriptManager_Toolbars_Dock_Area_Left";
            this._frmGScriptManager_Toolbars_Dock_Area_Left.ToolbarsManager = this.toolbarsManager;
            // 
            // _frmGScriptManager_Toolbars_Dock_Area_Right
            // 
            this._frmGScriptManager_Toolbars_Dock_Area_Right.AccessibleDescription = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Right.AccessibleName = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmGScriptManager_Toolbars_Dock_Area_Right, "_frmGScriptManager_Toolbars_Dock_Area_Right");
            this._frmGScriptManager_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmGScriptManager_Toolbars_Dock_Area_Right.BackgroundImage = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmGScriptManager_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGScriptManager_Toolbars_Dock_Area_Right.Name = "_frmGScriptManager_Toolbars_Dock_Area_Right";
            this._frmGScriptManager_Toolbars_Dock_Area_Right.ToolbarsManager = this.toolbarsManager;
            // 
            // _frmGScriptManager_Toolbars_Dock_Area_Top
            // 
            this._frmGScriptManager_Toolbars_Dock_Area_Top.AccessibleDescription = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Top.AccessibleName = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmGScriptManager_Toolbars_Dock_Area_Top, "_frmGScriptManager_Toolbars_Dock_Area_Top");
            this._frmGScriptManager_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmGScriptManager_Toolbars_Dock_Area_Top.BackgroundImage = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmGScriptManager_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGScriptManager_Toolbars_Dock_Area_Top.Name = "_frmGScriptManager_Toolbars_Dock_Area_Top";
            this._frmGScriptManager_Toolbars_Dock_Area_Top.ToolbarsManager = this.toolbarsManager;
            // 
            // _frmGScriptManager_Toolbars_Dock_Area_Bottom
            // 
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.AccessibleDescription = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.AccessibleName = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmGScriptManager_Toolbars_Dock_Area_Bottom, "_frmGScriptManager_Toolbars_Dock_Area_Bottom");
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.BackgroundImage = null;
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.Name = "_frmGScriptManager_Toolbars_Dock_Area_Bottom";
            this._frmGScriptManager_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.toolbarsManager;
            // 
            // frmGScriptManager
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.frmGScriptManager_Fill_Panel);
            this.Controls.Add(this._frmGScriptManager_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmGScriptManager_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmGScriptManager_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._frmGScriptManager_Toolbars_Dock_Area_Bottom);
            this.Name = "frmGScriptManager";
            this.Load += new System.EventHandler(this.frmGScriptManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarsManager)).EndInit();
            this.frmGScriptManager_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeViewList;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.Panel frmGScriptManager_Fill_Panel;
        private System.Windows.Forms.TreeView gscriptTreeView;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmGScriptManager_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager toolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmGScriptManager_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmGScriptManager_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmGScriptManager_Toolbars_Dock_Area_Bottom;
    }
}