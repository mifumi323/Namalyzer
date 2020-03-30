namespace Namalyzer
{
    partial class FormList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormList));
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.hostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remoteLogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.methodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hTTPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sendSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refererDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userAgentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.cmsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AutoGenerateColumns = false;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hostDataGridViewTextBoxColumn,
            this.remoteLogDataGridViewTextBoxColumn,
            this.userDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.methodDataGridViewTextBoxColumn,
            this.requestedDataGridViewTextBoxColumn,
            this.hTTPDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.sendSizeDataGridViewTextBoxColumn,
            this.refererDataGridViewTextBoxColumn,
            this.userAgentDataGridViewTextBoxColumn});
            this.dgvLog.ContextMenuStrip = this.cmsData;
            this.dgvLog.DataSource = this.logBindingSource;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowTemplate.Height = 21;
            this.dgvLog.Size = new System.Drawing.Size(358, 266);
            this.dgvLog.TabIndex = 0;
            // 
            // hostDataGridViewTextBoxColumn
            // 
            this.hostDataGridViewTextBoxColumn.DataPropertyName = "Host";
            this.hostDataGridViewTextBoxColumn.HeaderText = "ホスト名/IP";
            this.hostDataGridViewTextBoxColumn.Name = "hostDataGridViewTextBoxColumn";
            this.hostDataGridViewTextBoxColumn.ReadOnly = true;
            this.hostDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // remoteLogDataGridViewTextBoxColumn
            // 
            this.remoteLogDataGridViewTextBoxColumn.DataPropertyName = "RemoteLog";
            this.remoteLogDataGridViewTextBoxColumn.HeaderText = "リモートログ名";
            this.remoteLogDataGridViewTextBoxColumn.Name = "remoteLogDataGridViewTextBoxColumn";
            this.remoteLogDataGridViewTextBoxColumn.ReadOnly = true;
            this.remoteLogDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.remoteLogDataGridViewTextBoxColumn.Width = 20;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.DataPropertyName = "User";
            this.userDataGridViewTextBoxColumn.HeaderText = "ユーザー名";
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            this.userDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.userDataGridViewTextBoxColumn.Width = 20;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "日付";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dateDataGridViewTextBoxColumn.Width = 120;
            // 
            // methodDataGridViewTextBoxColumn
            // 
            this.methodDataGridViewTextBoxColumn.DataPropertyName = "Method";
            this.methodDataGridViewTextBoxColumn.HeaderText = "メソッド";
            this.methodDataGridViewTextBoxColumn.Name = "methodDataGridViewTextBoxColumn";
            this.methodDataGridViewTextBoxColumn.ReadOnly = true;
            this.methodDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.methodDataGridViewTextBoxColumn.Width = 40;
            // 
            // requestedDataGridViewTextBoxColumn
            // 
            this.requestedDataGridViewTextBoxColumn.DataPropertyName = "Requested";
            this.requestedDataGridViewTextBoxColumn.HeaderText = "リクエスト先";
            this.requestedDataGridViewTextBoxColumn.Name = "requestedDataGridViewTextBoxColumn";
            this.requestedDataGridViewTextBoxColumn.ReadOnly = true;
            this.requestedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // hTTPDataGridViewTextBoxColumn
            // 
            this.hTTPDataGridViewTextBoxColumn.DataPropertyName = "HTTP";
            this.hTTPDataGridViewTextBoxColumn.HeaderText = "HTTP";
            this.hTTPDataGridViewTextBoxColumn.Name = "hTTPDataGridViewTextBoxColumn";
            this.hTTPDataGridViewTextBoxColumn.ReadOnly = true;
            this.hTTPDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.hTTPDataGridViewTextBoxColumn.Width = 60;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "ステータスコード";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.statusDataGridViewTextBoxColumn.Width = 40;
            // 
            // sendSizeDataGridViewTextBoxColumn
            // 
            this.sendSizeDataGridViewTextBoxColumn.DataPropertyName = "SendSize";
            this.sendSizeDataGridViewTextBoxColumn.HeaderText = "転送量";
            this.sendSizeDataGridViewTextBoxColumn.Name = "sendSizeDataGridViewTextBoxColumn";
            this.sendSizeDataGridViewTextBoxColumn.ReadOnly = true;
            this.sendSizeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sendSizeDataGridViewTextBoxColumn.Width = 50;
            // 
            // refererDataGridViewTextBoxColumn
            // 
            this.refererDataGridViewTextBoxColumn.DataPropertyName = "Referer";
            this.refererDataGridViewTextBoxColumn.HeaderText = "参照元";
            this.refererDataGridViewTextBoxColumn.Name = "refererDataGridViewTextBoxColumn";
            this.refererDataGridViewTextBoxColumn.ReadOnly = true;
            this.refererDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // userAgentDataGridViewTextBoxColumn
            // 
            this.userAgentDataGridViewTextBoxColumn.DataPropertyName = "UserAgent";
            this.userAgentDataGridViewTextBoxColumn.HeaderText = "ユーザーエージェント";
            this.userAgentDataGridViewTextBoxColumn.Name = "userAgentDataGridViewTextBoxColumn";
            this.userAgentDataGridViewTextBoxColumn.ReadOnly = true;
            this.userAgentDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmsData
            // 
            this.cmsData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyTextToolStripMenuItem,
            this.detailFilterToolStripMenuItem});
            this.cmsData.Name = "cmsData";
            this.cmsData.Size = new System.Drawing.Size(134, 48);
            // 
            // copyTextToolStripMenuItem
            // 
            this.copyTextToolStripMenuItem.Name = "copyTextToolStripMenuItem";
            this.copyTextToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyTextToolStripMenuItem.Text = "Copy Text";
            this.copyTextToolStripMenuItem.Click += new System.EventHandler(this.CopyTextToolStripMenuItem_Click);
            // 
            // detailFilterToolStripMenuItem
            // 
            this.detailFilterToolStripMenuItem.Name = "detailFilterToolStripMenuItem";
            this.detailFilterToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.detailFilterToolStripMenuItem.Text = "Detail-Filter";
            this.detailFilterToolStripMenuItem.Click += new System.EventHandler(this.DetailFilterToolStripMenuItem_Click);
            // 
            // logBindingSource
            // 
            this.logBindingSource.DataSource = typeof(MifuminLib.AccessAnalyzer.Log);
            // 
            // FormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 266);
            this.Controls.Add(this.dgvLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormList";
            this.Text = "リスト表示";
            this.Shown += new System.EventHandler(this.FormList_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormList_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.cmsData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.BindingSource logBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remoteLogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn methodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hTTPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refererDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userAgentDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip cmsData;
        private System.Windows.Forms.ToolStripMenuItem copyTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailFilterToolStripMenuItem;

    }
}
