namespace SunnyChen.Gulu.Filters.FileName
{
    partial class FileNameFilterSettingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileNameFilterSettingsControl));
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.chkRegularExpression = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbCondition
            // 
            this.cbCondition.AccessibleDescription = null;
            this.cbCondition.AccessibleName = null;
            resources.ApplyResources(this.cbCondition, "cbCondition");
            this.cbCondition.BackgroundImage = null;
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondition.Font = null;
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            resources.GetString("cbCondition.Items"),
            resources.GetString("cbCondition.Items1"),
            resources.GetString("cbCondition.Items2"),
            resources.GetString("cbCondition.Items3"),
            resources.GetString("cbCondition.Items4"),
            resources.GetString("cbCondition.Items5"),
            resources.GetString("cbCondition.Items6")});
            this.cbCondition.Name = "cbCondition";
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
            // txtValue
            // 
            this.txtValue.AccessibleDescription = null;
            this.txtValue.AccessibleName = null;
            resources.ApplyResources(this.txtValue, "txtValue");
            this.txtValue.BackgroundImage = null;
            this.txtValue.Font = null;
            this.txtValue.Name = "txtValue";
            // 
            // chkRegularExpression
            // 
            this.chkRegularExpression.AccessibleDescription = null;
            this.chkRegularExpression.AccessibleName = null;
            resources.ApplyResources(this.chkRegularExpression, "chkRegularExpression");
            this.chkRegularExpression.BackgroundImage = null;
            this.chkRegularExpression.Font = null;
            this.chkRegularExpression.Name = "chkRegularExpression";
            this.chkRegularExpression.UseVisualStyleBackColor = true;
            this.chkRegularExpression.Click += new System.EventHandler(this.chkRegularExpression_Click);
            // 
            // FileNameFilterSettingsControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.chkRegularExpression);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCondition);
            this.Name = "FileNameFilterSettingsControl";
            this.Load += new System.EventHandler(this.FileNameFilterSettingsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.CheckBox chkRegularExpression;
    }
}
