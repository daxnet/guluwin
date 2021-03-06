﻿/* ----------------------------------------------------------------------------
 * GuluWin - The File Searching and Batch Processing Expert
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 6/5/2008
 * 
 * Exception for Gulu related operations.
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION      UPDATED_BY
 * 
 * ---------------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SunnyChen.Gulu
{
    /// <summary>
    /// Exception for Gulu related operations.
    /// This exception is specific to Gulu related operations.
    /// Throw this exception when Gulus failed to initialize
    /// or the Gulu manager failed to load gulus from assemblies.
    /// </summary>
    public class GuluException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GuluException()
            : base()
        {
        }

        /// <summary>
        /// The constructor that holds the exception message.
        /// </summary>
        /// <param name="_message">The exception error message.</param>
        public GuluException(string _message)
            : base(_message)
        {
        }

        /// <summary>
        /// The constructor that holds the exception message
        /// and inner exception.
        /// </summary>
        /// <param name="_message">The exception error message.</param>
        /// <param name="_innerException">The instance of inner exception.</param>
        public GuluException(string _message, Exception _innerException)
           : base(_message, _innerException)
        {
        }

        /// <summary>
        /// The constructor which provides serialization facilities.
        /// </summary>
        /// <param name="_info">Serialization information.</param>
        /// <param name="_context">Streaming context.</param>
        public GuluException(SerializationInfo _info, StreamingContext _context)
            : base(_info, _context)
        {
        }
    }
}
