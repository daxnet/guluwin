using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Common.Windows.Forms
{
    /// <summary>
    /// The Type Selector provides the user interface for selecting a .NET type
    /// that has a given signature.
    /// </summary>
    /// <remarks>
    /// <para>In Type Selector a signature on the .NET type stands for two things, one is the base type and
    /// another is the attribute which applies on that type.</para>
    /// <para>Take the following code as an example.</para>
    /// <code>
    /// [Serializable]
    /// public class Teacher : Person
    /// {
    ///     // ...
    /// }
    /// </code>
    /// This Teacher inherits from the base type Person, and has the attribute <see cref="System.SerializableAttribute"/> applied on it. These
    /// two objects are considered to be the signature of the type Teacher.
    /// </remarks>
    /// <example>
    /// Following example shows the way that initializes the Type Selector and lets user select a type with the
    /// <see cref="System.SerializableAttribute"/> attribute whose base type is Person in the specific assembly.
    /// <code>
    /// private void button1_click (object sender, System.EventArgs e)
    /// {
    ///     TypeSelector selector = new TypeSelector("Please select a person.", 
    ///         "Please select a person in the assembly",
    ///         typeof(Person), typeof(SerializableAttribute));
    ///         
    ///     if (selector.ShowDialog() == DialogResult.OK)
    ///         textBox1.Text = selector.SelectedText;
    /// }
    /// </code>
    /// </example>
    public partial class TypeSelector : Form
    {
        private Type superType__ = null;
        private Type attributeType__ = null;
        private Type selectedType__ = null;
        private Assembly selectedAssembly__ = null;
        /// <summary>
        /// Creates the TypeSelector instance with the given parameters.
        /// </summary>
        /// <param name="_title">The title text that is going to be shown on the TypeSelector.</param>
        /// <param name="_description">The description text that is going to be shown on the TypeSelector.</param>
        /// <param name="_superType">The base type of the types that need to be included in the selection list.</param>
        /// <param name="_attributeType">The attribute that applies on the types that need to be included in the selection list.</param>
        public TypeSelector(string _title, string _description, Type _superType, Type _attributeType)
        {
            InitializeComponent();
            superType__ = _superType;
            attributeType__ = _attributeType;
            Text = _title;
            txtDescription.Text = _description;
        }
        /// <summary>
        /// Creates the TypeSelector instance with the given parameters.
        /// </summary>
        /// <param name="_title">The title text that is going to be shown on the TypeSelector.</param>
        /// <param name="_description">The description text that is going to be shown on the TypeSelector.</param>
        /// <param name="_superType">The base type of the types that need to be included in the selection list.</param>
        public TypeSelector(string _title, string _description, Type _superType)
        {
            InitializeComponent();
            superType__ = _superType;
            attributeType__ = null;
            Text = _title;
            txtDescription.Text = _description;
        }


        private void BindTreeView(Assembly _assembly, Type _superType, Type _attributeType)
        {
            selectedAssembly__ = _assembly;

            treeView.Nodes.Clear();
            TreeNode root = treeView.Nodes.Add(_assembly.ToString(), _assembly.ToString(), "Assembly", "Assembly");
            root.Tag = null;
            foreach (Type type in _assembly.GetTypes())
            {
                if (_superType != null)
                {
                    if (!type.IsSubclassOf(_superType))
                        continue;
                }
                if (_attributeType != null)
                {
                    bool found = false;
                    object[] attrs = type.GetCustomAttributes(false);
                    foreach (object attr in attrs)
                    {
                        if (attr.GetType() == _attributeType)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found) continue;
                }
                TreeNode node = root.Nodes.Add(type.FullName, type.FullName, "Type", "Type");
                node.Tag = type;
            }

            root.ExpandAll();
            treeView.SelectedNode = root;
            btnOK.Enabled = false;
        }

        private void OnRadioChange(object sender, System.EventArgs e)
        {
            cbAssemblies.Enabled = rbAppDirectory.Checked;
            btnSelect.Enabled = rbSelect.Checked;
            if (sender == rbAppDirectory)
            {
                Assembly assembly = Assembly.Load(cbAssemblies.SelectedItem.ToString());
                this.BindTreeView(assembly, superType__, attributeType__);
            }
            else if (sender == rbSelect)
            {
                treeView.Nodes.Clear();
            }
        }
        /// <summary>
        /// Gets the selected type.
        /// </summary>
        public Type SelectedType
        {
            get { return selectedType__; }
        }
        /// <summary>
        /// Gets the assembly in which the selected type was.
        /// </summary>
        public Assembly SelectedAssembly
        {
            get { return selectedAssembly__; }
        }
        /// <summary>
        /// Gets the assembly qualified string of the selected type.
        /// </summary>
        public string SelectedText
        {
            //get { return string.Format("{0}, {1}", selectedType__.FullName, selectedAssembly__.FullName); }
            get { return selectedType__.AssemblyQualifiedName; }
        }
        /// <summary>
        /// Gets or sets a value that indicating if the "Select from specific file" should be enabled.
        /// </summary>
        public bool SelectFileEnabled
        {
            get { return rbSelect.Enabled; }
            set 
            {
                rbSelect.Enabled = value;
                rbAppDirectory.Checked = true;
                //OnRadioChange(rbAppDirectory, null);
            }
        }

        private void TypeSelector_Load(object sender, EventArgs e)
        {
            this.OnRadioChange(sender, e);
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
            FileInfo[] files = directoryInfo.GetFiles("*.dll");
            cbAssemblies.Items.Clear();

            foreach (FileInfo file in files)
            {
                try
                {
                    Assembly asm = Assembly.LoadFile(file.FullName);
                    cbAssemblies.Items.Add(asm.FullName);
                }
                catch
                {
                    continue;
                }
            }

            if (cbAssemblies.Items.Count > 0)
                cbAssemblies.SelectedIndex = 0;

            
        }

        private void cbAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.Load(cbAssemblies.SelectedItem.ToString());
            this.BindTreeView(assembly, superType__, attributeType__);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(openFileDialog.FileName);
                    this.BindTreeView(assembly, superType__, attributeType__);
                }
                catch
                {
                }
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
                btnOK.Enabled = true;
            else
                btnOK.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode selected = treeView.SelectedNode;
            if (selected != null && selected.Tag != null)
                selectedType__ = (Type)selected.Tag;
            else
                selectedType__ = null;
        }


    }
}
