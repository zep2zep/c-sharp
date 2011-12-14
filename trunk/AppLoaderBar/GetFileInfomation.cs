using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using DWORD = System.UInt32;

namespace AppLoaderBar
{
    class GetFileInfomation
    {
        //ȡ�ļ���Ϣ
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbSizeFileInfo, int uFlags);

        [DllImport("version.dll")]
        public static extern int GetFileVersionInfoSize(string sFileName,
        out int handle);

        [DllImport("version.dll")]
        private static extern int GetFileVersionInfo(
        string lpstrFilename,
        int dwHandle,
        int dwLen,
        byte[] lpData);

        [DllImport("version.dll")]
        unsafe public static extern bool VerQueryValue (byte[] pBlock, string pSubBlock, out short *pValue, out uint len);

        //���Բ��Ե�����
        /*
        CompanyName 
        FileDescription 
        FileVersion 
        InternalName 
        LegalCopyright
        OriginalFilename
        ProductName 
        ProductVersion 
        Comments
        LegalTrademarks 
        PrivateBuild 
        SpecialBuild 
        */

        //����ṹSHFILEINFO
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        //�����ļ����Ա�ʶ
        public enum FileAttributeFlags : int
        {
            FILE_ATTRIBUTE_READONLY = 0x00000001,
            FILE_ATTRIBUTE_HIDDEN = 0x00000002,
            FILE_ATTRIBUTE_SYSTEM = 0x00000004,
            FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
            FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
            FILE_ATTRIBUTE_DEVICE = 0x00000040,
            FILE_ATTRIBUTE_NORMAL = 0x00000080,
            FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
            FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
            FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
            FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
            FILE_ATTRIBUTE_OFFLINE = 0x00001000,
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
            FILE_ATTRIBUTE_ENCRYPTED = 0x00004000
        }

        //�����ȡ��Դ��ʶ
        public enum SHGFI : int
        {
            SHGFI_ICON = 0x000000100,                         // ��ȡͼ��
            SHGFI_DISPLAYNAME = 0x000000200,          // ��ȡ��ʾ����
            SHGFI_TYPENAME = 0x000000400,                // ��ȡ��������
            SHGFI_ATTRIBUTES = 0x000000800,               // ��ȡ����
            SHGFI_ICONLOCATION = 0x000001000,        // ��ȡͼ��λ��
            SHGFI_EXETYPE = 0x000002000,                     // ���� exe ����
            SHGFI_SYSICONINDEX = 0x000004000,         // ��ȡϵͳͼ������
            SHGFI_LINKOVERLAY = 0x000008000,            // put a link overlay on icon
            SHGFI_SELECTED = 0x000010000,                   // ��ʾ����ѡ��״̬��ͼ��
            SHGFI_ATTR_SPECIFIED = 0x000020000,         // ��ȡ��ָ������
            SHGFI_LARGEICON = 0x000000000,               // ��ȡ��ͼ��
            SHGFI_SMALLICON = 0x000000001,              // ��ȡСͼ��
            SHGFI_OPENICON = 0x000000002,                // ��ȡ��ͼ��
            SHGFI_SHELLICONSIZE = 0x000000004,         // ��ȡ�Ǵ�Сͼ��
            SHGFI_PIDL = 0x000000008,                           // pszPath is a pidl
            SHGFI_USEFILEATTRIBUTES = 0x000000010,   // use passed dwFileAttribute
            SHGFI_ADDOVERLAYS = 0x000000020,          // Ӧ���ʵ��ĵ���
            SHGFI_OVERLAYINDEX = 0x000000040          // ȡ�õ��ӵ�����
        }

        public static SHFILEINFO GetSHFileInfo(string fileName)
        {
            //��ʼ��SHFILEINFO�ṹ
            SHFILEINFO shfi = new SHFILEINFO();
            SHGetFileInfo(fileName, (int)FileAttributeFlags.FILE_ATTRIBUTE_NORMAL, ref shfi, Marshal.SizeOf(shfi), (int)SHGFI.SHGFI_ATTR_SPECIFIED);
            return shfi;
        }

        unsafe public static string GetEXEFileInfo(string fileName)
        {
            try
            {
                int handle = 0;
                // Figure out how much version info there is:
                int size = GetFileVersionInfoSize(fileName, out handle);

                if (size == 0)
                    return "";

                byte[] buffer = new byte[size];
                int iRtn = GetFileVersionInfo(fileName, handle, size, buffer);
                if (iRtn == 1)
                {
                    return "Failed to query file version information.";
                }

                short* subBlock = null;
                uint len = 0;
                // Get the locale info from the version info:
                if (!VerQueryValue(buffer, @"\VarFileInfo\Translation", out subBlock, out len))
                {
                    return "Failed to query version information.";
                }

                string spv = @"\StringFileInfo\" + subBlock[0].ToString("X4") + subBlock[1].ToString("X4") + @"\ProductVersion";

                byte* pVersion = null;
                // Get the ProductVersion value for this program:
                short* versionInfo;
                if (!VerQueryValue(buffer, spv, out versionInfo, out len))
                {
                    return "Failed to query version information.";
                }

                return "ProductVersion == {0}";
            }
            catch
            {
                return "Caught unexpected exception ";
            }
        }
    }
}
