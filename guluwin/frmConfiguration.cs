/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/9/2008
 * 
 * The form for the configuration.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using SunnyChen.Common.CodeDom;
using SunnyChen.Common.Patterns;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Win.Configuration;
using SunnyChen.Gulu.Win.Properties;

namespace SunnyChen.Gulu.Win
{
    /// <summary>
    /// Provides the user interface for configurations
    /// </summary>
    public partial class frmConfiguration : Form
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public frmConfiguration()
        {
            InitializeComponent();
        }
        #endregion

        #region Generated Event Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConfiguration_Load(object sender, System.EventArgs e)
        {
            try
            {
                cbSimpleTemplate.Items.Clear();
                cbGTemplate.Items.Clear();
                cbSyntaxFile.Items.Clear();

                // Populates values
                DirectoryInfo directoryInfo = new DirectoryInfo(Directories.ScriptsPath);

                FileInfo[] simpleTemplates = directoryInfo.GetFiles("*.simpletemplate");
                foreach (FileInfo simpleTemplate in simpleTemplates)
                    cbSimpleTemplate.Items.Add(simpleTemplate.Name);
                cbSimpleTemplate.Items.Add(Resources.TEXT_NOT_SPECIFIED);

                FileInfo[] gTemplates = directoryInfo.GetFiles("*.gtemplate");
                foreach (FileInfo gTemplate in gTemplates)
                    cbGTemplate.Items.Add(gTemplate.Name);
                cbGTemplate.Items.Add(Resources.TEXT_NOT_SPECIFIED);

                DirectoryInfo rootDirectoryInfo = new DirectoryInfo(Directories.ApplicationPath);
                FileInfo[] syntaxFiles = rootDirectoryInfo.GetFiles("*.syn");
                foreach (FileInfo syntaxFile in syntaxFiles)
                    cbSyntaxFile.Items.Add(syntaxFile.Name);
                cbSyntaxFile.Items.Add(Resources.TEXT_NOT_SPECIFIED);

                cbSimpleTemplate.SelectedIndex = 0;
                cbGTemplate.SelectedIndex = 0;
                cbSyntaxFile.SelectedIndex = 0;

                // Loads configurations
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                // Gets preference settings
                PreferenceConfigHandler preferenceConfigHandler = (PreferenceConfigHandler)config.GetSection("PreferenceConfig");
                chkSearchRecursivly.Checked = preferenceConfigHandler.SearchRecursivly;
                chkShowFiles.Checked = preferenceConfigHandler.FileTreeShowFiles;
                chkShowHidden.Checked = preferenceConfigHandler.FileTreeShowHidden;
                chkShowSystem.Checked = preferenceConfigHandler.FileTreeShowSystem;

                // Gets backup settings
                BackupConfigHandler backupConfigHandler = (BackupConfigHandler)config.GetSection("BackupConfig");
                chkEnableBackup.Checked = backupConfigHandler.EnableBackup;
                txtBackupDirectory.Text = backupConfigHandler.BackupDirectory;
                
                // Gets editor and compiler settings
                EditorCompilerConfigHandler editorCompilerConfigHandler = (EditorCompilerConfigHandler)config.GetSection("EditorCompilerConfig");
                txtCodeDomCompilerType.Text = editorCompilerConfigHandler.CompilerTypeName;
                if (!cbSimpleTemplate.Items.Contains(editorCompilerConfigHandler.SimpleTemplate))
                    cbSimpleTemplate.SelectedItem = Resources.TEXT_NOT_SPECIFIED;
                else
                    cbSimpleTemplate.SelectedItem = editorCompilerConfigHandler.SimpleTemplate;
                if (!cbGTemplate.Items.Contains(editorCompilerConfigHandler.GTemplate))
                    cbGTemplate.SelectedItem = Resources.TEXT_NOT_SPECIFIED;
                else
                    cbGTemplate.SelectedItem = editorCompilerConfigHandler.GTemplate;
                if (!cbSyntaxFile.Items.Contains(editorCompilerConfigHandler.SyntaxFileName))
                    cbSyntaxFile.SelectedItem = Resources.TEXT_NOT_SPECIFIED;
                else
                    cbSyntaxFile.SelectedItem = editorCompilerConfigHandler.SyntaxFileName;
            }
            catch (Exception ex)
            {
                ExceptionMessageBox.ShowDialog(ex, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                try
                {
                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    // Sets preference settings
                    PreferenceConfigHandler preferenceHandler = (PreferenceConfigHandler)config.GetSection("PreferenceConfig");
                    preferenceHandler.SearchRecursivly = chkSearchRecursivly.Checked;
                    preferenceHandler.FileTreeShowFiles = chkShowFiles.Checked;
                    preferenceHandler.FileTreeShowHidden = chkShowHidden.Checked;
                    preferenceHandler.FileTreeShowSystem = chkShowSystem.Checked;

                    // Sets backup settings
                    BackupConfigHandler backupHandler = (BackupConfigHandler)config.GetSection("BackupConfig");
                    backupHandler.BackupDirectory = txtBackupDirectory.Text;
                    backupHandler.EnableBackup = chkEnableBackup.Checked;

                    // Sets editor and compiler settings
                    EditorCompilerConfigHandler editorCompilerConfigHandler = (EditorCompilerConfigHandler)config.GetSection("EditorCompilerConfig");
                    editorCompilerConfigHandler.CompilerTypeName = txtCodeDomCompilerType.Text;
                    if (cbSimpleTemplate.SelectedItem.ToString().Equals(Resources.TEXT_NOT_SPECIFIED) ||
                        cbGTemplate.SelectedItem.ToString().Equals(Resources.TEXT_NOT_SPECIFIED) ||
                        cbSyntaxFile.SelectedItem.ToString().Equals(Resources.TEXT_NOT_SPECIFIED))
                    {
                        MessageBox.Show(Resources.TEXT_SCRIPT_MUST_SPECIFY,
                            Resources.TEXT_ERROR,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        // forbid closing
                        DialogResult = DialogResult.None;
                        return;
                    }
                    editorCompilerConfigHandler.SimpleTemplate = cbSimpleTemplate.SelectedItem.ToString();
                    editorCompilerConfigHandler.GTemplate = cbGTemplate.SelectedItem.ToString();
                    editorCompilerConfigHandler.SyntaxFileName = cbSyntaxFile.SelectedItem.ToString();

                    config.Save(ConfigurationSaveMode.Full);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    ExceptionMessageBox.ShowDialog(ex, true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectBackupDirectory_Click(object sender, System.EventArgs e)
        {
            folderBrowserDialog.Description = Resources.TEXT_CONFIG_BACKUP_PATH_DESC;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                txtBackupDirectory.Text = folderBrowserDialog.SelectedPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCodeDomCompiler_Click(object sender, System.EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                TypeSelector selector = new TypeSelector(Resources.TEXT_SELCOMPILER_TITLE,
                                Resources.TEXT_SELCOMPILER_DESC,
                                typeof(Compiler));

                selector.SelectFileEnabled = false;
                if (selector.ShowDialog() == DialogResult.OK)
                    txtCodeDomCompilerType.Text = selector.SelectedText;
            }

        }
        #endregion
    }
}
