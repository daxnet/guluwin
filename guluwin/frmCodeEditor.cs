/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/9/2008
 * 
 * The code editor form.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using SunnyChen.Common.CodeDom;
using SunnyChen.Common.Enumerations;
using SunnyChen.Common.Patterns;
using SunnyChen.Common.Patterns.ExtendableMDI.Attributes;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Win.Configuration;
using SunnyChen.Gulu.Win.ScriptRepositories;

namespace SunnyChen.Gulu.Win
{
    /// <summary>
    /// The code editor form of Gulu. Gulu allows users to create their
    /// domain specific scripts for handling file batch processing. In
    /// Gulu, code editor provides the abilities of editing and compiling
    /// scripts. There are two kinds of scripts in Gulu, the G Script and
    /// the Simple Script. Simple Script allows users to write simple
    /// scripts whereas G Script allows users to create and run their
    /// customized Gulus within script context.
    /// </summary>
    public partial class frmCodeEditor : frmDummy
    {
        #region Private Fields
        /// <summary>
        /// The script repository which is used to load/save and maintain the scripts.
        /// </summary>
        private IScriptRepository scriptRepository__ = new FileSystemScriptRepository();
        /// <summary>
        /// Name of the file that is currently editing.
        /// </summary>
        private string fileName__ = string.Empty;
        /// <summary>
        /// Name of the script that is currently editing, normally it is the main file
        /// name of the script.
        /// </summary>
        private string name__ = string.Empty;
        /// <summary>
        /// Type of the script, it has two values: Simple and G.
        /// </summary>
        private ScriptType type__ = ScriptType.G;
        /// <summary>
        /// The compiler instance which is handling the compiling and running of
        /// the script.
        /// </summary>
        private Compiler compiler__;
        /// <summary>
        /// Configuration reader. This reader is got from its 'parent' form, and it was
        /// initialized when the main form of GuluWin was loading. This ensures that the
        /// entire environment uses the same setting (like syntax file, compiler and script
        /// templates) synchronously in the same running context. So before these setings
        /// took effect, users MUST restart the program to ensure that same settings are
        /// used synchronously in the running context.
        /// </summary>
        private ConfigReader configReader__;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public frmCodeEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized constructor.
        /// </summary>
        /// <param name="_parent">The parent form in which the code editor creates.</param>
        /// <param name="_compiler">The compiler instance which was initialized when main form was loading.</param>
        /// <param name="_configReader">The configuration reader instance which was initailized when main form was loading.</param>
        public frmCodeEditor(frmMain _parent, Compiler _compiler, ConfigReader _configReader)
            : base(_parent)
        {
            InitializeComponent();
            compiler__ = _compiler;
            configReader__ = _configReader;
        }
        #endregion

        #region Action Handlers
        /// <summary>
        /// Action Method. This method was invoked once the user clicks "Save"
        /// button on the main form. For more information about Action Methods
        /// please refer to "Extendable MDI" pattern.
        /// </summary>
        [SaveAction]
        private void DoSave()
        {
            // Saves the code to the file system (The script file)
            editor.Save(fileName__);
            // Sends a message to the main form to prevent clicking of "Save"
            // button. For more information about Action Methods please refer
            // to "Extendable MDI" pattern.
            CanSave = false;
            // Changes the Modified attribute of the document
            syntaxDocument1.Modified = false;
            // Re-construct the code outline
            BuildCodeStruct(syntaxDocument1.Text);
        }
        #endregion

        #region Private Methods
 
        /// <summary>
        /// Gets the image key name according to the member attributes
        /// of a given type.
        /// </summary>
        /// <param name="_attribute">The member attribute of the type.</param>
        /// <param name="_isClass">Indicates whether the type is a class.</param>
        /// <param name="_isEnum">Indicates whether the type is an enumeration.</param>
        /// <param name="_isStruct">Indicates whether the type is a structure.</param>
        /// <param name="_isInterface">Indicates whether the type is an interface.</param>
        /// <returns>The key name of the image.</returns>
        private string GetTypeImageKeyName(MemberAttributes _attribute, 
            bool _isClass,
            bool _isEnum,
            bool _isStruct,
            bool _isInterface)
        {
            string ret = string.Empty;
            switch (_attribute)
            {
                case MemberAttributes.Private:
                    ret += "Private";
                    break;
                default:
                    break;
            }
            if (_isClass)
                ret += "Class";
            if (_isEnum)
                ret += "Enum";
            if (_isStruct)
                ret += "Struct";
            if (_isInterface)
                ret += "Interface";
            return ret;
        }

