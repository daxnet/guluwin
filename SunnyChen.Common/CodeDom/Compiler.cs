using System;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Win32;
using System.Collections.Specialized;


namespace SunnyChen.Common.CodeDom
{
    /// <summary>
    /// Provides the basic functionalities for CodeDom compilers. CodeDom compilers
    /// can simply inherit this class to implement a language-specific compiler.
    /// </summary>
    /// <remarks>The inherited compiler must contains the reference to the object that
    /// is of type <see cref="System.CodeDom.Compiler.CodeDomProvider"/>.</remarks>
    /// <example>
    /// Following example implements a C# compiler which is mostly the same implementation as
    /// <see cref="SunnyChen.Common.CodeDom.CSharpCompiler"/>. This implementation allows user
    /// to run the compiled assembly that has the entry point.
    /// <code>
    /// public class CSCompiler : Compiler
    /// {
    ///     public CSCompiler()
    ///         : base()
    ///     {
    ///         provider__ = new CSharpCodeProvider();
    ///     }
    ///
    ///     public CSCompiler(bool _generateExecutable, bool _generateInMemory, bool _includeDebugInformation)
    ///         : base(_generateExecutable, _generateInMemory, _includeDebugInformation)
    ///     {
    ///         provider__ = new CSharpCodeProvider();
    ///     }
    /// }
    /// </code>
    /// </example>
    public abstract class Compiler : IRunnable
    {
        #region Protected Members
        /// <summary>
        /// The CodeDomProvider instance.
        /// </summary>
        protected CodeDomProvider provider__;
        /// <summary>
        /// The parameters for compiling. For more information please refer to 
        /// <see cref="System.CodeDom.Compiler.CompilerParameters"/>.
        /// </summary>
        protected CompilerParameters parameters__ = new CompilerParameters();
        /// <summary>
        /// The result of the compiling process. For more information please refer to
        /// <see cref="System.CodeDom.Compiler.CompilerResults"/>.
        /// </summary>
        protected CompilerResults results__;
        /// <summary>
        /// Source code collection that is going to be compiled.
        /// </summary>
        /// <remarks>
        /// Before compiling, the compiler will sum up all the code snippets within this
        /// collection and compiles the code totally.
        /// </remarks>
        protected ArrayList codes__ = new ArrayList();
        #endregion

        #region Constructors
        /// <summary>
        /// <para>The default constructor that initializes fields with their default value.</para>
        /// </summary>
        /// <remarks>
        /// The constructor initializes the fields by using the default values as follows. These fields are the
        /// members of <see cref="System.CodeDom.Compiler.CompilerParameters"/>.
        /// <list type="table">
        /// <listheader><term>Member</term><description>Default Value</description></listheader>
        /// <item><term>GenerateExecutable</term><description>False</description></item>
        /// <item><term>GenerateInMemory</term><description>True</description></item>
        /// <item><term>IncludeDebugInformation</term><description>False</description></item>
        /// </list>
        /// <para>Where <b>GenerateExecutable</b> means the compile is going to generate the executable file.
        ///  <b>GenerateInMemory</b> means the compile won't generate an intermediate file on the disk. <b>
        ///  IncludeDebugInformation</b> means whether the debugging information should be included when compiling.
        ///  </para>
        /// </remarks>
        protected Compiler()
        {
            parameters__.GenerateExecutable = false;
            parameters__.GenerateInMemory = true;
            parameters__.IncludeDebugInformation = false;
        }
        /// <summary>
        /// <para>The constructor that initializes fields with specified parameters.</para>
        /// </summary>
        /// <param name="_generateExecutable">Specifies whether the compile is going to generate the executable file.</param>
        /// <param name="_generateInMemory">Specifies whether the compile is going to generate an intermediate file while compiling.</param>
        /// <param name="_includeDebugInformation">Specifies whether the debugging information should be included.</param>
        protected Compiler(bool _generateExecutable, bool _generateInMemory, bool _includeDebugInformation)
        {
            parameters__.GenerateExecutable = _generateExecutable;
            parameters__.GenerateInMemory = _generateInMemory;
            parameters__.IncludeDebugInformation = _includeDebugInformation;
        }
        #endregion

