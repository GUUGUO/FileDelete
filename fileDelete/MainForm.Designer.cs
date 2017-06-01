namespace fileDelete
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSize = new System.Windows.Forms.TextBox();
            this.labInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labFloder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelFIle = new System.Windows.Forms.Button();
            this.btnDelEmpty = new System.Windows.Forms.Button();
            this.labAttention = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSize
            // 
            this.txtSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSize.Location = new System.Drawing.Point(120, 0);
            this.txtSize.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(40, 25);
            this.txtSize.TabIndex = 0;
            this.txtSize.Text = "10";
            this.txtSize.TextChanged += new System.EventHandler(this.txtSize_TextChanged);
            // 
            // labInfo
            // 
            this.labInfo.AutoSize = true;
            this.labInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.labInfo.Location = new System.Drawing.Point(0, 0);
            this.labInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labInfo.Name = "labInfo";
            this.labInfo.Size = new System.Drawing.Size(120, 16);
            this.labInfo.TabIndex = 1;
            this.labInfo.Text = "请输入限制大小";
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(30, 86);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 100);
            this.panel1.TabIndex = 3;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.panel1.DragLeave += new System.EventHandler(this.panel1_DragLeave);
            // 
            // labFloder
            // 
            this.labFloder.Dock = System.Windows.Forms.DockStyle.Left;
            this.labFloder.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFloder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labFloder.Location = new System.Drawing.Point(0, 0);
            this.labFloder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labFloder.Name = "labFloder";
            this.labFloder.Size = new System.Drawing.Size(188, 50);
            this.labFloder.TabIndex = 4;
            this.labFloder.Text = "请拖拽文件夹到上面的方框内";
            this.labFloder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(160, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "MB";
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(30, 236);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 190);
            this.panel2.TabIndex = 3;
            this.panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            this.panel2.DragLeave += new System.EventHandler(this.panel1_DragLeave);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(430, 190);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(214, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 50);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "搜索文件";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelFIle
            // 
            this.btnDelFIle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelFIle.Location = new System.Drawing.Point(281, 0);
            this.btnDelFIle.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelFIle.Name = "btnDelFIle";
            this.btnDelFIle.Size = new System.Drawing.Size(67, 50);
            this.btnDelFIle.TabIndex = 6;
            this.btnDelFIle.Text = "删除文件";
            this.btnDelFIle.UseVisualStyleBackColor = true;
            this.btnDelFIle.Click += new System.EventHandler(this.btnDelFIle_Click);
            // 
            // btnDelEmpty
            // 
            this.btnDelEmpty.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelEmpty.Location = new System.Drawing.Point(348, 0);
            this.btnDelEmpty.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelEmpty.Name = "btnDelEmpty";
            this.btnDelEmpty.Size = new System.Drawing.Size(82, 50);
            this.btnDelEmpty.TabIndex = 6;
            this.btnDelEmpty.Text = "删除空文件夹";
            this.btnDelEmpty.UseVisualStyleBackColor = true;
            this.btnDelEmpty.Click += new System.EventHandler(this.btnDelEmpty_Click);
            // 
            // labAttention
            // 
            this.labAttention.AutoSize = true;
            this.labAttention.BackColor = System.Drawing.Color.OrangeRed;
            this.labAttention.Dock = System.Windows.Forms.DockStyle.Top;
            this.labAttention.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAttention.ForeColor = System.Drawing.Color.White;
            this.labAttention.Location = new System.Drawing.Point(0, 0);
            this.labAttention.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labAttention.Name = "labAttention";
            this.labAttention.Size = new System.Drawing.Size(218, 21);
            this.labAttention.TabIndex = 7;
            this.labAttention.Text = "请把文件夹拖拽到蓝色方框内";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 21);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(30, 40, 30, 40);
            this.panel3.Size = new System.Drawing.Size(490, 466);
            this.panel3.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labFloder);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.btnDelFIle);
            this.panel5.Controls.Add(this.btnDelEmpty);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(30, 186);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(430, 50);
            this.panel5.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtSize);
            this.panel4.Controls.Add(this.labInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(30, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(430, 46);
            this.panel4.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(490, 487);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labAttention);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "文件删除工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labFloder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelFIle;
        private System.Windows.Forms.Button btnDelEmpty;
        private System.Windows.Forms.Label labAttention;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}

