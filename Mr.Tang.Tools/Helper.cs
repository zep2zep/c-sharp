using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Tang_s_Tools
{
    class Helper
    {
        public Helper()
        {

        }
        public string pTitle = "";

        public string PTitle
        {
            get { return pTitle; }
            set { pTitle = value; }
        }

        //�������ڴ�
        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                IntPtr lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesRead
            );

        //�򿪽���
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
            (
                int dwDesiredAccess,
                bool bInheritHandle,
                int dwProcessId
            );

        //�ر�
        [DllImport("kernel32.dll")]
        private static extern void CloseHandle
            (
                IntPtr hObject
            );

        //д�ڴ�
        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                int[] lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesWritten
            );

        // Thread proc, to be used with Create*Thread
        public delegate int ThreadProc(IntPtr param);

        // Friendly version, marshals thread-proc as friendly delegate
        [DllImport("kernel32")]
        public static extern IntPtr CreateThread(
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            ThreadProc lpStartAddress, // ThreadProc as friendly delegate
            IntPtr lpParameter,
            uint dwCreationFlags,
            out uint dwThreadId);

        // Marshal with ThreadProc's function pointer as a raw IntPtr.
        [DllImport("kernel32", EntryPoint = "CreateThread")]
        public static extern IntPtr CreateThreadRaw(
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            IntPtr lpStartAddress, // ThreadProc as raw IntPtr
            IntPtr lpParameter,
            uint dwCreationFlags,
            out uint dwThreadId);

        // CreateRemoteThread, since ThreadProc is in remote process, we must use a raw function-pointer.
        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(
          IntPtr hProcess,
          IntPtr lpThreadAttributes,
          uint dwStackSize,
          IntPtr lpStartAddress, // raw Pointer into remote process
          IntPtr lpParameter,
          uint dwCreationFlags,
          out uint lpThreadId
        );


        //ShowWindowAsync
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);

        //SetForegroundWindow
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        //��ȡ����Ľ��̱�ʶID
        public static int GetPid(string pTitle)
        {
            int pid = 0;
            Process[] arrayProcess = Process.GetProcesses();
            foreach (Process p in arrayProcess)
            {
                if (p.MainWindowTitle.StartsWith(pTitle))
                {
                    pid = p.Id;
                    break;
                }
            }
            return pid;
        }

        /// <summary>
        /// ��ȡ���̴���ı���
        /// </summary>
        /// <returns>��ȡ�ı���</returns>
        public static string GetTitle(int pProcess)
        {
            Process arrayProcess = Process.GetProcessById(pProcess);
            return arrayProcess.MainWindowTitle;
        }

        /// <summary>
        /// ��ȡ���̴���ı���
        /// </summary>
        /// <param name="pTitle">Ҫ��ı���</param>
        /// <returns>��ȡ�ı���</returns>
        public static string GetTitle(string pTitle)
        {
            string st = "";
            Process[] arrayProcess = Process.GetProcesses();
            foreach (Process p in arrayProcess)
            {
                if (p.MainWindowTitle.StartsWith(pTitle))
                {
                    st = p.MainWindowTitle;
                    break;
                }
            }
            return st;
        }

        //���ݽ�������ȡPID
        public static int GetPidByProcessName(string pName, string pTitle)
        {
            Process[] arrayProcess = Process.GetProcessesByName(pName);
            foreach (Process p in arrayProcess)
            {
                if (p.MainWindowTitle.StartsWith(pTitle))
                    return p.Id;
            }
            return 0;
        }

        //���ݽ�������ȡ������Ϣ
        public static int GetInfoByProcessName(string pName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(pName);

            foreach (Process p in arrayProcess)
            {
                string s = p.MainModule.ModuleName;
                return p.Id;
            }
            return 0;
        }

        //���ݴ��������Ҵ��ھ����֧��ģ��ƥ�䣩
        public static IntPtr FindWindow(string title)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.IndexOf(title) != -1)
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// ��ȡָ���ڴ��ַ����
        /// </summary>
        /// <param name="pAddress">�ڴ��ַ</param>
        /// <param name="pProcess">���̾��</param>
        /// <returns>��ֵ</returns>
        public static int ReadMemoryValue(int pAddress, int pProcess)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);     //��ȡ��������ַ
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, pProcess);
                ReadProcessMemory(hProcess, (IntPtr)pAddress, byteAddress, 4, IntPtr.Zero);  //���ƶ��ڴ��е�ֵ���뻺����
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ��ȡָ���ڴ��ַ�ı�
        /// </summary>
        /// <param name="pAddress">�ڴ��ַ</param>
        /// <param name="pProcess">���̾��</param>
        /// <returns>�ı�</returns>
        public static string ReadMemoryText(int pAddress, int pProcess, int bLength)
        {
            try
            {
                byte[] buffer = new byte[bLength];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);     //��ȡ��������ַ
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, pProcess);
                ReadProcessMemory(hProcess, (IntPtr)pAddress, byteAddress, buffer.Length, IntPtr.Zero);  //���ƶ��ڴ��е�ֵ���뻺����
                CloseHandle(hProcess);
                string s = System.Text.Encoding.ASCII.GetString(buffer).Replace("\0", "");
                return s;
            }
            catch
            {
                return "";
            }
        }

        //byte[] ת��ԭ16���Ƹ�ʽ��string  |  0xae00cf => "AE00CF "
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        //�ַ���ת��Ϊ����(����ֵ)���㷨��Ҫ��string�е���ĸ����Ϸ�����д��������0X����0x��ͷ
        public static int StringToInt(string s)
        {
            int startpos = 0, c = 'A' - 10, ret = 0;
            int length = s.Substring(startpos).Length;
            for (int i = startpos; i < s.Length; i++)
            {
                int b = (int)Math.Pow(16, length - i + startpos - 1), k;
                if (int.TryParse(s[i].ToString(), out k))
                    ret += k * b;
                else
                {
                    ret += (int)(s[i] - (char)c) * b;
                }
            }
            return ret;
        }

        /// <summary>
        /// ��ֵд��ָ���ڴ��ַ��
        /// </summary>
        /// <param name="pAddress">�ڴ��ַ</param>
        /// <param name="pProcess">���̾��</param>
        /// <param name="value">��ֵ</param>
        public static void WriteMemoryValue(int pAddress, int pProcess, int value)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, pProcess);      //0x1F0FFF ���Ȩ��
            WriteProcessMemory(hProcess, (IntPtr)pAddress, new int[] { value }, 4, IntPtr.Zero);
            CloseHandle(hProcess);
        }

        //�����쳣
        public static void ExceptionMsg(Exception e)
        {
            MessageBox.Show(e.ToString(), "�����쳣", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}