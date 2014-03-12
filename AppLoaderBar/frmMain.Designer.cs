namespace AppLoaderBar
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.SystemColors.Desktop;
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.RightToLeftLayout = true;
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(592, 165);
            this.listView1.StateImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.TileSize = new System.Drawing.Size(32, 32);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.doDragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 54);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem1.Text = "顶层";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(91, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem2.Text = "删除";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 165);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(256, 64);
            this.Name = "frmMain";
            this.Opacity = 0.9;
            this.Text = "App Loader Bar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

