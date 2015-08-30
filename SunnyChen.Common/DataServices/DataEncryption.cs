using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.DataServices
{
    /// <summary>
    /// Data encryption/decryption utility.
    /// </summary>
    public static class DataEncryption
    {
        private const string DE_KEY = "-nIuBeR=";
        private const string DE_IV = "-nIuBeR=";

        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="_source">String to be encrypted.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encode(string _source)
        {
            return new SymmetricCryptoServiceProvider().Encode(_source, DE_KEY, DE_IV);
        }

        /// <summary>
        /// Decrypts a string.
        /// </summary>
        /// <param name="_source">String to be decrypted.</param>
        /// <returns>The decrypted string.</returns>
        public static string Decode(string _source)
        {
            return new SymmetricCryptoServiceProvider().Decode(_source, DE_KEY, DE_IV);
        }
    }
}