        /// <summary>
        /// Gets the image key name for a given member.
        /// </summary>
        /// <param name="_member">The code member of the type.</param>
        /// <returns>The key name of the image.</returns>
        private string GetMemberImageKeyName(CodeTypeMember _member)
        {
            string ret = string.Empty;

            switch (_member.Attributes)
            {
                case MemberAttributes.Private:
                    ret += "Private";
                    break;
            }
            if (_member is CodeMemberEvent)
                ret += "Event";
            if (_member is CodeMemberField)
                ret += "Field";
            if (_member is CodeMemberMethod)
                ret += "Method";
            if (_member is CodeMemberProperty)
                ret += "Property";
            return ret;
        }

        /// <summary>
        /// Builds or Re-constructs the tree structure/outline of the editing code.
        /// </summary>
        /// <param name="_code">The code for which the structure is going to be built.</param>
        /// <remarks>This function is specific to C# language.</remarks>
        private void BuildCodeStruct(string _code)
        {
            string namespaceName;
            // Parses the code
            CSharpCodeVisualizer visualizer = new CSharpCodeVisualizer();
            int ret = visualizer.Parse(_code);
            // Initialize the code structure tree view
            codeStructTreeView.Nodes.Clear();

            if (ret == 0)
            {
                // Get the namespaces from the code
                foreach (CodeNamespace ns in visualizer.CodeCompileUnit.Namespaces)
                {
                    // If the namespace is empty, it means that user didn't encapsulate the code
                    // into a given namespace. We use the default namespace for such case.
                    namespaceName = ns.Name == string.Empty ? SunnyChen.Gulu.Win.Properties.Resources.TEXT_DEFAULT_NAMESPACE : ns.Name;
                    // Creates the tree node for namespaces and place the position information
                    // into the Tag property.
                    TreeNode namespaceNode = codeStructTreeView.Nodes.Add(namespaceName, namespaceName, "Namespace", "Namespace");
                    namespaceNode.Tag = (CodeLinePragma)ns.UserData["Location"];
                    // Get the types from the current namespace
                    foreach (CodeTypeDeclaration typeDeclaration in ns.Types)
                    {
                        // Creates the tree node for types, select right image for the type, and
                        // place the position information into the Tag property of the node.
                        TreeNode typeNode = namespaceNode.Nodes.Add(typeDeclaration.Name,
                            typeDeclaration.Name,
                            GetTypeImageKeyName(typeDeclaration.Attributes, typeDeclaration.IsClass, typeDeclaration.IsEnum, typeDeclaration.IsStruct, typeDeclaration.IsInterface),
                            GetTypeImageKeyName(typeDeclaration.Attributes, typeDeclaration.IsClass, typeDeclaration.IsEnum, typeDeclaration.IsStruct, typeDeclaration.IsInterface));
                        typeNode.Tag = (CodeLinePragma)typeDeclaration.UserData["Location"];
                        // Get the members within the current type declaration.
                        foreach (CodeTypeMember member in typeDeclaration.Members)
                        {
                            // Creates the tree node for members, select right image for the type
                            // and place the position information into the Tag property of the node.
                            TreeNode memberNode = typeNode.Nodes.Add(member.Name,
                                member.Name,
                                GetMemberImageKeyName(member),
                                GetMemberImageKeyName(member));
                            memberNode.Tag = (CodeLinePragma)member.UserData["Location"];
                        }
                    }
                }
            }
            else
            {
                // Error occured while creating the outline, show the error text on the root node
                TreeNode errorNode = codeStructTreeView.Nodes.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_GET_CODE_STRUCT, 
                    SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_GET_CODE_STRUCT, 
                    "Error", 
                    "Error");

            }
            // Expand the tree so that users can pick the member easily.
            codeStructTreeView.ExpandAll();
        }

