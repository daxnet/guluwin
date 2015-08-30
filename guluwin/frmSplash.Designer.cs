namespace SunnyChen.Gulu.Win
{
    partial class frmSplash
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
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.lblPreRelease = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusInfo.ForeColor = System.Drawing.Color.White;
            this.lblStatusInfo.Location = new System.Drawing.Point(35, 157);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(233, 18);
            this.lblStatusInfo.TabIndex = 1;
            this.lblStatusInfo.Text = "lblStatusInfo";
            this.lblStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPreRelease
            // 
            this.lblPreRelease.BackColor = System.Drawing.Color.Transparent;
            this.lblPreRelease.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreRelease.ForeColor = System.Drawing.Color.White;
            this.lblPreRelease.Location = new System.Drawing.Point(312, 42);
            this.lblPreRelease.Name = "lblPreRelease";
            this.lblPreRelease.Size = new System.Drawing.Size(179, 23);
            this.lblPreRelease.TabIndex = 2;
            this.lblPreRelease.Text = "PRE-RELEASE";
            this.lblPreRelease.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SunnyChen.Gulu.Win.Properties.Resources.JPG_GULU;
            this.ClientSize = new System.Drawing.Size(518, 320);
            this.Controls.Add(this.lblPreRelease);
            this.Controls.Add(this.lblStatusInfo);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.Label lblPreRelease;

    }
}