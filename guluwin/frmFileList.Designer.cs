namespace SunnyChen.Gulu.Win
{
    partial class frmFileList
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("File list");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuStopSearch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuClearList");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCheckAll");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuUncheckAll");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Selected files");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuSelection");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuStopSearch");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuClearList");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCheckAll");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuUncheckAll");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("mnuSelection");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuStopSearch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuClearList");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuCheckAll");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("mnuUncheckAll");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileList));
            this.toolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.frmFileList_Fill_Panel = new System.Windows.Forms.Panel();
            this.fileList = new System.Windows.Forms.ListView();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colFullPath = new System.Windows.Forms.ColumnHeader();
            this._frmFileList_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmFileList_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmFileList_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._frmFileList_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarsManager)).BeginInit();
            this.frmFileList_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarsManager
            // 
            this.toolbarsManager.DesignerFlags = 1;
            this.toolbarsManager.DockWithinContainer = this;
            this.toolbarsManager.DockWithinContainerBaseType = typeof(SunnyChen.Gulu.Win.frmDummy);
            this.toolbarsManager.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolbarsManager.ShowFullMenusDelay = 500;
            this.toolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 1;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4});
            resources.ApplyResources(ultraToolbar1, "ultraToolbar1");
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.FloatingSize = new System.Drawing.Size(100, 20);
            ultraToolbar2.IsMainMenuBar = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1});
            resources.ApplyResources(ultraToolbar2, "ultraToolbar2");
            this.toolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            resources.ApplyResources(appearance1, "appearance1");
            buttonTool5.SharedProps.AppearancesSmall.Appearance = appearance1;
            buttonTool5.SharedProps.Caption = resources.GetString("resource.Caption");
            buttonTool5.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText");
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            resources.ApplyResources(appearance2, "appearance2");
            buttonTool6.SharedProps.AppearancesSmall.Appearance = appearance2;
            buttonTool6.SharedProps.Caption = resources.GetString("resource.Caption1");
            buttonTool6.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText1");
            appearance3.Image = ((object)(resources.GetObject("appearance3.Image")));
            resources.ApplyResources(appearance3, "appearance3");
            buttonTool7.SharedProps.AppearancesSmall.Appearance = appearance3;
            buttonTool7.SharedProps.Caption = resources.GetString("resource.Caption2");
            buttonTool7.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText2");
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            resources.ApplyResources(appearance4, "appearance4");
            buttonTool8.SharedProps.AppearancesSmall.Appearance = appearance4;
            buttonTool8.SharedProps.Caption = resources.GetString("resource.Caption3");
            buttonTool8.SharedProps.ToolTipText = resources.GetString("resource.ToolTipText3");
            popupMenuTool2.SharedProps.Caption = resources.GetString("resource.Caption4");
            popupMenuTool2.SharedProps.MergeOrder = 210;
            buttonTool10.InstanceProps.IsFirstInGroup = true;
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12});
            this.toolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            popupMenuTool2});
            this.toolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.toolbarsManager_ToolClick);
            // 
            // frmFileList_Fill_Panel
            // 
            this.frmFileList_Fill_Panel.AccessibleDescription = null;
            this.frmFileList_Fill_Panel.AccessibleName = null;
            resources.ApplyResources(this.frmFileList_Fill_Panel, "frmFileList_Fill_Panel");
            this.frmFileList_Fill_Panel.BackgroundImage = null;
            this.frmFileList_Fill_Panel.Controls.Add(this.fileList);
            this.frmFileList_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmFileList_Fill_Panel.Font = null;
            this.frmFileList_Fill_Panel.Name = "frmFileList_Fill_Panel";
            // 
            // fileList
            // 
            this.fileList.AccessibleDescription = null;
            this.fileList.AccessibleName = null;
            resources.ApplyResources(this.fileList, "fileList");
            this.fileList.AllowDrop = true;
            this.fileList.BackgroundImage = null;
            this.fileList.CheckBoxes = true;
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colSize,
            this.colFullPath});
            this.fileList.Font = null;
            this.fileList.HideSelection = false;
            this.fileList.MultiSelect = false;
            this.fileList.Name = "fileList";
            this.fileList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            this.fileList.VirtualMode = true;
            this.fileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileList_MouseDoubleClick);
            this.fileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileList_MouseClick);
            this.fileList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.fileList_DrawItem);
            this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
            this.fileList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.fileList_RetrieveVirtualItem);
            this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
            // 
            // colFileName
            // 
            resources.ApplyResources(this.colFileName, "colFileName");
            // 
            // colSize
            // 
            resources.ApplyResources(this.colSize, "colSize");
            // 
            // colFullPath
            // 
            resources.ApplyResources(this.colFullPath, "colFullPath");
            // 
            // _frmFileList_Toolbars_Dock_Area_Left
            // 
            this._frmFileList_Toolbars_Dock_Area_Left.AccessibleDescription = null;
            this._frmFileList_Toolbars_Dock_Area_Left.AccessibleName = null;
            this._frmFileList_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmFileList_Toolbars_Dock_Area_Left, "_frmFileList_Toolbars_Dock_Area_Left");
            this._frmFileList_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmFileList_Toolbars_Dock_Area_Left.BackgroundImage = null;
            this._frmFileList_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._frmFileList_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmFileList_Toolbars_Dock_Area_Left.Name = "_frmFileList_Toolbars_Dock_Area_Left";
            this._frmFileList_Toolbars_Dock_Area_Left.ToolbarsManager = this.toolbarsManager;
            // 
            // _frmFileList_Toolbars_Dock_Area_Right
            // 
            this._frmFileList_Toolbars_Dock_Area_Right.AccessibleDescription = null;
            this._frmFileList_Toolbars_Dock_Area_Right.AccessibleName = null;
            this._frmFileList_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmFileList_Toolbars_Dock_Area_Right, "_frmFileList_Toolbars_Dock_Area_Right");
            this._frmFileList_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmFileList_Toolbars_Dock_Area_Right.BackgroundImage = null;
            this._frmFileList_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._frmFileList_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmFileList_Toolbars_Dock_Area_Right.Name = "_frmFileList_Toolbars_Dock_Area_Right";
            this._frmFileList_Toolbars_Dock_Area_Right.ToolbarsManager = this.toolbarsManager;
            // 
            // _frmFileList_Toolbars_Dock_Area_Top
            // 
            this._frmFileList_Toolbars_Dock_Area_Top.AccessibleDescription = null;
            this._frmFileList_Toolbars_Dock_Area_Top.AccessibleName = null;
            this._frmFileList_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmFileList_Toolbars_Dock_Area_Top, "_frmFileList_Toolbars_Dock_Area_Top");
            this._frmFileList_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmFileList_Toolbars_Dock_Area_Top.BackgroundImage = null;
            this._frmFileList_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._frmFileList_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmFileList_Toolbars_Dock_Area_Top.Name = "_frmFileList_Toolbars_Dock_Area_Top";
            this._frmFileList_Toolbars_Dock_Area_Top.ToolbarsManager = this.toolbarsManager;
            // 
            // _frmFileList_Toolbars_Dock_Area_Bottom
            // 
            this._frmFileList_Toolbars_Dock_Area_Bottom.AccessibleDescription = null;
            this._frmFileList_Toolbars_Dock_Area_Bottom.AccessibleName = null;
            this._frmFileList_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            resources.ApplyResources(this._frmFileList_Toolbars_Dock_Area_Bottom, "_frmFileList_Toolbars_Dock_Area_Bottom");
            this._frmFileList_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._frmFileList_Toolbars_Dock_Area_Bottom.BackgroundImage = null;
            this._frmFileList_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._frmFileList_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._frmFileList_Toolbars_Dock_Area_Bottom.Name = "_frmFileList_Toolbars_Dock_Area_Bottom";
            this._frmFileList_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.toolbarsManager;
            // 
            // frmFileList
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.frmFileList_Fill_Panel);
            this.Controls.Add(this._frmFileList_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._frmFileList_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._frmFileList_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._frmFileList_Toolbars_Dock_Area_Bottom);
            this.Name = "frmFileList";
            this.Load += new System.EventHandler(this.frmFileList_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFileList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.toolbarsManager)).EndInit();
            this.frmFileList_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager toolbarsManager;
        private System.Windows.Forms.Panel frmFileList_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmFileList_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmFileList_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmFileList_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _frmFileList_Toolbars_Dock_Area_Bottom;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colFullPath;
    }
}