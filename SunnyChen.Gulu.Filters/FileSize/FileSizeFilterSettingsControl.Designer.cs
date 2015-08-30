namespace SunnyChen.Gulu.Filters.FileSize
{
    partial class FileSizeFilterSettingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSizeFilterSettingsControl));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSizeUnit = new System.Windows.Forms.ComboBox();
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
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // txtFrom
            // 
            this.txtFrom.AccessibleDescription = null;
            this.txtFrom.AccessibleName = null;
            resources.ApplyResources(this.txtFrom, "txtFrom");
            this.txtFrom.BackgroundImage = null;
            this.txtFrom.Font = null;
            this.txtFrom.Name = "txtFrom";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // txtTo
            // 
            this.txtTo.AccessibleDescription = null;
            this.txtTo.AccessibleName = null;
            resources.ApplyResources(this.txtTo, "txtTo");
            this.txtTo.BackgroundImage = null;
            this.txtTo.Font = null;
            this.txtTo.Name = "txtTo";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // cbSizeUnit
            // 
            this.cbSizeUnit.AccessibleDescription = null;
            this.cbSizeUnit.AccessibleName = null;
            resources.ApplyResources(this.cbSizeUnit, "cbSizeUnit");
            this.cbSizeUnit.BackgroundImage = null;
            this.cbSizeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSizeUnit.Font = null;
            this.cbSizeUnit.FormattingEnabled = true;
            this.cbSizeUnit.Items.AddRange(new object[] {
            resources.GetString("cbSizeUnit.Items"),
            resources.GetString("cbSizeUnit.Items1"),
            resources.GetString("cbSizeUnit.Items2"),
            resources.GetString("cbSizeUnit.Items3")});
            this.cbSizeUnit.Name = "cbSizeUnit";
            // 
            // FileSizeFilterSettingsControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.cbSizeUnit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FileSizeFilterSettingsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSizeUnit;
    }
}
