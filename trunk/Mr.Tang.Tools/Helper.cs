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

        //读进程内存
        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                IntPtr lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesRead
            );

        //打开进程
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
            (
                int dwDesiredAccess,
                bool bInheritHandle,
                int dwProcessId
            );

        //关闭
        [DllImport("kernel32.dll")]
        private static extern void CloseHandle
            (
                IntPtr hObject
            );

        //写内存
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

        //获取窗体的进程标识ID
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
        /// 获取进程窗体的标题
        /// </summary>
        /// <returns>获取的标题</returns>
        public static string GetTitle(int pProcess)
        {
            Process arrayProcess = Process.GetProcessById(pProcess);
            return arrayProcess.MainWindowTitle;
        }

        /// <summary>
        /// 获取进程窗体的标题
        /// </summary>
        /// <param name="pTitle">要查的标题</param>
        /// <returns>获取的标题</returns>
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

        //根据进程名获取PID
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

        //根据进程名获取程序信息
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

        //根据窗体标题查找窗口句柄（支持模糊匹配）
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
        /// 读取指定内存地址数据
        /// </summary>
        /// <param name="pAddress">内存地址</param>
        /// <param name="pProcess">进程句柄</param>
        /// <returns>数值</returns>
        public static int ReadMemoryValue(int pAddress, int pProcess)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);     //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, pProcess);
                ReadProcessMemory(hProcess, (IntPtr)pAddress, byteAddress, 4, IntPtr.Zero);  //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 读取指定内存地址文本
        /// </summary>
        /// <param name="pAddress">内存地址</param>
        /// <param name="pProcess">进程句柄</param>
        /// <returns>文本</returns>
        public static string ReadMemoryText(int pAddress, int pProcess, int bLength)
        {
            try
            {
                byte[] buffer = new byte[bLength];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);     //获取缓冲区地址
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, pProcess);
                ReadProcessMemory(hProcess, (IntPtr)pAddress, byteAddress, buffer.Length, IntPtr.Zero);  //将制定内存中的值读入缓冲区
                CloseHandle(hProcess);
                string s = System.Text.Encoding.ASCII.GetString(buffer).Replace("\0", "");
                return s;
            }
            catch
            {
                return "";
            }
        }

        //byte[] 转成原16进制格式的string  |  0xae00cf => "AE00CF "
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

        //字符串转换为数字(返回值)的算法。要求string中的字母必须合法，大写，并且以0X或者0x开头
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
        /// 将值写入指定内存地址中
        /// </summary>
        /// <param name="pAddress">内存地址</param>
        /// <param name="pProcess">进程句柄</param>
        /// <param name="value">数值</param>
        public static void WriteMemoryValue(int pAddress, int pProcess, int value)
        {
            IntPtr hProcess = OpenProcess(0x1F0FFF, false, pProcess);      //0x1F0FFF 最高权限
            WriteProcessMemory(hProcess, (IntPtr)pAddress, new int[] { value }, 4, IntPtr.Zero);
            CloseHandle(hProcess);
        }

        //捕获异常
        public static void ExceptionMsg(Exception e)
        {
            MessageBox.Show(e.ToString(), "捕获异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}