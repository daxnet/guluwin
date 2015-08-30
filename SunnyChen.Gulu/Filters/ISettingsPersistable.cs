
namespace SunnyChen.Gulu.Filters
{
    /// <summary>
    /// Defines the methods that are used for saving, loading and validating the settings.
    /// </summary>
    public interface ISettingsPersistable
    {
        /// <summary>
        /// Persists (Saves) the settings to a file.
        /// </summary>
        void PersistSettings();
        /// <summary>
        /// Materializes (Loads) the settings from a file.
        /// </summary>
        void MaterializeSettings();
        /// <summary>
        /// Validating the settings.
        /// </summary>
        /// <returns>True if the settings are valid. Otherwise, an <see cref="SunnyChen.Gulu.InvalidSettingValueException"/> exception will be thrown and false will be returned.</returns>
        bool ValidateSettings();
    }
}
