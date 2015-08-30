using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.CodeDom
{
    /// <summary>
    /// Defines a running method for the compiled assembly that can be implemented
    /// by the compilers so that the compilers may have the ability to run the compiled
    /// assemblies.
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Runs the compiled assembly by accessing its entry point.
        /// </summary>
        /// <param name="_className">The class name in which the entry point exists.</param>
        /// <param name="_entryMethodName">The entry method.</param>
        /// <remarks><para>The entry method must be a public static method and with no arguments in the method
        /// signature. For example, <c>public static void Main()</c> is a valid entry point.</para>
        /// <para>The method will return immediately when no entry point is specified.</para>
        /// </remarks>
        void Run(string _className, string _entryMethodName);
    }
}
