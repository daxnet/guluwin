using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Filters.FileName
{
    [Serializable]
    public sealed class FileNameFilterSettings : FilterSettingsBase, ISerializable
    {
        public enum FilterCondition
        {
            Contains,
            NotContains,
            BeginWith,
            EndWith,
            NotBeginWith,
            NotEndWith,
            Matches
        }

        private FilterCondition condition__ = FilterCondition.Contains;
        private string value__ = string.Empty;
        private bool regularExpression__ = false;

        public FileNameFilterSettings()
            : base()
        {
        }

        public FileNameFilterSettings(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            condition__ = (FilterCondition)info.GetInt32("Condition");
            value__ = info.GetString("Value");
            regularExpression__ = info.GetBoolean("ExpressRegularExpression");
        }

        
        public FilterCondition Condition
        {
            get { return condition__; }
            set { condition__ = value; }
        }

        public string Value
        {
            get { return value__; }
            set { value__ = value; }
        }

        public bool RepresentsRegularExpression
        {
            get { return regularExpression__; }
            set { regularExpression__ = value; }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Condition", Convert.ToInt32(condition__));
            info.AddValue("Value", value__.ToString());
            info.AddValue("ExpressRegularExpression", regularExpression__);
        }

        #endregion
    }
}
