using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu.Messaging
{
    /// <summary>
    /// The class that represents a singleton instance of the output message.
    /// </summary>
    public class OutputMessage
    {
        private string message__ = string.Empty;
        private static Mutex mutex__ = new Mutex();
        private static volatile OutputMessage instance__;
        private static object syncRoot__ = new object();

        private OutputMessage() { }

        /// <summary>
        /// Gets the singleton instance of the output message.
        /// </summary>
        public static OutputMessage Instance
        {
            get
            {
                if (instance__ == null)
                {
                    lock (syncRoot__)
                    {
                        if (instance__ == null)
                        {
                            instance__ = new OutputMessage();
                        }
                    }
                }
                return instance__;
            }
        }

        /// <summary>
        /// Gets the message string.
        /// </summary>
        public string Message
        {
            get
            {
                mutex__.WaitOne();
                string ret = message__;
                mutex__.ReleaseMutex();
                return ret;
                //return message__;
            }
            set
            {
                mutex__.WaitOne();
                message__ = value;
                mutex__.ReleaseMutex();

                //message__ = value;
            }
        }
    }
}
