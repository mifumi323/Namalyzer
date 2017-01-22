namespace Namalyzer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteLogBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestedBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refererBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAgentBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.readFilterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.readOptionToolStripMenuItem,
            this.abortToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.viewToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.reloadFileToolStripMenuItem,
            this.deleteFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.addFileToolStripMenuItem.Text = "ファイルを追加";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // reloadFileToolStripMenuItem
            // 
            this.reloadFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadAllToolStripMenuItem});
            this.reloadFileToolStripMenuItem.Name = "reloadFileToolStripMenuItem";
            this.reloadFileToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.reloadFileToolStripMenuItem.Text = "読み込みなおす";
            // 
            // reloadAllToolStripMenuItem
            // 
            this.reloadAllToolStripMenuItem.Name = "reloadAllToolStripMenuItem";
            this.reloadAllToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.reloadAllToolStripMenuItem.Text = "全て再読み込み";
            this.reloadAllToolStripMenuItem.Click += new System.EventHandler(this.reloadAllToolStripMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllToolStripMenuItem});
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.deleteFileToolStripMenuItem.Text = "ファイルを閉じる";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.closeAllToolStripMenuItem.Text = "全て閉じる";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "終了";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem,
            this.explorerToolStripMenuItem,
            this.statisticsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.viewToolStripMenuItem.Text = "表示";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.listToolStripMenuItem.Text = "リスト表示";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.explorerToolStripMenuItem.Text = "エクスプローラ";
            this.explorerToolStripMenuItem.Click += new System.EventHandler(this.explorerToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.statisticsToolStripMenuItem.Text = "統計";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFilterToolStripMenuItem,
            this.analyzeFilterToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.filterToolStripMenuItem.Text = "フィルタ";
            // 
            // readFilterToolStripMenuItem
            // 
            this.readFilterToolStripMenuItem.Name = "readFilterToolStripMenuItem";
            this.readFilterToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.readFilterToolStripMenuItem.Text = "読み込みフィルタ";
            this.readFilterToolStripMenuItem.Click += new System.EventHandler(this.readFilterToolStripMenuItem_Click);
            // 
            // analyzeFilterToolStripMenuItem
            // 
            this.analyzeFilterToolStripMenuItem.Name = "analyzeFilterToolStripMenuItem";
            this.analyzeFilterToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.analyzeFilterToolStripMenuItem.Text = "解析フィルタ";
            this.analyzeFilterToolStripMenuItem.Click += new System.EventHandler(this.analyzeFilterToolStripMenuItem_Click);
            // 
            // readOptionToolStripMenuItem
            // 
            this.readOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hostBufferToolStripMenuItem,
            this.remoteLogBufferToolStripMenuItem,
            this.userBufferToolStripMenuItem,
            this.requestedBufferToolStripMenuItem,
            this.refererBufferToolStripMenuItem,
            this.userAgentBufferToolStripMenuItem,
            this.toolStripMenuItem2,
            this.readFilterToolStripMenuItem1});
            this.readOptionToolStripMenuItem.Name = "readOptionToolStripMenuItem";
            this.readOptionToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.readOptionToolStripMenuItem.Text = "読み込みオプション";
            // 
            // hostBufferToolStripMenuItem
            // 
            this.hostBufferToolStripMenuItem.Name = "hostBufferToolStripMenuItem";
            this.hostBufferToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.hostBufferToolStripMenuItem.Tag = "hostBuffer";
            this.hostBufferToolStripMenuItem.Text = "ホスト名の長さ上限";
            this.hostBufferToolStripMenuItem.Click += new System.EventHandler(this.readOptionToolStripMenuItem_Click);
            // 
            // remoteLogBufferToolStripMenuItem
            // 
            this.remoteLogBufferToolStripMenuItem.Name = "remoteLogBufferToolStripMenuItem";
            this.remoteLogBufferToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.remoteLogBufferToolStripMenuItem.Tag = "remoteLogBuffer";
            this.remoteLogBufferToolStripMenuItem.Text = "リモートログ名の長さ上限";
            this.remoteLogBufferToolStripMenuItem.Click += new System.EventHandler(this.readOptionToolStripMenuItem_Click);
            // 
            // userBufferToolStripMenuItem
            // 
            this.userBufferToolStripMenuItem.Name = "userBufferToolStripMenuItem";
            this.userBufferToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.userBufferToolStripMenuItem.Tag = "userBuffer";
            this.userBufferToolStripMenuItem.Text = "ユーザー名の長さ上限";
            this.userBufferToolStripMenuItem.Click += new System.EventHandler(this.readOptionToolStripMenuItem_Click);
            // 
            // requestedBufferToolStripMenuItem
            // 
            this.requestedBufferToolStripMenuItem.Name = "requestedBufferToolStripMenuItem";
            this.requestedBufferToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.requestedBufferToolStripMenuItem.Tag = "requestedBuffer";
            this.requestedBufferToolStripMenuItem.Text = "リクエスト先の長さ上限";
            this.requestedBufferToolStripMenuItem.Click += new System.EventHandler(this.readOptionToolStripMenuItem_Click);
            // 
            // refererBufferToolStripMenuItem
            // 
            this.refererBufferToolStripMenuItem.Name = "refererBufferToolStripMenuItem";
            this.refererBufferToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.refererBufferToolStripMenuItem.Tag = "refererBuffer";
            this.refererBufferToolStripMenuItem.Text = "リファラの長さ上限";
            this.refererBufferToolStripMenuItem.Click += new System.EventHandler(this.readOptionToolStripMenuItem_Click);
            // 
            // userAgentBufferToolStripMenuItem
            // 
            this.userAgentBufferToolStripMenuItem.Name = "userAgentBufferToolStripMenuItem";
            this.userAgentBufferToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.userAgentBufferToolStripMenuItem.Tag = "userAgentBuffer";
            this.userAgentBufferToolStripMenuItem.Text = "ユーザーエージェントの長さ上限";
            this.userAgentBufferToolStripMenuItem.Click += new System.EventHandler(this.readOptionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 6);
            // 
            // readFilterToolStripMenuItem1
            // 
            this.readFilterToolStripMenuItem1.Name = "readFilterToolStripMenuItem1";
            this.readFilterToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.readFilterToolStripMenuItem1.Text = "読み込みフィルタ";
            this.readFilterToolStripMenuItem1.Click += new System.EventHandler(this.readFilterToolStripMenuItem_Click);
            // 
            // abortToolStripMenuItem
            // 
            this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
            this.abortToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.abortToolStripMenuItem.Text = "中止";
            this.abortToolStripMenuItem.Visible = false;
            this.abortToolStripMenuItem.Click += new System.EventHandler(this.abortToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.helpToolStripMenuItem.Text = "ヘルプ";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutToolStripMenuItem.Text = "バージョン情報";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "すべてのファイル|*";
            this.openFileDialog1.Multiselect = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(614, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 417);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "のんびりナマライザ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyzeFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteLogBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestedBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refererBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userAgentBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem readFilterToolStripMenuItem1;
    }
}

