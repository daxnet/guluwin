using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Common.Windows.Forms
{
    /// <summary>
    /// Provides the user interface of editing the properties of a given object.
    /// </summary>
    public partial class PropertyEditor : Form
    {
        /// <summary>
        /// Default constructor that initailzes the components by default.
        /// </summary>
        public PropertyEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the object on which the properties should be shown or modified.
        /// </summary>
        public object SelectedObject
        {
            get { return propertyGrid.SelectedObject; }
            set { propertyGrid.SelectedObject = value; }
        }

        /// <summary>
        /// Opens the property editor.
        /// </summary>
        /// <param name="_text">The description text that will be shown on the screen.</param>
        /// <param name="_selected">The object on which the properties should be shown or modified.</param>
        /// <returns>The dialog result of the property editor.</returns>
        public static DialogResult ShowModal(string _text, object _selected)
        {
            PropertyEditor frmPropertyEditor = new PropertyEditor();
            
            frmPropertyEditor.Text = _text;
            frmPropertyEditor.SelectedObject = _selected;

            return frmPropertyEditor.ShowDialog();
        }

        /// <summary>
        /// Opens the property editor in a MDI container.
        /// </summary>
        /// <param name="_parent">The MDI parent window.</param>
        /// <param name="_text">The description text that will be shown on the screen.</param>
        /// <param name="_selected">The object on which the properties should be shown or modified.</param>
        public static void ShowInMDI(Form _parent, string _text, object _selected)
        {
            PropertyEditor frmPropertyEditor = new PropertyEditor();

            frmPropertyEditor.MdiParent = _parent;
            frmPropertyEditor.Text = _text;

            frmPropertyEditor.SelectedObject = _selected;


            frmPropertyEditor.Show();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
