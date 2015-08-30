using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Resources;
using System.Reflection;
using System.Threading;

namespace SunnyChen.Gulu.Win.NodeProperties
{
    internal enum FileTreeNodeType
    {
        Root,
        Desktop,
        MyDocuments,
        Drive,
        Folder,
        File,
        Unknown
    }

    internal class FileTreeNodeProperty
    {
        #region Private Fields

        private string name__ = string.Empty;
        private FileTreeNodeType type__ = FileTreeNodeType.Unknown;
        private string fullPath__ = string.Empty;
        private FileAttributes fileSystemAttributes__ = FileAttributes.Normal;

        #endregion

        #region Constructors

        public FileTreeNodeProperty()
        {
        }

        public FileTreeNodeProperty(string _name, FileTreeNodeType _type, string _fullPath)
        {
            name__ = _name;
            type__ = _type;
            fullPath__ = _fullPath;
        }

        public FileTreeNodeProperty(string _name, FileTreeNodeType _type, string _fullPath, FileAttributes _fileSystemAttributes)
        {
            name__ = _name;
            type__ = _type;
            fullPath__ = _fullPath;
            fileSystemAttributes__ = _fileSystemAttributes;
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// 
        /// </summary>
        [ReadOnly(true)]
        public string Name { get { return name__; } set { name__ = value; } }
        /// <summary>
        /// 
        /// </summary>
        [ReadOnly(true)]
        public FileTreeNodeType Type { get { return type__; } set { type__ = value; } }
        /// <summary>
        /// 
        /// </summary>
        [ReadOnly(true)]
        public string FullPath { get { return fullPath__; } set { fullPath__ = value; } }
        /// <summary>
        /// 
        /// </summary>
        [ReadOnly(true)]
        public FileAttributes FileSystemAttributes { get { return fileSystemAttributes__; } set { fileSystemAttributes__ = value; } }
        #endregion
    }
}
