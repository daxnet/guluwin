using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Common.Patterns.ExtendableMDI.Attributes;

namespace SunnyChen.Common.Patterns.ExtendableMDI
{
    /// <summary>
    /// Base form of the main form for the MDI application.
    /// </summary>
    /// <remarks>
    /// <para>The main form of a MDI application should derive from MainFormBase. MainFormBase 
    /// class provides the central control of the MDI children in it. These operations include: 
    /// updating of the control elements on the main form, displaying of the processing result 
    /// which might be called within the child form, and the ability of calling the action handler 
    /// on its activated MDI child.</para>
    /// <para>For the example of MainFormBase please refer to <see cref="SunnyChen.Common.Patterns.ExtendableMDI.Attributes.ActionAttribute"/>. </para>
    /// </remarks>
    /// <seealso cref="SunnyChen.Common.Patterns.ExtendableMDI.Attributes.ActionAttribute"/>
    /// <seealso cref="SunnyChen.Common.Patterns.ExtendableMDI.MDIChildBase&lt;T&gt;"/>
    public partial class MainFormBase : Form
    {
        #region Constructors
        /// <summary>
        /// Default constructor, it act as the same as the constructor of <see cref="System.Windows.Forms.Form"/> class.
        /// </summary>
        public MainFormBase()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Updates the control elements on the main form.
        /// </summary>
        /// <remarks>For the MDI children forms that inherits from the <see cref="SunnyChen.Common.Patterns.ExtendableMDI.MDIChildBase&lt;T&gt;"/> 
        /// base class, it will call UpdateElements method after they have changed the action properties. This ensures that the control elements on 
        /// the MDI main form is properly updated once the action properties have been changed in the MDI children.</remarks>
        /// <example>
        /// For the example please refer to <see cref="SunnyChen.Common.Patterns.ExtendableMDI.Attributes.ActionAttribute"/>.
        /// </example>
        public virtual void UpdateElements() { }
        /// <summary>
        /// Displays the processing result on the main form.
        /// </summary>
        /// <param name="_result">The result which is going to be displayed.</param>
        [Obsolete("This method is obsolete, please use the event handling mechanism to display results on the main form. For more information please refer to the Observer[GoF95] pattern.")]
        public virtual void DisplayResults(object _result) { }
        /// <summary>
        /// Invokes a specific action on the activated MDI child.
        /// </summary>
        /// <typeparam name="T">The type of the main form.</typeparam>
        /// <typeparam name="U">The type of the action attribute. In the MDI children classes, 
        /// this action attribute identifies the method that performs the specific action.</typeparam>
        public virtual void InvokeAction<T, U>() where T : MainFormBase where U : ActionAttribute
        {
            Form activeChild = this.ActiveMdiChild;
            bool invoked = false;
            if (activeChild != null)
            {
                if (activeChild is MDIChildBase<T>)
                {
                    Type activeChildType = activeChild.GetType();
                    foreach (MethodInfo method in activeChildType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
                    {
                        invoked = false;
                        object[] custAttributes = method.GetCustomAttributes(true);
                        foreach (object attr in custAttributes)
                        {
                            if (attr is U)
                            {
                                method.Invoke(activeChild, null);
                                invoked = true;
                                break;
                            }
                        }
                        if (invoked)
                            break;
                    }
                }
            }
        }

        #endregion

        #region Event Handlers
        private void MainFormBase_MdiChildActivate(object sender, EventArgs e)
        {
            this.UpdateElements();
        }
        #endregion

    }
}
