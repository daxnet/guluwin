using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using SunnyChen.Gulu.Filters.Properties;

namespace SunnyChen.Gulu.Filters.FileSize
{
    [Filter]
    public sealed class FileSizeFilter : FilterBase
    {
        private FileSizeFilterSettings settings__ = new FileSizeFilterSettings();

        public FileSizeFilter()
        {
            settings__ = FilterSettingsBase.LoadSettings<FileSizeFilterSettings>(settings__.FileName);
        }

        public override UserControl GetSettingsControl()
        {
            UserControl settingsControl = this.GetSettingsControl<FileSizeFilterSettingsControl>();
            settingsControl.Dock = DockStyle.Fill;
            return settingsControl;
        }

        public override string Name
        {
            get { return Resources.FILTERNAME_FILESIZE; }
        }

        public override string Description
        {
            get { return Resources.FILTERDESC_FILESIZE; }
        }

        public override DateTime CreatedDate
        {
            get 
            {
                DateTime d = DateTime.Now;
                DateTime.TryParse("5/29/2008", out d);
                return d;
            }
        }

        public override string Author
        {
            get { return Resources.FILTERAUTHOR_FILESIZE; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        public override string Company
        {
            get { return Resources.FILTERCOMPANY_FILESIZE; }
        }

        public override string Copyright
        {
            get { return Resources.FILTERCOPYRIGHT_FILESIZE; }
        }

        public override System.Drawing.Bitmap Image
        {
            get { return Resources.BMP_FileSizeFilter; }
        }

        public override bool Execute(string _param)
        {
            Int64 min, max;

            switch (settings__.Unit)
            {
                case FileSizeFilterSettings.SizeUnit.KB:
                    min = settings__.MinimalSize * 1024;
                    max = settings__.MaximalSize * 1024;
                    break;
                case FileSizeFilterSettings.SizeUnit.MB:
                    min = settings__.MinimalSize * 1024 * 1024;
                    max = settings__.MaximalSize * 1024 * 1024;
                    break;
                case FileSizeFilterSettings.SizeUnit.GB:
                    min = settings__.MinimalSize * 1024 * 1024 * 1024;
                    max = settings__.MaximalSize * 1024 * 1024 * 1024;
                    break;
                case FileSizeFilterSettings.SizeUnit.TB:
                    min = settings__.MinimalSize * 1024 * 1024 * 1024 * 1024;
                    max = settings__.MaximalSize * 1024 * 1024 * 1024 * 1024;
                    break;
                default:
                    return true;
            }
            if (min == 0 && max == 0)
            {
                return true;
            }
            Int64 fs = new FileInfo(_param).Length;
            return (fs >= min && fs <= max);
        }
    }
}
