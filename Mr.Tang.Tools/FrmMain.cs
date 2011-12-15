using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AsmClassLibrary;
using Win32API;

namespace Tang_s_Tools
{
    public partial class FrmMain : Form
    {
        private int _baseAddress = 0;    //基址
        private int _baseOffset = 0  ;    //基址偏移
        private int _pAddress = 0;  //二级基址
        private int _pOffset = 0;     //二级基址偏移
        private int _p = 0;     //自定义的查找地址
        private int pHandle = 0;
        private int pid = 0;
        private int value = 0;

        public FrmMain()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.SetItemChecked(3, true);
            this.pid = Process.GetCurrentProcess().Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Security.Cryptography.
            //D5.Text = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
        }

        private void asmcall(int addr)
        {
            AsmClass class2 = new AsmClass();
            class2.Pushad();
            class2.Mov_EAX(0x15b3);
            class2.Mov_EBX(addr);
            class2.Call_EBX();
            class2.Popad();
            class2.Ret();
            class2.RunAsm(this.pid);
        }

        void testCall(int pid, int proc)
        { 
            IntPtr hProcess = new IntPtr(pid);
            IntPtr fpProc = new IntPtr(proc);
            
            uint dwThreadId;
            IntPtr hThread = Helper.CreateRemoteThread(
                    hProcess,
                    IntPtr.Zero,
                    0,
                    fpProc, 
                    new IntPtr(6789),
                    0,
                    out dwThreadId);

            //IntPtr hThread = Helper.CreateRemoteThread(this.pid,IntPtr.Zero,0,
        }

        private void btnCallTest_Click(object sender, EventArgs e)
        {
            int addr = Convert.ToInt32(this.txtCallAddress.Text, 0x10);
            testCall(this.pHandle, addr);
        }

        private void btnSelectProcess_Click(object sender, EventArgs e)
        {
            FrmProcessSelect select = new FrmProcessSelect();
            if (select.ShowDialog() == DialogResult.OK)
            {
                this.controlProcess = select.resultProcess;
                this.txtProcessName.Text = this.controlProcess.ProcessName;
            }
            else
            {
                select.Dispose();
                return;
            }
            select.Dispose();
            this.pid = this.controlProcess.Id;
            this.pHandle = API.OpenProcess(0x1f0fff, 0, this.pid);
            if (this.pHandle <= 0)
            {
                this.lblMsg.Text = "打开进程失败!";
            }
            else
            {
                this.lblMsg.Text = "进程创建成功!";
                this.groupBox1.Enabled = true;
                this.timer1.Interval = 100;
                this.timer1.Start();
            }
        }

