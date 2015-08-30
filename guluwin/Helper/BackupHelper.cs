using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SunnyChen.Common.DataServices;

namespace SunnyChen.Gulu.Win.Helper
{
    /// <summary>
    /// Provides helper utilities for creating file backups.
    /// </summary>
    internal sealed class BackupHelper
    {
        private IList<KeyValuePair<string, string>> backupMappings__ = new List<KeyValuePair<string, string>>();

        public BackupHelper(string _directoryName)
        {
            DirectoryName = _directoryName;
            backupMappings__.Clear();
            if (!Directory.Exists(DirectoryName))
                Directory.CreateDirectory(DirectoryName);
        }

        private string GetUniqueFileName(string _fullName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(_fullName);
            string uniqueFactor = DataUtility.GetRandomString(6);
            string ret = string.Empty;
            if (Path.HasExtension(_fullName))
                ret = string.Format("{0}_{1}{2}",
                    fileNameWithoutExtension,
                    uniqueFactor,
                    Path.GetExtension(_fullName));
            else
                ret = string.Format("{0}_{1}", fileNameWithoutExtension, uniqueFactor);
            return ret;
        }

        public bool Backup(string _fullName)
        {
            string uniqueFileName = this.GetUniqueFileName(_fullName);
            string destFileName = Path.Combine(DirectoryName, uniqueFileName);
            try
            {
                File.Copy(_fullName, destFileName, true);
                backupMappings__.Add(new KeyValuePair<string, string>(_fullName, destFileName));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void GenerateMappingList()
        {

        }

        public string DirectoryName { get; set; }
    }
}
