using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Win.Configuration
{
    internal class EditorCompilerConfigHandler : ConfigurationSection
    {
        [ConfigurationProperty("SyntaxFileName", 
            IsRequired = true, 
            IsKey = false, 
            DefaultValue = "csharp.syn")]
        public string SyntaxFileName
        {
            get { return (string)base["SyntaxFileName"]; }
            set { base["SyntaxFileName"] = value; }
        }

        [ConfigurationProperty("CompilerTypeName", 
            IsRequired = true, 
            IsKey = false,
            DefaultValue = "SunnyChen.Common.CodeDom.CSharpCompiler, SunnyChen.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=eb3d8930e21cc6ec")]
        public string CompilerTypeName
        {
            get { return (string)base["CompilerTypeName"]; }
            set { base["CompilerTypeName"] = value; }
        }

        [ConfigurationProperty("SimpleTemplate",
            IsRequired = true,
            IsKey = false,
            DefaultValue = "csharp.simpletemplate")]
        public string SimpleTemplate
        {
            get { return (string)base["SimpleTemplate"]; }
            set { base["SimpleTemplate"] = value; }
        }

        [ConfigurationProperty("GTemplate",
            IsRequired = true,
            IsKey = false,
            DefaultValue = "csharp.gtemplate")]
        public string GTemplate
        {
            get { return (string)base["GTemplate"]; }
            set { base["GTemplate"] = value; }
        }
    }
}
