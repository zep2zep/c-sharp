using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tang_s_Tools
{
    public partial class FrmProcessSelect : Form
    {
        public ListView lvProcess;
        private ColumnHeader PID;
        private ColumnHeader ProcessName;
        private ColumnHeader ProcessTitleName;
        public Process resultProcess = null;

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lvProcess = new System.Windows.Forms.ListView();
            this.PID = new System.Windows.Forms.ColumnHeader();
            this.ProcessName = new System.Windows.Forms.ColumnHeader();
            this.ProcessTitleName = new System.Windows.Forms.ColumnHeader();
            this.ProcessPath = new System.Windows.Forms.ColumnHeader();
            this.ProcessBaseAddress = new System.Windows.Forms.ColumnHeader();
            this.ProcessEntryPointAddress = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvProcess
            // 
            this.lvProcess.AllowColumnReorder = true;
            this.lvProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PID,
            this.ProcessName,
            this.ProcessTitleName,
            this.ProcessPath,
            this.ProcessBaseAddress,
            this.ProcessEntryPointAddress});
            this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcess.FullRowSelect = true;
            this.lvProcess.GridLines = true;
            this.lvProcess.Location = new System.Drawing.Point(0, 0);
            this.lvProcess.Name = "lvProcess";
            this.lvProcess.Size = new System.Drawing.Size(544, 333);
            this.lvProcess.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvProcess.TabIndex = 0;
            this.lvProcess.UseCompatibleStateImageBehavior = false;
            this.lvProcess.View = System.Windows.Forms.View.Details;
            this.lvProcess.DoubleClick += new System.EventHandler(this.lvProcess_DoubleClick);
            this.lvProcess.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProcess_ColumnClick);
            // 
            // PID
            // 
            this.PID.Text = "PID";
            this.PID.Width = 48;
            // 
            // ProcessName
            // 
            this.ProcessName.Text = "进程名";
            this.ProcessName.Width = 120;
            // 
            // ProcessTitleName
            // 
            this.ProcessTitleName.Text = "标题";
            this.ProcessTitleName.Width = 120;
            // 
            // ProcessPath
            // 
            this.ProcessPath.Text = "路径";
            this.ProcessPath.Width = 120;
            // 
            // ProcessBaseAddress
            // 
            this.ProcessBaseAddress.Text = "地址";
            // 
            // ProcessEntryPointAddress
            // 
            this.ProcessEntryPointAddress.Text = "入口点";
            // 
            // FrmProcessSelect
            // 
            this.ClientSize = new System.Drawing.Size(544, 333);
            this.Controls.Add(this.lvProcess);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProcessSelect";
            this.ShowInTaskbar = false;
            this.Text = "ProcessSelect";
            this.ResumeLayout(false);

        }

        #endregion

        public FrmProcessSelect()
        {
            InitializeComponent();
            Process[] processes = Process.GetProcesses();
            ListViewItem item = null;
            Application.DoEvents();
            foreach (Process process in processes)
            {
                string pId = process.Id.ToString();
                while (pId.Length < 5)
                {
                    pId = " " + pId;
                }
                string sDesc = "";
                string sBaseAddress = "";
                string sEntryPointAddress = "";
                try
                {
                    sDesc = process.MainModule.FileName;
                    sBaseAddress = process.MainModule.BaseAddress.ToString("X");
                    sEntryPointAddress = process.MainModule.EntryPointAddress.ToString("X");
                }
                catch
                { sDesc = ""; }
                if (process.SessionId!=0)
                {
                    item = new ListViewItem(new string[] { pId, process.ProcessName, process.MainWindowTitle, sDesc, sBaseAddress, sEntryPointAddress });
                    this.lvProcess.Items.Add(item);
                }
            }
        }
        private void lvProcess_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                this.lvProcess.ListViewItemSorter = new MyComparer(e.Column, true);
            }
            else
            {
                this.lvProcess.ListViewItemSorter = new MyComparer(e.Column, false);
            }
        }

        private void lvProcess_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.resultProcess = Process.GetProcessById(int.Parse(this.lvProcess.SelectedItems[0].Text));
            }
            catch
            {
                return;
            }
            base.DialogResult = DialogResult.OK;
        }
    }
}