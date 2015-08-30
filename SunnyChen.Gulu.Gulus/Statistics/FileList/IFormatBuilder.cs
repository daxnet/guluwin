using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Gulus.Statistics.FileList
{
    internal interface IFormatBuilder
    {
        string BuildHeader();
        string BuildBody();
        string BuildFooter();
    }
}
