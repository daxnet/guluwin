/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/17/2008
 * 
 * The filter settings form.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SunnyChen.Common.Patterns;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Filters;
using SunnyChen.Gulu.Win.Properties;

namespace SunnyChen.Gulu.Win
{
    public partial class frmFilters : Form
    {
        #region Private Fields
        private FilterManager filterManager__ = new FilterManager();
        #endregion

        #region Constructors
        public frmFilters()
        {
            InitializeComponent();
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }
        #endregion

        #region Private Methods
        private void SelectFilter(int _selectIndex)
        {
            FilterBase filter = (FilterBase)filterManager__.Items[_selectIndex];

            txtAuthor.Text = filter.Author;
            txtCompany.Text = filter.Company;
            txtCopyright.Text = filter.Copyright;
            txtDate.Text = filter.CreatedDate.ToShortDateString();
            txtDescription.Text = filter.Description;
            txtVersion.Text = filter.Version;
            lblFilterNameText.Text = filter.Name;
            
            filterImageList.Images.Clear();
            if (filter.Image != null)
            {
                filterImageList.Images.Add(filter.Image);
            }
            else
            {
                filterImageList.Images.Add(Resources.BMP_FILTER);
            }
            lblImage.ImageIndex = 0;
            lblImage.Refresh();

            grpFilterSettings.Controls.Clear();

            UserControl settingsControl = filter.GetSettingsControl();

            if (settingsControl != null && (settingsControl is ISettingsPersistable))
            {
                grpFilterSettings.Controls.Add(settingsControl);
                (settingsControl as ISettingsPersistable).MaterializeSettings();
            }
            else
            {
                Label noSettings = new Label();
                noSettings.Dock = DockStyle.Fill;
                noSettings.TextAlign = ContentAlignment.MiddleCenter;
                noSettings.Text = Resources.TEXT_NO_SETTINGS;
                grpFilterSettings.Controls.Add(noSettings);
            }
        }
        #endregion

        #region Generated Event Handlers
        private void frmFilters_Load(object sender, System.EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Directories.ApplicationPath);

                FileInfo[] filterFiles = directoryInfo.GetFiles("*.dll");
                if (filterFiles != null)
                {
                    foreach (FileInfo fileInfo in filterFiles)
                    {
                        try
                        {
                            filterManager__.Load(fileInfo.FullName);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    foreach (FilterBase filter in filterManager__.Items)
                    {
                        UserControl settingsControl = filter.GetSettingsControl();
                        if (settingsControl != null && (settingsControl is ISettingsPersistable))
                        {
                            (settingsControl as ISettingsPersistable).MaterializeSettings();
                        }
                        lstFilter.Items.Add(filter.Name, filter.Enabled);
                    }
                    if (lstFilter.Items.Count > 0)
                    {
                        lstFilter.SelectedIndex = 0;
                    }
                }
            } // using
        }

        private void lstFilter_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.SelectFilter(lstFilter.SelectedIndex);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //(filterManager__.Filters[0].GetSettingsControl() as ISettingsPersistable).PersistSettings();
        }

        private void grpFilterSettings_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is ISettingsPersistable)
            {
                (e.Control as ISettingsPersistable).PersistSettings();
            }
        }

        private void frmFilters_FormClosed(object sender, FormClosedEventArgs e)
        {
            filterManager__.SaveEnabling();
            // Triggers the control's PersistSettings event
            grpFilterSettings.Controls.Clear();
        }

        private void lstFilter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            switch (e.NewValue)
            {
                case CheckState.Checked:
                    filterManager__.Items[e.Index].Enabled = true;
                    break;
                default:
                    filterManager__.Items[e.Index].Enabled = false;
                    break;
            }

        }

        private void frmFilters_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (new LengthyOperation(this))
            {
                for (int i = 0; i < filterManager__.Count; i++)
                {
                    if (filterManager__.Items[i].Enabled && (filterManager__.Items[i] is FilterBase))
                    {
                        UserControl control = (filterManager__.Items[i] as FilterBase).GetSettingsControl();
                        if ((control is ISettingsPersistable))
                        {
                            ISettingsPersistable persistable = control as ISettingsPersistable;
                            try
                            {
                                if (!persistable.ValidateSettings())
                                {
                                    //MessageBox.Show("Invalid setting, please check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    e.Cancel = true;
                                    lstFilter.SelectedIndex = i;
                                }
                            }
                            catch (InvalidSettingValueException ex)
                            {
                                e.Cancel = true;
                                lstFilter.SelectedIndex = i;
                                MessageBox.Show(ex.Message, Resources.TEXT_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } // Catch
                            catch (Exception)
                            {
                            } // Catch
                        } // If
                    } // If
                } // For
            } // Using
        } // frmFilters_FormClosing
        #endregion
    } // frmFilters
} // namespace
