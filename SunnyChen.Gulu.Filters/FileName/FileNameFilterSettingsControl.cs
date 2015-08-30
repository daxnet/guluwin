using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Gulu.Filters.FileName
{
    public partial class FileNameFilterSettingsControl : UserControl, ISettingsPersistable
    {
        public FileNameFilterSettingsControl()
        {
            InitializeComponent();
        }

        #region ISettingsPersistable Members

        public void PersistSettings()
        {
            FileNameFilterSettings settings = new FileNameFilterSettings();
            settings.Condition = (FileNameFilterSettings.FilterCondition)cbCondition.SelectedIndex;
            settings.Value = txtValue.Text;
            settings.RepresentsRegularExpression = chkRegularExpression.Checked;
            
            FilterSettingsBase.SaveSettings<FileNameFilterSettings>(settings.FileName, settings);
        }

        public void MaterializeSettings()
        {
            FileNameFilterSettings settings = new FileNameFilterSettings();

            settings = FilterSettingsBase.LoadSettings<FileNameFilterSettings>(settings.FileName);

            cbCondition.SelectedIndex = Convert.ToInt32(settings.Condition);
            txtValue.Text = settings.Value;
            chkRegularExpression.Checked = settings.RepresentsRegularExpression;

        }

        public bool ValidateSettings()
        {
            if (txtValue.Text.Trim().Equals(string.Empty))
                throw new InvalidSettingValueException("Value cannot be empty.");
            return true;
        }

        #endregion

        private void FileNameFilterSettingsControl_Load(object sender, EventArgs e)
        {
            cbCondition.SelectedIndex = 0;
        }

        private void chkRegularExpression_Click(object sender, EventArgs e)
        {
            if (chkRegularExpression.Checked)
            {
                cbCondition.SelectedIndex = Convert.ToInt32(FileNameFilterSettings.FilterCondition.Matches);
                cbCondition.Enabled = false;
            }
            else
            {
                cbCondition.Enabled = true;
            }
        }
    }
}
