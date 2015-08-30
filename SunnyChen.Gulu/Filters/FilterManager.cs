using System;
using System.IO;
using System.Windows.Forms;

using SunnyChen.Common.Plugins;
using SunnyChen.Gulu.Environment;

namespace SunnyChen.Gulu.Filters
{
    /// <summary>
    /// Provides the management routines for filters.
    /// </summary>
    [Serializable]
    public class FilterManager : PluginManager<string, FilterAttribute>
    {
        private string enablingFileName__ = string.Empty;
        //public const string FILTER_SETTINGS_PATH = @"settings";
        /// <summary>
        /// Default constructor.
        /// </summary>
        public FilterManager()
        {
            //string path = Path.Combine(Application.StartupPath, FILTER_SETTINGS_PATH);
            string path = Directories.SettingsPath;
            enablingFileName__ = Path.Combine(path, "filters.xml");
        }
        /// <summary>
        /// Gets a value indicating the name of a file that is used for storing the
        /// enabling list of the filters.
        /// </summary>
        protected override string EnablingFileName
        {
            get 
            {
                return enablingFileName__;
            }
        }

        /// <summary>
        /// Determines if the current file should be excluded by the filter.
        /// </summary>
        /// <param name="_fileName">Name of the file.</param>
        /// <returns>True if the file matches all the condition provided by the filters, false when
        /// the file should be excluded.</returns>
        public bool Validate(string _fileName)
        {
            foreach (FilterBase filter in this.items__)
            {
                if (filter.Enabled && !filter.Execute(_fileName))
                    return false;
            }
            return true;
        }
    }
}
