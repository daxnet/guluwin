/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/9/2008
 * 
 * The dummy form which performs as the intermediate base of MDI children in
 * Extendable MDI pattern.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */


using SunnyChen.Common.Patterns.ExtendableMDI;

namespace SunnyChen.Gulu.Win
{
    public partial class frmDummy : MDIChildBase<frmMain>
    {
        #region Constructors
        public frmDummy()
        {
            InitializeComponent();
        }

        public frmDummy(frmMain _parent)
            : base(_parent)
        {
            InitializeComponent();
        }
        #endregion
    }
}
