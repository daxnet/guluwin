using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;


namespace SunnyChen.Common.DataServices
{
    /// <summary>
    /// Provides wrapper utilities for ICSharpCode.SharpZipLib data compression functionalities.
    /// for more information about ICSharpCode.SharpZipLib, please refer to http://www.icsharpcode.net/OpenSource/SharpZipLib/.
    /// </summary>
    public static class DataCompression
    {
        #region Public Static Methods

        /// <summary>
        /// Compress an array of bytes.
        /// </summary>
        /// <param name="_pBytes">An array of bytes to be compressed.</param>
        /// <returns>Compressed bytes.</returns>
        /// <example>
        /// Following example demonstrates the way of compressing an ASCII string text.
        /// <code>
        /// public void Compress()
        /// {
        ///     string source = "Hello, world!";
        ///     byte[] source_bytes = System.Text.Encoding.ASCII.GetBytes(source);
        ///     byte[] compressed = DataCompression.Compress(source_bytes);
        ///     
        ///     // Process the compressed bytes here.
        /// }
        /// </code>
        /// </example>
        /// <remarks>It is the best practice that use the overrided <b>DataCompression.Compress</b> method with <see cref="System.String"/> parameter to compress a string.</remarks>
        public static byte[] Compress(byte[] _pBytes)
        {
            MemoryStream ms = new MemoryStream();

            Deflater mDeflater = new Deflater(Deflater.BEST_COMPRESSION);
            DeflaterOutputStream outputStream = new DeflaterOutputStream(ms, mDeflater, 131072);

            outputStream.Write(_pBytes, 0, _pBytes.Length);
            outputStream.Close();

            return ms.ToArray();
        }

        /// <summary>
        /// Decompresses an array of bytes.
        /// </summary>
        /// <param name="_pBytes">An array of bytes to be decompressed.</param>
        /// <returns>Decompressed bytes</returns>
        public static byte[] DeCompress(byte[] _pBytes)
        {
            InflaterInputStream inputStream = new InflaterInputStream(new MemoryStream(_pBytes));

            MemoryStream ms = new MemoryStream();
            Int32 mSize;

            byte[] mWriteData = new byte[4096];

            while (true)
            {
                mSize = inputStream.Read(mWriteData, 0, mWriteData.Length);
                if (mSize > 0)
                {
                    ms.Write(mWriteData, 0, mSize);
                }
                else
                {
                    break;
                }
            }

            inputStream.Close();
            return ms.ToArray();
        }

        /// <summary>
        /// Compresses a string.
        /// </summary>
        /// <param name="_uncompressedString">The string to be compressed.</param>
        /// <returns>The compressed string.</returns>
        public static string Compress(string _uncompressedString)
        {
            byte[] compressedData = Compress(Encoding.Unicode.GetBytes(_uncompressedString));
            return System.Convert.ToBase64String(compressedData, 0, compressedData.Length);
        }

        /// <summary>
        /// Decompresses a string.
        /// </summary>
        /// <param name="_compressedString">The string to be decompressed.</param>
        /// <returns>The decompressed string.</returns>
        public static string DeCompress(string _compressedString)
        {
            byte[] bytes = Convert.FromBase64String(_compressedString); // Encoding.Unicode.GetBytes(compressedString);
            byte[] ret = DeCompress(bytes);
            return Encoding.Unicode.GetString(ret);
        }

        #endregion
    }
}
