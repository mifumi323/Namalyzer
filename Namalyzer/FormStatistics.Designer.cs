namespace Namalyzer
{
    partial class FormStatistics
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            this.lstStatistics = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowerLimitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFilter = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ignoreCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urldecodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlnodecodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvRank = new System.Windows.Forms.DataGridView();
            this.clmRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGraph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnView = new System.Windows.Forms.Button();
            this.cmsView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblEmpty = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRank)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstStatistics
            // 
            this.lstStatistics.ContextMenuStrip = this.contextMenuStrip1;
            this.lstStatistics.FormattingEnabled = true;
            this.lstStatistics.ItemHeight = 12;
            this.lstStatistics.Location = new System.Drawing.Point(0, 125);
            this.lstStatistics.Name = "lstStatistics";
            this.lstStatistics.Size = new System.Drawing.Size(86, 88);
            this.lstStatistics.TabIndex = 2;
            this.lstStatistics.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyTextToolStripMenuItem,
            this.lowerLimitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 48);
            // 
            // copyTextToolStripMenuItem
            // 
            this.copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
            this.copyTextToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.copyTextToolStripMenuItem.Text = "Copy Text";
            this.copyTextToolStripMenuItem.Click += new System.EventHandler(this.CopyTextToolStripMenuItem_Click);
            // 
            // lowerLimitToolStripMenuItem
            // 
            this.lowerLimitToolStripMenuItem.Name = "lowerLimitToolStripMenuItem";
            this.lowerLimitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.lowerLimitToolStripMenuItem.Text = "n件以上の項目のみ表示";
            this.lowerLimitToolStripMenuItem.Click += new System.EventHandler(this.LowerLimitToolStripMenuItem_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.ContextMenuStrip = this.contextMenuStrip2;
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.Location = new System.Drawing.Point(260, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(252, 26);
            this.btnFilter.TabIndex = 1;
            this.btnFilter.Text = "フィルタ編集";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignoreCaseToolStripMenuItem,
            this.urldecodeToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(176, 48);
            // 
            // ignoreCaseToolStripMenuItem
            // 
            this.ignoreCaseToolStripMenuItem.Name = "ignoreCaseToolStripMenuItem";
            this.ignoreCaseToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ignoreCaseToolStripMenuItem.Text = "大文字小文字を無視";
            this.ignoreCaseToolStripMenuItem.Click += new System.EventHandler(this.IgnoreCaseToolStripMenuItem_Click);
            // 
            // urldecodeToolStripMenuItem
            // 
            this.urldecodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urlnodecodeToolStripMenuItem,
            this.toolStripMenuItem1});
            this.urldecodeToolStripMenuItem.Name = "urldecodeToolStripMenuItem";
            this.urldecodeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.urldecodeToolStripMenuItem.Text = "URLデコード";
            this.urldecodeToolStripMenuItem.DropDownOpening += new System.EventHandler(this.UrldecodeToolStripMenuItem_DropDownOpening);
            // 
            // urlnodecodeToolStripMenuItem
            // 
            this.urlnodecodeToolStripMenuItem.Checked = true;
            this.urlnodecodeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.urlnodecodeToolStripMenuItem.Name = "urlnodecodeToolStripMenuItem";
            this.urlnodecodeToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.urlnodecodeToolStripMenuItem.Text = "しない";
            this.urlnodecodeToolStripMenuItem.Click += new System.EventHandler(this.UrlnodecodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 6);
            // 
            // dgvRank
            // 
            this.dgvRank.AllowUserToAddRows = false;
            this.dgvRank.AllowUserToDeleteRows = false;
            this.dgvRank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRank,
            this.clmData,
            this.clmCount,
            this.clmRate,
            this.clmGraph});
            this.dgvRank.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvRank.Location = new System.Drawing.Point(15, 238);
            this.dgvRank.Name = "dgvRank";
            this.dgvRank.ReadOnly = true;
            this.dgvRank.RowTemplate.Height = 21;
            this.dgvRank.Size = new System.Drawing.Size(493, 111);
            this.dgvRank.TabIndex = 1;
            this.dgvRank.Visible = false;
            // 
            // clmRank
            // 
            this.clmRank.HeaderText = "順位";
            this.clmRank.Name = "clmRank";
            this.clmRank.ReadOnly = true;
            this.clmRank.Width = 50;
            // 
            // clmData
            // 
            this.clmData.HeaderText = "データ";
            this.clmData.Name = "clmData";
            this.clmData.ReadOnly = true;
            this.clmData.Width = 200;
            // 
            // clmCount
            // 
            this.clmCount.HeaderText = "回数";
            this.clmCount.Name = "clmCount";
            this.clmCount.ReadOnly = true;
            this.clmCount.Width = 50;
            // 
            // clmRate
            // 
            this.clmRate.HeaderText = "割合";
            this.clmRate.Name = "clmRate";
            this.clmRate.ReadOnly = true;
            this.clmRate.Width = 50;
            // 
            // clmGraph
            // 
            this.clmGraph.HeaderText = "グラフ";
            this.clmGraph.Name = "clmGraph";
            this.clmGraph.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnFilter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnView, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 253);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnView
            // 
            this.btnView.ContextMenuStrip = this.contextMenuStrip2;
            this.btnView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnView.Location = new System.Drawing.Point(3, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(251, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "表示";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // cmsView
            // 
            this.cmsView.Name = "cmsView";
            this.cmsView.Size = new System.Drawing.Size(61, 4);
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Location = new System.Drawing.Point(5, 5);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(118, 12);
            this.lblEmpty.TabIndex = 5;
            this.lblEmpty.Text = "解析対象がありません。";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Visible = false;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 277);
            this.ContextMenuStrip = this.contextMenuStrip2;
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.dgvRank);
            this.Controls.Add(this.lstStatistics);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "統計";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            this.Shown += new System.EventHandler(this.FormStatistics_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormStatistics_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRank)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGraph;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyTextToolStripMenuItem;
        private System.Windows.Forms.ListBox lstStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ContextMenuStrip cmsView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ignoreCaseToolStripMenuItem;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.ToolStripMenuItem lowerLimitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urldecodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urlnodecodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}