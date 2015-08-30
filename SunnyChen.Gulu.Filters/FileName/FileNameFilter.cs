using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

using SunnyChen.Gulu.Filters.Properties;
using SunnyChen.Gulu;

namespace SunnyChen.Gulu.Filters.FileName
{
    [Filter]
    public sealed class FileNameFilter : FilterBase
    {
        private FileNameFilterSettings settings__ = new FileNameFilterSettings();

        public FileNameFilter()
        {
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            settings__ = FilterSettingsBase.LoadSettings<FileNameFilterSettings>(settings__.FileName);
        }

        public override string Name
        {
            get { return Resources.FILTERNAME_FILENAME; }
        }

        public override string Description
        {
            get { return Resources.FILTERDESC_FILENAME; }
        }

        public override DateTime CreatedDate
        {
            get 
            {
                DateTime value = DateTime.Now;
                if (DateTime.TryParse("5/16/2008", out value))
                {
                    return value;
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }

        public override string Author
        {
            get { return Resources.FILTERAUTHOR_FILENAME; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        public override string Company
        {
            get { return Resources.FILTERCOMPANY_FILENAME; }
        }

        public override string Copyright
        {
            get { return Resources.FILTERCOPYRIGHT_FILENAME; }
        }

        public override UserControl GetSettingsControl()
        {
            UserControl settingsControl = this.GetSettingsControl<FileNameFilterSettingsControl>();
            settingsControl.Dock = DockStyle.Fill;
            return settingsControl;
        }

        public override bool Execute(string _param)
        {
            if (settings__.RepresentsRegularExpression)
            {
                string expr = settings__.Value.Trim();
                System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(expr);
                return regEx.Match(_param).Success;
            }
            else
            {
                string val;
                switch (settings__.Condition)
                {
                    case FileNameFilterSettings.FilterCondition.BeginWith:
                        return Path.GetFileName(_param.ToUpper()).IndexOf(settings__.Value.Trim().ToUpper()) == 0;

                    case FileNameFilterSettings.FilterCondition.Contains:
                        return Path.GetFileName(_param.ToUpper()).IndexOf(settings__.Value.Trim().ToUpper()) != -1;

                    case FileNameFilterSettings.FilterCondition.EndWith:
                        val = settings__.Value.Trim().ToUpper();
                        return StrUtils.Right(Path.GetFileName(_param.ToUpper()), val.Length).Equals(val);
                        
                    case FileNameFilterSettings.FilterCondition.Matches:
                        return Path.GetFileName(_param.ToUpper()).Equals(settings__.Value.Trim());

                    case FileNameFilterSettings.FilterCondition.NotBeginWith:
                        return Path.GetFileName(_param.ToUpper()).IndexOf(settings__.Value.Trim().ToUpper()) != 0;

                    case FileNameFilterSettings.FilterCondition.NotContains:
                        return Path.GetFileName(_param.ToUpper()).IndexOf(settings__.Value.Trim().ToUpper()) == -1;

                    case FileNameFilterSettings.FilterCondition.NotEndWith:
                        val = settings__.Value.Trim().ToUpper();
                        return !StrUtils.Right(Path.GetFileName(_param.ToUpper()), val.Length).Equals(val);
                    default:
                        return true;
                }
            }
        }

        public override Bitmap Image
        {
            get { return Resources.BMP_FileNameFilter; }
        }
    }
}
