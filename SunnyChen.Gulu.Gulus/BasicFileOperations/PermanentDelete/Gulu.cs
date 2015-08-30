/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/11/2008
 * 
 * The Permanent Delete Gulu
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Gulus.Properties;

namespace SunnyChen.Gulu.Gulus.BasicFileOperations.PermanentDelete
{
    /// <summary>
    /// The permanent delete gulu is used for deleting files permanently.
    /// Before the action is going to be taken, a dialog box will appear
    /// to let user input "OK" so that the deleting operation is absolutely
    /// confirmed. This is because that the operation doesn't require the
    /// backup of the original files and this operation cannot be rollback.
    /// </summary>
    [Gulu]
    public sealed class Gulu : GuluBase
    {
        #region Private Fields
        /// <summary>
        /// Size of the filling block, here we use 100KB for standard.
        /// </summary>
        private const int BlockSize = 102400;
        /// <summary>
        /// A block of zero bytes, with the fixed length specified by
        /// BlockSize.
        /// </summary>
        private char[] block__ = new char[BlockSize];
        /// <summary>
        /// Number of blocks that we should fill into the file, it depends
        /// on the length of the file.
        /// </summary>
        private long numOfBlocks__;
        /// <summary>
        /// Remaining bytes that should be filled into the file.
        /// </summary>
        private long remaining__;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor. Initializes the zero-value block.
        /// </summary>
        public Gulu()
        {
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            Array.Clear(block__, 0, BlockSize);
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the name of the Gulu.
        /// </summary>
        public override string Name
        {
            get { return Resources.PDG_NAME; }
        }
        /// <summary>
        /// Gets the category of the Gulu.
        /// </summary>
        public override string Category
        {
            get { return Resources.PDG_CATEGORY; }
        }
        /// <summary>
        /// Gets the description of the Gulu.
        /// </summary>
        public override string Description
        {
            get { return Resources.PDG_DESCRIPTION; }
        }
        /// <summary>
        /// Gets the day on which the Gulu was created.
        /// </summary>
        public override DateTime CreatedDate
        {
            get 
            {
                DateTime date = DateTime.Now;
                DateTime.TryParse("5/27/2008", out date);
                return date;
            }
        }
        /// <summary>
        /// Gets the author of the Gulu.
        /// </summary>
        public override string Author
        {
            get { return Resources.AUTHOR_NAME; }
        }
        /// <summary>
        /// Gets the version of the Gulu.
        /// </summary>
        public override string Version
        {
            get { return "1.0"; }
        }
        /// <summary>
        /// Gets the company of the Gulu.
        /// </summary>
        public override string Company
        {
            get { return Resources.COMPANY_NAME; }
        }
        /// <summary>
        /// Gets the copyright information of the Gulu.
        /// </summary>
        public override string Copyright
        {
            get { return Resources.COPYRIGHT; }
        }
        /// <summary>
        /// Gets the documentation of the Gulu, which will be used in
        /// Dynamic Help.
        /// </summary>
        public override string Documentation
        {
            get
            {
                return Resources.PDG_DOCUMENT;
            }
        }
        /// <summary>
        /// Gets the image of the Gulu.
        /// </summary>
        public override Bitmap Image
        {
            get { return Resources.BMP_DELETE; }
        }
        /// <summary>
        /// Gets a value that indicates if the files should have a backup
        /// before any action has been taken.
        /// </summary>
        public override bool BackupRequired
        {
            get { return false; }
        }

        #endregion

        #region Public Overrided Methods
        /// <summary>
        /// Initializes the Gulu.
        /// </summary>
        /// <returns>True if succeed. False if it failed, in this case the
        /// operation will be canceled.</returns>
        public override bool Init()
        {
            string ok = StringInputBox.GetInputString(
                Resources.TEXT_INPUT_OK_TEXT, 
                Resources.TEXT_INPUT_OK_TITLE, 
                CharacterCasing.Upper);

            if (ok.Trim().ToUpper().Equals("OK"))
                return true;
            return false;
        }
        /// <summary>
        /// Running logic of the Gulu.
        /// </summary>
        /// <param name="_param">The filename that is going to be processed.</param>
        /// <returns>True if succeed. False if it failed.</returns>
        public override bool Execute(string _param)
        {
            try
            {
                Output.Add(string.Format(Resources.TEXT_PROCESSING, _param));
                FileStream fileStream = File.OpenWrite(_param);
                StreamWriter writer = new StreamWriter(fileStream);
                numOfBlocks__ = fileStream.Length / BlockSize;
                remaining__ = fileStream.Length % BlockSize;
                for (long i = 0; i < numOfBlocks__; i++)
                {
                    writer.Write(block__);
                }
                if (remaining__ > 0)
                {
                    char[] remainingBlock = new char[remaining__];
                    Array.Clear(remainingBlock, 0, (int)remaining__);
                    writer.Write(remainingBlock);
                }
                writer.Flush();
                writer.Close();
                fileStream.Close();
                File.Delete(_param);
                return true;
            }
            catch (Exception ex)
            {
                Output.Add(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Finializes the Gulu.
        /// </summary>
        /// <returns>True if succeed. False if it failed.</returns>
        public override bool Done()
        {
            return true;
        }
        #endregion
    }
}
