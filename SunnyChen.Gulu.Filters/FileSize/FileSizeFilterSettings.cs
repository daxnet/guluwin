using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SunnyChen.Gulu.Filters.FileSize
{
    [Serializable]
    public sealed class FileSizeFilterSettings : FilterSettingsBase, ISerializable
    {
        public enum SizeUnit
        {
            KB,
            MB,
            GB,
            TB
        }

        private int minimalSize__ = 0;
        private int maximalSize__ = 0;
        private SizeUnit unit__ = SizeUnit.KB;

        public FileSizeFilterSettings()
            : base()
        {
        }

        public FileSizeFilterSettings(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            minimalSize__ = info.GetInt32("MinimalSize");
            maximalSize__ = info.GetInt32("MaximalSize");
            unit__ = (SizeUnit)info.GetInt32("SizeUnit");
        }

        public SizeUnit Unit
        {
            get { return unit__; }
            set { unit__ = value; }
        }

        public int MinimalSize
        {
            get { return minimalSize__; }
            set { minimalSize__ = value; }
        }

        public int MaximalSize
        {
            get { return maximalSize__; }
            set { maximalSize__ = value; }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MinimalSize", minimalSize__);
            info.AddValue("MaximalSize", maximalSize__);
            info.AddValue("SizeUnit", Convert.ToInt32(unit__));
        }

        #endregion
    }
}
