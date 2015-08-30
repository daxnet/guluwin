using System;
using System.CodeDom;
using System.IO;
using System.Collections.Generic;
using System.Text;

using Mono.CSharp;

namespace SunnyChen.Common.CodeDom
{
    /// <summary>
    /// Provides code visualizer structure for C# code.
    /// </summary>
    /// <remarks>
    /// This class is a wrapper of CSParser which was originally created by Debreuil Digital Works, 
    /// in December 2006 to support C# on microcontrollers. Denis Erchoff added all the 2.0 support. 
    /// For more information about CSParser please refer to http://www.codeplex.com/csparser.
    /// </remarks>
    /// <example>
    /// Following example shows the way of creating the C# code structure tree by
    /// using the CSharpCodeVisualizer.
    /// <code>
    /// private void BuildCodeStruct(string _code)
    /// {
    ///    string namespaceName;
    ///    // Parses the code
    ///    CSharpCodeVisualizer visualizer = new CSharpCodeVisualizer();
    ///    int ret = visualizer.Parse(_code);
    ///    // Initialize the code structure tree view
    ///    codeStructTreeView.Nodes.Clear();
    ///    if (ret == 0)
    ///    {
    ///        // Get the namespaces from the code
    ///        foreach (CodeNamespace ns in visualizer.CodeCompileUnit.Namespaces)
    ///        {
    ///            // If the namespace is empty, it means that user didn't encapsulate the code
    ///            // into a given namespace. We use the default namespace for such case.
    ///            namespaceName = ns.Name == string.Empty ? "DEFAULT_NAMESPACE" : ns.Name;
    ///            // Creates the tree node for namespaces and place the position information
    ///            // into the Tag property.
    ///            TreeNode namespaceNode = codeStructTreeView.Nodes.Add(namespaceName, namespaceName, "Namespace", "Namespace");
    ///            namespaceNode.Tag = (CodeLinePragma)ns.UserData["Location"];
    ///            // Get the types from the current namespace
    ///            foreach (CodeTypeDeclaration typeDeclaration in ns.Types)
    ///            {
    ///                // Creates the tree node for types, select right image for the type, and
    ///                // place the position information into the Tag property of the node.
    ///                TreeNode typeNode = namespaceNode.Nodes.Add(typeDeclaration.Name,
    ///                    typeDeclaration.Name,
    ///                    "Type",
    ///                    "Type";
    ///                // Record the code location
    ///                typeNode.Tag = (CodeLinePragma)typeDeclaration.UserData["Location"];
    ///                // Get the members within the current type declaration.
    ///                foreach (CodeTypeMember member in typeDeclaration.Members)
    ///                {
    ///                    // Creates the tree node for members, select right image for the type
    ///                    // and place the position information into the Tag property of the node.
    ///                    TreeNode memberNode = typeNode.Nodes.Add(member.Name,
    ///                        member.Name,
    ///                        "Member",
    ///                        "Member";
    ///                    memberNode.Tag = (CodeLinePragma)member.UserData["Location"];
    ///                }
    ///            }
    ///        }
    ///    }
    ///    else
    ///    {
    ///        // Error occurred while creating the outline, show the error text on the root node
    ///        TreeNode errorNode = codeStructTreeView.Nodes.Add("Cannot Get Code Structure", 
    ///            "Cannot Get Code Structure", 
    ///            "Error", 
    ///            "Error");
    ///    }
    ///    // Expand the tree so that users can pick the member easily.
    ///    codeStructTreeView.ExpandAll();
    /// }
    /// </code>
    /// </example>
    public sealed class CSharpCodeVisualizer
    {
        private CodeCompileUnit codeCompileUnit__;

        /// <summary>
        /// Parses the code and generate the compiled units.
        /// </summary>
        /// <param name="_code">The source code that is being parsed.</param>
        /// <returns>Zero if success, otherwise a non-zero value would return.</returns>
        /// <remarks>
        /// For more information about compiled units, please refer to <see cref="System.CodeDom.CodeCompileUnit"/>.
        /// </remarks>
        /// <seealso cref="System.CodeDom.CodeCompileUnit"/>
        public int Parse(string _code)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(_code));
            CSharpParser parser = new CSharpParser(null, memoryStream, null);
            int ret = parser.parse();
            codeCompileUnit__ = parser.Builder.CurrCompileUnit;
            return ret;
        }

        /// <summary>
        /// Gets the compiled unit information after the calling of <see cref="Parse"/> method.
        /// </summary>
        public CodeCompileUnit CodeCompileUnit
        {
            get { return codeCompileUnit__; }
        }
    }
}
