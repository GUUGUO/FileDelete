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
            this.tv_limit_size = new System.Windows.Forms.TextBox();
            this.labInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSearchResult = new System.Windows.Forms.Panel();
            this.lv_search_result = new System.Windows.Forms.ListView();
            this.labAttention = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelFunction = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelFIle = new System.Windows.Forms.Button();
            this.btnDelEmpty = new System.Windows.Forms.Button();
            this.btnClearDrag = new System.Windows.Forms.Button();
            this.labFloder = new System.Windows.Forms.Label();
            this.panalDrag = new System.Windows.Forms.Panel();
            this.lv_drag_list = new System.Windows.Forms.ListView();
            this.panelInput = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tv_extention = new System.Windows.Forms.TextBox();
            this.panelSearchResult.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelFunction.SuspendLayout();
            this.panalDrag.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_limit_size
            // 
            this.tv_limit_size.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_limit_size.Location = new System.Drawing.Point(120, 0);
            this.tv_limit_size.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tv_limit_size.Name = "tv_limit_size";
            this.tv_limit_size.Size = new System.Drawing.Size(40, 25);
            this.tv_limit_size.TabIndex = 0;
            this.tv_limit_size.Text = "10";
            this.tv_limit_size.TextChanged += new System.EventHandler(this.txtSize_TextChanged);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(160, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "MB    后缀名";
            // 
            // panelSearchResult
            // 
            this.panelSearchResult.AllowDrop = true;
            this.panelSearchResult.AutoScroll = true;
            this.panelSearchResult.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSearchResult.Controls.Add(this.lv_search_result);
            this.panelSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearchResult.Location = new System.Drawing.Point(30, 326);
            this.panelSearchResult.Margin = new System.Windows.Forms.Padding(2);
            this.panelSearchResult.Name = "panelSearchResult";
            this.panelSearchResult.Size = new System.Drawing.Size(554, 231);
            this.panelSearchResult.TabIndex = 3;
            this.panelSearchResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.panelSearchResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // lv_search_result
            // 
            this.lv_search_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_search_result.FullRowSelect = true;
            this.lv_search_result.Location = new System.Drawing.Point(0, 0);
            this.lv_search_result.Margin = new System.Windows.Forms.Padding(2);
            this.lv_search_result.Name = "lv_search_result";
            this.lv_search_result.Size = new System.Drawing.Size(554, 231);
            this.lv_search_result.TabIndex = 0;
            this.lv_search_result.UseCompatibleStateImageBehavior = false;
            this.lv_search_result.View = System.Windows.Forms.View.Details;
            this.lv_search_result.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
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
            this.panel3.Controls.Add(this.panelSearchResult);
            this.panel3.Controls.Add(this.panelFunction);
            this.panel3.Controls.Add(this.panalDrag);
            this.panel3.Controls.Add(this.panelInput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 21);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(30, 40, 30, 40);
            this.panel3.Size = new System.Drawing.Size(614, 597);
            this.panel3.TabIndex = 8;
            // 
            // panelFunction
            // 
            this.panelFunction.Controls.Add(this.btnSearch);
            this.panelFunction.Controls.Add(this.btnDelFIle);
            this.panelFunction.Controls.Add(this.btnDelEmpty);
            this.panelFunction.Controls.Add(this.btnClearDrag);
            this.panelFunction.Controls.Add(this.labFloder);
            this.panelFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFunction.Location = new System.Drawing.Point(30, 276);
            this.panelFunction.Name = "panelFunction";
            this.panelFunction.Size = new System.Drawing.Size(554, 50);
            this.panelFunction.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(295, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 50);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "搜索文件";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnDelFIle
            // 
            this.btnDelFIle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelFIle.Location = new System.Drawing.Point(362, 0);
            this.btnDelFIle.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelFIle.Name = "btnDelFIle";
            this.btnDelFIle.Size = new System.Drawing.Size(67, 50);
            this.btnDelFIle.TabIndex = 11;
            this.btnDelFIle.Text = "删除文件";
            this.btnDelFIle.UseVisualStyleBackColor = true;
            // 
            // btnDelEmpty
            // 
            this.btnDelEmpty.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelEmpty.Location = new System.Drawing.Point(429, 0);
            this.btnDelEmpty.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelEmpty.Name = "btnDelEmpty";
            this.btnDelEmpty.Size = new System.Drawing.Size(70, 50);
            this.btnDelEmpty.TabIndex = 10;
            this.btnDelEmpty.Text = "删除空文件夹";
            this.btnDelEmpty.UseVisualStyleBackColor = true;
            // 
            // btnClearDrag
            // 
            this.btnClearDrag.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClearDrag.Font = new System.Drawing.Font("宋体", 9F);
            this.btnClearDrag.Location = new System.Drawing.Point(499, 0);
            this.btnClearDrag.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearDrag.Name = "btnClearDrag";
            this.btnClearDrag.Size = new System.Drawing.Size(55, 50);
            this.btnClearDrag.TabIndex = 7;
            this.btnClearDrag.Text = "清空拖拽面板";
            this.btnClearDrag.UseVisualStyleBackColor = true;
            this.btnClearDrag.Click += new System.EventHandler(this.btnClearDrag_Click);
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
            // panalDrag
            // 
            this.panalDrag.Controls.Add(this.lv_drag_list);
            this.panalDrag.Dock = System.Windows.Forms.DockStyle.Top;
            this.panalDrag.Location = new System.Drawing.Point(30, 86);
            this.panalDrag.Margin = new System.Windows.Forms.Padding(2);
            this.panalDrag.Name = "panalDrag";
            this.panalDrag.Size = new System.Drawing.Size(554, 190);
            this.panalDrag.TabIndex = 3;
            // 
            // lv_drag_list
            // 
            this.lv_drag_list.AllowDrop = true;
            this.lv_drag_list.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lv_drag_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_drag_list.Location = new System.Drawing.Point(0, 0);
            this.lv_drag_list.Name = "lv_drag_list";
            this.lv_drag_list.Size = new System.Drawing.Size(554, 190);
            this.lv_drag_list.TabIndex = 0;
            this.lv_drag_list.UseCompatibleStateImageBehavior = false;
            this.lv_drag_list.View = System.Windows.Forms.View.Details;
            this.lv_drag_list.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel1_DragDrop);
            this.lv_drag_list.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel1_DragEnter);
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.tv_extention);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.tv_limit_size);
            this.panelInput.Controls.Add(this.labInfo);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelInput.Location = new System.Drawing.Point(30, 40);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(554, 46);
            this.panelInput.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(304, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "(使用逗号隔开)";
            // 
            // tv_extention
            // 
            this.tv_extention.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_extention.Location = new System.Drawing.Point(264, 0);
            this.tv_extention.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.tv_extention.Name = "tv_extention";
            this.tv_extention.Size = new System.Drawing.Size(40, 25);
            this.tv_extention.TabIndex = 6;
            this.tv_extention.TextChanged += new System.EventHandler(this.tv_extention_TextChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(614, 618);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labAttention);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "文件删除工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSearchResult.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelFunction.ResumeLayout(false);
            this.panalDrag.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tv_limit_size;
        private System.Windows.Forms.Label labInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSearchResult;
        private System.Windows.Forms.ListView lv_search_result;
        private System.Windows.Forms.Label labAttention;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Panel panelFunction;
        private System.Windows.Forms.Panel panalDrag;
        private System.Windows.Forms.ListView lv_drag_list;
        private System.Windows.Forms.TextBox tv_extention;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labFloder;
        private System.Windows.Forms.Button btnClearDrag;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelFIle;
        private System.Windows.Forms.Button btnDelEmpty;
    }
}

