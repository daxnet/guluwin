using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SunnyChen.Common.Properties;

namespace SunnyChen.Common.Windows.Forms
{
    /// <summary>
    /// String input box with Regular Expression enhanced.
    /// </summary>
    public partial class StringInputBox : Form
    {
        #region Private Fields

        private Regex regEx__ = null;

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        public StringInputBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Gets the input string without regular expression checking.
        /// </summary>
        /// <param name="_text">Prompt text to be shown on the dialog.</param>
        /// <param name="_caption">The caption of the dialog.</param>
        /// <returns>The input string.</returns>
        public static string GetInputString(string _text, string _caption)
        {
            return GetInputString(_text, _caption, (Regex)null, CharacterCasing.Normal);
        }

        /// <summary>
        /// Gets the input string without regular expression checking.
        /// </summary>
        /// <param name="_text">Prompt text to be shown on the dialog.</param>
        /// <param name="_caption">The caption of the dialog.</param>
        /// <param name="_casing">The character casing.</param>
        /// <returns>The input string.</returns>
        public static string GetInputString(string _text, string _caption, CharacterCasing _casing)
        {
            return GetInputString(_text, _caption, (Regex)null, _casing);
        }

        /// <summary>
        /// Gets the input string with regular expression checking and character casing.
        /// </summary>
        /// <param name="_text">Prompt text to be shown on the dialog.</param>
        /// <param name="_caption">The caption of the dialog.</param>
        /// <param name="_regEx">The regular expression checking object.</param>
        /// <param name="_casing">The character casing.</param>
        /// <returns></returns>
        public static string GetInputString(string _text, string _caption, Regex _regEx, CharacterCasing _casing)
        {
            StringInputBox inputBox = new StringInputBox();
            inputBox.lblPrompt.Text = _text;
            inputBox.Text = _caption;
            inputBox.regEx__ = _regEx;
            inputBox.textBox1.CharacterCasing = _casing;

            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                return inputBox.textBox1.Text;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the input string with regular expression checking.
        /// </summary>
        /// <param name="_text">Prompt text to be shown on the dialog.</param>
        /// <param name="_caption">The caption of the dialog.</param>
        /// <param name="_regEx">The regular expression checking object.</param>
        /// <param name="_casing">The character casing.</param>
        /// <returns>The input string.</returns>
        public static string GetInputString(string _text, string _caption, Regex _regEx)
        {
            return GetInputString(_text, _caption, _regEx, CharacterCasing.Normal);
        }

        /// <summary>
        /// Gets the input string with regular expression checking.
        /// </summary>
        /// <param name="_text">Prompt text to be shown on the dialog.</param>
        /// <param name="_caption">The caption of the dialog.</param>
        /// <param name="_pattern">The regular expression pattern string.</param>
        /// <returns>The input string.</returns>
        public static string GetInputString(string _text, string _caption, string _pattern)
        {
            return GetInputString(_text, _caption, new Regex(_pattern), CharacterCasing.Normal);
        }

        /// <summary>
        /// Gets the input string with regular expression checking and character casing.
        /// </summary>
        /// <param name="_text">Prompt text to be shown on the dialog.</param>
        /// <param name="_caption">The caption of the dialog.</param>
        /// <param name="_pattern">The regular expression pattern string.</param>
        /// <param name="_casing">The character casing.</param>
        /// <returns>The input string.</returns>
        public static string GetInputString(string _text, string _caption, string _pattern, CharacterCasing _casing)
        {
            return GetInputString(_text, _caption, new Regex(_pattern), _casing);
        }

        #endregion

        #region Private Event Processing Procedures

        private void btnOK_Click(object sender, System.EventArgs e)
        {

            if (textBox1.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show(Resources.TEXT_PLEASE_INPUT_TEXT, 
                    Resources.TEXT_ERROR, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                this.DialogResult = DialogResult.None;
                textBox1.Focus();
                return;
            }

            if (regEx__ != null)
            {
                if (!regEx__.IsMatch(textBox1.Text))
                {
                    MessageBox.Show(Resources.TEXT_PATTERN_NOT_MATCH, 
                        Resources.TEXT_ERROR, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.None;
                    textBox1.SelectAll();
                    textBox1.Focus();
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;

        }

        #endregion

    }
}