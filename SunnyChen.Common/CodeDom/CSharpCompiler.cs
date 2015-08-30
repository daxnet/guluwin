using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.CSharp;

namespace SunnyChen.Common.CodeDom
{
    /// <summary>
    /// The implementation of the C# CodeDom Compiler.
    /// </summary>
    public class CSharpCompiler : Compiler
    {
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
        public CSharpCompiler()
            : base()
        {
            provider__ = new CSharpCodeProvider();
        }

        /// <summary>
        /// <para>The constructor that initializes fields with specified parameters.</para>
        /// </summary>
        /// <param name="_generateExecutable">Specifies whether the compile is going to generate the executable file.</param>
        /// <param name="_generateInMemory">Specifies whether the compile is going to generate an intermediate file while compiling.</param>
        /// <param name="_includeDebugInformation">Specifies whether the debugging information should be included.</param>
        public CSharpCompiler(bool _generateExecutable, bool _generateInMemory, bool _includeDebugInformation)
            : base(_generateExecutable, _generateInMemory, _includeDebugInformation)
        {
            provider__ = new CSharpCodeProvider();
        }
    }
}
