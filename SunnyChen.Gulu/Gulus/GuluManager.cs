using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Common.Plugins;
using SunnyChen.Gulu.Environment;

namespace SunnyChen.Gulu.Gulus
{
    /// <summary>
    /// Provides management routines for Gulus.
    /// </summary>
    [Serializable]
    public class GuluManager : PluginManager<string, GuluAttribute>
    {
        private string enablingFileName__ = string.Empty;
        /// <summary>
        /// Default constructor that initializes the file names.
        /// </summary>
        public GuluManager()
        {
            enablingFileName__ = Path.Combine(Directories.GuluPath, @"gulus.xml");
        }
        /// <summary>
        /// Gets the name of file that is used for storing the enabling list of Gulus.
        /// </summary>
        protected override string EnablingFileName
        {
            get { return enablingFileName__; }
        }
        /// <summary>
        /// Gets the list of Gulus.
        /// </summary>
        public IList<GuluBase> Gulus
        {
            get
            {
                IList<GuluBase> gulus = new List<GuluBase>();
                gulus.Clear();
                foreach (GuluBase gulu in items__)
                {
                    gulus.Add(gulu);
                }
                return gulus;
            }
        }
    }
}
