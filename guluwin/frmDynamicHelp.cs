/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/9/2008
 * 
 * Dynamic Help form: Provides the help documentation presentation for Gulus and
 * Filters dynamically.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System.IO;
using System.Text;
using System.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Filters;
using SunnyChen.Gulu.Gulus;
using SunnyChen.Gulu.Win.Properties;

namespace SunnyChen.Gulu.Win
{
    public partial class frmDynamicHelp : frmDummy
    {
        #region Private Fields
        private GuluManager guluManager__;
        private FilterManager filterManager__;
        private TreeNode filterRoot__;
        private TreeNode guluRoot__;
        #endregion

        #region Constructors
        public frmDynamicHelp(frmMain _parent)
            : base(_parent)
        {
            InitializeComponent();
            guluManager__ = new GuluManager();
            filterManager__ = new FilterManager();
        }
        #endregion

        #region Private Methods
        private void InitializeTreeView()
        {
            filterRoot__ = treeView.Nodes.Add(Resources.TEXT_FILTERS,
                Resources.TEXT_FILTERS,
                "Root", "Root");
            filterRoot__.Tag = null;

            guluRoot__ = treeView.Nodes.Add(Resources.TEXT_GULUS,
                Resources.TEXT_GULUS,
                "Root", "Root");
            guluRoot__.Tag = null;

            this.InitializeFilterNodes();
            this.InitializeGuluNodes();
        }

        private void InitializeFilterNodes()
        {
            
            DirectoryInfo directoryInfo = new DirectoryInfo(Directories.ApplicationPath);

            FileInfo[] filterFiles = directoryInfo.GetFiles("*.dll");
            if (filterFiles != null && filterFiles.Length != 0)
            {
                filterManager__.Clear();
                foreach (FileInfo fileInfo in filterFiles)
                {
                    try
                    {
                        filterManager__.Load(fileInfo.FullName);
                    }
                    catch
                    {
                        continue;
                    }
                }
                filterRoot__.Nodes.Clear();
                foreach (FilterBase filter in filterManager__.Items)
                {
                    TreeNode node = filterRoot__.Nodes.Add(filter.Name,
                        filter.Name,
                        "Leaf", "Leaf");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(string.Format("<FONT STYLE=\"Bold\" FACE=\"Arial\" COLOR=\"#34689A\" SIZE=\"5px\">{0}</FONT><BR/><HR/>", filter.Name));
                    if (filter.Documentation == null || filter.Documentation.Trim().Equals(string.Empty))
                        sb.Append(string.Format("<P>{0}</P><BR/><HR/>", Resources.TEXT_NO_DOCUMENT_AVAILABLE));
                    else
                        sb.Append(string.Format("<P>{0}</P><BR/><HR/>", filter.Documentation));
                    sb.Append(string.Format("<FONT FACE=\"Tahoma\" SIZE=\"1px\" COLOR=\"GRAY\">{0}</FONT><BR/><BR/>", 
                        filter.Copyright.Replace("SunnyChen.ORG", "<A HREF=\"http://www.sunnychen.org\" TARGET=\"_blank\">SunnyChen.ORG</A>")));
                    node.Tag = sb.ToString();
                }
            }
        }

        private void InitializeGuluNodes()
        {
            if (!Directory.Exists(Directories.GuluPath))
            {
                Directory.CreateDirectory(Directories.GuluPath);
                return;
            }
            DirectoryInfo gulusDirectory = new DirectoryInfo(Directories.GuluPath);
            FileInfo[] assemblyFiles = gulusDirectory.GetFiles("*.dll", System.IO.SearchOption.AllDirectories);

            if (assemblyFiles != null && assemblyFiles.Length != 0)
            {
                guluManager__.Clear();
                foreach (FileInfo assemblyFile in assemblyFiles)
                {
                    try
                    {
                        guluManager__.Load(assemblyFile.FullName, true);
                    }
                    catch
                    {
                        continue;
                    }
                }
                guluRoot__.Nodes.Clear();
                foreach (GuluBase gulu in guluManager__.Items)
                {
                    TreeNode node = guluRoot__.Nodes.Add(gulu.Name,
                        gulu.Name,
                        "Leaf", "Leaf");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(string.Format("<FONT STYLE=\"Bold\" FACE=\"Arial\" COLOR=\"#34689A\" SIZE=\"5px\">{0}</FONT><BR/><HR/>", gulu.Name ?? string.Empty));
                    if (gulu.Documentation == null || gulu.Documentation.Trim().Equals(string.Empty))
                        sb.Append(string.Format("<P>{0}</P><BR/><HR/>", Resources.TEXT_NO_DOCUMENT_AVAILABLE));
                    else
                        sb.Append(string.Format("<P>{0}</P><BR/><HR/>", gulu.Documentation));
                    sb.Append(string.Format("<FONT FACE=\"Tahoma\" SIZE=\"1px\" COLOR=\"GRAY\">{0}</FONT><BR/><BR/>",
                        gulu.Copyright.Replace("SunnyChen.ORG", "<A HREF=\"http://www.sunnychen.org\" TARGET=\"_blank\">SunnyChen.ORG</A>")));
                    node.Tag = sb.ToString();
                }
            }
        }

        #endregion

        #region Generated Event Handlers
        private void frmDynamicHelp_Load(object sender, System.EventArgs e)
        {
            InitializeTreeView();
        }

        private void treeView_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode node = treeView.SelectedNode;
            if (node != null)
            {
                if (node.Tag != null)
                {
                    string content = (string)node.Tag;
                    browser.DocumentText = content;
                }
            }
        }
        #endregion
    }
}
