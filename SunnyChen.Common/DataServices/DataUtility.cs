using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.DataServices
{
    /// <summary>
    /// The utility class that provides the data routines.
    /// </summary>
    public static class DataUtility
    {
        /// <summary>
        /// Generates a simulated random string.
        /// </summary>
        /// <param name="_len">The length of the string that needs to be generated.</param>
        /// <returns>The random string which consists of the characters that is readable for human.</returns>
        public static string GetRandomString(int _len)
        {
            byte[] bytes = new byte[_len];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(bytes);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte((bytes[i] % 26) + 65);
            }
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
