using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SunnyChen.Common.Patterns
{
    /// <summary>
    /// Changes the cursor on the screen to <see cref="System.Windows.Forms.Cursors.WaitCursor"/> before a lengthy operation starts, and 
    /// changes the cursor back to the default after the operation finishes.
    /// </summary>
    /// <remarks>
    /// <para>The Lengthy Operation pattern can only be used on a Windows Forms UI context. It requires
    /// the caller form as an instance when it goes to change the cursor on the form.</para>
    /// <para>The Lengthy Operation pattern is based on the Scoped Locking pattern. This class implements
    /// the <see cref="System.IDisposable"/> interface so that the Cursor will be changed when the instance is being created 
    /// and changed back when the instance is being disposed.</para>
    /// <para>Other classes can extend this class so that specific resources could be allocated when constructing the 
    /// class instance and cleaned up when the instance is being destroyed.</para>
    /// </remarks>
    /// <example>
    /// Following example shows how to use the LengthyOperation class when the user clicks a button on the form.
    /// <code>
    /// private void button1_Click(object sender, System.EventArgs e)
    /// {
    ///     using (new LengthOperation(this))
    ///     {
    ///         // Place your code here. You can throw exceptions here or just exit the
    ///         // function directly.
    ///     }
    /// }
    /// </code>
    /// </example>
    public class LengthyOperation : IDisposable
    {
        private Form form__;

        /// <summary>
        /// The constructor which takes the instance of parent Windows Forms UI.
        /// </summary>
        /// <remarks>The cursor on the specified form will be changed to <see cref="System.Windows.Forms.Cursors.WaitCursor"/> once the instance is being constructed.</remarks>
        /// <param name="_form">The instance of the parent form.</param>
        public LengthyOperation(Form _form)
        {
            form__ = _form;
            form__.Cursor = Cursors.WaitCursor;
        }

        #region IDisposable Members
        /// <summary>
        /// Disposes the current instance and changes the cursor back to default.
        /// </summary>
        public void Dispose()
        {
            form__.Cursor = Cursors.Default;
        }

        #endregion
    }
}
