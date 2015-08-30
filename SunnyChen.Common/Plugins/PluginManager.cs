using System;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Common.Properties;

namespace SunnyChen.Common.Plugins
{
    /// <summary>
    /// The plug-in manager class manages the plug-ins and maintains
    /// the enabling states for the plug-ins.
    /// </summary>
    /// <typeparam name="T">The type of parameter in the plug-in's Execute method.</typeparam>
    /// <typeparam name="U">The attribute type of the plug-in, it is always used to identify
    /// the type of the plug-in.</typeparam>
    [Serializable]
    public abstract class PluginManager<T, U> : ICollection<PluginBase<T>> where U : PluginAttribute
    {
        /// <summary>
        /// The plug-in items which are managed by the plgin manager.
        /// </summary>
        protected IList<PluginBase<T>> items__ = new List<PluginBase<T>>();
        /// <summary>
        /// The hash table that is used to store the enabling status for all the plug-ins loaded.
        /// </summary>
        protected Hashtable enablingHash__ = new Hashtable();

        /// <summary>
        /// Default constructor
        /// </summary>
        public PluginManager()
        {
        }

        /// <summary>
        /// The name of the file which is used to store the
        /// Enabled attribute of all the plug-ins.
        /// </summary>
        protected abstract string EnablingFileName
        {
            get;
        }

        /// <summary>
        /// Saves the Enabled attribute of all the plug-ins to the file.
        /// </summary>
        public virtual void SaveEnabling()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(this.EnablingFileName, Encoding.Unicode);

                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                writer.WriteStartDocument();

                writer.WriteComment("WARNING: DO NOT MODIFY THIS FILE MANUALLY!!!");

                writer.WriteStartElement("plugins");

                foreach (PluginBase<T> item in items__)
                {
                    writer.WriteStartElement("plugin");
                    writer.WriteAttributeString("identifier", item.Identifier);
                    writer.WriteElementString("enabled", item.Enabled.ToString());
                    writer.WriteElementString("name", item.Name);
                    writer.WriteElementString("author", item.Author);
                    writer.WriteElementString("version", item.Version);
                    writer.WriteElementString("date", item.CreatedDate.ToShortDateString());
                    writer.WriteElementString("company", item.Company);
                    writer.WriteElementString("copyright", item.Copyright);
                    writer.WriteElementString("description", item.Description);
                    writer.WriteElementString("category", item.Category);
                    writer.WriteElementString("type", item.GetType().ToString());
                    writer.WriteElementString("assembly", item.GetType().Assembly.FullName);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                throw new PluginException(Resources.EX_SAVE_ENABLING_FAILED, ex);
            }
        }

        /// <summary>
        /// Loads the Enabled attribute of all the plug-ins from the file.
        /// </summary>
        public virtual void LoadEnabling()
        {
            try
            {
                if (!File.Exists(this.EnablingFileName))
                    return;

                enablingHash__.Clear();

                XmlDocument document = new XmlDocument();
                document.Load(this.EnablingFileName);
                XmlNodeList nodeList = document.SelectNodes(@"/plugins/plugin");
                foreach (XmlNode node in nodeList)
                {
                    string curIdentifier = node.Attributes.GetNamedItem("identifier").Value;
                    bool curEnabled = Convert.ToBoolean(node.ChildNodes.Item(0).InnerText);
                    enablingHash__[curIdentifier] = curEnabled;
                }
            }
            catch (Exception ex)
            {
                throw new PluginException(Resources.EX_LOAD_ENABLING_FAILED, ex);
            }
        }

