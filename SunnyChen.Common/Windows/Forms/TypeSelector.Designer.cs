namespace SunnyChen.Common.Windows.Forms
{
    partial class TypeSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeSelector));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeViewImages = new System.Windows.Forms.ImageList(this.components);
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.rbAppDirectory = new System.Windows.Forms.RadioButton();
            this.rbSelect = new System.Windows.Forms.RadioButton();
            this.cbAssemblies = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AccessibleDescription = null;
            this.flowLayoutPanel.AccessibleName = null;
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.BackgroundImage = null;
            this.flowLayoutPanel.Controls.Add(this.btnCancel);
            this.flowLayoutPanel.Controls.Add(this.btnOK);
            this.flowLayoutPanel.Font = null;
            this.flowLayoutPanel.Name = "flowLayoutPanel";
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
            // treeView
            // 
            this.treeView.AccessibleDescription = null;
            this.treeView.AccessibleName = null;
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.BackgroundImage = null;
            this.treeView.Font = null;
            this.treeView.HideSelection = false;
            this.treeView.ImageList = this.treeViewImages;
            this.treeView.Name = "treeView";
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // treeViewImages
            // 
            this.treeViewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImages.ImageStream")));
            this.treeViewImages.TransparentColor = System.Drawing.Color.Fuchsia;
            this.treeViewImages.Images.SetKeyName(0, "Assembly");
            this.treeViewImages.Images.SetKeyName(1, "Type");
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleDescription = null;
            this.txtDescription.AccessibleName = null;
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.BackgroundImage = null;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = null;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            // 
            // rbAppDirectory
            // 
            this.rbAppDirectory.AccessibleDescription = null;
            this.rbAppDirectory.AccessibleName = null;
            resources.ApplyResources(this.rbAppDirectory, "rbAppDirectory");
            this.rbAppDirectory.BackgroundImage = null;
            this.rbAppDirectory.Checked = true;
            this.rbAppDirectory.Font = null;
            this.rbAppDirectory.Name = "rbAppDirectory";
            this.rbAppDirectory.TabStop = true;
            this.rbAppDirectory.UseVisualStyleBackColor = true;
            this.rbAppDirectory.Click += new System.EventHandler(this.OnRadioChange);
            // 
            // rbSelect
            // 
            this.rbSelect.AccessibleDescription = null;
            this.rbSelect.AccessibleName = null;
            resources.ApplyResources(this.rbSelect, "rbSelect");
            this.rbSelect.BackgroundImage = null;
            this.rbSelect.Font = null;
            this.rbSelect.Name = "rbSelect";
            this.rbSelect.UseVisualStyleBackColor = true;
            this.rbSelect.Click += new System.EventHandler(this.OnRadioChange);
            // 
            // cbAssemblies
            // 
            this.cbAssemblies.AccessibleDescription = null;
            this.cbAssemblies.AccessibleName = null;
            resources.ApplyResources(this.cbAssemblies, "cbAssemblies");
            this.cbAssemblies.BackgroundImage = null;
            this.cbAssemblies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAssemblies.Font = null;
            this.cbAssemblies.FormattingEnabled = true;
            this.cbAssemblies.Name = "cbAssemblies";
            this.cbAssemblies.SelectedIndexChanged += new System.EventHandler(this.cbAssemblies_SelectedIndexChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleDescription = null;
            this.btnSelect.AccessibleName = null;
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.BackgroundImage = null;
            this.btnSelect.Font = null;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // TypeSelector
            // 
            this.AcceptButton = this.btnOK;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.cbAssemblies);
            this.Controls.Add(this.rbSelect);
            this.Controls.Add(this.rbAppDirectory);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypeSelector";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TypeSelector_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.RadioButton rbAppDirectory;
        private System.Windows.Forms.RadioButton rbSelect;
        private System.Windows.Forms.ComboBox cbAssemblies;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ImageList treeViewImages;
    }
}