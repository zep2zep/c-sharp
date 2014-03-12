using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace AppLoaderBar
{
    class OperateIniFile
    {
        //����0��ʾʧ�ܣ���0Ϊ�ɹ�
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,string key, string val,string filePath);

        //����ȡ���ַ����������ĳ���
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section,string key, string def,StringBuilder retVal,int size,string filePath);

        //����ȡ�����ֻ������ĳ���
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileInt(string section, string key, int def, string filePath);
        
        //ȡ DOS8.3 ��ʽ�̵�ַ
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

        //ȡ������ʽ����ַ
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLongPathName(string path, StringBuilder longPath, int longPathLength);

        //Ԥ���������ļ�
        public static string iniPaths = System.Environment.CurrentDirectory + "\\Config.INI";

        /// <summary>
        /// ��INI�ļ����ַ�����
        /// </summary>
        /// <param name="Section">�ڵ�</param>
        /// <param name="Key">������</param>
        /// <param name="NoText">��շ��ص��ı�</param>
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
        /// д��INI�ļ��ַ�����
        /// </summary>
        /// <param name="Section">�ڵ�</param>
        /// <param name="Key">������</param>
        /// <param name="Value">д����ı�</param>
        /// <returns>��/��</returns>
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
        /// ��INI�ļ�����������
        /// </summary>
        /// <param name="Section">�ڵ�</param>
        /// <param name="Key">������</param>
        /// <param name="NoInt">��շ��ص���ֵ</param>
        /// <returns>��ֵ</returns>
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

        /// <summary>
        /// ���������ֵ��
        /// </summary>
        /// <param name="sectionName">Ҫ���õ������ơ�����ִ������ִ�Сд��</param>
        /// <param name="keyName">Ҫ����������ơ�����ִ������ִ�Сд��</param>
        public static void ClearKeyValue(string sectionName, string keyName)
        {
            WritePrivateProfileString(sectionName, keyName, null, iniPaths);
        }
        
        /// <summary>
        /// ɾ�����С�ڵ����������
        /// </summary>
        /// <param name="sectionName">Ҫɾ���Ľڵ���������ִ������ִ�Сд��</param>
        public static void DeleteSection(string sectionName)
        {
            WritePrivateProfileString(sectionName, null, null, iniPaths);
        }
    }
}
