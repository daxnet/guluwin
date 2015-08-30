
namespace SunnyChen.Common.Patterns
{
    /// <summary>
    /// Converts a given class to be a singleton.
    /// </summary>
    /// <typeparam name="T">The class type that is going to be converted.</typeparam>
    /// <remarks><para>This converting is not thread safe because it is impossible to declare a volatile member 
    /// on a generic type. To make a singleton thread safe please use the standard implementation of the Singleton pattern.</para>
    /// <para>There must be a public default constructor on the T type, otherwise it is impossible to create an instance 
    /// when the instance has not been created.</para>
    /// </remarks>
    public class SingletonGeneric<T> where T : new()
    {
        private static T instance__ = default(T);
        private static object syncRoot__ = new object();

        private SingletonGeneric()
        {
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance__ == null)
                {
                    lock (syncRoot__)
                    {
                        if (instance__ == null)
                        {
                            instance__ = new T();
                        }
                    }
                }
                return instance__;
            }
        }
    }
}
