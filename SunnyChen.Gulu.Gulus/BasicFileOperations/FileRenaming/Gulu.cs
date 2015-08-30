using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Gulus.Properties;

namespace SunnyChen.Gulu.Gulus.BasicFileOperations.FileRenaming
{
    /// <summary>
    /// Renaming the files according to the specific options.
    /// </summary>
    [Gulu]
    public class Gulu : GuluBase
    {
        private bool SimpleTextReplacing { get; set; }
        private bool ChangeExtension { get; set; }
        private bool AddPrefixAndSuffix { get; set; }
        private string ReplaceFrom { get; set; }
        private string ReplaceTo { get; set; }
        private string Extension { get; set; }
        private bool AddPrefix { get; set; }
        private bool AddSuffix { get; set; }
        private string PrefixSuffixString { get; set; }

        public override bool Init()
        {
            SettingsDialog dialog = new SettingsDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SimpleTextReplacing = dialog.SimpleTextReplacing;
                ChangeExtension = dialog.ChangeExtension;
                AddPrefixAndSuffix = dialog.AddPrefixAndSuffix;
                ReplaceFrom = dialog.ReplaceFrom;
                ReplaceTo = dialog.ReplaceTo;
                Extension = dialog.Extension;
                AddPrefix = dialog.AddPrefix;
                AddSuffix = dialog.AddSuffix;
                PrefixSuffixString = dialog.PrefixSuffixString;
                return true;
            }
            return false;
        }

        public override bool Done()
        {
            return true;
        }

        public override bool BackupRequired
        {
            get { return false; }
        }

        public override string Name
        {
            get { return Resources.FRG_NAME; }
        }

        public override string Category
        {
            get { return Resources.FRG_CATEGORY; }
        }

        public override string Description
        {
            get { return Resources.FRG_DESCRIPTION; }
        }

        public override DateTime CreatedDate
        {
            get
            {
                DateTime date = DateTime.Now;
                DateTime.TryParse("6/5/2008", out date);
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

        public override Bitmap Image
        {
            get { return Resources.BMP_RENAME; }
        }

        public override bool Execute(string _param)
        {
            try
            {
                string path = Path.GetDirectoryName(_param);
                string newFileName;
                if (SimpleTextReplacing)
                {
                    newFileName = Path.GetFileNameWithoutExtension(_param);
                    newFileName = newFileName.Replace(ReplaceFrom, ReplaceTo);
                    newFileName = Path.Combine(path, newFileName);
                    if (Path.HasExtension(_param))
                        newFileName = string.Format("{0}{1}", newFileName,
                            Path.GetExtension(_param));
                    File.Move(_param, newFileName);
                }
                else if (ChangeExtension)
                {
                    newFileName = Path.GetFileNameWithoutExtension(_param);
                    newFileName = Path.Combine(path, newFileName);
                    if (Extension.Substring(0, 1) != ".")
                        newFileName = string.Format("{0}.{1}", newFileName, Extension);
                    else
                        newFileName = string.Format("{0}{1}", newFileName, Extension);
                    File.Move(_param, newFileName);
                }
                else if (AddPrefixAndSuffix)
                {
                    newFileName = Path.GetFileNameWithoutExtension(_param);
                    if (AddPrefix)
                        newFileName = PrefixSuffixString + newFileName;
                    else if (AddSuffix)
                        newFileName += PrefixSuffixString;
                    else
                        throw new InvalidOperationException(Resources.TEXT_INVALID_OPERATION);
                    newFileName = Path.Combine(path, newFileName);
                    if (Path.HasExtension(_param))
                        newFileName = string.Format("{0}{1}", newFileName,
                            Path.GetExtension(_param));
                    File.Move(_param, newFileName);
                }
                else
                    throw new InvalidOperationException(Resources.TEXT_INVALID_OPERATION);

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
