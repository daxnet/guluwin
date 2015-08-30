using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Win.NodeProperties
{
    internal enum ScriptTreeNodeType
    {
        SimpleRoot,
        Simple,
        GRoot,
        G
    }

    internal class ScriptTreeNodeProperty
    {
        private string name__ = string.Empty;
        private string fileName__ = string.Empty;
        private ScriptTreeNodeType type__ = ScriptTreeNodeType.Simple;

        public ScriptTreeNodeProperty(string _name, string _fileName, ScriptTreeNodeType _type)
        {
            name__ = _name;
            fileName__ = _fileName;
            type__ = _type;
        }

        public string Name
        {
            get { return name__; }
            set { name__ = value; }
        }

        public string FileName
        {
            get { return fileName__; }
            set { fileName__ = value; }
        }

        public ScriptTreeNodeType Type
        {
            get { return type__; }
            set { type__ = value; }
        }
    }
}
