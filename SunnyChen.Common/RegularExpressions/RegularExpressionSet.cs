using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.RegularExpressions
{
    /// <summary>
    /// Contains a list of constant string each of which represents a valid regular expression.
    /// </summary>
    public static class RegularExpressionSet
    {
        /// <summary>
        /// Declaring a regular expression that indicates the identifier.
        /// </summary>
        /// <remarks>
        /// <para>Matches: abc ||| ab1 ||| _abc ||| _ab_</para>
        /// <para>Non-matches: 1a ||| ;ab ||| abc= ||| abc+</para>
        /// </remarks>
        public const string IDENTIFIER = @"^[a-zA-Z0-9_]*$";

    }
}
