using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

using SunnyChen.Gulu.Environment;

namespace SunnyChen.Gulu.Filters
{
    /// <summary>
    /// Base class for the filter settings.
    /// </summary>
    /// <example>
    /// For the example please refer to <see cref="SunnyChen.Gulu.Filters.FilterBase"/>.
    /// </example>
    [Serializable]
    public abstract class FilterSettingsBase
    {
        /// <summary>
        /// Name of the file that stores the filter settings.
        /// </summary>
        protected string fileName__ = string.Empty;
        /// <summary>
        /// Default constructor that initializes the settings file name.
        /// </summary>
        public FilterSettingsBase()
        {
            //string path = Path.Combine(Application.StartupPath, FilterManager.FILTER_SETTINGS_PATH);
            string path = Directories.SettingsPath;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch
                {
                    throw;
                }
            }

            fileName__ = string.Format("{0}.flt", this.GetType().Name);
            fileName__ = Path.Combine(path, fileName__);
        }

        /// <summary>
        /// The constructor for serialization/deserialization.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        public FilterSettingsBase(SerializationInfo info, StreamingContext context)
        {
            
        }
        /// <summary>
        /// Gets the name of the file that stores filter settings.
        /// </summary>
        public string FileName
        {
            get { return fileName__; }
        }

        /// <summary>
        /// Saves the filter settings to a given file.
        /// </summary>
        /// <typeparam name="T">Indicates a type that is of or inherits from <see cref="SunnyChen.Gulu.Filters.FilterSettingsBase"/> and
        /// implements <see cref="System.SerializableAttribute"/> interface.</typeparam>
        /// <param name="_fileName">Name of the file to which the filter settings are stored.</param>
        /// <param name="_object">The settings object that is going to be saved.</param>
        public static void SaveSettings<T>(string _fileName, T _object) where T : FilterSettingsBase, ISerializable, new()
        {
            try
            {
                Stream stream = File.Open(_fileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _object);
                stream.Close();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the filter settings from a given file.
        /// </summary>
        /// <typeparam name="T">Indicates a type that is of or inherits from <see cref="SunnyChen.Gulu.Filters.FilterSettingsBase"/> and
        /// implements <see cref="System.SerializableAttribute"/> interface.</typeparam>
        /// <param name="_fileName">Name of the file from which the filter settings are being read.</param>
        /// <returns>The settings object.</returns>
        /// <remarks>If it failed while loading, a new instance of the settings class will be created and returned.</remarks>
        public static T LoadSettings<T>(string _fileName) where T : FilterSettingsBase, ISerializable, new()
        {
            try
            {
                if (!File.Exists(_fileName))
                {
                    return new T();
                }
                T obj;
                Stream stream = File.Open(_fileName, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                
                obj = (T)formatter.Deserialize(stream);

                stream.Close();
                return obj;
            }
            catch
            {
                return new T();
            }
        }
    }
}
