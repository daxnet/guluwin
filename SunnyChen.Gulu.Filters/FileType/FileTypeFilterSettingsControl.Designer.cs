namespace SunnyChen.Gulu.Filters.FileType
{
    partial class FileTypeFilterSettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTypeFilterSettingsControl));
            this.label1 = new System.Windows.Forms.Label();
            this.cbPresets = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExtensions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // cbPresets
            // 
            this.cbPresets.AccessibleDescription = null;
            this.cbPresets.AccessibleName = null;
            resources.ApplyResources(this.cbPresets, "cbPresets");
            this.cbPresets.BackgroundImage = null;
            this.cbPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPresets.Font = null;
            this.cbPresets.FormattingEnabled = true;
            this.cbPresets.Name = "cbPresets";
            this.cbPresets.SelectedIndexChanged += new System.EventHandler(this.cbPresets_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // txtExtensions
            // 
            this.txtExtensions.AccessibleDescription = null;
            this.txtExtensions.AccessibleName = null;
            resources.ApplyResources(this.txtExtensions, "txtExtensions");
            this.txtExtensions.BackgroundImage = null;
            this.txtExtensions.Font = null;
            this.txtExtensions.Name = "txtExtensions";
            // 
            // FileTypeFilterSettingsControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.txtExtensions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPresets);
            this.Controls.Add(this.label1);
            this.Name = "FileTypeFilterSettingsControl";
            this.Load += new System.EventHandler(this.FileTypeFilterSettingsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPresets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExtensions;
    }
}
