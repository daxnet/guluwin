using System;
using System.Collections.Generic;
using System.Text;

using SunnyChen.Common.Plugins;

namespace SunnyChen.Gulu.Gulus
{
    /// <summary>
    /// The base type of Gulus.
    /// </summary>
    /// <example>
    /// Following example shows an implementation of a Gulu.
    /// <code>
    /// [Gulu]
    /// public class Gulu : GuluBase
    /// {
    ///     public override bool Init()
    ///     {
    ///         return true;
    ///     }
    /// 
    ///     public override bool Done()
    ///     {
    ///         return true;
    ///     }
    ///
    ///     public override bool BackupRequired
    ///     {
    ///         get { return false; }
    ///     }
    ///
    ///     public override string Name
    ///     {
    ///         get { return "File Parsing"; }
    ///     }
    ///
    ///     public override string Category
    ///     {
    ///         get { return "File Management"; }
    ///     }
    ///
    ///     public override string Description
    ///     {
    ///         get { return "The Gulu for file parsing."; }
    ///     }
    ///
    ///     public override DateTime CreatedDate
    ///     {
    ///         get
    ///         {
    ///             DateTime date = DateTime.Today;
    ///             DateTime.TryParse("6/5/2008", out date);
    ///             return date;
    ///         }
    ///     }
    ///
    ///     public override string Author
    ///     {
    ///         get { return "Sunny Chen"; }
    ///     }
    ///
    ///     public override string Version
    ///     {
    ///         get { return "1.0"; }
    ///     }
    ///
    ///     public override string Company
    ///     {
    ///         get { return "SunnyChen.ORG"; }
    ///     }
    ///
    ///     public override string Copyright
    ///     {
    ///         get { return "Copyright (C) 2007-2008, SunnyChen.ORG, all rights reserved."; }
    ///     }
    ///
    ///     public override Bitmap Image
    ///     {
    ///         get { return null; }
    ///     }
    ///
    ///     public override bool Execute(string _param)
    ///     {
    ///         // TODO: Place executing code here.
    ///         return true;
    ///     }
    /// }
    /// </code>
    /// </example>
    public abstract class GuluBase : PluginBase<string>
    {
        /// <summary>
        /// Gets the string that identifies each Gulu in the Gulu collection.
        /// </summary>
        public override string Identifier
        {
            get { return this.GetType().ToString(); }
        }
        /// <summary>
        /// Gets the documentation of the Gulu.
        /// </summary>
        /// <remarks>This documentation will be shown in the Dynamic Help.</remarks>
        public override string Documentation
        {
            get { return string.Empty; }
        }
        /// <summary>
        /// Initializes the Gulu which is going to run.
        /// </summary>
        /// <returns>True if successfully initialized, otherwise false.</returns>
        /// <remarks>The running of the Gulu will be cancelled once the initialization failed.</remarks>
        public abstract bool Init();
        /// <summary>
        /// Finalizes the Gulu which has been run.
        /// </summary>
        /// <returns>True if successfully finalized, otherwise false.</returns>
        public abstract bool Done();
        /// <summary>
        /// Gets a value indicating if the Gulu requires a backup of the file before it is going to process the file.
        /// </summary>
        public abstract bool BackupRequired { get; }
        
    }
}
