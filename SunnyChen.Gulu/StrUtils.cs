using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Gulu
{
    /// <summary>
    /// The utility class that provides string facilities.
    /// </summary>
    public static class StrUtils
    {
        /// <summary>
        /// Gets the left part of a string.
        /// </summary>
        /// <param name="_str">The source string.</param>
        /// <param name="_count">Indicating the number of characters to get.</param>
        /// <returns>The left part of the source string.</returns>
        public static string Left(string _str, int _count)
        {
            return _str.Substring(0, _count);
        }
        /// <summary>
        /// Gets the right part of a string.
        /// </summary>
        /// <param name="_str">The source string.</param>
        /// <param name="_count">Indicating the number of characters to get.</param>
        /// <returns>The right part of the source string.</returns>
        public static string Right(string _str, int _count)
        {
            return _str.Substring(_str.Length - _count, _count);
        }
    }
}
