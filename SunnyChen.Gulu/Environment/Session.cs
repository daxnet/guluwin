using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Common.Patterns.ExtendableMDI;
using SunnyChen.Gulu.Gulus;

namespace SunnyChen.Gulu.Environment
{
    /// <summary>
    /// Provides attributes for the gulu session.
    /// </summary>
    public class Session
    {
        #region Private Fields
        /// <summary>
        /// Determines if the parameters have been set.
        /// </summary>
        private static volatile bool hasSet__ = false;
        /// <summary>
        /// The singleton instance of the session.
        /// </summary>
        private static volatile Session instance__;
        /// <summary>
        /// Synchronized object.
        /// </summary>
        private static object syncRoot__ = new object();
        /// <summary>
        /// The starting date/time of the session.
        /// </summary>
        private DateTime startTime__ = DateTime.Now;
        /// <summary>
        /// Name of the session.
        /// </summary>
        private string sessionName__ = string.Empty;
        /// <summary>
        /// The MDI parent form.
        /// </summary>
        private MainFormBase parent__;
        /// <summary>
        /// The gulu that is going to run (Set by GuluRunner) or the gulu
        /// that has already run.
        /// </summary>
        private GuluBase gulu__ = null;
        /// <summary>
        /// The loaded gulus in the current session.
        /// </summary>
        private IList<GuluBase> loadedGulus__ = null;

        private Type compilerType__ = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Default private constructor, for singleton pattern.
        /// </summary>
        private Session() { }

        #endregion

        #region Public Methods
        /// <summary>
        /// Sets the parameter for the session.
        /// </summary>
        /// <param name="_sessionName">Name of the session.</param>
        /// <param name="_parent">The MDI parent form.</param>
        /// <param name="_compilerType">Type of the CodeDom compiler which is used for compiling the scripts.</param>
        /// <remarks>Calls this method when the Gulu program starts. DO NOT call it at anytime in any places of
        /// your program.</remarks>
        public void SetParameter(string _sessionName, MainFormBase _parent, Type _compilerType)
        {
            if (!hasSet__)
            {
                sessionName__ = _sessionName;
                parent__ = _parent;
                compilerType__ = _compilerType;
                hasSet__ = true;
            }
        }

        /// <summary>
        /// Sets the Gulu that is going to run.
        /// </summary>
        /// <param name="_gulu">The gulu for running.</param>
        /// <remarks>
        /// Calls this method just before a gulu is going to be run. DO NOT call it within your own program context.
        /// </remarks>
        public void SetGulu(GuluBase _gulu)
        {
            gulu__ = _gulu;
        }

        /// <summary>
        /// Sets a list of gulus that has been loaded by the application.
        /// </summary>
        /// <param name="_loadedGulus">The gulus loaded.</param>
        public void SetLoadedGulus(IList<GuluBase> _loadedGulus)
        {
            if (loadedGulus__ == null)
            {
                loadedGulus__ = _loadedGulus;
            }
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the instance of the session.
        /// </summary>
        public static Session CurrentSession
        {
            get
            {
                if (instance__ == null)
                {
                    lock (syncRoot__)
                    {
                        if (instance__ == null)
                        {
                            instance__ = new Session();
                        }
                    }
                }
                return instance__;
            }
        }

        /// <summary>
        /// Gets the name of the session.
        /// </summary>
        public string SessionName
        {
            get { return sessionName__; }
        }

        /// <summary>
        /// Gets the MDI parent of the session.
        /// </summary>
        public MainFormBase MDIParent
        {
            get { return parent__; }
        }

        /// <summary>
        /// Gets the elapsed time since the session is activated.
        /// </summary>
        public TimeSpan TimeElapsed
        {
            get { return DateTime.Now - startTime__; }
        }

        /// <summary>
        /// Gets the currently running or previous run gulu.
        /// </summary>
        public GuluBase Gulu
        {
            get { return gulu__; }
        }

        /// <summary>
        /// Gets the list of loaded gulus.
        /// </summary>
        public IList<GuluBase> LoadedGulus
        {
            get
            {
                return loadedGulus__;
            }
        }

        /// <summary>
        /// Gets the CodeDom compiler type that is currently used by the session.
        /// </summary>
        public Type CompilerType
        {
            get { return compilerType__; }
        }
        #endregion
    }
}
