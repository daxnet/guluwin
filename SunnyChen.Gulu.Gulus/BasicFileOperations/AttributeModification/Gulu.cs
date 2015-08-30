using System;
using System.Drawing;
using System.Windows.Forms;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Gulus.Properties;
using System.IO;

namespace SunnyChen.Gulu.Gulus.BasicFileOperations.AttributeModification
{
    [Gulu]
    public class Gulu : GuluBase
    {
        private bool readOnly__;
        private bool hidden__;
        private bool archive__;
        private bool system__;
        private bool changeCreatedDate__;
        private bool changeModifiedDate__;
        private bool changeAccessedDate__;

        private DateTime _createdDate__;
        private DateTime modifiedDate__;
        private DateTime accessedDate__;

        public override bool BackupRequired
        {
            get { return false; }
        }

        public override string Name
        {
            get { return Resources.AMG_NAME; }
        }

        public override string Category
        {
            get { return Resources.AMG_CATEGORY; }
        }

        public override string Description
        {
            get { return Resources.AMG_DESCRIPTION; }
        }

        public override DateTime CreatedDate
        {
            get
            {
                DateTime date = DateTime.Now;
                DateTime.TryParse("6/6/2008", out date);
                return date;
            }
        }

        public override string Author
        {
            get { return Resources.AUTHOR_NAME; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        public override string Company
        {
            get { return Resources.COMPANY_NAME; }
        }

        public override string Copyright
        {
            get { return Resources.COPYRIGHT; }
        }

        public override string Documentation
        {
            get
            {
                return Resources.AMG_DOCUMENT;
            }
        }

        public override Bitmap Image
        {
            get { return Resources.BMP_ATTRIBUTES; }
        }

        public override bool Init()
        {
            SettingsDialog dialog = new SettingsDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                readOnly__ = dialog.SetReadOnly;
                hidden__ = dialog.SetHidden;
                system__ = dialog.SetSystem;
                archive__ = dialog.SetArchive;
                changeAccessedDate__ = dialog.ChangeAccessedDate;
                changeCreatedDate__ = dialog.ChangeCreatedDate;
                changeModifiedDate__ = dialog.ChangeModifiedDate;
                accessedDate__ = dialog.AccessedDate;
                _createdDate__ = dialog.CreatedDate;
                modifiedDate__ = dialog.ModifiedDate;
                return true;
            }
            else
                return false;
        }

        public override bool Done()
        {
            return true;
        }

        public override bool Execute(string _param)
        {
            try
            {
                Output.Add(string.Format(Resources.TEXT_PROCESSING, _param));
                FileInfo fileInfo = new FileInfo(_param);

                if ((fileInfo.Attributes & FileAttributes.System) != FileAttributes.System &&
                    (fileInfo.Attributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                {
                    if (changeCreatedDate__)
                        fileInfo.CreationTime = _createdDate__;
                    if (changeModifiedDate__)
                        fileInfo.LastWriteTime = modifiedDate__;
                    if (changeAccessedDate__)
                        fileInfo.LastAccessTime = accessedDate__;
                }
                else
                {
                    Output.Add(Resources.TEXT_ATTRIBUTE_PREVENT_SETTING);
                }

                if (readOnly__)
                    fileInfo.Attributes |= FileAttributes.ReadOnly;
                else
                    fileInfo.Attributes &= ~FileAttributes.ReadOnly;

                if (hidden__)
                    fileInfo.Attributes |= FileAttributes.Hidden;
                else
                    fileInfo.Attributes &= ~FileAttributes.Hidden;

                if (archive__)
                    fileInfo.Attributes |= FileAttributes.Archive;
                else
                    fileInfo.Attributes &= ~FileAttributes.Archive;

                if (system__)
                    fileInfo.Attributes |= FileAttributes.System;
                else
                    fileInfo.Attributes &= ~FileAttributes.System;

                Output.Add();
                return true;
            }
            catch (System.Exception e)
            {
                Output.Add(e.Message);
                return false;
            }
        }
    }
}
