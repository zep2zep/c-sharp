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
                    setAppLoader(paths[0], "");  //加载程序信息
                }
                catch { }
                finally { readAppLoaderIni(); }
            }
        }

        void doDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
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
            //加载ini
            readAppLoaderIni();
        }

        void readAppLoaderIni()
        {
            //读INI
            if (!File.Exists(OperateIniFile.iniPaths))
                File.Create(OperateIniFile.iniPaths);

            listView1.Items.Clear();
            iniSequence = OperateIniFile.ReadIniInt("AppSet", "Total", 0);
            if (iniSequence < 1)
                return;

            for (int iSequence = 1; iSequence <= iniSequence; iSequence++)
                setAppLoader("", iSequence.ToString());
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
                        string[] paths = sPath.Split('\\');
                        string filename = paths[paths.Length - 1];    //文件名
                        if (filename.ToLower().EndsWith(".lnk"))
                        {
                            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)
                            shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(sPath);
                            sPath = shortcut.TargetPath;
                        }
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(sPath);
                        sName = filename + " - "+fvi.ProductName;
                        if(fvi.FileDescription != "" && fvi.FileDescription != null)
                            sDesc = fvi.FileDescription;
                        else if (fvi.ProductName != "" && fvi.ProductName != null)
                            sDesc = fvi.ProductName;
                        else
                            sDesc = fvi.FileName;
                    }
                }
                else 
                {
                    sName = OperateIniFile.ReadIniData(sequence, "Name", "");
                    sPath = OperateIniFile.ReadIniData(sequence, "FILE", "");
                    sDesc = OperateIniFile.ReadIniData(sequence, "DESC", "");
                    if (string.IsNullOrEmpty(sPath))
                        return succes;
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
                _Item.Tag = sequence;
                _Item.Text = sDesc;
                _Item.ToolTipText = sPath;
                _Item.ImageIndex = imageList1.Images.IndexOfKey(sName);
                listView1.Items.Add(_Item);

                if (isnew)
                {
                    iniSequence++;
                    OperateIniFile.WriteIniData("AppSet", "Version", getAppVersion());        //版本
                    OperateIniFile.WriteIniData("AppSet", "Total", iniSequence.ToString());	//条目 
                    OperateIniFile.WriteIniData("AppSet", "Last Date", System.DateTime.Now.ToString());  //时间
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
            OperateIniFile.DeleteSection(iSequence.ToString());
            iniSequence = OperateIniFile.ReadIniInt("AppSet", "Total", 0);
            OperateIniFile.WriteIniData("AppSet", "Version", getAppVersion());              //版本
            OperateIniFile.WriteIniData("AppSet", "Total", Convert.ToString(iniSequence-1));     //条目 
            OperateIniFile.WriteIniData("AppSet", "Last Date", System.DateTime.Now.ToString());  //时间
            readAppLoaderIni();
        }

        /// <summary>
        /// 双击项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string sName = listView1.SelectedIndices.Count > 0 ? listView1.SelectedItems[0].Name : " ";
                string sDesc = listView1.SelectedIndices.Count > 0 ? listView1.SelectedItems[0].Text : " ";
                string sPath = listView1.SelectedIndices.Count > 0 ? listView1.SelectedItems[0].ToolTipText : " ";
                if (sPath != "")
                    System.Diagnostics.Process.Start(sPath);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
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
            return " ("+BuildMode + " " + ApplicationVersion+")";
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listView1_DragLeave(object sender, EventArgs e)
        {
            //int iTag = -1;
            //try
            //{
            //    if (listView1.SelectedIndices.Count > 0)
            //        iTag = Convert.ToInt32(listView1.SelectedItems[0].Tag);
            //}
            //catch(Exception ex) { MessageBox.Show(ex.Message); }
            //if (iTag>-1)
            //    clearAppLoader(iTag);
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int iTag = -1;
                try
                {
                    if (listView1.SelectedIndices.Count > 0)
                        iTag = Convert.ToInt32(listView1.SelectedItems[0].Tag);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                if (iTag > -1)
                    clearAppLoader(iTag);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.TopMost = !TopMost;
            toolStripMenuItem1.Checked = this.TopMost;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices.Count == 1)
                {
                    toolStripMenuItem1.Visible = false;
                    toolStripMenuItem2.Visible = true;
                }
                else
                {
                    toolStripMenuItem1.Visible = true;
                    toolStripMenuItem2.Visible = false;
                }
            }
            catch (Exception ex) { toolStripMenuItem2.Enabled = false; }  
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int iTag = -1;
            try
            {
                if (listView1.SelectedIndices.Count > 0)
                    iTag = Convert.ToInt32(listView1.SelectedItems[0].Tag);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            if (iTag > -1)
                clearAppLoader(iTag);
        }
    }
}
