using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace _GUIDGenerator
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frm_GUIDGenerator : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.TextBox txtAmount;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnSingleGen;
		private System.Windows.Forms.Button btnMultiGen;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtGUID;
		private System.Windows.Forms.TextBox txtLens;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		string[] sName = {"横杠","无","小括号","大括号"};
		string[] sFormat = {"D","N","P","B"};
		string sCF;	//格式
		private System.Windows.Forms.ProgressBar progressBar1;	
		int iMax = 9999;	//最大数

		//ShowWindowAsync
		[DllImport("User32.dll")] 
		private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow); 

		//SetForegroundWindow
		[DllImport("User32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		public frm_GUIDGenerator()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnMultiGen = new System.Windows.Forms.Button();
			this.txtGUID = new System.Windows.Forms.TextBox();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.btnCopy = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnSingleGen = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLens = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnMultiGen
			// 
			this.btnMultiGen.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.btnMultiGen.ForeColor = System.Drawing.SystemColors.ControlText;
			this.errorProvider1.SetIconAlignment(this.btnMultiGen, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
			this.btnMultiGen.Location = new System.Drawing.Point(304, 169);
			this.btnMultiGen.Name = "btnMultiGen";
			this.btnMultiGen.Size = new System.Drawing.Size(48, 23);
			this.btnMultiGen.TabIndex = 1;
			this.btnMultiGen.Text = "生成";
			this.toolTip1.SetToolTip(this.btnMultiGen, "点击生成GUID");
			this.btnMultiGen.Click += new System.EventHandler(this.btnMultiGen_Click);
			// 
			// txtGUID
			// 
			this.txtGUID.BackColor = System.Drawing.Color.Beige;
			this.txtGUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGUID.HideSelection = false;
			this.txtGUID.Location = new System.Drawing.Point(40, 11);
			this.txtGUID.Multiline = true;
			this.txtGUID.Name = "txtGUID";
			this.txtGUID.ReadOnly = true;
			this.txtGUID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtGUID.Size = new System.Drawing.Size(250, 305);
			this.txtGUID.TabIndex = 3;
			this.txtGUID.Text = "";
			this.txtGUID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGUID_KeyDown);
			this.txtGUID.TextChanged += new System.EventHandler(this.txtGUID_TextChanged);
			this.txtGUID.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.txtGUID_MouseWheel);
			this.txtGUID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtGUID_MouseUp);
			// 
			// txtAmount
			// 
			this.txtAmount.AcceptsReturn = true;
			this.txtAmount.BackColor = System.Drawing.Color.Cornsilk;
			this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAmount.Location = new System.Drawing.Point(296, 137);
			this.txtAmount.MaxLength = 4;
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(48, 21);
			this.txtAmount.TabIndex = 0;
			this.txtAmount.Text = "1";
			this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip1.SetToolTip(this.txtAmount, "生成数量");
			// 
			// btnCopy
			// 
			this.btnCopy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.errorProvider1.SetIconAlignment(this.btnCopy, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
			this.btnCopy.Location = new System.Drawing.Point(304, 200);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(48, 23);
			this.btnCopy.TabIndex = 2;
			this.btnCopy.Text = "复制";
			this.toolTip1.SetToolTip(this.btnCopy, "复制GUID到剪贴板");
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// toolTip1
			// 
			this.toolTip1.ShowAlways = true;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(40, 312);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(250, 18);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 13;
			this.toolTip1.SetToolTip(this.progressBar1, "正在生成");
			// 
			// btnSingleGen
			// 
			this.btnSingleGen.Location = new System.Drawing.Point(304, 9);
			this.btnSingleGen.Name = "btnSingleGen";
			this.btnSingleGen.Size = new System.Drawing.Size(48, 23);
			this.btnSingleGen.TabIndex = 4;
			this.btnSingleGen.Text = "单条";
			this.btnSingleGen.Click += new System.EventHandler(this.btnSingleGen_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(304, 41);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(48, 24);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "大写";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(296, 121);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "数量";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(304, 288);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 40);
			this.label2.TabIndex = 7;
			// 
			// comboBox1
			// 
			this.comboBox1.BackColor = System.Drawing.Color.Cornsilk;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(296, 89);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(56, 20);
			this.comboBox1.TabIndex = 8;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(296, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "格式";
			// 
			// txtLens
			// 
			this.txtLens.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLens.Cursor = System.Windows.Forms.Cursors.Cross;
			this.txtLens.Enabled = false;
			this.txtLens.HideSelection = false;
			this.txtLens.Location = new System.Drawing.Point(8, 13);
			this.txtLens.Multiline = true;
			this.txtLens.Name = "txtLens";
			this.txtLens.ReadOnly = true;
			this.txtLens.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtLens.Size = new System.Drawing.Size(24, 305);
			this.txtLens.TabIndex = 10;
			this.txtLens.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(296, 232);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 11;
			this.label4.Text = "行号";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.numericUpDown1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.numericUpDown1.Location = new System.Drawing.Point(296, 248);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(56, 21);
			this.numericUpDown1.TabIndex = 12;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.numericUpDown1.Click += new System.EventHandler(this.numericUpDown1_ValueChanged);
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// frm_GUIDGenerator
			// 
			this.AcceptButton = this.btnMultiGen;
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(358, 326);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtLens);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtAmount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.btnSingleGen);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnMultiGen);
			this.Controls.Add(this.txtGUID);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frm_GUIDGenerator";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = ".Net GUID Generator";
			this.Load += new System.EventHandler(this.frm_GUIDGenerator_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			bool appIsRunning;
			Mutex mutex = new System.Threading.Mutex(true, @"Local\GUIDGenerator", out appIsRunning);
			if(appIsRunning)
			{
				Application.EnableVisualStyles();
				Application.Run(new frm_GUIDGenerator());
				mutex.ReleaseMutex();
			}
			else
			{
				Process cp = Process.GetCurrentProcess();
				Process[] p = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
				foreach (Process ps in p)
				{
					try
					{
						if(ps.Id != cp.Id)
						{
							IntPtr hWnd = ps.MainWindowHandle;	//取句柄
							ShowWindowAsync(hWnd, 1);	//调用api函数，正常显示窗口 
							SetForegroundWindow(hWnd);	//将窗口放置最前端。 
						}
					}
					catch(Exception eX)
					{
						MessageBox.Show(eX.Message);
					}
					finally
					{
						Application.Exit();
					}
				}
			}	
		}

		/// <summary>
		/// 窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frm_GUIDGenerator_Load(object sender, System.EventArgs e)
		{
			try
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
				label2.Text = BuildMode + " " + ApplicationVersion;
				for(int x=0;x<sFormat.Length;x++)
				{
					ListItem item = new ListItem(sName[x],sFormat[x]);
					comboBox1.Items.Add(item);
				}
				this.comboBox1.DisplayMember = "Key";
				this.comboBox1.ValueMember = "Value";
				this.comboBox1.SelectedIndex = 0;
				txtGUID.Text = System.Guid.NewGuid().ToString();
			}
			catch(Exception eX)
			{
				MessageBox.Show(eX.Message);
			}
		}

		/// <summary>
		/// 单条并拷贝
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSingleGen_Click(object sender, System.EventArgs e)
		{
			txtGUID.Text = System.Guid.NewGuid().ToString(sCF);
			setLowerOrUpper(txtGUID.Text);
			Clipboard.SetDataObject(txtGUID.Text,true);
		}

		/// <summary>
		/// 单选 - 大/小写
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
//			setLowerOrUpper(txtGUID.Text);
			ThreadStart start = new ThreadStart(DoCheck);
			Thread thread = new Thread(start);
			thread.Start(); 
		}

		/// <summary>
		/// 线程 单选 - 大/小写
		/// </summary>
		private void DoCheck()
		{
			txtGUID.Enabled = false;
			string sGUID = "";
			int iNbr = txtGUID.Lines.Length;
		
			progressBar1.Value = 0;
			progressBar1.Maximum = iNbr;
			//耗时操作
			while(iNbr>0)
			{
				if(checkBox1.Checked==true)
				{
					if(sGUID=="")
						sGUID += txtGUID.Lines[progressBar1.Maximum-iNbr].ToUpper();
					else
						sGUID += "\r\n"+txtGUID.Lines[progressBar1.Maximum-iNbr].ToUpper();
					iNbr--; 
				}
				else
				{
					if(sGUID=="")
						sGUID += txtGUID.Lines[progressBar1.Maximum-iNbr].ToLower();
					else
						sGUID += "\r\n"+txtGUID.Lines[progressBar1.Maximum-iNbr].ToLower();
					iNbr--; 
				}
				progressBar1.Value = progressBar1.Maximum-iNbr;
			}
			SyncLines(false);
			txtGUID.Text = sGUID;
			txtGUID.Enabled = true;
		}

		/// <summary>
		/// 生成多条
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMultiGen_Click(object sender, System.EventArgs e)
		{
			int iNbr = 0;
			if(IsInt(txtAmount.Text.Trim()))
				iNbr = Convert.ToInt32(txtAmount.Text.Trim());
			if(iNbr<1 || iNbr>iMax)
			{
				errorProvider1.Dispose();
				errorProvider1.SetError(txtAmount, "数量错误! 1-"+iMax);
				return;
			}
			
			ThreadStart start = new ThreadStart(DoGen);
			Thread thread = new Thread(start);
			thread.Start(); 
				
//			setLowerOrUpper(sGUID);
		}
		
		/// <summary>
		/// 线程生成多条
		/// </summary>
		private void DoGen()
		{
			txtGUID.Enabled = false;
			string sGUID = "";
			int iNbr = Convert.ToInt32(txtAmount.Text.Trim());
			
			progressBar1.Value = 0;
			progressBar1.Maximum = iNbr;
			//耗时操作
			while(iNbr>0)
			{
				if(sGUID=="")
					sGUID += System.Guid.NewGuid().ToString(sCF);
				else
					sGUID += "\r\n"+System.Guid.NewGuid().ToString(sCF);
				iNbr--; 
				progressBar1.Value = progressBar1.Maximum-iNbr;
			}
			setLowerOrUpper(sGUID);
		}

		/// <summary>
		/// 改变格式
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ThreadStart start = new ThreadStart(DoChang);
			Thread thread = new Thread(start);
			thread.Start(); 
		}

		/// <summary>
		/// 线程改变格式
		/// </summary>
		private void DoChang()
		{
			txtGUID.Enabled = false;
			sCF = ((ListItem)comboBox1.SelectedItem).Value.ToString();
			if(txtGUID.Lines.Length<1)
				return;
			progressBar1.Value = 0;
			progressBar1.Maximum = txtGUID.Lines.Length;
			string sGUID = "";
			foreach (string tx in txtGUID.Lines)
			{
				Guid g = new Guid(tx.Replace("\r\n",""));
				if(sGUID=="")
					sGUID += g.ToString(sCF);
				else
					sGUID += "\r\n"+g.ToString(sCF);

				progressBar1.Value = progressBar1.Value+1;
			}
			setLowerOrUpper(sGUID);
		}

		/// <summary>
		/// 复制
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			if(txtGUID.Text.Trim()!="")
			{
				Clipboard.SetDataObject(txtGUID.Text,true);
				errorProvider1.Dispose();
			}
			else
				errorProvider1.SetError(txtGUID,"点击生成GUID");
		}

		/// <summary>
		/// 全选
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtGUID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Control && ((e.KeyData & Keys.A)==Keys.A))
			{
				this.txtGUID.SelectionStart = 0; 
				this.txtGUID.SelectionLength = this.txtGUID.Text.Length;
//				SyncLines(true);
			}
		}

		/// <summary>
		/// 滚动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtGUID_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				//上滚滑轮 Min
				if((numericUpDown1.Value-1)>=numericUpDown1.Minimum)
					numericUpDown1.Value = numericUpDown1.Value-1;
			}
			else
			{
				//下滚滑轮 Max
				if((numericUpDown1.Value+1)<=numericUpDown1.Maximum)
					numericUpDown1.Value = numericUpDown1.Value+1;
			}
		}

		/// <summary>
		/// 改变Guid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtGUID_TextChanged(object sender, System.EventArgs e)
		{
			setGUIDLines();
		}

		/// <summary>
		/// 选择行号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			SyncLines(true);
		}

		/// <summary>
		/// 验证非负整数（正整数 + 0）
		/// </summary>
		/// <param name="input">要验证的字符对象</param>
		/// <returns>验证通过返回true</returns>
		public static bool IsInt(string input)
		{
			return Regex.IsMatch(input,@"^\d+$");
		}

		/// <summary>
		/// 设置大小写
		/// </summary>
		void setLowerOrUpper(string strGuid)
		{
			if(checkBox1.Checked==true)
				txtGUID.Text = strGuid.ToUpper();
			else
				txtGUID.Text = strGuid.ToLower();
			SyncLines(false);
			txtGUID.Enabled = true;
		}

		/// <summary>
		/// 设置行号
		/// </summary>
		void setGUIDLines()
		{
			int iLength = txtGUID.Lines.Length;
			int iLines = 0;
			string sLens = "";
			while(iLength>0)
			{
				iLines ++;
				if(sLens=="")
					sLens += iLines;
				else
					sLens += "\r\n"+iLines;
				iLength--;
			}
			txtLens.Text = sLens;
			numericUpDown1.Maximum = iLines;
		}

		/// <summary>
		/// 同步滚动条行号
		/// </summary>
		void SyncLines(bool isFocus)
		{
			try
			{
				int iNbr = 0;
				if(IsInt(numericUpDown1.Value.ToString()))
					iNbr = Convert.ToInt32(numericUpDown1.Value.ToString())-1;
				if(iNbr>=0 && iNbr<txtGUID.Lines.Length)
				{
					txtLens.SelectionStart = txtLens.Text.IndexOf(txtLens.Lines[iNbr]);
					txtLens.SelectionLength = txtLens.Lines[iNbr].Length;
					txtLens.ScrollToCaret();
					txtGUID.SelectionStart = txtGUID.Text.IndexOf(txtGUID.Lines[iNbr]);
					txtGUID.SelectionLength = txtGUID.Lines[iNbr].Length;
					txtGUID.ScrollToCaret();
					if(isFocus)
						numericUpDown1.Focus();
				}
			}
			catch(Exception eX)
			{
				MessageBox.Show(eX.Message);
			}
		}

		private void txtGUID_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (txtGUID.SelectedText.Trim() == "")
				return;
		}

		/// <summary>
		/// 列表对象
		/// </summary>
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
				get{return this._key;}
				set{this._key = value;}
			}

			public string Value
			{
				get{return this._value;}
				set{this._value = value;}
			}
		}
	}
}