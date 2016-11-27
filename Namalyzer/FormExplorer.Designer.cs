namespace Namalyzer
{
    partial class FormExplorer
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ディレクトリ", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ファイル", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExplorer));
            this.lsvExplorer = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.imlLarge = new System.Windows.Forms.ImageList(this.components);
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tstDirectory = new System.Windows.Forms.ToolStripTextBox();
            this.tsbUpDirectory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbViewLargeIcon = new System.Windows.Forms.ToolStripButton();
            this.tsbViewDetails = new System.Windows.Forms.ToolStripButton();
            this.tsbViewSmallIcon = new System.Windows.Forms.ToolStripButton();
            this.tsbViewList = new System.Windows.Forms.ToolStripButton();
            this.tsbViewTile = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvExplorer
            // 
            this.lsvExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvExplorer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            listViewGroup1.Header = "ディレクトリ";
            listViewGroup1.Name = "lvgFolder";
            listViewGroup2.Header = "ファイル";
            listViewGroup2.Name = "lvgFile";
            this.lsvExplorer.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lsvExplorer.LargeImageList = this.imlLarge;
            this.lsvExplorer.Location = new System.Drawing.Point(0, 25);
            this.lsvExplorer.MultiSelect = false;
            this.lsvExplorer.Name = "lsvExplorer";
            this.lsvExplorer.Size = new System.Drawing.Size(459, 241);
            this.lsvExplorer.SmallImageList = this.imlSmall;
            this.lsvExplorer.TabIndex = 0;
            this.lsvExplorer.UseCompatibleStateImageBehavior = false;
            this.lsvExplorer.View = System.Windows.Forms.View.Details;
            this.lsvExplorer.DoubleClick += new System.EventHandler(this.lsvExplorer_DoubleClick);
            this.lsvExplorer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvExplorer_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ファイル名";
            this.columnHeader1.Width = 64;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "リクエスト数";
            this.columnHeader2.Width = 72;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "多かったステータスコード";
            this.columnHeader3.Width = 131;
            // 
            // imlLarge
            // 
            this.imlLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLarge.ImageStream")));
            this.imlLarge.TransparentColor = System.Drawing.Color.Magenta;
            this.imlLarge.Images.SetKeyName(0, "FolderOKL.bmp");
            this.imlLarge.Images.SetKeyName(1, "FolderInfoL.bmp");
            this.imlLarge.Images.SetKeyName(2, "FolderErrorL.bmp");
            this.imlLarge.Images.SetKeyName(3, "FileOKL.bmp");
            this.imlLarge.Images.SetKeyName(4, "FileInfoL.bmp");
            this.imlLarge.Images.SetKeyName(5, "FileErrorL.bmp");
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Magenta;
            this.imlSmall.Images.SetKeyName(0, "FolderOKS.bmp");
            this.imlSmall.Images.SetKeyName(1, "FolderInfoS.bmp");
            this.imlSmall.Images.SetKeyName(2, "FolderErrorS.bmp");
            this.imlSmall.Images.SetKeyName(3, "FileOKS.bmp");
            this.imlSmall.Images.SetKeyName(4, "FileInfoS.bmp");
            this.imlSmall.Images.SetKeyName(5, "FileErrorS.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstDirectory,
            this.tsbUpDirectory,
            this.toolStripSeparator1,
            this.tsbViewLargeIcon,
            this.tsbViewDetails,
            this.tsbViewSmallIcon,
            this.tsbViewList,
            this.tsbViewTile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(459, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tstDirectory
            // 
            this.tstDirectory.Name = "tstDirectory";
            this.tstDirectory.ReadOnly = true;
            this.tstDirectory.Size = new System.Drawing.Size(300, 25);
            // 
            // tsbUpDirectory
            // 
            this.tsbUpDirectory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpDirectory.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpDirectory.Image")));
            this.tsbUpDirectory.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbUpDirectory.Name = "tsbUpDirectory";
            this.tsbUpDirectory.Size = new System.Drawing.Size(23, 22);
            this.tsbUpDirectory.Text = "toolStripButton6";
            this.tsbUpDirectory.ToolTipText = "上へ";
            this.tsbUpDirectory.Click += new System.EventHandler(this.tsbUpDirectory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbViewLargeIcon
            // 
            this.tsbViewLargeIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewLargeIcon.Image = ((System.Drawing.Image)(resources.GetObject("tsbViewLargeIcon.Image")));
            this.tsbViewLargeIcon.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbViewLargeIcon.Name = "tsbViewLargeIcon";
            this.tsbViewLargeIcon.Size = new System.Drawing.Size(23, 22);
            this.tsbViewLargeIcon.Text = "toolStripButton1";
            this.tsbViewLargeIcon.ToolTipText = "大きいアイコン";
            this.tsbViewLargeIcon.Click += new System.EventHandler(this.tsbViewLargeIcon_Click);
            // 
            // tsbViewDetails
            // 
            this.tsbViewDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsbViewDetails.Image")));
            this.tsbViewDetails.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbViewDetails.Name = "tsbViewDetails";
            this.tsbViewDetails.Size = new System.Drawing.Size(23, 22);
            this.tsbViewDetails.Text = "toolStripButton2";
            this.tsbViewDetails.ToolTipText = "詳細";
            this.tsbViewDetails.Click += new System.EventHandler(this.tsbViewDetails_Click);
            // 
            // tsbViewSmallIcon
            // 
            this.tsbViewSmallIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewSmallIcon.Image = ((System.Drawing.Image)(resources.GetObject("tsbViewSmallIcon.Image")));
            this.tsbViewSmallIcon.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbViewSmallIcon.Name = "tsbViewSmallIcon";
            this.tsbViewSmallIcon.Size = new System.Drawing.Size(23, 22);
            this.tsbViewSmallIcon.Text = "toolStripButton3";
            this.tsbViewSmallIcon.ToolTipText = "小さいアイコン";
            this.tsbViewSmallIcon.Click += new System.EventHandler(this.tsbViewSmallIcon_Click);
            // 
            // tsbViewList
            // 
            this.tsbViewList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewList.Image = ((System.Drawing.Image)(resources.GetObject("tsbViewList.Image")));
            this.tsbViewList.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbViewList.Name = "tsbViewList";
            this.tsbViewList.Size = new System.Drawing.Size(23, 22);
            this.tsbViewList.Text = "toolStripButton4";
            this.tsbViewList.ToolTipText = "一覧";
            this.tsbViewList.Click += new System.EventHandler(this.tsbViewList_Click);
            // 
            // tsbViewTile
            // 
            this.tsbViewTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbViewTile.Image = ((System.Drawing.Image)(resources.GetObject("tsbViewTile.Image")));
            this.tsbViewTile.ImageTransparentColor = System.Drawing.Color.Silver;
            this.tsbViewTile.Name = "tsbViewTile";
            this.tsbViewTile.Size = new System.Drawing.Size(23, 22);
            this.tsbViewTile.Text = "toolStripButton5";
            this.tsbViewTile.ToolTipText = "並べて表示";
            this.tsbViewTile.Click += new System.EventHandler(this.tsbViewTile_Click);
            // 
            // FormExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 266);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lsvExplorer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExplorer";
            this.Text = "FormExplorer";
            this.Load += new System.EventHandler(this.FormExplorer_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormExplorer_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvExplorer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbViewLargeIcon;
        private System.Windows.Forms.ToolStripButton tsbViewDetails;
        private System.Windows.Forms.ToolStripButton tsbViewSmallIcon;
        private System.Windows.Forms.ToolStripButton tsbViewList;
        private System.Windows.Forms.ToolStripButton tsbViewTile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tstDirectory;
        private System.Windows.Forms.ToolStripButton tsbUpDirectory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imlLarge;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}