using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Filters.FileType
{
    [Serializable]
    public sealed class FileTypeFilterSettings : FilterSettingsBase, ISerializable
    {

        private string fileTypes__ = string.Empty;

        public FileTypeFilterSettings()
            : base()
        {
        }

        public FileTypeFilterSettings(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            fileTypes__ = info.GetString("FileTypes");
        }

        public string FileTypes
        {
            get { return fileTypes__; }
            set { fileTypes__ = value; }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FileTypes", fileTypes__);
        }

        #endregion
    }
}
