/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/19/2008
 * 
 * The utility class that provides the constants and static definitions for
 * path and filename.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Gulu.Environment
{
    /// <summary>
    /// Provides the constants and static definitions for path and filename.
    /// Routines defined within this class are available for both gulu project
    /// and the scripts created within the gulu UI.
    /// </summary>
    public static class Directories
    {
        #region Public Constants
        /// <summary>
        /// The relative path in which gulus are stored.
        /// </summary>
        public const string RELATIVE_GULU_PATH = @"gulus";
        /// <summary>
        /// The relative path for scripts. It is the root path for both
        /// simple scripts and G scripts.
        /// </summary>
        public const string RELATIVE_SCRIPTS_PATH = @"scripts";
        /// <summary>
        /// The relative path for G scripts. G scripts are stored in this
        /// directory.
        /// </summary>
        public const string RELATIVE_GSCRIPT_PATH = @"scripts\g";
        /// <summary>
        /// The relative path for simple scripts. Simple scripts are stored
        /// in this directory.
        /// </summary>
        public const string RELATIVE_SIMPLESCRIPT_PATH = @"scripts\simple";
        /// <summary>
        /// The relative path for storing the application settings. it includes
        /// the settings for filters, gulus and the enabling list for plug-ins.
        /// </summary>
        public const string RELATIVE_SETTINGS_PATH = @"settings";
        /// <summary>
        /// The relative path for help files.
        /// </summary>
        public const string RELATIVE_HELP_PATH = @"help";
        /// <summary>
        /// The filename of the User Guide Chinese (PRC) edition.
        /// </summary>
        [Obsolete("This field is now obsolete, please use the UserGuideFileName attribute directly.")]
        public const string FILENAME_USERGUIDE_ZHCN = @"userguide.zh-CN.chm";
        /// <summary>
        /// The filename of the User Guide English (USA) edition.
        /// </summary>
        [Obsolete("This field is now obsolete, please use the UserGuideFileName attribute directly.")]
        public const string FILENAME_USERGUIDE_ENUS = @"userguide.en-US.chm";
        /// <summary>
        /// The filename of the Developer Manual.
        /// </summary>
        public const string FILENAME_DEVELOPERMANUAL = @"devman.chm";
        /// <summary>
        /// The filename of the Common Class Library.
        /// </summary>
        public const string FILENAME_COMMONLIBRARY = @"comlib.chm";
        /// <summary>
        /// The filename of the Gulu Class Library.
        /// </summary>
        public const string FILENAME_GULULIBRARY = @"gululib.chm";
        #endregion

        #region Private Constants
        private const string FILENAME_USERGUIDE_PATTERN = @"userguide.{0}.chm";
        #endregion

        #region Public Static Properties
        /// <summary>
        /// The absolute path for gulus.
        /// </summary>
        public static string GuluPath
        {
            get { return Path.Combine(Application.StartupPath, RELATIVE_GULU_PATH); }
        }
        /// <summary>
        /// Gets the absolute path for script root directory.
        /// </summary>
        public static string ScriptsPath
        {
            get { return Path.Combine(Application.StartupPath, RELATIVE_SCRIPTS_PATH); }
        }
        /// <summary>
        /// Gets the absolute path for the G scripts.
        /// </summary>
        public static string GScriptPath
        {
            get { return Path.Combine(Application.StartupPath, RELATIVE_GSCRIPT_PATH); }
        }
        /// <summary>
        /// Gets the absolute path for the simple scripts.
        /// </summary>
        public static string SimpleScriptPath
        {
            get { return Path.Combine(Application.StartupPath, RELATIVE_SIMPLESCRIPT_PATH); }
        }
        /// <summary>
        /// Gets the absolute path for application settings. These settings include the settings
        /// for filters, gulus and the enabling list for plug-ins.
        /// </summary>
        public static string SettingsPath
        {
            get { return Path.Combine(Application.StartupPath, RELATIVE_SETTINGS_PATH); }
        }
        /// <summary>
        /// Gets the absolute path for the application.
        /// </summary>
        public static string ApplicationPath
        {
            get { return Application.StartupPath; }
        }
        /// <summary>
        /// Gets the absolute path for help files.
        /// </summary>
        public static string HelpPath
        {
            get { return Path.Combine(Application.StartupPath, RELATIVE_HELP_PATH); }
        }
        /// <summary>
        /// Gets the absolute path for User Guide.
        /// </summary>
        public static string UserGuideFileName
        {
            get 
            {
                string localizedName = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
                return Path.Combine(HelpPath, string.Format(FILENAME_USERGUIDE_PATTERN, localizedName)); 
            }
        }
        /// <summary>
        /// Gets the absolute path for Developer Manual.
        /// </summary>
        public static string DevelopManualFileName
        {
            get { return Path.Combine(HelpPath, FILENAME_DEVELOPERMANUAL); }
        }
        /// <summary>
        /// Gets the absolute path for Common Class Library.
        /// </summary>
        public static string CommonClassLibraryFileName
        {
            get { return Path.Combine(HelpPath, FILENAME_COMMONLIBRARY); }
        }
        /// <summary>
        /// Gets the absolute path for Gulu Class Library.
        /// </summary>
        public static string GuluClassLibraryFileName
        {
            get { return Path.Combine(HelpPath, FILENAME_GULULIBRARY); }
        }
        #endregion
    }
}
