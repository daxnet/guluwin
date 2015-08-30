/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/4/2008
 * 
 * The splash form of the application.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System.Reflection;
using System.Windows.Forms;
using SunnyChen.Gulu.Win.Properties;

namespace SunnyChen.Gulu.Win
{
    /// <summary>
    /// This is the splash form for application. It displays the current status text
    /// on the screen when loading the program. It also displays the release status
    /// (Pre-Release or not) on the screen.
    /// 
    /// The Release status is controlled by the PreRelease attribute which was applied
    /// to the guluwin assembly (here we consider it as the executing assembly). To
    /// change the status of the release, go to AssemblyInfo.cs file and set the attribute
    /// properly:
    /// 
    /// [assembly: PreRelease(true)] indicates currently the program is a pre-release version.
    /// [assembly: PreRelease(false)] stands for that the program is a normal release.
    /// 
    /// Note: The status will turn into Pre-Release if this attribute is missing.
    /// 
    /// </summary>
    public partial class frmSplash : Form
    {
        #region Constructors
        /// <summary>
        /// Default constructor, it sets the culture for both resource manager and UI.
        /// </summary>
        public frmSplash()
        {
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Sets the loading status text so that the user may see the loading progress.
        /// This property is write-only.
        /// </summary>
        public string StatusText
        {
            set
            {
                lblStatusInfo.Text = value;
                this.Update();
            }
        }
        #endregion

        #region Control Event Handlers

        /// <summary>
        /// Occurs when the form is loading.
        /// It checks the PreRelease attribute of the executing assembly so that
        /// it can determine if it is reasonable to show the release status.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event argument.</param>
        private void frmSplash_Load(object sender, System.EventArgs e)
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(PreReleaseAttribute), false);
            lblPreRelease.Text = Resources.TEXT_PRERELEASE;
            if (attributes.Length > 0)
            {
                PreReleaseAttribute preReleaseAttribute = (PreReleaseAttribute)attributes[0];
                lblPreRelease.Visible = preReleaseAttribute.IsPreRelease;
            }
            else
                lblPreRelease.Visible = true;
        }
        #endregion
    }
}
