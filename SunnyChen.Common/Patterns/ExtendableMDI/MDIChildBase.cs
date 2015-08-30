using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Common.Patterns.ExtendableMDI
{
    /// <summary>
    /// The base class for the MDI children.
    /// </summary>
    /// <typeparam name="T">The type of the MDI parent (main form).</typeparam>
    public partial class MDIChildBase<T> : Form where T : MainFormBase
    {
        /// <summary>
        /// The instance of the MDI parent.
        /// </summary>
        protected T parent__;

        #region Constructors
        /// <summary>
        /// The default constructor. It acts the same as the default constructor of <see cref="System.Windows.Forms.Form"/> type.
        /// </summary>
        public MDIChildBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The constructor that initializes the form components and assigns the main form of MDI application.
        /// </summary>
        /// <param name="_form"></param>
        public MDIChildBase(T _form)
        {
            InitializeComponent();
            parent__ = _form;
            this.MdiParent = _form;
        }
        #endregion

        private bool canNew__ = false;
        /// <summary>
        /// Gets or sets the value which determines if the New action could be invoked.
        /// </summary>
        public virtual bool CanNew
        {
            get { return canNew__; }
            set { canNew__ = value; parent__.UpdateElements(); }
        }

        private bool canOpen__ = false;
        /// <summary>
        /// Gets or sets the value which determines if the Open action could be invoked.
        /// </summary>
        public virtual bool CanOpen
        {
            get { return canOpen__; }
            set { canOpen__ = value; parent__.UpdateElements(); }
        }

        private bool canSave__ = false;
        /// <summary>
        /// Gets or sets the value which determines if the Save action could be invoked.
        /// </summary>
        public virtual bool CanSave
        {
            get { return canSave__; }
            set { canSave__ = value; parent__.UpdateElements(); }
        }

    }
}
