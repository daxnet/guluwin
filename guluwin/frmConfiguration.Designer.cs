namespace SunnyChen.Gulu.Win
{
    partial class frmConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguration));
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.tpPreferences = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSearchRecursivly = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowSystem = new System.Windows.Forms.CheckBox();
            this.chkShowFiles = new System.Windows.Forms.CheckBox();
            this.chkShowHidden = new System.Windows.Forms.CheckBox();
            this.tpBackup = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.btnSelectBackupDirectory = new System.Windows.Forms.Button();
            this.txtBackupDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEnableBackup = new System.Windows.Forms.CheckBox();
            this.tpEditorAndCompiler = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSelectCodeDomCompiler = new System.Windows.Forms.Button();
            this.txtCodeDomCompilerType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSyntaxFile = new System.Windows.Forms.ComboBox();
            this.cbGTemplate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSimpleTemplate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openSyntaxFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tpPreferences.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpBackup.SuspendLayout();
            this.tpEditorAndCompiler.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpPreferences
            // 
            this.tpPreferences.AccessibleDescription = null;
            this.tpPreferences.AccessibleName = null;
            resources.ApplyResources(this.tpPreferences, "tpPreferences");
            this.tpPreferences.Controls.Add(this.groupBox2);
            this.tpPreferences.Controls.Add(this.groupBox1);
            this.tpPreferences.Font = null;
            this.tpPreferences.Name = "tpPreferences";
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.chkSearchRecursivly);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // chkSearchRecursivly
            // 
            this.chkSearchRecursivly.AccessibleDescription = null;
            this.chkSearchRecursivly.AccessibleName = null;
            resources.ApplyResources(this.chkSearchRecursivly, "chkSearchRecursivly");
            this.chkSearchRecursivly.BackgroundImage = null;
            this.chkSearchRecursivly.Font = null;
            this.chkSearchRecursivly.Name = "chkSearchRecursivly";
            this.chkSearchRecursivly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.chkShowSystem);
            this.groupBox1.Controls.Add(this.chkShowFiles);
            this.groupBox1.Controls.Add(this.chkShowHidden);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkShowSystem
            // 
            this.chkShowSystem.AccessibleDescription = null;
            this.chkShowSystem.AccessibleName = null;
            resources.ApplyResources(this.chkShowSystem, "chkShowSystem");
            this.chkShowSystem.BackgroundImage = null;
            this.chkShowSystem.Font = null;
            this.chkShowSystem.Name = "chkShowSystem";
            this.chkShowSystem.UseVisualStyleBackColor = true;
            // 
            // chkShowFiles
            // 
            this.chkShowFiles.AccessibleDescription = null;
            this.chkShowFiles.AccessibleName = null;
            resources.ApplyResources(this.chkShowFiles, "chkShowFiles");
            this.chkShowFiles.BackgroundImage = null;
            this.chkShowFiles.Font = null;
            this.chkShowFiles.Name = "chkShowFiles";
            this.chkShowFiles.UseVisualStyleBackColor = true;
            // 
            // chkShowHidden
            // 
            this.chkShowHidden.AccessibleDescription = null;
            this.chkShowHidden.AccessibleName = null;
            resources.ApplyResources(this.chkShowHidden, "chkShowHidden");
            this.chkShowHidden.BackgroundImage = null;
            this.chkShowHidden.Font = null;
            this.chkShowHidden.Name = "chkShowHidden";
            this.chkShowHidden.UseVisualStyleBackColor = true;
            // 
            // tpBackup
            // 
            this.tpBackup.AccessibleDescription = null;
            this.tpBackup.AccessibleName = null;
            resources.ApplyResources(this.tpBackup, "tpBackup");
            this.tpBackup.Controls.Add(this.btnSelectBackupDirectory);
            this.tpBackup.Controls.Add(this.txtBackupDirectory);
            this.tpBackup.Controls.Add(this.label1);
            this.tpBackup.Controls.Add(this.chkEnableBackup);
            this.tpBackup.Font = null;
            this.tpBackup.Name = "tpBackup";
            // 
            // btnSelectBackupDirectory
            // 
            this.btnSelectBackupDirectory.AccessibleDescription = null;
            this.btnSelectBackupDirectory.AccessibleName = null;
            resources.ApplyResources(this.btnSelectBackupDirectory, "btnSelectBackupDirectory");
            this.btnSelectBackupDirectory.BackgroundImage = null;
            this.btnSelectBackupDirectory.Font = null;
            this.btnSelectBackupDirectory.Name = "btnSelectBackupDirectory";
            this.btnSelectBackupDirectory.UseVisualStyleBackColor = true;
            this.btnSelectBackupDirectory.Click += new System.EventHandler(this.btnSelectBackupDirectory_Click);
            // 
            // txtBackupDirectory
            // 
            this.txtBackupDirectory.AccessibleDescription = null;
            this.txtBackupDirectory.AccessibleName = null;
            resources.ApplyResources(this.txtBackupDirectory, "txtBackupDirectory");
            this.txtBackupDirectory.BackgroundImage = null;
            this.txtBackupDirectory.Font = null;
            this.txtBackupDirectory.Name = "txtBackupDirectory";
            this.txtBackupDirectory.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // chkEnableBackup
            // 
            this.chkEnableBackup.AccessibleDescription = null;
            this.chkEnableBackup.AccessibleName = null;
            resources.ApplyResources(this.chkEnableBackup, "chkEnableBackup");
            this.chkEnableBackup.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableBackup.BackgroundImage = null;
            this.chkEnableBackup.Font = null;
            this.chkEnableBackup.Name = "chkEnableBackup";
            this.chkEnableBackup.UseVisualStyleBackColor = false;
            // 
            // tpEditorAndCompiler
            // 
            this.tpEditorAndCompiler.AccessibleDescription = null;
            this.tpEditorAndCompiler.AccessibleName = null;
            resources.ApplyResources(this.tpEditorAndCompiler, "tpEditorAndCompiler");
            this.tpEditorAndCompiler.Controls.Add(this.label6);
            this.tpEditorAndCompiler.Controls.Add(this.groupBox4);
            this.tpEditorAndCompiler.Controls.Add(this.groupBox3);
            this.tpEditorAndCompiler.Font = null;
            this.tpEditorAndCompiler.Name = "tpEditorAndCompiler";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = null;
            this.label6.ImageList = this.imageList;
            this.label6.Name = "label6";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imageList.Images.SetKeyName(0, "Warning.bmp");
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleDescription = null;
            this.groupBox4.AccessibleName = null;
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.BackgroundImage = null;
            this.groupBox4.Controls.Add(this.btnSelectCodeDomCompiler);
            this.groupBox4.Controls.Add(this.txtCodeDomCompilerType);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = null;
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // btnSelectCodeDomCompiler
            // 
            this.btnSelectCodeDomCompiler.AccessibleDescription = null;
            this.btnSelectCodeDomCompiler.AccessibleName = null;
            resources.ApplyResources(this.btnSelectCodeDomCompiler, "btnSelectCodeDomCompiler");
            this.btnSelectCodeDomCompiler.BackgroundImage = null;
            this.btnSelectCodeDomCompiler.Font = null;
            this.btnSelectCodeDomCompiler.Name = "btnSelectCodeDomCompiler";
            this.btnSelectCodeDomCompiler.UseVisualStyleBackColor = true;
            this.btnSelectCodeDomCompiler.Click += new System.EventHandler(this.btnSelectCodeDomCompiler_Click);
            // 
            // txtCodeDomCompilerType
            // 
            this.txtCodeDomCompilerType.AccessibleDescription = null;
            this.txtCodeDomCompilerType.AccessibleName = null;
            resources.ApplyResources(this.txtCodeDomCompilerType, "txtCodeDomCompilerType");
            this.txtCodeDomCompilerType.BackgroundImage = null;
            this.txtCodeDomCompilerType.Font = null;
            this.txtCodeDomCompilerType.Name = "txtCodeDomCompilerType";
            this.txtCodeDomCompilerType.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleDescription = null;
            this.groupBox3.AccessibleName = null;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.BackgroundImage = null;
            this.groupBox3.Controls.Add(this.cbSyntaxFile);
            this.groupBox3.Controls.Add(this.cbGTemplate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbSimpleTemplate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = null;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // cbSyntaxFile
            // 
            this.cbSyntaxFile.AccessibleDescription = null;
            this.cbSyntaxFile.AccessibleName = null;
            resources.ApplyResources(this.cbSyntaxFile, "cbSyntaxFile");
            this.cbSyntaxFile.BackgroundImage = null;
            this.cbSyntaxFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSyntaxFile.Font = null;
            this.cbSyntaxFile.FormattingEnabled = true;
            this.cbSyntaxFile.Name = "cbSyntaxFile";
            // 
            // cbGTemplate
            // 
            this.cbGTemplate.AccessibleDescription = null;
            this.cbGTemplate.AccessibleName = null;
            resources.ApplyResources(this.cbGTemplate, "cbGTemplate");
            this.cbGTemplate.BackgroundImage = null;
            this.cbGTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGTemplate.Font = null;
            this.cbGTemplate.FormattingEnabled = true;
            this.cbGTemplate.Name = "cbGTemplate";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // cbSimpleTemplate
            // 
            this.cbSimpleTemplate.AccessibleDescription = null;
            this.cbSimpleTemplate.AccessibleName = null;
            resources.ApplyResources(this.cbSimpleTemplate, "cbSimpleTemplate");
            this.cbSimpleTemplate.BackgroundImage = null;
            this.cbSimpleTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSimpleTemplate.Font = null;
            this.cbSimpleTemplate.FormattingEnabled = true;
            this.cbSimpleTemplate.Name = "cbSimpleTemplate";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AccessibleDescription = null;
            this.flowLayoutPanel1.AccessibleName = null;
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackgroundImage = null;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Font = null;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleDescription = null;
            this.btnOK.AccessibleName = null;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.BackgroundImage = null;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl
            // 
            this.tabControl.AccessibleDescription = null;
            this.tabControl.AccessibleName = null;
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.BackgroundImage = null;
            this.tabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.tabControl.Controls.Add(this.tpPreferences);
            this.tabControl.Controls.Add(this.tpBackup);
            this.tabControl.Controls.Add(this.tpEditorAndCompiler);
            this.tabControl.Font = null;
            this.tabControl.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.tabControl.Name = "tabControl";
            this.tabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            appearance1.Image = global::SunnyChen.Gulu.Win.Properties.Resources.BMP_PREFERENCES;
            resources.ApplyResources(appearance1, "appearance1");
            ultraTab1.Appearance = appearance1;
            ultraTab1.Key = "tpPreferences";
            ultraTab1.TabPage = this.tpPreferences;
            resources.ApplyResources(ultraTab1, "ultraTab1");
            appearance2.Image = global::SunnyChen.Gulu.Win.Properties.Resources.BMP_COPY;
            resources.ApplyResources(appearance2, "appearance2");
            ultraTab2.Appearance = appearance2;
            ultraTab2.Key = "tpBackup";
            ultraTab2.TabPage = this.tpBackup;
            resources.ApplyResources(ultraTab2, "ultraTab2");
            appearance3.Image = global::SunnyChen.Gulu.Win.Properties.Resources.BMP_EDITOR;
            resources.ApplyResources(appearance3, "appearance3");
            ultraTab3.Appearance = appearance3;
            ultraTab3.Key = "tpEditorAndCompiler";
            ultraTab3.TabPage = this.tpEditorAndCompiler;
            resources.ApplyResources(ultraTab3, "ultraTab3");
            this.tabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3});
            this.tabControl.TabStop = false;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.AccessibleDescription = null;
            this.ultraTabSharedControlsPage1.AccessibleName = null;
            resources.ApplyResources(this.ultraTabSharedControlsPage1, "ultraTabSharedControlsPage1");
            this.ultraTabSharedControlsPage1.Font = null;
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            // 
            // openSyntaxFileDialog
            // 
            this.openSyntaxFileDialog.DefaultExt = "syn";
            resources.ApplyResources(this.openSyntaxFileDialog, "openSyntaxFileDialog");
            // 
            // frmConfiguration
            // 
            this.AcceptButton = this.btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguration";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            this.tpPreferences.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpBackup.ResumeLayout(false);
            this.tpBackup.PerformLayout();
            this.tpEditorAndCompiler.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl tabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl tpPreferences;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl tpBackup;
        private System.Windows.Forms.CheckBox chkEnableBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackupDirectory;
        private System.Windows.Forms.Button btnSelectBackupDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkShowHidden;
        private System.Windows.Forms.CheckBox chkShowFiles;
        private System.Windows.Forms.CheckBox chkShowSystem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSearchRecursivly;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl tpEditorAndCompiler;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSelectCodeDomCompiler;
        private System.Windows.Forms.TextBox txtCodeDomCompilerType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openSyntaxFileDialog;
        private System.Windows.Forms.ComboBox cbGTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSimpleTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ComboBox cbSyntaxFile;
    }
}