using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Gulu.Filters.Properties;

namespace SunnyChen.Gulu.Filters.FileType
{
    public partial class FileTypeFilterSettingsControl : UserControl, ISettingsPersistable
    {
        private readonly IList<KeyValuePair<string, string>> presets__;

        public FileTypeFilterSettingsControl()
        {
            InitializeComponent();
            
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;

            presets__ = new List<KeyValuePair<string, string>>();

            presets__.Add(new KeyValuePair<string, string>(Resources.TEXT_TEXT_FILE, ".txt"));
            presets__.Add(new KeyValuePair<string, string>(Resources.TEXT_IMAGE_FILE, ".bmp; .dib"));
            presets__.Add(new KeyValuePair<string, string>(Resources.TEXT_WAVE_FILE, ".mp3; .wav"));
        }

        #region ISettingsPersistable Members

        public void PersistSettings()
        {
            FileTypeFilterSettings settings = new FileTypeFilterSettings();
            settings.FileTypes = txtExtensions.Text;

            FilterSettingsBase.SaveSettings<FileTypeFilterSettings>(settings.FileName, settings);
        }

        public void MaterializeSettings()
        {
            FileTypeFilterSettings settings = new FileTypeFilterSettings();
            settings = FilterSettingsBase.LoadSettings<FileTypeFilterSettings>(settings.FileName);
            foreach (KeyValuePair<string, string> keyValuePair in presets__)
            {
                if (keyValuePair.Value.Equals(settings.FileTypes))
                {
                    cbPresets.SelectedItem = keyValuePair.Key;
                    txtExtensions.Text = settings.FileTypes;
                    return;
                }
            }
            cbPresets.SelectedIndex = cbPresets.Items.Count - 1;
            txtExtensions.Text = settings.FileTypes;
        }

        public bool ValidateSettings()
        {
            if (txtExtensions.Text.Trim().Equals(string.Empty))
                throw new InvalidSettingValueException(Resources.ERROR_EXTENSION_EMPTY);
            return true;
        }

        #endregion

        private void FileTypeFilterSettingsControl_Load(object sender, EventArgs e)
        {
            cbPresets.Items.Clear();
            foreach (KeyValuePair<string, string> keyValuePair in presets__)
            {
                cbPresets.Items.Add(keyValuePair.Key);
            }
            cbPresets.Items.Add(Resources.TEXT_CUSTOMIZED);
        }

        private void cbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPresets.SelectedIndex.Equals(cbPresets.Items.Count - 1))
            {
                txtExtensions.Text = string.Empty;
            }
            else
            {
                txtExtensions.Text = presets__[cbPresets.SelectedIndex].Value;
            }
        }
    }
}
