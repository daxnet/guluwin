using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Win.Configuration
{
    internal class PreferenceConfigHandler : ConfigurationSection
    {
        [ConfigurationProperty("FileTreeShowHidden", IsRequired=true, IsKey=false, DefaultValue=true)]
        public bool FileTreeShowHidden
        {
            get { return (bool)base["FileTreeShowHidden"]; }
            set { base["FileTreeShowHidden"] = value; }
        }

        [ConfigurationProperty("FileTreeShowFiles", IsRequired = true, IsKey = false, DefaultValue = true)]
        public bool FileTreeShowFiles
        {
            get { return (bool)base["FileTreeShowFiles"]; }
            set { base["FileTreeShowFiles"] = value; }
        }

        [ConfigurationProperty("FileTreeShowSystem", IsRequired = true, IsKey = false, DefaultValue = true)]
        public bool FileTreeShowSystem
        {
            get { return (bool)base["FileTreeShowSystem"]; }
            set { base["FileTreeShowSystem"] = value; }
        }

        [ConfigurationProperty("SearchRecursivly", IsRequired = true, IsKey = false, DefaultValue = true)]
        public bool SearchRecursivly
        {
            get { return (bool)base["SearchRecursivly"]; }
            set { base["SearchRecursivly"] = value; }
        }
    }
}
