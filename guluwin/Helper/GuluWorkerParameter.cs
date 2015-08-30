using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Gulu.Win.Configuration;
using SunnyChen.Gulu.Gulus;


namespace SunnyChen.Gulu.Win.Helper
{
    /// <summary>
    /// 
    /// </summary>
    internal class GuluWorkerParameter
    {
        private GuluBase gulu__;
        private IList<ListViewItem> items__;
        /* Sunny Chen Added 2008/07/01 --> */
        private ConfigReader configReader__;
        /* Sunny Chen Added 2008/07/01 <-- */

        public GuluWorkerParameter(GuluBase _gulu, IList<ListViewItem> _items
            /* Sunny Chen Added 2008/07/01 --> */
            , ConfigReader _configReader
            /* Sunny Chen Added 2008/07/01 <-- */
            )
        {
            gulu__ = _gulu;
            items__ = _items;
            /* Sunny Chen Added 2008/07/01 --> */
            configReader__ = _configReader;
            /* Sunny Chen Added 2008/07/01 <-- */
        }

        public GuluBase Gulu
        {
            get { return gulu__; }
        }

        public IList<ListViewItem> Items
        {
            get { return items__; }
        }

        /* Sunny Chen Added 2008/07/01 --> */
        public ConfigReader ConfigurationReader
        {
            get { return configReader__; }
        }
        /* Sunny Chen Added 2008/07/01 <-- */
    }
}
