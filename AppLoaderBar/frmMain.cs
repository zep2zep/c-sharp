using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;

namespace AppLoaderBar
{
    public partial class frmMain : Form
    {
        private int iniSequence = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        void doDragDrop(object sender, DragEventArgs e)
        {
            // 拖放完成时 
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);   // 取得文件名
//                    StringBuilder shortPath = new StringBuilder(256);
//                    GetShortPathName(paths[0], shortPath, 256);
                    setAppLoader(paths[0],"");  //加载程序信息
                }
                catch { }
            }
        }

        void doDragEnter(object sender, DragEventArgs e)
        {
            // 拖放进入时 
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            doDragDrop(sender, e);
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            doDragEnter(sender, e);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        	//版本信息
        	this.Text += getAppVersion();
            
        	//读INI
            if (!File.Exists(OperateIniFile.iniPaths))
                File.Create(OperateIniFile.iniPaths);

            iniSequence = OperateIniFile.ReadIniInt("AppSet", "Total", 0);
            if (iniSequence < 1)
                return;
            
            for (int iSequence = 1; iSequence <= iniSequence; iSequence++)
                setAppLoader("",iSequence.ToString());
        }

        bool setAppLoader(string filepath, string sequence)
        {
            bool succes = false;  //返回的状态
            bool isnew = false; //操作标志

            if (filepath.Trim() != string.Empty)
                isnew = true;    //新建

            string sPath = "";
            string sName = "";
            string sDesc = "";

            try
            {
                StringBuilder longPath = new StringBuilder(filepath);
//                longPath = filepath.ToString();
//                GetLongPathName(filepath.Trim(), longPath, 256);
                if (isnew)
                {
                    if (File.Exists(longPath.ToString()))
                    {
                        sPath = longPath.ToString();
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(sPath);
                        sName = fvi.ProductName;
                        if(fvi.FileDescription=="")
                        	sDesc = fvi.ProductName;
                        else
                        	sDesc = fvi.FileDescription;
                    }
                }
                else 
                {
                    sName = OperateIniFile.ReadIniData(sequence, "Name", "");
                    sPath = OperateIniFile.ReadIniData(sequence, "FILE", "");
                    sDesc = OperateIniFile.ReadIniData(sequence, "DESC", "");
                }
                //string[] paths = sPath.Split('\\');
                //string filename = paths[paths.Length - 1];
                //GetFileInfomation.SHFILEINFO SHinfo = GetFileInfomation.GetSHFileInfo(sPath);
                //Icon thefileicon = Icon.FromHandle(SHinfo.hIcon);
                //if (!File.Exists(filepath))
                //        File.Create(filepath);
                Icon thefileicon = IconReader.GetFileIcon(sPath, IconReader.IconSize.Large, false);
                imageList1.Images.Add(sName, thefileicon);
                ListViewItem _Item = new ListViewItem();
                _Item.Name = sName;
                _Item.Tag = sPath;
                _Item.Text = sDesc;
                _Item.ToolTipText = sPath;
                _Item.ImageIndex = imageList1.Images.IndexOfKey(sName);
                listView1.Items.Add(_Item);

                if (isnew)
                {
                    iniSequence++;
                    OperateIniFile.WriteIniData("AppSet", "Version", getAppVersion());        //版本
                    OperateIniFile.WriteIniData("AppSet", "Total", iniSequence.ToString());	//条目 
                    OperateIniFile.WriteIniData("AppSet", "Dater", System.DateTime.Now.ToString());  //时间
                    OperateIniFile.WriteIniData(iniSequence.ToString(), "Name", sName);   //名称
                    OperateIniFile.WriteIniData(iniSequence.ToString(), "FILE", sPath);   //路径tips
                    OperateIniFile.WriteIniData(iniSequence.ToString(), "DESC", sDesc);   //注释
                }
                succes = true;
            }
            catch { return succes; }
            return succes;
        }

        /// <summary>
        /// 清除INI信息
        /// </summary>
        /// <param name="iSequence"></param>
        void clearAppLoader(int iSequence)
        {
            OperateIniFile.WriteIniData(iniSequence.ToString(), "Name", "");   //名称
            OperateIniFile.WriteIniData(iniSequence.ToString(), "FILE", "");   //路径
            OperateIniFile.WriteIniData(iniSequence.ToString(), "DESC", "");   //注释
        }

        /// <summary>
        /// 双击项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string sName = listView1.SelectedIndices.Count > 0 ? listView1.SelectedItems[0].Name : " ";
            string sDesc = listView1.SelectedIndices.Count > 0 ? listView1.SelectedItems[0].Text : " ";
            string sPath = listView1.SelectedIndices.Count > 0 ? listView1.SelectedItems[0].Tag.ToString() : " ";
            if(sPath!="")
            	System.Diagnostics.Process.Start(sPath);
        }

        private void mbox()
        {
            
        }

        /// <summary>
        /// 版本信息
        /// </summary>
        /// <returns></returns>
        string getAppVersion()
        {
            string BuildMode = String.Empty;
            Assembly asm = Assembly.GetExecutingAssembly();
            object[] objArray = asm.GetCustomAttributes(false);
            foreach (object obj in objArray)
            {
                AssemblyConfigurationAttribute conf = obj as AssemblyConfigurationAttribute;
                if (conf != null)
                    BuildMode = conf.Configuration;
            }
            Version ApplicationVersion = new Version(Application.ProductVersion);
            return BuildMode + " " + ApplicationVersion;
        }
    }
}
