
namespace SunnyChen.Common
{
    /// <summary>
    /// Common constant definitions. These definitions includes static readonly fields and constant fields.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Constant defined for hand shaking in network communication.
        /// </summary>
        public static readonly string HAND_SHAKE = "HAND_SHAKE";

        /// <summary>
        /// The default separator character that can and might be used by many programs as a string
        /// splitter. 
        /// </summary>
        public const char DEFAULT_SEP_CHAR = ',';

        /// <summary>
        /// <para>The default separator character that can and might be used by many programs as a command
        /// splitter. Currently it is used by the <see cref="SunnyChen.Common.Servers"/>.</para>
        /// </summary>
        /// <example>
        /// Following is an example.
        /// <code>
        /// string[] splitted = source.Split(DEFAULT_CMD_SEP_CHAR);
        /// </code>
        /// </example>
        public const char DEFAULT_CMD_SEP_CHAR = ' ';
    }
}
