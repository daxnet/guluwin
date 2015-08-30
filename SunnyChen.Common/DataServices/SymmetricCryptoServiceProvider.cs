using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using SunnyChen.Common.Enumerations;

namespace SunnyChen.Common.DataServices
{
    /// <summary>
    /// 
    /// </summary>
    internal class SymmetricCryptoServiceProvider
    {
        #region Private Fields
        /// <summary>
        /// 
        /// </summary>
        private SymmetricCryptoAlgorithm algorithm__ = SymmetricCryptoAlgorithm.DES;

        /// <summary>
        /// 
        /// </summary>
        private readonly Type[] algorithmTypes = 
			{typeof(System.Security.Cryptography.DESCryptoServiceProvider),
			 typeof(System.Security.Cryptography.RC2CryptoServiceProvider),
			 typeof(System.Security.Cryptography.RijndaelManaged),
			 typeof(System.Security.Cryptography.TripleDESCryptoServiceProvider)};

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SymmetricCryptoServiceProvider()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_algorithm"></param>
        public SymmetricCryptoServiceProvider(SymmetricCryptoAlgorithm _algorithm)
        {
            //
            // TODO: Add constructor logic here
            //
            algorithm__ = _algorithm;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dataToEncode"></param>
        /// <param name="_key"></param>
        /// <param name="_iv"></param>
        /// <returns></returns>
        public string Encode(string _dataToEncode, string _key, string _iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_iv);

            SymmetricAlgorithm cryptoProvider = (SymmetricAlgorithm)Activator.CreateInstance(algorithmTypes[(int)algorithm__], true);
            int i = cryptoProvider.KeySize;
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter streamWriter = new StreamWriter(cryptoStream);
            streamWriter.Write(_dataToEncode);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dataToEncode"></param>
        /// <param name="_key"></param>
        /// <param name="_iv"></param>
        /// <returns></returns>
        public string Decode(string _dataToEncode, string _key, string _iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_iv);

            byte[] byEnc;

            try
            {
                byEnc = Convert.FromBase64String(_dataToEncode);
            }
            catch
            {
                return null;
            }

            SymmetricAlgorithm cryptoProvider = (SymmetricAlgorithm)Activator.CreateInstance(algorithmTypes[(int)algorithm__], true);
            MemoryStream memoryStream = new MemoryStream(byEnc);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader streamReader = new StreamReader(cryptoStream);
            return streamReader.ReadToEnd();
        }

        #endregion

    }
}
