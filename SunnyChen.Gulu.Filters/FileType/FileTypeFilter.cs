using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Gulu.Filters.Properties;
using System.Drawing;

namespace SunnyChen.Gulu.Filters.FileType
{
    [Filter]
    public sealed class FileTypeFilter : FilterBase
    {
        private FileTypeFilterSettings settings__ = new FileTypeFilterSettings();
        private string[] extensions__;

        public FileTypeFilter()
        {
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            settings__ = FilterSettingsBase.LoadSettings<FileTypeFilterSettings>(settings__.FileName);
            if (settings__ != null)
            {
                extensions__ = settings__.FileTypes.Split(';');
            }
        }


        public override string Name
        {
            get { return Resources.FILTERNAME_FILETYPE; }
        }

        public override string Description
        {
            get { return Resources.FILTERDESC_FILETYPE; }
        }

        public override DateTime CreatedDate
        {
            get
            {
                DateTime val = DateTime.Now;
                DateTime.TryParse("5/20/2008", out val);
                return val;
            }
        }

        public override string Author
        {
            get { return Resources.FILTERAUTHOR_FILETYPE; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        public override string Company
        {
            get { return Resources.FILTERCOMPANY_FILETYPE; }
        }

        public override string Copyright
        {
            get { return Resources.FILTERCOPYRIGHT_FILETYPE; }
        }

        public override UserControl GetSettingsControl()
        {
            UserControl settingsControl = this.GetSettingsControl<FileTypeFilterSettingsControl>();
            settingsControl.Dock = DockStyle.Fill;
            return settingsControl;
        }

        public override bool Execute(string _param)
        {
            if (extensions__ == null)
            {
                return true;
            }
            else
            {
                string extension = Path.GetExtension(_param);
                foreach (string ext in extensions__)
                {
                    if (ext.Trim().ToUpper().Equals(extension.Trim().ToUpper()))
                        return true;
                }
                return false;
            }
            
        }

        public override Bitmap Image
        {
            get { return Resources.BMP_FileTypeFilter; }
        }
    }
}
