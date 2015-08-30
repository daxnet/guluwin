using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Diagnostic
{
    [Obsolete("This class is now obsolete.")]
    internal sealed class TimeCounter
    {
        private string resultFile__ = string.Empty;
        private DateTime startTime__;

        [Obsolete("This class is now obsolete.")]
        public TimeCounter(string _resultFile)
        {
            resultFile__ = _resultFile;
        }

        [Conditional("BENCHMARK"), Obsolete("This method is now obsolete.")]
        public void Start()
        {
            startTime__ = DateTime.Now;
        }

        [Conditional("BENCHMARK"), Obsolete("This method is now obsolete.")]
        public void Stop(string _taskName, bool _showSeconds)
        {
            TimeSpan ts = DateTime.Now - startTime__;
            string result;
            if (_taskName == null || _taskName.Trim().Equals(string.Empty))
            {
                if (_showSeconds)
                {
                    result = string.Format("Time used: {0}ms, {1}s.", ts.Milliseconds, ts.Seconds);
                }
                else
                {
                    result = string.Format("Time used: {0}ms.", ts.Milliseconds);
                }
            }
            else
            {
                if (_showSeconds)
                {
                    result = string.Format("Task: {0} ---> Time used: {1}ms, {2}s.", _taskName, ts.Milliseconds, ts.Seconds);
                }
                else
                {
                    result = string.Format("Task: {0} ---> Time used: {1}ms.", _taskName, ts.Milliseconds);
                }
            }
            StreamWriter sw = File.AppendText(resultFile__);
            sw.WriteLine(result);
            sw.Close();
        }
    }
}
