namespace SunnyChen.Gulu.Win
{
    partial class frmFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilters));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lstFilter = new System.Windows.Forms.CheckedListBox();
            this.grpFilterSettings = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblImage = new System.Windows.Forms.Label();
            this.filterImageList = new System.Windows.Forms.ImageList(this.components);
            this.lblFilterNameText = new System.Windows.Forms.Label();
            this.flowLayoutPanelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.flowLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.AccessibleDescription = null;
            this.splitContainer.AccessibleName = null;
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.BackgroundImage = null;
            this.splitContainer.Font = null;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AccessibleDescription = null;
            this.splitContainer.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.BackgroundImage = null;
            this.splitContainer.Panel1.Controls.Add(this.lstFilter);
            this.splitContainer.Panel1.Font = null;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleDescription = null;
            this.splitContainer.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.BackgroundImage = null;
            this.splitContainer.Panel2.Controls.Add(this.grpFilterSettings);
            this.splitContainer.Panel2.Controls.Add(this.txtDescription);
            this.splitContainer.Panel2.Controls.Add(this.label6);
            this.splitContainer.Panel2.Controls.Add(this.txtCopyright);
            this.splitContainer.Panel2.Controls.Add(this.label5);
            this.splitContainer.Panel2.Controls.Add(this.txtCompany);
            this.splitContainer.Panel2.Controls.Add(this.label4);
            this.splitContainer.Panel2.Controls.Add(this.txtDate);
            this.splitContainer.Panel2.Controls.Add(this.label3);
            this.splitContainer.Panel2.Controls.Add(this.txtVersion);
            this.splitContainer.Panel2.Controls.Add(this.label2);
            this.splitContainer.Panel2.Controls.Add(this.txtAuthor);
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Font = null;
            // 
            // lstFilter
            // 
            this.lstFilter.AccessibleDescription = null;
            this.lstFilter.AccessibleName = null;
            resources.ApplyResources(this.lstFilter, "lstFilter");
            this.lstFilter.BackgroundImage = null;
            this.lstFilter.Font = null;
            this.lstFilter.FormattingEnabled = true;
            this.lstFilter.Name = "lstFilter";
            this.lstFilter.SelectedIndexChanged += new System.EventHandler(this.lstFilter_SelectedIndexChanged);
            this.lstFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFilter_ItemCheck);
            // 
            // grpFilterSettings
            // 
            this.grpFilterSettings.AccessibleDescription = null;
            this.grpFilterSettings.AccessibleName = null;
            resources.ApplyResources(this.grpFilterSettings, "grpFilterSettings");
            this.grpFilterSettings.BackgroundImage = null;
            this.grpFilterSettings.Font = null;
            this.grpFilterSettings.Name = "grpFilterSettings";
            this.grpFilterSettings.TabStop = false;
            this.grpFilterSettings.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.grpFilterSettings_ControlRemoved);
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleDescription = null;
            this.txtDescription.AccessibleName = null;
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.BackgroundImage = null;
            this.txtDescription.Font = null;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Font = null;
            this.label6.Name = "label6";
            // 
            // txtCopyright
            // 
            this.txtCopyright.AccessibleDescription = null;
            this.txtCopyright.AccessibleName = null;
            resources.ApplyResources(this.txtCopyright, "txtCopyright");
            this.txtCopyright.BackgroundImage = null;
            this.txtCopyright.Font = null;
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // txtCompany
            // 
            this.txtCompany.AccessibleDescription = null;
            this.txtCompany.AccessibleName = null;
            resources.ApplyResources(this.txtCompany, "txtCompany");
            this.txtCompany.BackgroundImage = null;
            this.txtCompany.Font = null;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // txtDate
            // 
            this.txtDate.AccessibleDescription = null;
            this.txtDate.AccessibleName = null;
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.BackgroundImage = null;
            this.txtDate.Font = null;
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // txtVersion
            // 
            this.txtVersion.AccessibleDescription = null;
            this.txtVersion.AccessibleName = null;
            resources.ApplyResources(this.txtVersion, "txtVersion");
            this.txtVersion.BackgroundImage = null;
            this.txtVersion.Font = null;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // txtAuthor
            // 
            this.txtAuthor.AccessibleDescription = null;
            this.txtAuthor.AccessibleName = null;
            resources.ApplyResources(this.txtAuthor, "txtAuthor");
            this.txtAuthor.BackgroundImage = null;
            this.txtAuthor.Font = null;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblImage);
            this.pnlTop.Controls.Add(this.lblFilterNameText);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // lblImage
            // 
            this.lblImage.AccessibleDescription = null;
            this.lblImage.AccessibleName = null;
            resources.ApplyResources(this.lblImage, "lblImage");
            this.lblImage.BackColor = System.Drawing.Color.Transparent;
            this.lblImage.Font = null;
            this.lblImage.ImageList = this.filterImageList;
            this.lblImage.Name = "lblImage";
            // 
            // filterImageList
            // 
            this.filterImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            resources.ApplyResources(this.filterImageList, "filterImageList");
            this.filterImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // lblFilterNameText
            // 
            this.lblFilterNameText.AccessibleDescription = null;
            this.lblFilterNameText.AccessibleName = null;
            resources.ApplyResources(this.lblFilterNameText, "lblFilterNameText");
            this.lblFilterNameText.BackColor = System.Drawing.Color.Transparent;
            this.lblFilterNameText.Name = "lblFilterNameText";
            // 
            // flowLayoutPanelBottom
            // 
            this.flowLayoutPanelBottom.AccessibleDescription = null;
            this.flowLayoutPanelBottom.AccessibleName = null;
            resources.ApplyResources(this.flowLayoutPanelBottom, "flowLayoutPanelBottom");
            this.flowLayoutPanelBottom.BackgroundImage = null;
            this.flowLayoutPanelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelBottom.Controls.Add(this.btnSave);
            this.flowLayoutPanelBottom.Font = null;
            this.flowLayoutPanelBottom.Name = "flowLayoutPanelBottom";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = null;
            this.btnSave.AccessibleName = null;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackgroundImage = null;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = null;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmFilters
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.flowLayoutPanelBottom);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilters";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmFilters_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFilters_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFilters_FormClosing);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.flowLayoutPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFilterNameText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBottom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.CheckedListBox lstFilter;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpFilterSettings;
        private System.Windows.Forms.ImageList filterImageList;
        private System.Windows.Forms.Label lblImage;

    }
}