using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Gulu.Gulus.BasicFileOperations.FileRenaming
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        public bool SimpleTextReplacing { get; set; }
        public bool ChangeExtension { get; set; }
        public bool AddPrefixAndSuffix { get; set; }
        public string ReplaceFrom { get; set; }
        public string ReplaceTo { get; set; }
        public string Extension { get; set; }
        public bool AddPrefix { get; set; }
        public bool AddSuffix { get; set; }
        public string PrefixSuffixString { get; set; }

        private void MainRadioButton_Click(object sender, System.EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = (sender as RadioButton);
                grpSimpleTextReplacing.Enabled = (rb == rbSimpleTextReplacing && rb.Checked);
                txtExtension.Enabled = (rb == rbChangeExtension && rb.Checked);
                grpPrefixingAndSuffixing.Enabled = (rb == rbPrefixingAndSuffixing && rb.Checked);
            }
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            MainRadioButton_Click(rbSimpleTextReplacing, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SimpleTextReplacing = rbSimpleTextReplacing.Checked;
            ChangeExtension = rbChangeExtension.Checked;
            AddPrefixAndSuffix = rbPrefixingAndSuffixing.Checked;
            ReplaceFrom = txtReplaceFrom.Text;
            ReplaceTo = txtReplaceTo.Text;
            Extension = txtExtension.Text;
            AddPrefix = rbPrefix.Checked;
            AddSuffix = rbSuffix.Checked;
            PrefixSuffixString = txtPrefixAndSuffix.Text;
        }
    }
}
