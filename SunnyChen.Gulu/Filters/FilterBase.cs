using System.Windows.Forms;

using SunnyChen.Common.Patterns;
using SunnyChen.Common.Plugins;

namespace SunnyChen.Gulu.Filters
{
    /// <summary>
    /// The base type of Gulu filters.
    /// </summary>
    /// <remarks>
    /// <para>All filters should inherit from this base class, otherwise it cannot be handled by the Filter Manager.</para>
    /// <para>
    /// Beside the filter has been implemented, a filter setting instance and user control should be associated with
    /// the filter. This makes the application have the ability of managing filter settings.
    /// </para>
    /// </remarks>
    /// <example>
    /// Following example created a file filter that takes the file size into account. In this example, the
    /// filter setting and user control for settings are also be implemented.
    /// <para>Code below is the implementation of the filter settings.</para>
    /// <code>
    /// [Serializable]
    /// public sealed class FileSizeFilterSettings : FilterSettingsBase, ISerializable
    /// {
    ///     public enum SizeUnit
    ///     {
    ///         KB,
    ///         MB,
    ///         GB,
    ///         TB
    ///     }
    ///     
    ///     private int minimalSize__ = 0;
    ///     private int maximalSize__ = 0;
    ///     private SizeUnit unit__ = SizeUnit.KB;    
    /// 
    ///     public FileSizeFilterSettings()
    ///        : base()
    ///     {
    ///     }
    ///
    ///     public FileSizeFilterSettings(SerializationInfo info, StreamingContext context)
    ///        : base(info, context)
    ///     {
    ///         minimalSize__ = info.GetInt32("MinimalSize");
    ///         maximalSize__ = info.GetInt32("MaximalSize");
    ///         unit__ = (SizeUnit)info.GetInt32("SizeUnit");
    ///     }
    ///     
    ///     public SizeUnit Unit
    ///     {
    ///         get { return unit__; }
    ///         set { unit__ = value; }
    ///     }
    ///
    ///     public int MinimalSize
    ///     {
    ///         get { return minimalSize__; }
    ///         set { minimalSize__ = value; }
    ///     }
    ///
    ///     public int MaximalSize
    ///     {
    ///         get { return maximalSize__; }
    ///         set { maximalSize__ = value; }
    ///     }
    /// 
    ///     #region ISerializable Members
    ///
    ///     public void GetObjectData(SerializationInfo info, StreamingContext context)
    ///     {
    ///         info.AddValue("MinimalSize", minimalSize__);
    ///         info.AddValue("MaximalSize", maximalSize__);
    ///         info.AddValue("SizeUnit", Convert.ToInt32(unit__));
    ///     }
    ///
    ///     #endregion
    /// }
    /// </code>
    /// <para>Code below is the implementation of the filter settings user control.</para>
    /// <code>
    /// public partial class FileSizeFilterSettingsControl : UserControl, ISettingsPersistable
    /// {
    ///     public FileSizeFilterSettingsControl()
    ///     {
    ///         InitializeComponent();
    ///     }
    ///
    ///     #region ISettingsPersistable Members
    /// 
    ///     public void PersistSettings()
    ///     {
    ///         FileSizeFilterSettings settings = new FileSizeFilterSettings();
    ///        
    ///         int maxSize = 0;
    ///         if (!int.TryParse(txtTo.Text, out maxSize))
    ///             txtTo.Text = "0";
    ///         
    ///         int minSize = 0;
    ///         if (!int.TryParse(txtFrom.Text, out minSize))
    ///             txtFrom.Text = "0";
    ///
    ///         settings.MaximalSize = maxSize;
    ///         settings.MinimalSize = minSize;
    ///         settings.Unit = (FileSizeFilterSettings.SizeUnit)cbSizeUnit.SelectedIndex;
    ///
    ///         FilterSettingsBase.SaveSettings&lt;FileSizeFilterSettings&gt;(settings.FileName, settings);
    ///     }
    ///
    ///     public void MaterializeSettings()
    ///     {
    ///         FileSizeFilterSettings settings = new FileSizeFilterSettings();
    ///         settings = FilterSettingsBase.LoadSettings&lt;FileSizeFilterSettings&gt;(settings.FileName);
    ///
    ///         txtFrom.Text = settings.MinimalSize.ToString();
    ///         txtTo.Text = settings.MaximalSize.ToString();
    ///         cbSizeUnit.SelectedIndex = Convert.ToInt32(settings.Unit);
    ///     }
    ///
    ///     public bool ValidateSettings()
    ///     {
    ///         int maxSize = 0;
    ///         if (!int.TryParse(txtTo.Text, out maxSize))
    ///             txtTo.Text = "0";
    ///
    ///         int minSize = 0;
    ///         if (!int.TryParse(txtFrom.Text, out minSize))
    ///             txtFrom.Text = "0";
    ///
    ///         if (maxSize &lt; minSize)
    ///             throw new InvalidSettingValueException("Invalid argument.");
    ///
    ///         return true;
    ///     }
    ///     #endregion
    ///
    /// }
    /// </code>
    /// <para>Code below is the implementation of the filter.</para>
    /// <code>
    /// [Filter]
    /// public sealed class FileSizeFilter : FilterBase
    /// {
    ///     private FileSizeFilterSettings settings__ = new FileSizeFilterSettings();
    ///
    ///     public FileSizeFilter()
    ///     {
    ///         settings__ = FilterSettingsBase.LoadSettings&lt;FileSizeFilterSettings&gt;(settings__.FileName);
    ///     }
    ///
    ///     public override UserControl GetSettingsControl()
    ///     {
    ///         UserControl settingsControl = this.GetSettingsControl&lt;FileSizeFilterSettingsControl&gt;();
    ///         settingsControl.Dock = DockStyle.Fill;
    ///         return settingsControl;
    ///     }
    ///
    ///     public override string Name
    ///     {
    ///         get { return "File Size Filter"; }
    ///     }
    ///
    ///     public override string Description
    ///     {
    ///         get { return "This is the filter for file size."; }
    ///     }
    ///
    ///     public override DateTime CreatedDate
    ///     {
    ///         get
    ///         {
    ///             DateTime d = DateTime.Now;
    ///             DateTime.TryParse("5/29/2008", out d);
    ///             return d;
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
    ///         get { return "Copyright (C) 2007-2008, SunnyChen.ORG. All rights reserved."; }
    ///     }
    ///
    ///     public override System.Drawing.Bitmap Image
    ///     {
    ///         get { return null; }
    ///     }
    /// 
    ///     public override bool Execute(string _param)
    ///     {
    ///         Int64 min, max;
    ///
    ///         switch (settings__.Unit)
    ///         {
    ///             case FileSizeFilterSettings.SizeUnit.KB:
    ///                 min = settings__.MinimalSize * 1024;
    ///                 max = settings__.MaximalSize * 1024;
    ///                 break;
    ///             case FileSizeFilterSettings.SizeUnit.MB:
    ///                 min = settings__.MinimalSize * 1024 * 1024;
    ///                 max = settings__.MaximalSize * 1024 * 1024;
    ///                 break;
    ///             case FileSizeFilterSettings.SizeUnit.GB:
    ///                 min = settings__.MinimalSize * 1024 * 1024 * 1024;
    ///                 max = settings__.MaximalSize * 1024 * 1024 * 1024;
    ///                 break;
    ///             case FileSizeFilterSettings.SizeUnit.TB:
    ///                 min = settings__.MinimalSize * 1024 * 1024 * 1024 * 1024;
    ///                 max = settings__.MaximalSize * 1024 * 1024 * 1024 * 1024;
    ///                 break;
    ///             default:
    ///                 return true;
    ///         }
    ///         if (min == 0 &amp;&amp; max == 0)
    ///         {
    ///             return true;
    ///         }
    ///         Int64 fs = new FileInfo(_param).Length;
    ///         return (fs &gt;= min &amp;&amp; fs &lt;= max);
    ///    }
    /// }
    /// </code>
    /// </example>
    public abstract class FilterBase : PluginBase<string>
    {
        /// <summary>
        /// The default constructor that initializes the Filter.
        /// </summary>
        public FilterBase() : base()
        {
        }

