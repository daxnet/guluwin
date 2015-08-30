using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Win.Configuration
{
    public class ConfigReader
    {
        private System.Configuration.Configuration config__;
        private BackupConfigHandler backupConfigHandler__;
        private EditorCompilerConfigHandler editorCompilerConfigHandler__;
        private PreferenceConfigHandler preferenceConfigHandler__;

        public ConfigReader()
        {
            config__ = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            backupConfigHandler__ = (BackupConfigHandler)config__.GetSection("BackupConfig");
            editorCompilerConfigHandler__ = (EditorCompilerConfigHandler)config__.GetSection("EditorCompilerConfig");
            preferenceConfigHandler__ = (PreferenceConfigHandler)config__.GetSection("PreferenceConfig");
        }

        public bool SearchRecursivly
        {
            get { return preferenceConfigHandler__.SearchRecursivly; }
        }

        public bool FileTreeShowFiles
        {
            get { return preferenceConfigHandler__.FileTreeShowFiles; }
        }

        public bool FileTreeShowHidden
        {
            get { return preferenceConfigHandler__.FileTreeShowHidden; }
        }

        public bool FileTreeShowSystem
        {
            get { return preferenceConfigHandler__.FileTreeShowSystem; }
        }

        public string BackupDirectory
        {
            get { return backupConfigHandler__.BackupDirectory; }
        }

        public bool BackupEnabled
        {
            get { return backupConfigHandler__.EnableBackup; }
        }

        public string CompilerTypeName
        {
            get { return editorCompilerConfigHandler__.CompilerTypeName; }
        }

        public string SyntaxFileName
        {
            get { return editorCompilerConfigHandler__.SyntaxFileName; }
        }

        public string SimpleTemplateFileName
        {
            get { return editorCompilerConfigHandler__.SimpleTemplate; }
        }

        public string GTemplateFileName
        {
            get { return editorCompilerConfigHandler__.GTemplate; }
        }
    }
}
