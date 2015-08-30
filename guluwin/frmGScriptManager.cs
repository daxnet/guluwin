/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/17/2008
 * 
 * The script manager form.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
using SunnyChen.Common.CodeDom;
using SunnyChen.Common.Enumerations;
using SunnyChen.Common.Patterns;
using SunnyChen.Common.Patterns.ExtendableMDI.Attributes;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Win.Configuration;
using SunnyChen.Gulu.Win.NodeProperties;
using SunnyChen.Gulu.Win.Properties;
using SunnyChen.Gulu.Win.ScriptRepositories;

namespace SunnyChen.Gulu.Win
{
    public partial class frmGScriptManager : frmDummy
    {
        #region Private Fields
        /// <summary>
        /// The root node of Simple Scripts
        /// </summary>
        private TreeNode simpleScriptsRoot__;
        /// <summary>
        /// The Root node of G Scripts
        /// </summary>
        private TreeNode gScriptsRoot__;
        /// <summary>
        /// The script repository which holds the operation of scripts
        /// </summary>
        private IScriptRepository scriptRepository__ = new FileSystemScriptRepository();
        /// <summary>
        /// The CodeDom compiler
        /// </summary>
        private Compiler compiler__;

        private ConfigReader configReader__;
        #endregion

        #region Constructors
        public frmGScriptManager()
        {
            InitializeComponent();
        }