        /// <summary>
        /// Gets a <see cref="System.Windows.Forms.UserControl"/> instance that provides the user
        /// interface for the filter settings.
        /// </summary>
        /// <typeparam name="T">Indicates a type that inherits from <see cref="System.Windows.Forms.UserControl"/>
        /// and implements <see cref="SunnyChen.Gulu.Filters.ISettingsPersistable"/> interface.</typeparam>
        /// <returns>The user control that provides the user interface for the filter settings.</returns>
        protected T GetSettingsControl<T>() where T : UserControl, ISettingsPersistable, new()
        {
            return SingletonGeneric<T>.Instance;
        }

        /// <summary>
        /// Gets the string that identifies each filter in the filter collection.
        /// </summary>
        public override string Identifier
        {
            get { return this.GetType().Name; }
        }
        /// <summary>
        /// Gets the category of the filter.
        /// </summary>
        public override string Category
        {
            get { return "Filters"; }
        }
        /// <summary>
        /// Gets the documentation of the filter.
        /// </summary>
        /// <remarks>This documentation will be shown in the Dynamic Help.</remarks>
        public override string Documentation
        {
            get { return string.Empty; }
        }
        /// <summary>
        /// Gets the user control that provides the filter settings.
        /// </summary>
        /// <returns>The user control.</returns>
        public abstract UserControl GetSettingsControl();

    }
}