        /// <summary>
        /// Update the attribute for tool elements on the form.
        /// </summary>
        private void UpdateTools()
        {
            toolbarsManager.Tools["mnuCopy"].SharedProps.Enabled = editor.CanCopy;
            toolbarsManager.Tools["mnuPaste"].SharedProps.Enabled = editor.CanPaste;
            toolbarsManager.Tools["mnuCut"].SharedProps.Enabled = editor.CanCopy;
            toolbarsManager.Tools["mnuDelete"].SharedProps.Enabled = editor.CanCopy;
        }

        #endregion

        #region Private User-Defined Event Handlers
        /// <summary>
        /// Occurs when the user presses "Undo" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Undo(object sender, System.EventArgs e)
        {
            if (editor.CanUndo)
                editor.Caret.Position = syntaxDocument1.Undo();
        }

        /// <summary>
        /// Occurs when the user presses "Redo" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Redo(object sender, System.EventArgs e)
        {
            if (editor.CanRedo)
                editor.Caret.Position = syntaxDocument1.Redo();
        }

        /// <summary>
        /// Occurs when the user presses "Copy" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Copy(object sender, System.EventArgs e)
        {
            if (editor.CanCopy)
                editor.Copy();
        }

        /// <summary>
        /// Occurs when the user presses "Paste" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Paste(object sender, System.EventArgs e)
        {
            if (editor.CanPaste)
                editor.Paste();
        }

        /// <summary>
        /// Occurs when the user presses "Cut" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Cut(object sender, System.EventArgs e)
        {
            if (editor.CanCopy)
                editor.Cut();
        }

        /// <summary>
        /// Occurs when the user presses "Select all" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_SelectAll(object sender, System.EventArgs e)
        {
            editor.SelectAll();
        }

        /// <summary>
        /// Occurs when the user presses "Delete" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Delete(object sender, System.EventArgs e)
        {
            if (editor.CanCopy)
                editor.Delete();
        }

        /// <summary>
        /// Occurs when the user is going to update the code structure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_UpdateCodeStruct(object sender, System.EventArgs e)
        {
            this.BuildCodeStruct(syntaxDocument1.Text);
        }

