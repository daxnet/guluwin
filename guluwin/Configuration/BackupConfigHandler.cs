using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Win.Configuration
{
    internal class BackupConfigHandler : ConfigurationSection
    {
        [ConfigurationProperty("EnableBackup", IsRequired = true, IsKey = false, DefaultValue = true)]
        public bool EnableBackup
        {
            get { return (bool)base["EnableBackup"]; }
            set { base["EnableBackup"] = value; }
        }

        [ConfigurationProperty("BackupDirectory", IsKey = false)]
        public string BackupDirectory
        {
            get { return (string)base["BackupDirectory"]; }
            set { base["BackupDirectory"] = value; }
        }
    }
}
