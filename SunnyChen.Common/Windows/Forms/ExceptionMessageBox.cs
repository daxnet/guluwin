using System;
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
    /// The exception message box which shows exception and inner exception messages
    /// with a friendly user interface.
    /// </summary>
    public partial class ExceptionMessageBox : Form
    {
        /// <summary>
        /// Default constructor that initializes the form by default parameters.
        /// </summary>
        public ExceptionMessageBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Displays the exception message box by filling the specified exception message
        /// into the form in a detailed manner.
        /// </summary>
        /// <param name="_ex">The exception of which the message should be shown on the form.</param>
        /// <returns>The dialog result of the message box.</returns>
        public static DialogResult ShowDialog(Exception _ex)
        {
            return ShowDialog(_ex, false);
        }

        /// <summary>
        /// Displays the exception message box by filling the specified exception message
        /// into the form.
        /// </summary>
        /// <param name="_ex">The exception of which the message should be shown on the form.</param>
        /// <param name="_showSimple">Determines if it should show a detailed information. True for simple style, whereas false for the detailed style.</param>
        /// <returns>The dialog result of the message box.</returns>
        public static DialogResult ShowDialog(Exception _ex, bool _showSimple)
        {
            if (_ex != null)
            {
                ExceptionMessageBox messageBox = new ExceptionMessageBox();
                messageBox.txtMessage.Text = _ex.Message;
                if (_showSimple)
                {
                    messageBox.detailGrid.SelectedObject = new SimpleExceptionMessage(_ex);
                }
                else
                {
                    messageBox.detailGrid.SelectedObject = _ex;
                }
                return messageBox.ShowDialog();
            }
            return DialogResult.Cancel;
        }
    }

    internal class SimpleExceptionMessage
    {
        private string message__ = string.Empty;
        private string stackTrace__ = string.Empty;
        private MethodBase targetSite__ = null;

        public SimpleExceptionMessage(string _message, string _stackTrace, MethodBase _targetSite)
        {
            message__ = _message;
            stackTrace__ = _stackTrace;
            targetSite__ = _targetSite;
        }

        public SimpleExceptionMessage(Exception _ex)
        {
            message__ = _ex.Message;
            stackTrace__ = _ex.StackTrace;
            targetSite__ = _ex.TargetSite;
        }
        
        [ReadOnly(true)]
        public string Message
        {
            get { return message__; }
            set { message__ = value; }
        }

        [ReadOnly(true)]
        public string StackTrace
        {
            get { return stackTrace__; }
            set { stackTrace__ = value; }
        }

        [ReadOnly(true)]
        public MethodBase TargetSite
        {
            get { return targetSite__; }
            set { targetSite__ = value; }
        }
    }
}
