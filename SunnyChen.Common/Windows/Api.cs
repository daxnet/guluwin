using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace SunnyChen.Common.Windows
{
    public static class Api
    {
        public const int MAX_PATH = 206;
        public const int MAX_ALTERNATE = 14;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_STYLE = -16;
        public const int WS_EX_MDICHILD = 0x00000040;
        public const int WS_CHILD = 0x40000000;

        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        #region FindFirstFile and FileNextFile

        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ALTERNATE)]
            public string cAlternate;
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll")]
        public static extern bool FindClose(IntPtr hFindFile);

        #region SampleCode for FindFirstFile and FindNextFile
        //private long RecurseDirectory(string directory, int level, out int files, out int folders)
        //{
        //    IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        //    long size = 0;
        //    files = 0;
        //    folders = 0;
        //    Kernel32.WIN32_FIND_DATA findData;

        //    IntPtr findHandle;

        //    // please note that the following line won't work if you try this on a network folder, like \\Machine\C$
        //    // simply remove the \\?\ part in this case or use \\?\UNC\ prefix
        //    findHandle = Kernel32.FindFirstFile(@"\\?\" + directory + @"\*", out findData);
        //    if (findHandle != INVALID_HANDLE_VALUE)
        //    {

        //        do
        //        {
        //            if ((findData.dwFileAttributes & FileAttributes.Directory) != 0)
        //            {

        //                if (findData.cFileName != "." && findData.cFileName != "..")
        //                {
        //                    folders++;

        //                    int subfiles, subfolders;
        //                    string subdirectory = directory + (directory.EndsWith(@"\") ? "" : @"\") +
        //                        findData.cFileName;
        //                    if (level != 0)  // allows -1 to do complete search.
        //                    {
        //                        size += RecurseDirectory(subdirectory, level - 1, out subfiles, out subfolders);

        //                        folders += subfolders;
        //                        files += subfiles;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                // File
        //                files++;

        //                size += (long)findData.nFileSizeLow + (long)findData.nFileSizeHigh * 4294967296;
        //            }
        //        }
        //        while (Kernel32.FindNextFile(findHandle, out findData));
        //        Kernel32.FindClose(findHandle);

        //    }

        //    return size;
        //}
        #endregion

        #endregion

        #region ExitWindowsEx

        public enum ExitWindowsAction
        {
            EWX_LOGOFF = 0,
            EWX_SHUTDOWN = 1,
            EWX_REBOOT = 2,
            EWX_FORCE = 4,
            EWX_POWEROFF = 8
        }

        [DllImport("aygshell.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ExitWindowsEx([MarshalAs(UnmanagedType.U4)] ExitWindowsAction uFlags, [MarshalAs(UnmanagedType.U4)] uint dwReserved);

        #endregion

        #region MessageBeep
        public enum beepType
        {
            /// <summary>
            /// A simple windows beep
            /// </summary>            
            SimpleBeep = -1,
            /// <summary>
            /// A standard windows OK beep
            /// </summary>
            OK = 0x00,
            /// <summary>
            /// A standard windows Question beep
            /// </summary>
            Question = 0x20,
            /// <summary>
            /// A standard windows Exclamation beep
            /// </summary>
            Exclamation = 0x30,
            /// <summary>
            /// A standard windows Asterisk beep
            /// </summary>
            Asterisk = 0x40,
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool MessageBeep(uint uType);
        #endregion

        #region DestroyIcon
        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
        #endregion

        #region SendMessage
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(
               int hWnd,　　　// handle to destination window 
               int Msg,　　　 // message 
               int wParam,　// first message parameter 
               int lParam // second message parameter 
         );
        #endregion

        #region SetForegroundWindow
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);
        #endregion

        #region FindWindow
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        #endregion

        #region SetWindowLong
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        #endregion

        #region GetWindowLong
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        #endregion

        #region SetParent
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        #endregion

    }
}
