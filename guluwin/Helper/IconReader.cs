using System;
using System.Drawing;
using System.Runtime.InteropServices;

using SunnyChen.Common.Windows;
using SunnyChen.Common.Windows.ShellApi;

namespace SunnyChen.Gulu.Win.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IconReader
    {
        /// <summary>
        /// 
        /// </summary>
        public enum IconSize
        {
            /// <summary>
            /// 
            /// </summary>
            Large = 0,
            /// <summary>
            /// 
            /// </summary>
            Small
        }
        /// <summary>
        /// 
        /// </summary>
        public enum FolderType
        {
            /// <summary>
            /// 
            /// </summary>
            Open = 0,
            /// <summary>
            /// 
            /// </summary>
            Closed
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_fileName"></param>
        /// <param name="_size"></param>
        /// <param name="_linkOverlay"></param>
        /// <returns></returns>
        public static Icon GetFileIcon(string _fileName, IconSize _size, bool _linkOverlay)
        {
            ShellApi.SHFILEINFO shfi = new ShellApi.SHFILEINFO();
            uint flags = ShellApi.SHGFI_ICON | ShellApi.SHGFI_USEFILEATTRIBUTES;

            if (_linkOverlay)
                flags += ShellApi.SHGFI_LINKOVERLAY;

            if (_size == IconSize.Small)
                flags += ShellApi.SHGFI_SMALLICON;
            else
                flags += ShellApi.SHGFI_LARGEICON;

            ShellApi.SHGetFileInfo(_fileName,
                ShellApi.FILE_ATTRIBUTE_NORMAL,
                out shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);

            Icon icon = Icon.FromHandle(shfi.hIcon);
            return icon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="folderType"></param>
        /// <returns></returns>
        [Obsolete("This function is now obsolete.")]
        public static Icon GetFolderIcon(IconSize _size, FolderType _folderType)
        {
            // Need to add size check, although errors generated at present!
            uint flags = ShellApi.SHGFI_ICON | ShellApi.SHGFI_USEFILEATTRIBUTES;

            if (FolderType.Open == _folderType)
            {
                flags += ShellApi.SHGFI_OPENICON;
            }

            if (IconSize.Small == _size)
            {
                flags += ShellApi.SHGFI_SMALLICON;
            }
            else
            {
                flags += ShellApi.SHGFI_LARGEICON;
            }

            // Get the folder icon
            ShellApi.SHFILEINFO shfi = new ShellApi.SHFILEINFO();
            ShellApi.SHGetFileInfo(null,
                ShellApi.FILE_ATTRIBUTE_DIRECTORY,
                out shfi,
                (uint)Marshal.SizeOf(shfi),
                flags);

            // Now clone the icon, so that it can be successfully stored in an ImageList
            Icon icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();

            Api.DestroyIcon(shfi.hIcon);		// Cleanup
            return icon;
        }
    }
}