        public frmGScriptManager(frmMain _parent, Compiler _compiler, ConfigReader _configReader)
            : base(_parent)
        {
            InitializeComponent();
            // Assigns the instance of the compiler which was created
            // when the main form was loading.
            compiler__ = _compiler;
            configReader__ = _configReader;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Initialize the tree view of scripts
        /// </summary>
        private void InitializeGScriptTreeView()
        {
            gscriptTreeView.Nodes.Clear();
            /*
            simpleScriptsRoot__ = gscriptTreeView.Nodes.Add(Resources.TEXT_SIMPLESCRIPT_ROOT,
                Resources.TEXT_SIMPLESCRIPT_ROOT,
                "SimpleScriptRoot", "SimpleScriptRoot");
             * */
            // We use the same image as the G Script Root node
            simpleScriptsRoot__ = gscriptTreeView.Nodes.Add(Resources.TEXT_SIMPLESCRIPT_ROOT,
                Resources.TEXT_SIMPLESCRIPT_ROOT,
                "GScriptRoot", "GScriptRoot");
            simpleScriptsRoot__.Tag = new ScriptTreeNodeProperty(Resources.TEXT_SIMPLESCRIPT_ROOT,
                string.Empty, ScriptTreeNodeType.SimpleRoot);

            gScriptsRoot__ = gscriptTreeView.Nodes.Add(Resources.TEXT_GSCRIPT_ROOT,
                Resources.TEXT_GSCRIPT_ROOT,
                "GScriptRoot", "GScriptRoot");
            gScriptsRoot__.Tag = new ScriptTreeNodeProperty(Resources.TEXT_GSCRIPT_ROOT,
                string.Empty, ScriptTreeNodeType.GRoot);

            string[] simpleScripts = scriptRepository__.GetNames(ScriptType.Simple);
            string[] gScripts = scriptRepository__.GetNames(ScriptType.G);

            if (simpleScripts != null && simpleScripts.Length > 0)
            {
                simpleScriptsRoot__.Nodes.Clear();
                foreach (string name in simpleScripts)
                {
                    string shortName = Path.GetFileNameWithoutExtension(name);
                    TreeNode node = simpleScriptsRoot__.Nodes.Add(shortName, shortName, "Script", "Script");
                    node.Tag = new ScriptTreeNodeProperty(shortName, name, ScriptTreeNodeType.Simple);
                }
            }

            if (gScripts != null && gScripts.Length > 0)
            {
                gScriptsRoot__.Nodes.Clear();
                foreach (string name in gScripts)
                {
                    string shortName = Path.GetFileNameWithoutExtension(name);
                    TreeNode node = gScriptsRoot__.Nodes.Add(shortName, shortName, "Script", "Script");
                    node.Tag = new ScriptTreeNodeProperty(shortName, name, ScriptTreeNodeType.G);
                }
            }
        }

        private void UpdateGScriptTreeView(ScriptType _type)
        {
            TreeNode rootNode;

            switch (_type)
            {
                case ScriptType.G:
                    rootNode = gScriptsRoot__;
                    break;
                case ScriptType.Simple:
                    rootNode = simpleScriptsRoot__;
                    break;
                default:
                    return;
            }

            bool expanded = rootNode.IsExpanded;

            string[] names = scriptRepository__.GetNames(_type);
            
            rootNode.Nodes.Clear();

            if (names != null && names.Length > 0)
            {
                
                foreach (string name in names)
                {
                    string shortName = Path.GetFileNameWithoutExtension(name);
                    TreeNode node = rootNode.Nodes.Add(shortName, shortName, "Script", "Script");
                    switch (_type)
                    {
                        case ScriptType.G:
                            node.Tag = new ScriptTreeNodeProperty(shortName, name, ScriptTreeNodeType.G);
                            break;
                        case ScriptType.Simple:
                            node.Tag = new ScriptTreeNodeProperty(shortName, name, ScriptTreeNodeType.Simple);
                            break;
                        default:
                            node.Tag = null;
                            break;
                    }
                }
            }
            if (expanded)
                rootNode.Expand();
        }

        #endregion

        #region Private User-Defined Event Handlers
        
        private void EventHandler_Open(object sender, System.EventArgs e)
        {
            TreeNode node = gscriptTreeView.SelectedNode;
            frmCodeEditor codeEditor;
            if (node != null)
            {
                ScriptTreeNodeProperty prop = (ScriptTreeNodeProperty)node.Tag;
                if (prop != null)
                {
                    if (prop.Type == ScriptTreeNodeType.G ||
                        prop.Type == ScriptTreeNodeType.Simple)
                    {
                        try
                        {
                            ScriptType type = prop.Type == ScriptTreeNodeType.G ? ScriptType.G : ScriptType.Simple;
                            foreach (frmDummy form in parent__.MdiChildren)
                            {
                                if (form is frmCodeEditor)
                                {
                                    codeEditor = (form as frmCodeEditor);
                                    if (codeEditor.ScriptName.Equals(prop.Name) &&
                                        codeEditor.ScriptType.Equals(type))
                                    {
                                        codeEditor.BringToFront();
                                        return;
                                    }
                                }
                            }
                            codeEditor = new frmCodeEditor(parent__, compiler__, configReader__);
                            codeEditor.LoadExistingCode(prop.Name, type, false);
                            codeEditor.Show();
                            return;
                        }
                        catch
                        {

                        }
                    }
                    if (e == null)
                    {
                        if (prop.Type == ScriptTreeNodeType.GRoot ||
                            prop.Type == ScriptTreeNodeType.SimpleRoot)
                        {
                            if (!node.IsExpanded)
                            {
                                node.Expand();
                            }
                        }
                    }
                }
            }
        }

        private void EventHandler_Delete(object sender, System.EventArgs e)
        {
            TreeNode node = gscriptTreeView.SelectedNode;
            if (node != null)
            {
                ScriptTreeNodeProperty prop = (ScriptTreeNodeProperty)node.Tag;
                if (prop != null)
                {
                    if (prop.Type == ScriptTreeNodeType.G ||
                        prop.Type == ScriptTreeNodeType.Simple)
                    {
                        if (MessageBox.Show(Resources.TEXT_CONFIRM_DELETE_ITEM,
                            Resources.TEXT_CONFIRMATION,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                ScriptType type = prop.Type == ScriptTreeNodeType.G ? ScriptType.G : ScriptType.Simple;
                                scriptRepository__.Remove(prop.Name, type);
                                UpdateGScriptTreeView(type);
                                TreeNode parentNode = type == ScriptType.G ? gScriptsRoot__ : simpleScriptsRoot__;
                                gscriptTreeView.SelectedNode = parentNode;
                                toolbarsManager.Tools["mnuDelete"].SharedProps.Enabled = false;
                                toolbarsManager.Tools["mnuRun"].SharedProps.Enabled = false;
                                toolbarsManager.Tools["mnuCompile"].SharedProps.Enabled = false;
                            }
                            catch
                            {
                            }
                        } // User confirmation
                    } // property type
                }
            }
        }

        public void EventHandler_Compile(object sender, System.EventArgs e)
        {
            try
            {
                TreeNode node = gscriptTreeView.SelectedNode;
                if (node != null)
                {
                    ScriptTreeNodeProperty prop = (ScriptTreeNodeProperty)node.Tag;
                    if (prop != null)
                    {
                        if (prop.Type == ScriptTreeNodeType.G ||
                            prop.Type == ScriptTreeNodeType.Simple)
                        {
                            ScriptType type;
                            type = prop.Type == ScriptTreeNodeType.G ? ScriptType.G : ScriptType.Simple;
                            string code = scriptRepository__.GetContent(prop.Name, type);
                            compiler__.ClearCodes();
                            compiler__.AddCode(code);
                            int ret = compiler__.Compile();
                            Output.Clear();
                            ErrorList.Clear();
                            if (ret > 0)
                            {
                                foreach (CompilerError error in compiler__.Errors)
                                {
                                    ErrorLevel level = error.IsWarning ? ErrorLevel.elWarning : ErrorLevel.elError;
                                    ErrorList.Add(level, error.ErrorNumber, error.ErrorText, error.Line);
                                }
                                Output.Add(Resources.TEXT_ERR_COMPILE);
                                ErrorList.Show();
                            }
                            else if (ret == 0)
                            {
                                Output.Add(Resources.TEXT_COMPILE_OK);
                                Output.Show();
                            }
                            else if (ret == -1)
                            {
                                Output.Add(Resources.TEXT_ERR_NO_CODE);
                                Output.Show();
                            }
                            else
                            {
                                Output.Add(Resources.TEXT_ERR_COMPILE_GENERAL);
                                Output.Show();
                            }
                        }
                    }
                }
               
            }
            catch
            {
                throw;
            }
        }

        public void EventHandler_Run(object sender, System.EventArgs e)
        {
            try
            {
                TreeNode node = gscriptTreeView.SelectedNode;
                if (node != null)
                {
                    ScriptTreeNodeProperty prop = (ScriptTreeNodeProperty)node.Tag;
                    if (prop != null)
                    {
                        if (prop.Type == ScriptTreeNodeType.G ||
                            prop.Type == ScriptTreeNodeType.Simple)
                        {
                            ScriptType type;
                            type = prop.Type == ScriptTreeNodeType.G ? ScriptType.G : ScriptType.Simple;
                            string code = scriptRepository__.GetContent(prop.Name, type);
                            compiler__.ClearCodes();
                            compiler__.AddCode(code);
                            int ret = compiler__.Compile();
                            Output.Clear();
                            ErrorList.Clear();
                            if (ret > 0)
                            {
                                foreach (CompilerError error in compiler__.Errors)
                                {
                                    ErrorLevel level = error.IsWarning ? ErrorLevel.elWarning : ErrorLevel.elError;
                                    ErrorList.Add(level, error.ErrorNumber, error.ErrorText, error.Line);
                                }
                                Output.Add(Resources.TEXT_ERR_COMPILE);
                                ErrorList.Show();
                            }
                            else if (ret == 0)
                            {
                                Output.Add(Resources.TEXT_COMPILE_OK);
                                Output.Show();
                                try
                                {
                                    compiler__.Run("Program", "Main");
                                }
                                catch (Exception ex)
                                {
                                    //ExceptionMessageBox.ShowDialog(ex);
                                    Exception param = ex.InnerException == null ? ex : ex.InnerException;
                                    ExceptionMessageBox.ShowDialog(param, true);
                                }
                            }
                            else if (ret == -1)
                            {
                                Output.Add(Resources.TEXT_ERR_NO_CODE);
                                Output.Show();
                            }
                            else
                            {
                                Output.Add(Resources.TEXT_ERR_COMPILE_GENERAL);
                                Output.Show();
                            }
                        }
                    }
                }

            }
            catch
            {
                throw;
            }
        }

        private void EventHandler_New(object sender, System.EventArgs e)
        {
            try
            {
                TreeNode node = gscriptTreeView.SelectedNode;
                if (node != null)
                {
                    ScriptTreeNodeProperty prop = (ScriptTreeNodeProperty)node.Tag;
                    if (prop != null)
                    {
                        ScriptType type;
                        if (prop.Type == ScriptTreeNodeType.G ||
                            prop.Type == ScriptTreeNodeType.GRoot)
                            type = ScriptType.G;
                        else
                            type = ScriptType.Simple;

                        string name = StringInputBox.GetInputString(Resources.TEXT_INPUTNAME, 
                            Resources.TEXT_INPUTNAME_TITLE,
                            SunnyChen.Common.RegularExpressions.RegularExpressionSet.IDENTIFIER);

                        if (name.Trim().Equals(string.Empty))
                        {
                            return;
                        }
                        string fileName = FileSystemScriptRepository.GetScriptFileName(name, type);
                        if (File.Exists(fileName))
                        {
                            MessageBox.Show(Resources.TEXT_SCRIPT_ALREADY_EXISTS, 
                                Resources.TEXT_ERROR, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);

                            return;
                        }
                        frmCodeEditor codeEditor = new frmCodeEditor(parent__, compiler__, configReader__);
                        codeEditor.CreateNewCode(name, fileName, type);
                        codeEditor.Show();
                        toolbarsManager.Tools["mnuDelete"].SharedProps.Enabled = false;
                        toolbarsManager.Tools["mnuRun"].SharedProps.Enabled = false;
                        toolbarsManager.Tools["mnuCompile"].SharedProps.Enabled = false;
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Private Action Handlers
        /// <summary>
        /// Fires when the user clicks "Open" button on the main form.
        /// </summary>
        [OpenAction]
        private void DoOpen()
        {
            this.EventHandler_Open(this, null);
        }

        [NewAction]
        private void DoNew()
        {
            this.EventHandler_New(this, null);
        }
        #endregion

        #region Public Methods

        #endregion

        #region Public Properties

        #endregion

        #region Generated Event Handlers
        private void frmGScriptManager_Load(object sender, System.EventArgs e)
        {
            // Initialize the Script Manager tree view.
            InitializeGScriptTreeView();

            // Initialize the file system watcher. If the script repository
            // is not a file system repository, file system watcher will be
            // disabled.
            if (scriptRepository__ is FileSystemScriptRepository)
            {
                fileSystemWatcher.EnableRaisingEvents = true;
                fileSystemWatcher.Path = Directories.ScriptsPath;
            }

            // GScript manager allows creating new scripts, open an existing
            // script, so CanNew, CanOpen attributes should be set to true.
            CanNew = true;
            CanOpen = true;
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (scriptRepository__ is FileSystemScriptRepository)
            {
                this.UpdateGScriptTreeView(ScriptType.Simple);
                this.UpdateGScriptTreeView(ScriptType.G);
            }
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (scriptRepository__ is FileSystemScriptRepository)
            {
                this.UpdateGScriptTreeView(ScriptType.Simple);
                this.UpdateGScriptTreeView(ScriptType.G);
            }
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (scriptRepository__ is FileSystemScriptRepository)
            {
                this.UpdateGScriptTreeView(ScriptType.Simple);
                this.UpdateGScriptTreeView(ScriptType.G);
            }
        }

        private void gscriptTreeView_DoubleClick(object sender, System.EventArgs e)
        {
            using (new LengthyOperation(this))
            {
                this.EventHandler_Open(sender, e);
            }
        }

        private void gscriptTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode node = gscriptTreeView.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                gscriptTreeView.SelectedNode = node;
            }
        }

        private void gscriptTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                ScriptTreeNodeProperty prop = (ScriptTreeNodeProperty)e.Node.Tag;
                toolbarsManager.Tools["mnuDelete"].SharedProps.Enabled = 
                    (prop.Type == ScriptTreeNodeType.G || 
                    prop.Type == ScriptTreeNodeType.Simple);
                toolbarsManager.Tools["mnuCompile"].SharedProps.Enabled =
                    (prop.Type == ScriptTreeNodeType.G ||
                    prop.Type == ScriptTreeNodeType.Simple);
                toolbarsManager.Tools["mnuRun"].SharedProps.Enabled =
                    (prop.Type == ScriptTreeNodeType.G ||
                    prop.Type == ScriptTreeNodeType.Simple);

            }
        }

        private void toolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            using (new LengthyOperation(parent__))
            {
                switch (e.Tool.Key)
                {
                    case "mnuDelete":
                        this.EventHandler_Delete(sender, e);
                        break;
                    case "mnuCompile":
                        this.EventHandler_Compile(sender, e);
                        break;
                    case "mnuRun":
                        this.EventHandler_Run(sender, e);
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}
