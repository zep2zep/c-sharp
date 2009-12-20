using System;
using System.Reflection;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace _GetWindowHandle
{
	/// <summary>
	/// GetWindowHandle ��ժҪ˵����
	/// </summary>
	public class GetWindowHandle : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components;

		public GetWindowHandle()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 1;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(72, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(272, 14);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.Control;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Location = new System.Drawing.Point(72, 32);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(272, 14);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.TabIndex = 4;
			this.label3.Text = "label3";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(248, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 32);
			this.label4.TabIndex = 5;
			// 
			// GetWindowHandle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(352, 101);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GetWindowHandle";
			this.Text = "GetWindowHandleForm";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.GetWindowHandle_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			bool isAppRunning = false;
			System.Threading.Mutex mutex = new System.Threading.Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out isAppRunning);
			if (!isAppRunning)
			{
				MessageBox.Show("�������Ѿ��������ˣ��벻Ҫ�ظ����У�");
				Environment.Exit(1);
			}
			else
			{
				Application.EnableVisualStyles();
				Application.Run(new GetWindowHandle());
			}	
		}

		private void GetWindowHandle_Load(object sender, System.EventArgs e)
		{
			//���ô��ڲ���ý���
			_WHandleMethods.SetWindowPos(this.Handle, new IntPtr(-1), 0, 0, 360, 128,
				_WHandleMethods.SWP_NOACTIVATE | _WHandleMethods.SWP_SHOWWINDOW);

			//�汾��Ϣ
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
			label4.Text = BuildMode + " " + ApplicationVersion;
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			Point p;
			if (_WHandleMethods.GetCursorPos(out p))
			{
				//��ȡ��괦��window��handle
				IntPtr hwndCurWindow = _WHandleMethods.WindowFromPoint(p);

				//��ȡ���ָ��
				this.Text = string.Format("{0} : {1}",p.ToString(), Convert.ToString(hwndCurWindow));
                
				//��ȡhandle����
				int length = _WHandleMethods.GetWindowTextLength(hwndCurWindow);
				StringBuilder getWindowText = new StringBuilder(length+1);   
				label1.Text = "Text:";
				_WHandleMethods.GetWindowText(hwndCurWindow, getWindowText, getWindowText.Capacity);
				textBox1.Text = string.Format("{0}", getWindowText);

				//��ȡhandle����
				StringBuilder getClassName = new StringBuilder(128);  
				_WHandleMethods.GetClassName(hwndCurWindow, getClassName, getClassName.Capacity);
				label2.Text = "Name:";
				textBox2.Text = string.Format("{0}", getClassName);

				label3.Text = this.Handle.ToString();
			}
		}
	}
}
