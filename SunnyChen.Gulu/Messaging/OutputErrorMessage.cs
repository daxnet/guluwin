using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using SunnyChen.Common.Enumerations;

namespace SunnyChen.Gulu.Messaging
{
    /// <summary>
    /// The class that represents a singleton instance of the output error message.
    /// </summary>
    public class OutputErrorMessage
    {
        private ErrorLevel level__ = ErrorLevel.elOK;
        private string text__ = string.Empty;
        private string code__ = string.Empty;
        private int lineNum__ = 0;
        private static Mutex mutex__ = new Mutex();
        private static volatile OutputErrorMessage instance__;
        private static object syncRoot__ = new object();

        private OutputErrorMessage() { }

        /// <summary>
        /// Gets the singleton instance of the output error message.
        /// </summary>
        public static OutputErrorMessage Instance
        {
            get
            {
                if (instance__ == null)
                {
                    lock (syncRoot__)
                    {
                        if (instance__ == null)
                        {
                            instance__ = new OutputErrorMessage();
                        }
                    }
                }
                return instance__;
            }
        }

        /// <summary>
        /// Gets the text of the error message.
        /// </summary>
        public string Text
        {
            get
            {
                mutex__.WaitOne();
                string ret = text__;
                mutex__.ReleaseMutex();
                return ret;
                //return message__;
            }
            set
            {
                mutex__.WaitOne();
                text__ = value;
                mutex__.ReleaseMutex();

                //message__ = value;
            }
        }

        /// <summary>
        /// Gets the error level of the error message.
        /// </summary>
        public ErrorLevel Level
        {
            get
            {
                mutex__.WaitOne();
                ErrorLevel ret = level__;
                mutex__.ReleaseMutex();
                return ret;
            }
            set
            {
                mutex__.WaitOne();
                level__ = value;
                mutex__.ReleaseMutex();
            }
        }

        /// <summary>
        /// Gets the line number which causes the error to occur.
        /// </summary>
        public int LineNum
        {
            get
            {
                mutex__.WaitOne();
                int ret = lineNum__;
                mutex__.ReleaseMutex();
                return ret;
            }
            set
            {
                mutex__.WaitOne();
                lineNum__ = value;
                mutex__.ReleaseMutex();
            }
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Code
        {
            get
            {
                mutex__.WaitOne();
                string ret = code__;
                mutex__.ReleaseMutex();
                return ret;
            }
            set
            {
                mutex__.WaitOne();
                code__ = value;
                mutex__.ReleaseMutex();
            }
        }
    }
}