        private void btnSubtractCall_Click(object sender, EventArgs e)
        {
            AsmClass class2 = new AsmClass();
            class2.Pushad();
            class2.Mov_EBX(0xd53f8c);
            class2.Mov_EAX(0xd51f28);
            class2.Mov_EDX_DWORD_Ptr_EBX_Add(0x214);
            class2.Mov_DWORD_Ptr_EAX_Add_EDX(0x24c);
            class2.Mov_EAX_EBX();
            class2.Mov_EBX(0x430020);
            class2.Call_EBX();
            class2.Popad();
            class2.Ret();
            class2.RunAsm(this.pid);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pHandle != 0)
                btnFind.Enabled = true;
            //API.ReadProcessMemory(this.pHandle, this.baseAddress, out this.value, 4, 0);
            //this.label1.Text = this.value.ToString();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _baseAddress = Helper.StringToInt(txtBaseAddress.Text.Trim());   //基址
            if (checkBox1.Checked)
            {
                if (_baseAddress == 0)
                    return;
                _pAddress = _baseOffset;    //二级基址
            }
            else
            {
                _baseOffset = Helper.StringToInt(txtBaseOffset.Text.Trim());   //基址偏移
                _pOffset = Helper.StringToInt(txtOffset2.Text.Trim());   //二级基址偏移
                if (_baseAddress == 0 || _baseOffset == 0 || _pOffset == 0)
                    return;
                int p = ReadMemoryValue(_baseAddress);
                _pAddress = _baseOffset + p;    //二级基址
            }
            _p = _pAddress+_pOffset;    //自定义的查找地址
            string s = "";
            int n = Convert.ToInt32(maskedTextBox1.Text);   //查询数量
            int m = 1;
            try
            {
                m = Convert.ToInt32(checkedListBox1.SelectedItems[0].ToString());  //递增
            }
            catch
            {
                m = 8;  //递增    
            }
            int _pA = 0;
            int _pB = 0;
            if (radioButton1.Checked) 
            {
                s = "地址: " + Convert.ToString(_p, 16) + " 前后的" + n + "个地址. 递增 " + m;
                _pA = n * m;
                _pB = n * 2;
            }
            if (radioButton2.Checked)
            {
                s = "地址: " + Convert.ToString(_p, 16) + "之前的" + n + "个地址. 递增 " + m;
                _pA = n * m * 2;
                _pB = n;
            }
            if (radioButton3.Checked) 
            {
                s = "地址: " + Convert.ToString(_p, 16) + "之后的" + n + "个地址. 递增 " + m;
                _pA = 0;
                _pB = n;
            }
            _p -= _pA;
            listFind.Items.Clear();
            for (int i = 0; i < _pB+1; i ++)
            {
                string s10 = Convert.ToString(_p, 16);
                if (_p == _pAddress + _pOffset)
                    listFind.Items.Add(" 偏移: " + Convert.ToString(_p - _pAddress, 16) + " \t" + s10.ToUpper() + "  \t" + ReadMemoryValue(_p) + " \t(当前查询的地址)");
                else
                    listFind.Items.Add(" 偏移: " + Convert.ToString(_p - _pAddress, 16) + " \t" + s10.ToUpper() + "  \t" + ReadMemoryValue(_p));
                _p += m;
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                if (checkedListBox1.CheckedIndices[i] != e.Index)
                {
                    //checkedListBox1.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                    checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[i], false);
                }
            }
        }

        //读取制定内存中的数值
        public int ReadMemoryValue(int baseAdd)
        {
            return Helper.ReadMemoryValue(baseAdd, pid);
        }

        //读取制定内存中的文本
        public string ReadMemoryText(int baseAdd, int bLength)
        {
            return Helper.ReadMemoryText(baseAdd, pid, bLength);
        }

        //将值写入指定内存中
        public void WriteMemory(int baseAdd, int value)
        {
            Helper.WriteMemoryValue(baseAdd, pid, value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(3, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtBaseOffset.Enabled = false;
            else
                txtBaseOffset.Enabled = true;
        }

        private void txtToASCIIBytes_TextChanged(object sender, EventArgs e)
        {
            if (txtToASCIIBytes.Text.Length != 1)
                return;
            byte[] b = System.Text.Encoding.ASCII.GetBytes(txtToASCIIBytes.Text);
            txtASCIIBytes.Text = txtToASCIIBytes.Text + " ： 10进制 " + Convert.ToString(b[0], 10) + " 16进制 " + Convert.ToString(b[0], 16) + "\r\n" + txtASCIIBytes.Text;
            txtToASCIIBytes.Text = "";
        }

        private void but10To16_Click(object sender, EventArgs e)
        {
            txt16.Text = Convert.ToString(Convert.ToInt32(txt10.Text), 16);
        }

        private void but16To10_Click(object sender, EventArgs e)
        {
            txt10.Text = StringToInt(txt16.Text).ToString();
        }

        //字符串转换为数字(返回值)的算法。要求string中的字母必须合法，大写，并且以0X或者0x开头
        public static int StringToInt(string s)
        {
            if (s.ToLower().StartsWith("0x"))
                s = s.Replace("0x", "");
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
    }
}