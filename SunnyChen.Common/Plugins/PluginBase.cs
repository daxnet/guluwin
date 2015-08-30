using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Plugins
{
    /// <summary>
    /// The base class of plug-ins.
    /// </summary>
    /// <typeparam name="T">The parameter type of the Execute method.</typeparam>
    public abstract class PluginBase<T>
    {
        #region Protected Fields
        /// <summary>
        /// Indicates if the plug-in is enabled.
        /// </summary>
        protected bool enabled__ = false;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PluginBase()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Indicates if the plug-in is enabled.
        /// </summary>
        public bool Enabled
        {
            get { return enabled__; }
            set { enabled__ = value; }
        }

        /// <summary>
        /// Gets the name of the plug-in.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the category of the plug-in.
        /// </summary>
        public abstract string Category { get; }

        /// <summary>
        /// Gets the description information of the plug-in.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Gets the created date information of the plug-in.
        /// </summary>
        public abstract DateTime CreatedDate { get; }

        /// <summary>
        /// Gets the author information of the plug-in.
        /// </summary>
        public abstract string Author { get; }

        /// <summary>
        /// Gets the version information of the plug-in.
        /// </summary>
        public abstract string Version { get; }

        /// <summary>
        /// Gets the company information of the plug-in.
        /// </summary>
        public abstract string Company { get; }

        /// <summary>
        /// Gets the copyright information of the plug-in.
        /// </summary>
        public abstract string Copyright { get; }

        /// <summary>
        /// Gets the bitmap image of the plug-in. This bitmap image can be used
        /// for displaying.
        /// </summary>
        public abstract Bitmap Image { get; }

        /// <summary>
        /// Gets the documentation which describes the current plug-in in more detail.
        /// </summary>
        public abstract string Documentation { get; }

        /// <summary>
        /// Gets the identifier of the plug-in, this property must be identical in the plug-in context.
        /// </summary>
        public abstract string Identifier { get; }

        #endregion

        #region Public Methods
        /// <summary>
        /// Executes the tasks defined by the plug-in.
        /// </summary>
        /// <param name="_param">The executing parameter.</param>
        /// <returns>True when successfully executed, otherwise false.</returns>
        public abstract bool Execute(T _param);

        #endregion

        /// <summary>
        /// Overrided from Object, get the simple signature of the plug-in
        /// </summary>
        /// <returns>The simple plug-in signature.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("Name={0}, ", Name));
            stringBuilder.Append(string.Format("Identifier={0}", Identifier));
            return stringBuilder.ToString();
        }

    }
}