        /// <summary>
        /// Occurs when the script is going to be compiled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Compile(object sender, System.EventArgs e)
        {
            try
            {
                compiler__.ClearCodes();
                compiler__.AddCode(syntaxDocument1.Text);
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
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_COMPILE);
                    ErrorList.Show();
                }
                else if (ret == 0)
                {
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_COMPILE_OK);
                    Output.Show();
                }
                else if (ret == -1)
                {
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_NO_CODE);
                    Output.Show();
                }
                else
                {
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_COMPILE_GENERAL);
                    Output.Show();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Occurs when the script is going to be run.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventHandler_Run(object sender, System.EventArgs e)
        {
            try
            {
                compiler__.ClearCodes();
                compiler__.AddCode(syntaxDocument1.Text);
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
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_COMPILE);
                    ErrorList.Show();
                }
                else if (ret == 0)
                {
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_COMPILE_OK);
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
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_NO_CODE);
                    Output.Show();
                }
                else
                {
                    Output.Add(SunnyChen.Gulu.Win.Properties.Resources.TEXT_ERR_COMPILE_GENERAL);
                    Output.Show();
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the script code into code editor.
        /// </summary>
        /// <param name="_name">Name of the script.</param>
        /// <param name="_scriptType">Type of the script.</param>
        /// <param name="_openReadOnly">Determines if the script should be opened read-only.</param>
        public void LoadExistingCode(string _name, ScriptType _scriptType, bool _openReadOnly)
        {
            using (new LengthyOperation(parent__))
            {
                try
                {
                    name__ = _name;
                    type__ = _scriptType;
                    Text = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_CODEEDITOR_TITLE, name__, type__);

                    string content = scriptRepository__.GetContent(_name, _scriptType);
                    syntaxDocument1.Text = content;
                    editor.ReadOnly = _openReadOnly;
                    this.BuildCodeStruct(content);
                    editor.Focus();

                    fileName__ = FileSystemScriptRepository.GetScriptFileName(_name, _scriptType);
                    
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Create new script with template according to the type of the script.
        /// </summary>
        /// <param name="_name">Name of the script.</param>
        /// <param name="_fileName">Filename of the script.</param>
        /// <param name="_scriptType">Type of the script.</param>
        public void CreateNewCode(string _name, string _fileName, ScriptType _scriptType)
        {
            using (new LengthyOperation(parent__))
            {
                try
                {
                    name__ = _name;
                    type__ = _scriptType;
                    fileName__ = _fileName;// FileSystemScriptRepository.GetScriptFileName(_name, _scriptType);
                    syntaxDocument1.Text = scriptRepository__.GetTemplateContent(_scriptType).Replace("<%DATE%>", DateTime.Now.ToShortDateString()).Replace("<%NAME%>", _name);
                    Text = string.Format(SunnyChen.Gulu.Win.Properties.Resources.TEXT_CODEEDITOR_TITLE, name__, type__);
                    DoSave();
                }
                catch
                {
                }
            }
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the name of the script.
        /// </summary>
        public string ScriptName
        {
            get { return name__; }
        }
        /// <summary>
        /// Gets the type of the script.
        /// </summary>
        public ScriptType ScriptType
        {
            get { return type__; }
        }
        #endregion

        #region Generated Event Handlers
        private void frmCodeEditor_Load(object sender, System.EventArgs e)
        {
            syntaxDocument1.SyntaxFile = configReader__.SyntaxFileName;// "csharp.syn";
            UpdateTools();
            CanSave = false;
        }

        private void codeStructTreeView_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode node = codeStructTreeView.SelectedNode;
            if (node != null && (node.Tag is CodeLinePragma))
            {
                CodeLinePragma pragma = (CodeLinePragma)node.Tag;
                if (pragma != null)
                {
                    editor.GotoLine(pragma.LineNumber);
                    editor.Focus();
                }
            }
        }

        private void syntaxDocument1_ModifiedChanged(object sender, System.EventArgs e)
        {
            if (syntaxDocument1.Modified)
            {
                CanSave = true;
            }
        }

        private void frmCodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (syntaxDocument1.Modified)
            {
                DialogResult dr = MessageBox.Show(SunnyChen.Gulu.Win.Properties.Resources.TEXT_CONFIRM_SAVE_SCRIPT,
                    SunnyChen.Gulu.Win.Properties.Resources.TEXT_CONFIRMATION,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DoSave();
                    e.Cancel = false;
                }
                else if (dr == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
        }

        private void toolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            using (new LengthyOperation(parent__))
            {
                switch (e.Tool.Key)
                {
                    case "mnuUndo":
                        this.EventHandler_Undo(sender, e);
                        break;
                    case "mnuRedo":
                        this.EventHandler_Redo(sender, e);
                        break;
                    case "mnuCopy":
                        this.EventHandler_Copy(sender, e);
                        break;
                    case "mnuPaste":
                        this.EventHandler_Paste(sender, e);
                        break;
                    case "mnuCut":
                        this.EventHandler_Cut(sender, e);
                        break;
                    case "mnuSelectAll":
                        this.EventHandler_SelectAll(sender, e);
                        break;
                    case "mnuDelete":
                        this.EventHandler_Delete(sender, e);
                        break;
                    case "mnuUpdateCodeStructure":
                        this.EventHandler_UpdateCodeStruct(sender, e);
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

        private void editor_CaretChange(object sender, System.EventArgs e)
        {
            
        }

        private void editor_SelectionChange(object sender, System.EventArgs e)
        {
            UpdateTools();
        }

        private void toolbarsManager_ToolKeyPress(object sender, Infragistics.Win.UltraWinToolbars.ToolKeyPressEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "mnuFindField":
                    if (e.KeyChar == 0x0D)
                    {
                        ComboBoxTool cbt = (e.Tool as ComboBoxTool);
                        editor.FindNext(cbt.Text, false, false, false);
                        bool found = false;
                        for (int i = 0; i < cbt.ValueList.ValueListItems.Count; i++)
                        {
                            if (cbt.ValueList.ValueListItems[i].DisplayText.Equals(cbt.Text))
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found) cbt.ValueList.ValueListItems.Add(cbt.Text);
                    }
                    break;
                case "mnuGotoLine":
                    if (e.KeyChar == 0x0D)
                    {
                        int lineNum = 1;
                        TextBoxTool tbt = (e.Tool as TextBoxTool);
                        int.TryParse(tbt.Text, out lineNum);
                        editor.GotoLine(lineNum - 1);
                        editor.Focus();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