        /// <summary>
        /// Loads the plug-ins from the specific assembly.
        /// </summary>
        /// <param name="_assembly">The assembly which may contains the plug-ins.</param>
        /// <param name="_enabledForDefault">The default value if the plug-in is not found in the enabling list.</param>
        public virtual void Load(Assembly _assembly, bool _enabledForDefault)
        {
            try
            {
                Type[] types = _assembly.GetTypes();
                
                LoadEnabling();

                foreach (Type type in types)
                {
                    if (!type.IsSubclassOf(typeof(PluginBase<T>)))
                        continue;

                    object[] custAttributes = type.GetCustomAttributes(true);
                    foreach (object custAttr in custAttributes)
                    {
                        if (custAttr is U)
                        {
                            PluginBase<T> plugin = (PluginBase<T>)Activator.CreateInstance(type);
                            if (enablingHash__.Contains(plugin.Identifier))
                                plugin.Enabled = Convert.ToBoolean(enablingHash__[plugin.Identifier]);
                            else
                                plugin.Enabled = _enabledForDefault;
                            items__.Add(plugin);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PluginException("Failed to load plugin.", ex);
            }
        }

        /// <summary>
        /// Loads the plug-ins from the specific assembly.
        /// </summary>
        /// <param name="_assembly">The assembly which may contains the plug-ins.</param>
        public virtual void Load(Assembly _assembly)
        {
            try
            {
                this.Load(_assembly, false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the specific assembly which is identified by its name.
        /// </summary>
        /// <param name="_assemblyName">Name of the assembly.</param>
        /// <param name="_enabledForDefault">The default value if the plug-in is not found in the enabling list.</param>
        public virtual void Load(AssemblyName _assemblyName, bool _enabledForDefault)
        {
            try
            {
                Assembly assembly = Assembly.Load(_assemblyName);
                if (assembly != null)
                {
                    this.Load(assembly, _enabledForDefault);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the specific assembly which is identified by its name.
        /// </summary>
        /// <param name="_assemblyName">Name of the assembly.</param>
        public virtual void Load(AssemblyName _assemblyName)
        {
            try
            {
                this.Load(_assemblyName, false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the assemblies which is identified by a series of names.
        /// </summary>
        /// <param name="_assemblyNames">Names of the assemblies.</param>
        /// <param name="_enabledForDefault">The default value if the plug-in is not found in the enabling list.</param>
        public virtual void Load(AssemblyName[] _assemblyNames, bool _enabledForDefault)
        {
            try
            {
                foreach (AssemblyName name in _assemblyNames)
                {
                    this.Load(name, _enabledForDefault);
                }
            }
            catch
            { 
                throw; 
            }
        }

        /// <summary>
        /// Loads the plug-ins from the assemblies which is identified by a series of names.
        /// </summary>
        /// <param name="_assemblyNames">Names of the assemblies.</param>
        public virtual void Load(AssemblyName[] _assemblyNames)
        {
            try
            {
                this.Load(_assemblyNames, false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the specific assembly file.
        /// </summary>
        /// <param name="_assemblyFileName">The filename of the assembly in which the plug-ins may be contained.</param>
        /// <param name="_enabledForDefault">The default value if the plug-in is not found in the enabling list.</param>
        public virtual void Load(string _assemblyFileName, bool _enabledForDefault)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(_assemblyFileName);
                if (assembly != null)
                {
                    this.Load(assembly, _enabledForDefault);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the specific assembly file.
        /// </summary>
        /// <param name="_assemblyFileName">The filename of the assembly in which the plug-ins may be contained.</param>
        public virtual void Load(string _assemblyFileName)
        {
            try
            {
                this.Load(_assemblyFileName, false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the filenames.
        /// </summary>
        /// <param name="_assemblyFileNames">Filenames of the assemblies in which the plug-ins may be contained.</param>
        /// <param name="_enabledForDefault">The default value if the plug-in is not found in the enabling list.</param>
        public virtual void Load(string[] _assemblyFileNames, bool _enabledForDefault)
        {
            try
            {
                foreach (string assemblyFileName in _assemblyFileNames)
                {
                    this.Load(assemblyFileName, _enabledForDefault);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the filenames.
        /// </summary>
        /// <param name="_assemblyFileNames">Filenames of the assemblies in which the plug-ins may be contained.</param>
        public virtual void Load(string[] _assemblyFileNames)
        {
            try
            {
                this.Load(_assemblyFileNames, false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the filenames that is described by a generic string list.
        /// </summary>
        /// <param name="_assemblyFileNames">Filenames of the assemblies in which the plug-ins may be contained.</param>
        /// <param name="_enabledForDefault">The default value if the plug-in is not found in the enabling list.</param>
        public virtual void Load(IList<string> _assemblyFileNames, bool _enabledForDefault)
        {
            try
            {
                foreach (string assemblyFileName in _assemblyFileNames)
                {
                    this.Load(assemblyFileName, _enabledForDefault);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Loads the plug-ins from the filenames that is described by a generic string list.
        /// </summary>
        /// <param name="_assemblyFileNames">Filenames of the assemblies in which the plug-ins may be contained.</param>
        public virtual void Load(IList<string> _assemblyFileNames)
        {
            try
            {
                this.Load(_assemblyFileNames, false);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets a list of loaded plug-ins.
        /// </summary>
        public IList<PluginBase<T>> Items
        {
            get { return items__; }
        }

        #region ICollection<PluginBase<T>> Members

        /// <summary>
        /// Adds a plugin to the plug-in collection.
        /// </summary>
        /// <param name="item">The item that is going to be added to the collection.</param>
        public void Add(PluginBase<T> item)
        {
            items__.Add(item);
        }

        /// <summary>
        /// Clears all the items in the collection.
        /// </summary>
        public void Clear()
        {
            items__.Clear();
        }

        /// <summary>
        /// Checks if a specific item exists in the collection.
        /// </summary>
        /// <param name="item">The item to be checked.</param>
        /// <returns>True if the item exists, otherwise false.</returns>
        public bool Contains(PluginBase<T> item)
        {
            return items__.Contains(item);
        }

        /// <summary>
        /// Copies the collection of plug-ins to a specific array.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">Indicates the position from which the items are to be copied.</param>
        public void CopyTo(PluginBase<T>[] array, int arrayIndex)
        {
            items__.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int Count
        {
            get { return items__.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="SunnyChen.Common.Plugins.PluginManager"/> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return items__.IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occurrence of the item from the collection.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        /// <returns>True if the item was successfully removed from the collection. Otherwise, false.</returns>
        public bool Remove(PluginBase<T> item)
        {
            return items__.Remove(item);
        }

        #endregion

        #region IEnumerable<PluginBase<T>> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A System.Collections.Generic.IEnumerator&lt;PluginBase&lt;T&gt;&gt; that can be used to iterate through 
        /// the collection.</returns>
        public IEnumerator<PluginBase<T>> GetEnumerator()
        {
            return items__.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return items__.GetEnumerator();
        }

        #endregion
    }
}
