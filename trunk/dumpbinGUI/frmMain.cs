using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace dumpbinGUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);
        
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLongPathName(string path, StringBuilder longPath, int longPathLength);

        // 拖放进入时
        void doDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // 拖放完成时
        void doDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    string[] droppaths = (string[])e.Data.GetData(DataFormats.FileDrop);   // 取得文件名
                    string[] paths = droppaths[0].Split('\\');
               		string filename = paths[paths.Length - 1];
                    StringBuilder shortPath = new StringBuilder(256);
                    GetShortPathName(droppaths[0], shortPath, 256);
                    ListItem item = new ListItem(filename,shortPath.ToString());
					comboBox1.Items.Insert(0,item);
					comboBox1.DisplayMember = "Key";
					comboBox1.ValueMember = "Value";
					comboBox1.SelectedIndex = 0;
                    dumpBinFile(shortPath.ToString());
                }
                catch { }
            }
        }

        /// <summary>
        ///  dumpbin 的方法
        /// </summary>
        /// <param name="binPath">Bin文件地址</param>
        void dumpBinFile(string binPath)
        {
            Process p = new Process();

            p.StartInfo.FileName = @"dumpbin.exe";
            p.StartInfo.Arguments = "/exports " + binPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.ErrorDialog = true;
            string strOutput = null;

            try
            {
                p.Start();
                strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            StringBuilder longPath = new StringBuilder(256);
            GetLongPathName(binPath, longPath, 256);
            strOutput = strOutput.Replace("Microsoft (R) COFF/PE Dumper Version 8.00.50727.762\r\n", "");
            strOutput = strOutput.Replace("Copyright (C) Microsoft Corporation.  All rights reserved.\r\n\r\n", "");
            txtdumpInfo.Text = strOutput.Replace(binPath,longPath.ToString());
        }
        
        void TxtdumpInfoKeyDown(object sender, KeyEventArgs e)
        {
        	if(e.Control && ((e.KeyData & Keys.A)==Keys.A))
            {
                this.txtdumpInfo.SelectionStart = 0;
                this.txtdumpInfo.SelectionLength = this.txtdumpInfo.Text.Length;
            }
        }
        
        void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
        {
        	string sName = ((ListItem)comboBox1.SelectedItem).Key.ToString();
			string sUrl = ((ListItem)comboBox1.SelectedItem).Value.ToString();
			if(sUrl=="")
				return;
			dumpBinFile(sUrl);
        }
        
        private void txtdumpInfo_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtdumpInfo.SelectedText.Trim() == "")
                return;

            string s = txtdumpInfo.SelectedText.Trim();
            bool a = s.IndexOf(" ") == -1;
            bool b = s.StartsWith("?");
            bool c = s.StartsWith("_");
            if (a&&(b||c))
            {
                undname(txtdumpInfo.SelectedText);
            }
        }

        /// <summary>
        ///  undname 的方法
        /// </summary>
        /// <param name="dname">dname</param>
        void undname(string dname)
        {
            Process p = new Process();

            p.StartInfo.FileName = @"undname.exe";
            p.StartInfo.Arguments = dname;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.ErrorDialog = true;
            string strOutput = null;

            try
            {
                p.Start();
                strOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            strOutput = strOutput.Replace("Microsoft (R) C++ Name Undecorator\r\n", "");
            strOutput = strOutput.Replace("Copyright (C) Microsoft Corporation. All rights reserved.\r\n\r\n", "");
            txtundName.Text = strOutput.TrimEnd();
        }
        
        void FrmMainLoad(object sender, EventArgs e)
        {
        	string BuildMode = String.Empty;
	        Assembly asm = Assembly.GetExecutingAssembly();
	        object[] objArray = asm.GetCustomAttributes(false) ;
	        foreach (object obj in objArray)
	        {
	        	AssemblyConfigurationAttribute conf = obj as AssemblyConfigurationAttribute;
	        	if (conf != null)
	        		BuildMode = conf.Configuration;
	        }
	        Version ApplicationVersion = new Version(Application.ProductVersion);
	        this.Text += "  "+BuildMode + " " + ApplicationVersion;
        }
    }
    
    public class ListItem
	{
		private string _key = string.Empty;
		private string _value = string.Empty;

		public ListItem(string pKey, string pValue)
		{
			_key = pKey;
			_value = pValue;
		}

		public override string ToString()
		{
			return this._value;
		}

		public string Key
		{
			get
			{
				return this._key;
			}
			set
			{
				this._key = value;
			}
		}

		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}
	}
}
