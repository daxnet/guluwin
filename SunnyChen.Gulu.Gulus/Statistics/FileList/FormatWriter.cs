using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SunnyChen.Gulu.Gulus.Statistics.FileList
{
    internal class FormatWriter : IFormatBuilder
    {
        private IFormatBuilder builder__;
        private StreamWriter writer__;

        public FormatWriter(IFormatBuilder _builder, StreamWriter _writer)
        {
            builder__ = _builder;
            writer__ = _writer;
        }

        #region IFormatBuilder Members

        public string BuildHeader()
        {
            string header = builder__.BuildHeader();
            if (header != null && !header.Trim().Equals(string.Empty))
                writer__.WriteLine(header);
            return header;
        }

        public string BuildBody()
        {
            string body = builder__.BuildBody();
            if (body != null && !body.Trim().Equals(string.Empty))
                writer__.WriteLine(body);
            return body;
        }

        public string BuildFooter()
        {
            string footer = builder__.BuildFooter();
            if (footer != null && !footer.Trim().Equals(string.Empty))
                writer__.WriteLine(footer);
            return footer;
        }

        #endregion
    }
}
