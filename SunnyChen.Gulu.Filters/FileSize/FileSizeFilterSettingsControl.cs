using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Gulu.Filters.Properties;

namespace SunnyChen.Gulu.Filters.FileSize
{
    public partial class FileSizeFilterSettingsControl : UserControl, ISettingsPersistable
    {
        public FileSizeFilterSettingsControl()
        {
            InitializeComponent();
        }

        #region ISettingsPersistable Members

        public void PersistSettings()
        {
            FileSizeFilterSettings settings = new FileSizeFilterSettings();
            
            int maxSize = 0;
            if (!int.TryParse(txtTo.Text, out maxSize))
                txtTo.Text = "0";
            
            int minSize = 0;
            if (!int.TryParse(txtFrom.Text, out minSize))
                txtFrom.Text = "0";

            settings.MaximalSize = maxSize;
            settings.MinimalSize = minSize;
            settings.Unit = (FileSizeFilterSettings.SizeUnit)cbSizeUnit.SelectedIndex;

            FilterSettingsBase.SaveSettings<FileSizeFilterSettings>(settings.FileName, settings);
        }

        public void MaterializeSettings()
        {
            FileSizeFilterSettings settings = new FileSizeFilterSettings();
            settings = FilterSettingsBase.LoadSettings<FileSizeFilterSettings>(settings.FileName);

            txtFrom.Text = settings.MinimalSize.ToString();
            txtTo.Text = settings.MaximalSize.ToString();
            cbSizeUnit.SelectedIndex = Convert.ToInt32(settings.Unit);
        }

        public bool ValidateSettings()
        {
            int maxSize = 0;
            if (!int.TryParse(txtTo.Text, out maxSize))
                txtTo.Text = "0";

            int minSize = 0;
            if (!int.TryParse(txtFrom.Text, out minSize))
                txtFrom.Text = "0";

            if (maxSize < minSize)
                throw new InvalidSettingValueException(Resources.ERROR_MAX_LARGER_MIN);

            return true;
        }

        #endregion



    }
}