        #region Private Methods

        private bool IsValidNet20Assembly(string _fileToTest)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(_fileToTest);
                if (assembly.ImageRuntimeVersion.Equals("v2.0.50727"))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private ArrayList GetRegisteredNet20SystemAssemblies()
        {
            RegistryKey subKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework");
            string installRoot = string.Empty;
            ArrayList array = new ArrayList();
            if (subKey != null)
            {
                installRoot = (string)subKey.GetValue("InstallRoot");
                if (installRoot != null)
                {
                    foreach (string subDirectory in Directory.GetDirectories(installRoot))
                    {
                        foreach (string fileName in Directory.GetFiles(subDirectory, "System*.dll"))
                        {
                            if (this.IsValidNet20Assembly(fileName))
                            {
                                array.Add(Path.GetFileName(fileName));
                            }
                        }

                    }
                    return array;
                }
            }
            return null;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds all the system references to the compiler parameter.
        /// </summary>
        /// <remarks>Only Microsoft.NET Framework v2.0.50727 assemblies will be loaded to the compiler parameter. For
        ///  other versions of Microsoft.NET Framework please use <see cref="AddReference"/> individually for each
        ///  assembly that needs to be added.</remarks>
        public void AddSystemReferences()
        {
            ArrayList array = this.GetRegisteredNet20SystemAssemblies();
            if (array != null)
            {
                foreach (string s in array)
                    parameters__.ReferencedAssemblies.Add(s);
            }
        }
        /// <summary>
        /// Adds an individual assembly reference.
        /// </summary>
        /// <param name="_name">The assembly name that is going to be added to the reference list.</param>
        public void AddReference(string _name)
        {
            parameters__.ReferencedAssemblies.Add(_name);
        }

        /// <summary>
        /// Adds an individual source code snippet into the code collection.
        /// </summary>
        /// <param name="_code">The source code snippet that is going to be added.</param>
        public void AddCode(string _code)
        {
            codes__.Add(_code);
        }

        /// <summary>
        /// Clears all the source code snippets and assembly references.
        /// </summary>
        public void ClearAll()
        {
            codes__.Clear();
            parameters__.ReferencedAssemblies.Clear();
        }

        /// <summary>
        /// Just clears all the assembly references.
        /// </summary>
        public void ClearReferences()
        {
            parameters__.ReferencedAssemblies.Clear();
        }

        /// <summary>
        /// Just clears all the source code snippets in the code collection.
        /// </summary>
        public void ClearCodes()
        {
            codes__.Clear();
        }

        /// <summary>
        /// Compiles the source code according to the settings in CodeDom parameters.
        /// </summary>
        /// <returns>
        /// <list type="table">
        /// <listheader><term>Value</term><description>Description</description></listheader>
        /// <item><term>0</term><description>The function terminates normally.</description></item>
        /// <item><term>-1</term><description>No code to compile, the function terminates abnormally.</description></item>
        /// <item><term>&gt;0</term><description>Errors or warnings when compiling.</description></item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>When the function returns an integer that is greater than zero, which means errors or warnings 
        /// were found while compiling. Please check <see cref="Errors"/> for the error/warning details.</para>
        /// </remarks>
        public int Compile()
        {
            try
            {
                if (codes__.Count > 0)
                {
                    results__ = provider__.CompileAssemblyFromSource(parameters__,
                        (string[])codes__.ToArray(typeof(string)));
                    return results__.Errors.Count;
                }
                else
                {
                    results__ = null;
                    return -1;
                }
            }
            catch
            {
                results__ = null;
                return -2;
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the compiler errors. For more information about compiler error, please refer to <see cref="System.CodeDom.Compiler.CompilerError"/>.
        /// </summary>
        public CompilerErrorCollection Errors
        {
            get
            {
                return results__ != null ? results__.Errors : null;
            }
        }
        /// <summary>
        /// Gets the output result.
        /// </summary>
        public StringCollection Output
        {
            get
            {
                return results__ != null ? results__.Output : null;
            }
        }
        /// <summary>
        /// Gets the compiled assembly.
        /// </summary>
        public Assembly CompiledAssembly
        {
            get
            {
                return results__ != null ? results__.CompiledAssembly : null;
            }
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Creates the concrete compiler instance by using the default constructor.
        /// </summary>
        /// <param name="_compilerType">The type which defines the compiler implementation.</param>
        /// <returns>The concrete compiler instance.</returns>
        /// <example>
        /// Following example demonstrates the way of creating a c-sharp compiler instance.
        /// <code>
        /// public Compiler CreateCSCompiler()
        /// {
        ///     Type csCompilerType = typeof(CSCompiler);
        ///     return Compiler.CreateCompiler(csCompilerType);
        /// }
        /// </code>
        /// <para>Note that the <b>CSCompiler</b> above was implemented in the <seealso cref="SunnyChen.Common.CodeDom.Compiler"/> documentation.</para>
        /// </example>
        public static Compiler CreateCompiler(Type _compilerType)
        {
            try
            {
                Compiler compiler = (Compiler)Activator.CreateInstance(_compilerType);
                return compiler;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Creates the concrete compiler instance by using the specified parameters.
        /// </summary>
        /// <param name="_compilerType">The type which defines the compiler implementation.</param>
        /// <param name="_generateExecutable">Specifies whether the compile is going to generate the executable file.</param>
        /// <param name="_generateInMemory">Specifies whether the compile is going to generate an intermediate file while compiling.</param>
        /// <param name="_includeDebugInformation">Specifies whether the debugging information should be included.</param>
        /// <returns>The concrete compiler instance.</returns>
        /// <example>
        /// Following example demonstrates the way of creating a c-sharp compiler instance which requires assembly to be generated
        /// as a physical file.
        /// <code>
        /// public Compiler CreateCSCompiler()
        /// {
        ///     Type csCompilerType = typeof(CSCompiler);
        ///     return Compiler.CreateCompiler(csCompilerType, false, false, false);
        /// }
        /// </code>
        /// <para>Note that the <b>CSCompiler</b> above was implemented in the <seealso cref="SunnyChen.Common.CodeDom.Compiler"/> documentation.</para>
        /// </example>
        public static Compiler CreateCompiler(Type _compilerType, bool _generateExecutable, bool _generateInMemory, bool _includeDebugInformation)
        {
            try
            {
                Compiler compiler = (Compiler)Activator.CreateInstance(_compilerType, 
                    new object[] { 
                        _generateExecutable, 
                        _generateInMemory, 
                        _includeDebugInformation });

                return compiler;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region IRunnable Members

        /// <summary>
        /// Runs the compiled assembly by accessing its entry point.
        /// </summary>
        /// <param name="_className">The class name in which the entry point exists.</param>
        /// <param name="_entryMethodName">The entry method.</param>
        /// <remarks><para>The entry method must be a public static method and with no arguments in the method
        /// signature. For example, <c>public static void Main()</c> is a valid entry point.</para>
        /// <para>The method will return immediately when no entry point is specified.</para>
        /// </remarks>
        public void Run(string _className, string _entryMethodName)
        {
            if (results__ != null)
            {
                Assembly assembly = results__.CompiledAssembly;
                if (assembly != null)
                {
                    Module[] modules = assembly.GetModules(false);
                    if (modules != null && modules.Length > 0)
                    {
                        Type[] types = modules[0].GetTypes();
                        foreach (Type type in types)
                        {
                            if (type.Name.Equals(_className))
                            {
                                MethodInfo mi = type.GetMethod(_entryMethodName, BindingFlags.Public | BindingFlags.Static);
                                if (mi != null)
                                {
                                    mi.Invoke(type, null);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
