namespace Tang_s_Tools
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.listFind = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labSteps = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOffset2 = new System.Windows.Forms.TextBox();
            this.labOffset2 = new System.Windows.Forms.Label();
            this.txtBaseOffset = new System.Windows.Forms.TextBox();
            this.labBaseOffset = new System.Windows.Forms.Label();
            this.txtBaseAddress = new System.Windows.Forms.TextBox();
            this.labBaseAddress = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.labScope = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCallTest = new System.Windows.Forms.Button();
            this.txtCallAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lab16To10 = new System.Windows.Forms.Label();
            this.lab10 = new System.Windows.Forms.Label();
            this.but16To10 = new System.Windows.Forms.Button();
            this.txt16 = new System.Windows.Forms.TextBox();
            this.txt10 = new System.Windows.Forms.TextBox();
            this.but10To16 = new System.Windows.Forms.Button();
            this.txtASCIIBytes = new System.Windows.Forms.TextBox();
            this.txtToASCIIBytes = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.btnSelectProcess = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.controlProcess = new System.Diagnostics.Process();
            this.labProcess = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage0.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage0);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(15, 56);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(598, 446);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage0
            // 
            this.tabPage0.Controls.Add(this.listFind);
            this.tabPage0.Controls.Add(this.groupBox2);
            this.tabPage0.Location = new System.Drawing.Point(4, 26);
            this.tabPage0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage0.Size = new System.Drawing.Size(590, 416);
            this.tabPage0.TabIndex = 0;
            this.tabPage0.Text = "基址";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // listFind
            // 
            this.listFind.FormattingEnabled = true;
            this.listFind.ItemHeight = 17;
            this.listFind.Location = new System.Drawing.Point(6, 135);
            this.listFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listFind.Name = "listFind";
            this.listFind.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listFind.Size = new System.Drawing.Size(575, 276);
            this.listFind.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.labSteps);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtOffset2);
            this.groupBox2.Controls.Add(this.labOffset2);
            this.groupBox2.Controls.Add(this.txtBaseOffset);
            this.groupBox2.Controls.Add(this.labBaseOffset);
            this.groupBox2.Controls.Add(this.txtBaseAddress);
            this.groupBox2.Controls.Add(this.labBaseAddress);
            this.groupBox2.Controls.Add(this.btnFind);
            this.groupBox2.Controls.Add(this.labScope);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(575, 112);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查找基址";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(473, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // labSteps
            // 
            this.labSteps.AutoSize = true;
            this.labSteps.Location = new System.Drawing.Point(356, 73);
            this.labSteps.Name = "labSteps";
            this.labSteps.Size = new System.Drawing.Size(32, 17);
            this.labSteps.TabIndex = 20;
            this.labSteps.Text = "增量";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.maskedTextBox1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(77, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(265, 34);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "二级偏移";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(220, 9);
            this.maskedTextBox1.Mask = "99";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(25, 23);
            this.maskedTextBox1.TabIndex = 21;
            this.maskedTextBox1.Text = "16";
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.radioButton2.Location = new System.Drawing.Point(117, 11);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(38, 21);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "前";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(161, 11);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(38, 21);
            this.radioButton3.TabIndex = 18;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "后";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(61, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(50, 21);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.Text = "前后";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "的        个";
            // 
            // txtOffset2
            // 
            this.txtOffset2.Location = new System.Drawing.Point(388, 31);
            this.txtOffset2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOffset2.Name = "txtOffset2";
            this.txtOffset2.Size = new System.Drawing.Size(74, 23);
            this.txtOffset2.TabIndex = 15;
            this.txtOffset2.Text = "5C0";
            // 
            // labOffset2
            // 
            this.labOffset2.AutoSize = true;
            this.labOffset2.Location = new System.Drawing.Point(290, 34);
            this.labOffset2.Name = "labOffset2";
            this.labOffset2.Size = new System.Drawing.Size(92, 17);
            this.labOffset2.TabIndex = 14;
            this.labOffset2.Text = "二级地址偏移量";
            // 
            // txtBaseOffset
            // 
            this.txtBaseOffset.Location = new System.Drawing.Point(196, 31);
            this.txtBaseOffset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBaseOffset.Name = "txtBaseOffset";
            this.txtBaseOffset.Size = new System.Drawing.Size(74, 23);
            this.txtBaseOffset.TabIndex = 13;
            this.txtBaseOffset.Text = "69F0";
            // 
            // labBaseOffset
            // 
            this.labBaseOffset.AutoSize = true;
            this.labBaseOffset.Location = new System.Drawing.Point(146, 34);
            this.labBaseOffset.Name = "labBaseOffset";
            this.labBaseOffset.Size = new System.Drawing.Size(44, 17);
            this.labBaseOffset.TabIndex = 12;
            this.labBaseOffset.Text = "偏移量";
            // 
            // txtBaseAddress
            // 
            this.txtBaseAddress.Location = new System.Drawing.Point(55, 31);
            this.txtBaseAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBaseAddress.Name = "txtBaseAddress";
            this.txtBaseAddress.Size = new System.Drawing.Size(74, 23);
            this.txtBaseAddress.TabIndex = 11;
            this.txtBaseAddress.Text = "01874800";
            // 
            // labBaseAddress
            // 
            this.labBaseAddress.AutoSize = true;
            this.labBaseAddress.Location = new System.Drawing.Point(15, 34);
            this.labBaseAddress.Name = "labBaseAddress";
            this.labBaseAddress.Size = new System.Drawing.Size(32, 17);
            this.labBaseAddress.TabIndex = 10;
            this.labBaseAddress.Text = "基址";
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(494, 24);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(68, 32);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // labScope
            // 
            this.labScope.AutoSize = true;
            this.labScope.Location = new System.Drawing.Point(15, 76);
            this.labScope.Name = "labScope";
            this.labScope.Size = new System.Drawing.Size(56, 17);
            this.labScope.TabIndex = 8;
            this.labScope.Text = "读取范围";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ColumnWidth = 32;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.checkedListBox1.Location = new System.Drawing.Point(394, 71);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(168, 22);
            this.checkedListBox1.TabIndex = 5;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblMsg);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(590, 416);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "钩子";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(23, 88);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            this.lblMsg.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCallTest);
            this.groupBox1.Controls.Add(this.txtCallAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 139);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(537, 238);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CallTest";
            // 
            // btnCallTest
            // 
            this.btnCallTest.Location = new System.Drawing.Point(343, 58);
            this.btnCallTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCallTest.Name = "btnCallTest";
            this.btnCallTest.Size = new System.Drawing.Size(87, 33);
            this.btnCallTest.TabIndex = 2;
            this.btnCallTest.Text = "Call测试";
            this.btnCallTest.UseVisualStyleBackColor = true;
            this.btnCallTest.Click += new System.EventHandler(this.btnCallTest_Click);
            // 
            // txtCallAddress
            // 
            this.txtCallAddress.Location = new System.Drawing.Point(127, 58);
            this.txtCallAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCallAddress.Name = "txtCallAddress";
            this.txtCallAddress.Size = new System.Drawing.Size(139, 23);
            this.txtCallAddress.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(590, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "封包";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(3, 220);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(578, 169);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(578, 169);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lab16To10);
            this.tabPage3.Controls.Add(this.lab10);
            this.tabPage3.Controls.Add(this.but16To10);
            this.tabPage3.Controls.Add(this.txt16);
            this.tabPage3.Controls.Add(this.txt10);
            this.tabPage3.Controls.Add(this.but10To16);
            this.tabPage3.Controls.Add(this.txtASCIIBytes);
            this.tabPage3.Controls.Add(this.txtToASCIIBytes);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(590, 416);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "计算";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lab16To10
            // 
            this.lab16To10.AutoSize = true;
            this.lab16To10.Location = new System.Drawing.Point(267, 62);
            this.lab16To10.Name = "lab16To10";
            this.lab16To10.Size = new System.Drawing.Size(56, 17);
            this.lab16To10.TabIndex = 19;
            this.lab16To10.Text = "十六进制";
            // 
            // lab10
            // 
            this.lab10.AutoSize = true;
            this.lab10.Location = new System.Drawing.Point(279, 26);
            this.lab10.Name = "lab10";
            this.lab10.Size = new System.Drawing.Size(44, 17);
            this.lab10.TabIndex = 18;
            this.lab10.Text = "十进制";
            // 
            // but16To10
            // 
            this.but16To10.Location = new System.Drawing.Point(503, 55);
            this.but16To10.Name = "but16To10";
            this.but16To10.Size = new System.Drawing.Size(75, 24);
            this.but16To10.TabIndex = 17;
            this.but16To10.Text = "转10进制";
            this.but16To10.UseVisualStyleBackColor = true;
            this.but16To10.Click += new System.EventHandler(this.but16To10_Click);
            // 
            // txt16
            // 
            this.txt16.Location = new System.Drawing.Point(329, 60);
            this.txt16.Name = "txt16";
            this.txt16.Size = new System.Drawing.Size(168, 23);
            this.txt16.TabIndex = 16;
            // 
            // txt10
            // 
            this.txt10.Location = new System.Drawing.Point(329, 20);
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(168, 23);
            this.txt10.TabIndex = 15;
            // 
            // but10To16
            // 
            this.but10To16.Location = new System.Drawing.Point(503, 16);
            this.but10To16.Name = "but10To16";
            this.but10To16.Size = new System.Drawing.Size(75, 24);
            this.but10To16.TabIndex = 14;
            this.but10To16.Text = "转16进制";
            this.but10To16.UseVisualStyleBackColor = true;
            this.but10To16.Click += new System.EventHandler(this.but10To16_Click);
            // 
            // txtASCIIBytes
            // 
            this.txtASCIIBytes.Location = new System.Drawing.Point(13, 62);
            this.txtASCIIBytes.Multiline = true;
            this.txtASCIIBytes.Name = "txtASCIIBytes";
            this.txtASCIIBytes.Size = new System.Drawing.Size(240, 339);
            this.txtASCIIBytes.TabIndex = 4;
            this.txtASCIIBytes.WordWrap = false;
            // 
            // txtToASCIIBytes
            // 
            this.txtToASCIIBytes.Location = new System.Drawing.Point(13, 19);
            this.txtToASCIIBytes.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtToASCIIBytes.Multiline = true;
            this.txtToASCIIBytes.Name = "txtToASCIIBytes";
            this.txtToASCIIBytes.Size = new System.Drawing.Size(182, 24);
            this.txtToASCIIBytes.TabIndex = 3;
            this.txtToASCIIBytes.TextChanged += new System.EventHandler(this.txtToASCIIBytes_TextChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(590, 416);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "汇编";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(130, 17);
            this.txtProcessName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(341, 23);
            this.txtProcessName.TabIndex = 1;
            // 
            // btnSelectProcess
            // 
            this.btnSelectProcess.Location = new System.Drawing.Point(491, 12);
            this.btnSelectProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectProcess.Name = "btnSelectProcess";
            this.btnSelectProcess.Size = new System.Drawing.Size(118, 33);
            this.btnSelectProcess.TabIndex = 0;
            this.btnSelectProcess.Text = "选择进程";
            this.btnSelectProcess.UseVisualStyleBackColor = true;
            this.btnSelectProcess.Click += new System.EventHandler(this.btnSelectProcess_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // controlProcess
            // 
            this.controlProcess.StartInfo.Domain = "";
            this.controlProcess.StartInfo.LoadUserProfile = false;
            this.controlProcess.StartInfo.Password = null;
            this.controlProcess.StartInfo.StandardErrorEncoding = null;
            this.controlProcess.StartInfo.StandardOutputEncoding = null;
            this.controlProcess.StartInfo.UserName = "";
            this.controlProcess.SynchronizingObject = this;
            // 
            // labProcess
            // 
            this.labProcess.AutoSize = true;
            this.labProcess.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProcess.Location = new System.Drawing.Point(15, 17);
            this.labProcess.Name = "labProcess";
            this.labProcess.Size = new System.Drawing.Size(93, 20);
            this.labProcess.TabIndex = 2;
            this.labProcess.Text = "目标进程名称";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 522);
            this.Controls.Add(this.labProcess);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.btnSelectProcess);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Mr.Tang\'s Helper Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage0.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage0;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSelectProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCallTest;
        private System.Windows.Forms.TextBox txtCallAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Timer timer1;
        private System.Diagnostics.Process controlProcess;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listFind;
        private System.Windows.Forms.Label labProcess;
        private System.Windows.Forms.Label labScope;
        private System.Windows.Forms.TextBox txtOffset2;
        private System.Windows.Forms.Label labOffset2;
        private System.Windows.Forms.TextBox txtBaseOffset;
        private System.Windows.Forms.Label labBaseOffset;
        private System.Windows.Forms.TextBox txtBaseAddress;
        private System.Windows.Forms.Label labBaseAddress;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labSteps;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtToASCIIBytes;
        private System.Windows.Forms.TextBox txtASCIIBytes;
        private System.Windows.Forms.Label lab16To10;
        private System.Windows.Forms.Label lab10;
        private System.Windows.Forms.Button but16To10;
        private System.Windows.Forms.TextBox txt16;
        private System.Windows.Forms.TextBox txt10;
        private System.Windows.Forms.Button but10To16;
    }
}

