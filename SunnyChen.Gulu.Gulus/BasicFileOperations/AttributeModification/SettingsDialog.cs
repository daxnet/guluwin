using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Gulu.Gulus.BasicFileOperations.AttributeModification
{
    public partial class SettingsDialog : Form
    {
        private bool readOnly__;
        private bool hidden__;
        private bool archive__;
        private bool system__;
        private bool changeCreatedDate__;
        private bool changeModifiedDate__;
        private bool changeAccessedDate__;
        private DateTime createdDate__;
        private DateTime modifiedDate__;
        private DateTime accessedDate__;

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox obj = (sender as CheckBox);
                if (obj.Checked)
                {
                    if (obj == chkReadOnly || obj == chkSystem)
                    {
                        chkChangeAccessedDate.Checked = false;
                        chkChangeCreatedDate.Checked = false;
                        chkChangeModifiedDate.Checked = false;
                        groupBox2.Enabled = false;
                    }
                    if (obj == chkSystem)
                    {
                        chkHidden.Checked = true;
                        chkReadOnly.Checked = true;
                        chkArchive.Checked = true;
                        chkHidden.Enabled = false;
                        chkReadOnly.Enabled = false;
                        chkArchive.Enabled = false;
                    }
                }
                else
                {
                    if (obj == chkReadOnly || obj == chkSystem)
                    {
                        groupBox2.Enabled = true;
                    }
                    if (obj == chkSystem)
                    {
                        chkHidden.Enabled = true;
                        chkReadOnly.Enabled = true;
                        chkArchive.Enabled = true;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            readOnly__ = chkReadOnly.Checked;
            hidden__ = chkHidden.Checked;
            archive__ = chkArchive.Checked;
            system__ = chkSystem.Checked;
            changeCreatedDate__ = chkChangeCreatedDate.Checked;
            changeModifiedDate__ = chkChangeModifiedDate.Checked;
            changeAccessedDate__ = chkChangeAccessedDate.Checked;
            createdDate__ = dtCreatedDate.Value;
            modifiedDate__ = dtModifiedDate.Value;
            accessedDate__ = dtAccessedDate.Value;
        }

        public bool SetReadOnly
        {
            get { return readOnly__; }
        }

        public bool SetHidden
        {
            get { return hidden__; }
        }

        public bool SetArchive
        {
            get { return archive__; }
        }

        public bool SetSystem
        {
            get { return system__; }
        }

        public bool ChangeCreatedDate
        {
            get { return changeCreatedDate__; }
        }

        public bool ChangeModifiedDate
        {
            get { return changeModifiedDate__; }
        }

        public bool ChangeAccessedDate
        {
            get { return changeAccessedDate__; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate__; }
        }

        public DateTime ModifiedDate
        {
            get { return modifiedDate__; }
        }

        public DateTime AccessedDate
        {
            get { return accessedDate__; }
        }
    }
}
