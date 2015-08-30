using System;
using System.Drawing;
using System.Windows.Forms;
using SunnyChen.Common.Windows.Forms;
using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Gulus.Properties;

namespace SunnyChen.Gulu.Gulus.Statistics.FileList
{
    // Comment out the GuluAttribute to hide the gulu since it is not completed yet.
    //[Gulu]
    public class Gulu : GuluBase
    {
        public override bool Init()
        {
            return true;
        }

        public override bool Done()
        {
            return true;
        }

        public override bool BackupRequired
        {
            get { return false; }
        }

        public override string Name
        {
            get { return Resources.FLG_NAME; }
        }

        public override string Category
        {
            get { return Resources.FLG_CATEGORY; }
        }

        public override string Description
        {
            get { return Resources.FLG_DESCRIPTION; }
        }

        public override DateTime CreatedDate
        {
            get
            {
                DateTime date = DateTime.Today;
                DateTime.TryParse("6/5/2008", out date);
                return date;
            }
        }

        public override string Author
        {
            get { return Resources.AUTHOR_NAME; }
        }

        public override string Version
        {
            get { return "1.0"; }
        }

        public override string Company
        {
            get { return Resources.COMPANY_NAME; }
        }

        public override string Copyright
        {
            get { return Resources.COPYRIGHT; }
        }

        public override Bitmap Image
        {
            get { return Resources.BMP_FILELIST; }
        }

        public override bool Execute(string _param)
        {
            return true;
        }
    }
}
