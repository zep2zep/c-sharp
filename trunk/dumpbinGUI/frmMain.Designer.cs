namespace dumpbinGUI
{
    partial class frmMain
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
        	this.txtdumpInfo = new SearchableControls.SearchableTextBox();
        	this.comboBox1 = new System.Windows.Forms.ComboBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.txtundName = new System.Windows.Forms.TextBox();
        	this.SuspendLayout();
        	// 
        	// txtdumpInfo
        	// 
        	this.txtdumpInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.txtdumpInfo.Location = new System.Drawing.Point(13, 71);
        	this.txtdumpInfo.Multiline = true;
        	this.txtdumpInfo.Name = "txtdumpInfo";
        	this.txtdumpInfo.ReadOnly = true;
        	this.txtdumpInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.txtdumpInfo.Size = new System.Drawing.Size(389, 376);
        	this.txtdumpInfo.TabIndex = 3;
        	this.txtdumpInfo.WordWrap = false;
        	this.txtdumpInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtdumpInfo_MouseUp);
        	// 
        	// comboBox1
        	// 
        	this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
        	this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.comboBox1.Location = new System.Drawing.Point(12, 35);
        	this.comboBox1.Name = "comboBox1";
        	this.comboBox1.Size = new System.Drawing.Size(389, 20);
        	this.comboBox1.TabIndex = 4;
        	this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
        	// 
        	// label1
        	// 
        	this.label1.Location = new System.Drawing.Point(13, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(119, 23);
        	this.label1.TabIndex = 5;
        	this.label1.Text = "拖拽文件至窗体";
        	// 
        	// txtundName
        	// 
        	this.txtundName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.txtundName.Location = new System.Drawing.Point(12, 453);
        	this.txtundName.Multiline = true;
        	this.txtundName.Name = "txtundName";
        	this.txtundName.ReadOnly = true;
        	this.txtundName.Size = new System.Drawing.Size(390, 60);
        	this.txtundName.TabIndex = 6;
        	// 
        	// frmMain
        	// 
        	this.AllowDrop = true;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(414, 525);
        	this.Controls.Add(this.txtundName);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.comboBox1);
        	this.Controls.Add(this.txtdumpInfo);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.Name = "frmMain";
        	this.Text = "dumpbin GUI";
        	this.Load += new System.EventHandler(this.FrmMainLoad);
        	this.DragDrop += new System.Windows.Forms.DragEventHandler(this.doDragDrop);
        	this.DragEnter += new System.Windows.Forms.DragEventHandler(this.doDragEnter);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox txtundName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;

        #endregion

        private SearchableControls.SearchableTextBox txtdumpInfo; 
    }
}
