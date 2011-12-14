using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace AppLoaderBar
{
    class OperateIniFile
    {
        //返回0表示失败，非0为成功
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,string key, string val,string filePath);

        //返回取得字符串缓冲区的长度
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section,string key, string def,StringBuilder retVal,int size,string filePath);

        //返回取得数字缓冲区的长度
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileInt(string section, string key, int def, string filePath);
        
        //取 DOS8.3 格式短地址
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

        //取完整格式长地址
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLongPathName(string path, StringBuilder longPath, int longPathLength);

        //预定义配置文件
        public static string iniPaths = System.Environment.CurrentDirectory + "\\Config.INI";

        /// <summary>
        /// 读INI文件的字符数据
        /// </summary>
        /// <param name="Section">节点</param>
        /// <param name="Key">数据名</param>
        /// <param name="NoText">如空返回的文本</param>
        /// <returns></returns>
        public static string ReadIniData(string Section,string Key,string NoText)
        {
            if(File.Exists(iniPaths))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section,Key,NoText,temp,1024,iniPaths);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// 写入INI文件字符数据
        /// </summary>
        /// <param name="Section">节点</param>
        /// <param name="Key">数据名</param>
        /// <param name="Value">写入的文本</param>
        /// <returns>真/假</returns>
        public static bool WriteIniData(string Section, string Key, string Value)
        {
            if (File.Exists(iniPaths))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, iniPaths);
                if (OpStation == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 读INI文件的数字数据
        /// </summary>
        /// <param name="Section">节点</param>
        /// <param name="Key">数据名</param>
        /// <param name="NoInt">如空返回的数值</param>
        /// <returns>数值</returns>
        public static int ReadIniInt(string Section, string Key, int NoInt)
        {
            int temp = 0;
            if (File.Exists(iniPaths))
            {
                temp= (int)GetPrivateProfileInt(Section, Key, NoInt, iniPaths);
                return temp;
            }
            else
            {
                return temp;
            }
        }
    }
}
