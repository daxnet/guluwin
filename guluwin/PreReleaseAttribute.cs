using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Win
{
    public class PreReleaseAttribute : Attribute
    {
        private bool isPreRelease__ = false;

        public PreReleaseAttribute(bool _isPreRelease)
        {
            isPreRelease__ = _isPreRelease;
        }

        public bool IsPreRelease
        {
            get { return isPreRelease__; }
        }
    }
}
