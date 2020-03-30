namespace Namalyzer
{
    partial class FormFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFilter));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvFilter = new System.Windows.Forms.TreeView();
            this.btnAction = new System.Windows.Forms.Button();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clbEnum = new System.Windows.Forms.CheckedListBox();
            this.tlpDate = new System.Windows.Forms.TableLayoutPanel();
            this.chkDateStart = new System.Windows.Forms.CheckBox();
            this.chkDateEnd = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDateStart = new System.Windows.Forms.DateTimePicker();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.tlpNumber = new System.Windows.Forms.TableLayoutPanel();
            this.chkNumberMax = new System.Windows.Forms.CheckBox();
            this.numNumberMax = new System.Windows.Forms.NumericUpDown();
            this.chkNumberMin = new System.Windows.Forms.CheckBox();
            this.numNumberMin = new System.Windows.Forms.NumericUpDown();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tlpCollection = new System.Windows.Forms.TableLayoutPanel();
            this.lstCollection = new System.Windows.Forms.ListBox();
            this.btnEditSub = new System.Windows.Forms.Button();
            this.btnAddSub = new System.Windows.Forms.Button();
            this.btnRemoveSub = new System.Windows.Forms.Button();
            this.pnlString = new System.Windows.Forms.Panel();
            this.tlpStringLength = new System.Windows.Forms.TableLayoutPanel();
            this.chkStringMin = new System.Windows.Forms.CheckBox();
            this.numStringMin = new System.Windows.Forms.NumericUpDown();
            this.chkStringMax = new System.Windows.Forms.CheckBox();
            this.numStringMax = new System.Windows.Forms.NumericUpDown();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.cmbString = new System.Windows.Forms.ComboBox();
            this.txtString = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToClipBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromClipBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.addChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBrotherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpDate.SuspendLayout();
            this.tlpNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberMin)).BeginInit();
            this.tlpCollection.SuspendLayout();
            this.pnlString.SuspendLayout();
            this.tlpStringLength.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStringMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStringMax)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnAction);
            this.splitContainer1.Panel2.Controls.Add(this.cmbFilter);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(533, 278);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // trvFilter
            // 
            this.trvFilter.AllowDrop = true;
            this.trvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFilter.HideSelection = false;
            this.trvFilter.HotTracking = true;
            this.trvFilter.Location = new System.Drawing.Point(0, 0);
            this.trvFilter.Name = "trvFilter";
            this.trvFilter.Size = new System.Drawing.Size(185, 278);
            this.trvFilter.TabIndex = 0;
            this.trvFilter.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.TrvFilter_NodeMouseHover);
            this.trvFilter.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvFilter_AfterSelect);
            this.trvFilter.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TrvFilter_BeforeSelect);
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.Location = new System.Drawing.Point(257, 3);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "操作";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(3, 5);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(248, 20);
            this.cmbFilter.TabIndex = 1;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.CmbFilter_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.clbEnum);
            this.panel1.Controls.Add(this.tlpDate);
            this.panel1.Controls.Add(this.tlpNumber);
            this.panel1.Controls.Add(this.tlpCollection);
            this.panel1.Controls.Add(this.pnlString);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(2, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 246);
            this.panel1.TabIndex = 0;
            // 
            // clbEnum
            // 
            this.clbEnum.CheckOnClick = true;
            this.clbEnum.FormattingEnabled = true;
            this.clbEnum.Location = new System.Drawing.Point(198, 104);
            this.clbEnum.Name = "clbEnum";
            this.clbEnum.Size = new System.Drawing.Size(128, 60);
            this.clbEnum.TabIndex = 5;
            this.clbEnum.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ClbEnum_ItemCheck);
            // 
            // tlpDate
            // 
            this.tlpDate.ColumnCount = 2;
            this.tlpDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDate.Controls.Add(this.chkDateStart, 0, 0);
            this.tlpDate.Controls.Add(this.chkDateEnd, 0, 1);
            this.tlpDate.Controls.Add(this.lblDate, 0, 2);
            this.tlpDate.Controls.Add(this.dtpDateStart, 1, 0);
            this.tlpDate.Controls.Add(this.dtpDateEnd, 1, 1);
            this.tlpDate.Location = new System.Drawing.Point(133, 24);
            this.tlpDate.Name = "tlpDate";
            this.tlpDate.RowCount = 3;
            this.tlpDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDate.Size = new System.Drawing.Size(197, 70);
            this.tlpDate.TabIndex = 4;
            this.tlpDate.Visible = false;
            // 
            // chkDateStart
            // 
            this.chkDateStart.AutoSize = true;
            this.chkDateStart.Location = new System.Drawing.Point(3, 3);
            this.chkDateStart.Name = "chkDateStart";
            this.chkDateStart.Size = new System.Drawing.Size(48, 16);
            this.chkDateStart.TabIndex = 0;
            this.chkDateStart.Text = "開始";
            this.chkDateStart.UseVisualStyleBackColor = true;
            this.chkDateStart.CheckedChanged += new System.EventHandler(this.ChkDateStart_CheckedChanged);
            // 
            // chkDateEnd
            // 
            this.chkDateEnd.AutoSize = true;
            this.chkDateEnd.Location = new System.Drawing.Point(3, 28);
            this.chkDateEnd.Name = "chkDateEnd";
            this.chkDateEnd.Size = new System.Drawing.Size(48, 16);
            this.chkDateEnd.TabIndex = 2;
            this.chkDateEnd.Text = "終了";
            this.chkDateEnd.UseVisualStyleBackColor = true;
            this.chkDateEnd.CheckedChanged += new System.EventHandler(this.ChkDateEnd_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDate.AutoSize = true;
            this.tlpDate.SetColumnSpan(this.lblDate, 2);
            this.lblDate.Location = new System.Drawing.Point(45, 54);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(106, 12);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "日付フィルターの説明";
            // 
            // dtpDateStart
            // 
            this.dtpDateStart.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpDateStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateStart.Location = new System.Drawing.Point(57, 3);
            this.dtpDateStart.Name = "dtpDateStart";
            this.dtpDateStart.Size = new System.Drawing.Size(137, 19);
            this.dtpDateStart.TabIndex = 5;
            this.dtpDateStart.ValueChanged += new System.EventHandler(this.DtpDateStart_ValueChanged);
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpDateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(57, 28);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(137, 19);
            this.dtpDateEnd.TabIndex = 6;
            this.dtpDateEnd.ValueChanged += new System.EventHandler(this.DtpDateEnd_ValueChanged);
            // 
            // tlpNumber
            // 
            this.tlpNumber.ColumnCount = 2;
            this.tlpNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpNumber.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNumber.Controls.Add(this.chkNumberMax, 0, 0);
            this.tlpNumber.Controls.Add(this.numNumberMax, 1, 0);
            this.tlpNumber.Controls.Add(this.chkNumberMin, 0, 1);
            this.tlpNumber.Controls.Add(this.numNumberMin, 1, 1);
            this.tlpNumber.Controls.Add(this.lblNumber, 0, 2);
            this.tlpNumber.Location = new System.Drawing.Point(7, 24);
            this.tlpNumber.Name = "tlpNumber";
            this.tlpNumber.RowCount = 3;
            this.tlpNumber.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpNumber.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNumber.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpNumber.Size = new System.Drawing.Size(120, 70);
            this.tlpNumber.TabIndex = 3;
            this.tlpNumber.Visible = false;
            // 
            // chkNumberMax
            // 
            this.chkNumberMax.AutoSize = true;
            this.chkNumberMax.Location = new System.Drawing.Point(3, 3);
            this.chkNumberMax.Name = "chkNumberMax";
            this.chkNumberMax.Size = new System.Drawing.Size(48, 16);
            this.chkNumberMax.TabIndex = 0;
            this.chkNumberMax.Text = "上限";
            this.chkNumberMax.UseVisualStyleBackColor = true;
            this.chkNumberMax.CheckedChanged += new System.EventHandler(this.ChkNumberMax_CheckedChanged);
            // 
            // numNumberMax
            // 
            this.numNumberMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numNumberMax.Location = new System.Drawing.Point(57, 3);
            this.numNumberMax.Name = "numNumberMax";
            this.numNumberMax.Size = new System.Drawing.Size(60, 19);
            this.numNumberMax.TabIndex = 1;
            this.numNumberMax.ValueChanged += new System.EventHandler(this.NumNumberMax_ValueChanged);
            // 
            // chkNumberMin
            // 
            this.chkNumberMin.AutoSize = true;
            this.chkNumberMin.Location = new System.Drawing.Point(3, 28);
            this.chkNumberMin.Name = "chkNumberMin";
            this.chkNumberMin.Size = new System.Drawing.Size(48, 16);
            this.chkNumberMin.TabIndex = 2;
            this.chkNumberMin.Text = "下限";
            this.chkNumberMin.UseVisualStyleBackColor = true;
            this.chkNumberMin.CheckedChanged += new System.EventHandler(this.ChkNumberMin_CheckedChanged);
            // 
            // numNumberMin
            // 
            this.numNumberMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numNumberMin.Location = new System.Drawing.Point(57, 28);
            this.numNumberMin.Name = "numNumberMin";
            this.numNumberMin.Size = new System.Drawing.Size(60, 19);
            this.numNumberMin.TabIndex = 3;
            this.numNumberMin.ValueChanged += new System.EventHandler(this.NumNumberMin_ValueChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNumber.AutoSize = true;
            this.tlpNumber.SetColumnSpan(this.lblNumber, 2);
            this.lblNumber.Location = new System.Drawing.Point(7, 54);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(106, 12);
            this.lblNumber.TabIndex = 4;
            this.lblNumber.Text = "数値フィルターの説明";
            // 
            // tlpCollection
            // 
            this.tlpCollection.ColumnCount = 3;
            this.tlpCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tlpCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tlpCollection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpCollection.Controls.Add(this.lstCollection, 0, 0);
            this.tlpCollection.Controls.Add(this.btnEditSub, 0, 1);
            this.tlpCollection.Controls.Add(this.btnAddSub, 1, 1);
            this.tlpCollection.Controls.Add(this.btnRemoveSub, 2, 1);
            this.tlpCollection.Location = new System.Drawing.Point(35, 192);
            this.tlpCollection.Name = "tlpCollection";
            this.tlpCollection.RowCount = 2;
            this.tlpCollection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCollection.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCollection.Size = new System.Drawing.Size(304, 51);
            this.tlpCollection.TabIndex = 2;
            this.tlpCollection.Visible = false;
            // 
            // lstCollection
            // 
            this.tlpCollection.SetColumnSpan(this.lstCollection, 3);
            this.lstCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCollection.FormattingEnabled = true;
            this.lstCollection.ItemHeight = 12;
            this.lstCollection.Location = new System.Drawing.Point(3, 3);
            this.lstCollection.Name = "lstCollection";
            this.lstCollection.Size = new System.Drawing.Size(298, 16);
            this.lstCollection.TabIndex = 0;
            this.lstCollection.DoubleClick += new System.EventHandler(this.LstCollection_DoubleClick);
            // 
            // btnEditSub
            // 
            this.btnEditSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditSub.Location = new System.Drawing.Point(3, 25);
            this.btnEditSub.Name = "btnEditSub";
            this.btnEditSub.Size = new System.Drawing.Size(115, 23);
            this.btnEditSub.TabIndex = 1;
            this.btnEditSub.Text = "編集";
            this.btnEditSub.UseVisualStyleBackColor = true;
            this.btnEditSub.Click += new System.EventHandler(this.BtnEditSub_Click);
            // 
            // btnAddSub
            // 
            this.btnAddSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddSub.Location = new System.Drawing.Point(124, 25);
            this.btnAddSub.Name = "btnAddSub";
            this.btnAddSub.Size = new System.Drawing.Size(115, 23);
            this.btnAddSub.TabIndex = 2;
            this.btnAddSub.Text = "追加";
            this.btnAddSub.UseVisualStyleBackColor = true;
            this.btnAddSub.Click += new System.EventHandler(this.BtnAddSub_Click);
            // 
            // btnRemoveSub
            // 
            this.btnRemoveSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveSub.Location = new System.Drawing.Point(245, 25);
            this.btnRemoveSub.Name = "btnRemoveSub";
            this.btnRemoveSub.Size = new System.Drawing.Size(56, 23);
            this.btnRemoveSub.TabIndex = 3;
            this.btnRemoveSub.Text = "削除";
            this.btnRemoveSub.UseVisualStyleBackColor = true;
            this.btnRemoveSub.Click += new System.EventHandler(this.BtnRemoveSub_Click);
            // 
            // pnlString
            // 
            this.pnlString.Controls.Add(this.tlpStringLength);
            this.pnlString.Controls.Add(this.chkIgnoreCase);
            this.pnlString.Controls.Add(this.cmbString);
            this.pnlString.Controls.Add(this.txtString);
            this.pnlString.Location = new System.Drawing.Point(7, 105);
            this.pnlString.Name = "pnlString";
            this.pnlString.Size = new System.Drawing.Size(181, 84);
            this.pnlString.TabIndex = 1;
            this.pnlString.Visible = false;
            // 
            // tlpStringLength
            // 
            this.tlpStringLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpStringLength.AutoSize = true;
            this.tlpStringLength.ColumnCount = 4;
            this.tlpStringLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpStringLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStringLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpStringLength.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStringLength.Controls.Add(this.chkStringMin, 0, 0);
            this.tlpStringLength.Controls.Add(this.numStringMin, 1, 0);
            this.tlpStringLength.Controls.Add(this.chkStringMax, 2, 0);
            this.tlpStringLength.Controls.Add(this.numStringMax, 3, 0);
            this.tlpStringLength.Location = new System.Drawing.Point(0, 59);
            this.tlpStringLength.Name = "tlpStringLength";
            this.tlpStringLength.RowCount = 1;
            this.tlpStringLength.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpStringLength.Size = new System.Drawing.Size(181, 25);
            this.tlpStringLength.TabIndex = 3;
            // 
            // chkStringMin
            // 
            this.chkStringMin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkStringMin.AutoSize = true;
            this.chkStringMin.Location = new System.Drawing.Point(3, 4);
            this.chkStringMin.Name = "chkStringMin";
            this.chkStringMin.Size = new System.Drawing.Size(48, 16);
            this.chkStringMin.TabIndex = 0;
            this.chkStringMin.Text = "下限";
            this.chkStringMin.UseVisualStyleBackColor = true;
            this.chkStringMin.CheckedChanged += new System.EventHandler(this.ChkStringMin_CheckedChanged);
            // 
            // numStringMin
            // 
            this.numStringMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numStringMin.Location = new System.Drawing.Point(57, 3);
            this.numStringMin.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numStringMin.Name = "numStringMin";
            this.numStringMin.Size = new System.Drawing.Size(30, 19);
            this.numStringMin.TabIndex = 1;
            this.numStringMin.ValueChanged += new System.EventHandler(this.NumStringMin_ValueChanged);
            // 
            // chkStringMax
            // 
            this.chkStringMax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkStringMax.AutoSize = true;
            this.chkStringMax.Location = new System.Drawing.Point(93, 4);
            this.chkStringMax.Name = "chkStringMax";
            this.chkStringMax.Size = new System.Drawing.Size(48, 16);
            this.chkStringMax.TabIndex = 0;
            this.chkStringMax.Text = "上限";
            this.chkStringMax.UseVisualStyleBackColor = true;
            this.chkStringMax.CheckedChanged += new System.EventHandler(this.ChkStringMax_CheckedChanged);
            // 
            // numStringMax
            // 
            this.numStringMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numStringMax.Location = new System.Drawing.Point(147, 3);
            this.numStringMax.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numStringMax.Name = "numStringMax";
            this.numStringMax.Size = new System.Drawing.Size(31, 19);
            this.numStringMax.TabIndex = 2;
            this.numStringMax.ValueChanged += new System.EventHandler(this.NumStringMax_ValueChanged);
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIgnoreCase.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Location = new System.Drawing.Point(146, 31);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(35, 22);
            this.chkIgnoreCase.TabIndex = 3;
            this.chkIgnoreCase.Text = "A=a";
            this.toolTip1.SetToolTip(this.chkIgnoreCase, "大文字小文字を区別しない");
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            this.chkIgnoreCase.CheckedChanged += new System.EventHandler(this.ChkIgnoreCase_CheckedChanged);
            // 
            // cmbString
            // 
            this.cmbString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbString.FormattingEnabled = true;
            this.cmbString.Location = new System.Drawing.Point(0, 33);
            this.cmbString.Name = "cmbString";
            this.cmbString.Size = new System.Drawing.Size(140, 20);
            this.cmbString.TabIndex = 1;
            this.cmbString.SelectedIndexChanged += new System.EventHandler(this.CmbString_SelectedIndexChanged);
            // 
            // txtString
            // 
            this.txtString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtString.Location = new System.Drawing.Point(0, 0);
            this.txtString.Multiline = true;
            this.txtString.Name = "txtString";
            this.txtString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtString.Size = new System.Drawing.Size(181, 25);
            this.txtString.TabIndex = 0;
            this.txtString.WordWrap = false;
            this.txtString.TextChanged += new System.EventHandler(this.TxtString_TextChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMessage.Location = new System.Drawing.Point(3, 2);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(124, 19);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "メッセージを表示します。";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(365, 284);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(446, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ｷｬﾝｾﾙ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToFileToolStripMenuItem,
            this.importFromFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportToClipBoardToolStripMenuItem,
            this.importFromClipBoardToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addChildToolStripMenuItem,
            this.addBrotherToolStripMenuItem,
            this.toolStripMenuItem4,
            this.upToolStripMenuItem,
            this.downToolStripMenuItem,
            this.toolStripMenuItem6,
            this.sortToolStripMenuItem,
            this.toolStripMenuItem3,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 254);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.ContextMenuStrip1_Opened);
            // 
            // exportToFileToolStripMenuItem
            // 
            this.exportToFileToolStripMenuItem.Name = "exportToFileToolStripMenuItem";
            this.exportToFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportToFileToolStripMenuItem.Text = "ファイルに保存";
            this.exportToFileToolStripMenuItem.Click += new System.EventHandler(this.ExportToFileToolStripMenuItem_Click);
            // 
            // importFromFileToolStripMenuItem
            // 
            this.importFromFileToolStripMenuItem.Name = "importFromFileToolStripMenuItem";
            this.importFromFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importFromFileToolStripMenuItem.Text = "ファイルから読み込み";
            this.importFromFileToolStripMenuItem.Click += new System.EventHandler(this.ImportFromFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // exportToClipBoardToolStripMenuItem
            // 
            this.exportToClipBoardToolStripMenuItem.Name = "exportToClipBoardToolStripMenuItem";
            this.exportToClipBoardToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportToClipBoardToolStripMenuItem.Text = "クリップボードにコピー";
            this.exportToClipBoardToolStripMenuItem.Click += new System.EventHandler(this.ExportToClipBoardToolStripMenuItem_Click);
            // 
            // importFromClipBoardToolStripMenuItem
            // 
            this.importFromClipBoardToolStripMenuItem.Name = "importFromClipBoardToolStripMenuItem";
            this.importFromClipBoardToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importFromClipBoardToolStripMenuItem.Text = "クリップボードから貼り付け";
            this.importFromClipBoardToolStripMenuItem.Click += new System.EventHandler(this.ImportFromClipBoardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 6);
            // 
            // addChildToolStripMenuItem
            // 
            this.addChildToolStripMenuItem.Name = "addChildToolStripMenuItem";
            this.addChildToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addChildToolStripMenuItem.Text = "サブフィルタを追加";
            this.addChildToolStripMenuItem.Click += new System.EventHandler(this.AddChildToolStripMenuItem_Click);
            // 
            // addBrotherToolStripMenuItem
            // 
            this.addBrotherToolStripMenuItem.Name = "addBrotherToolStripMenuItem";
            this.addBrotherToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addBrotherToolStripMenuItem.Text = "同列のフィルタを追加";
            this.addBrotherToolStripMenuItem.Click += new System.EventHandler(this.AddBrotherToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(187, 6);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.upToolStripMenuItem.Text = "順序をひとつ上へ";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.UpToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.downToolStripMenuItem.Text = "順序をひとつ下へ";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.DownToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(187, 6);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sortToolStripMenuItem.Text = "サブフィルタの並び替え";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.SortToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(187, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeToolStripMenuItem.Text = "このフィルタを削除";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "nnf";
            this.openFileDialog1.Filter = "のんびりナマライザフィルタ|*.nnf|XMLファイル|*.xml|すべてのファイル|*.*";
            this.openFileDialog1.Title = "フィルタを開く";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "nnf";
            this.saveFileDialog1.Filter = "のんびりナマライザフィルタ|*.nnf|XMLファイル|*.xml|すべてのファイル|*.*";
            this.saveFileDialog1.Title = "フィルタを保存";
            // 
            // FormFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 319);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "フィルタ";
            this.Load += new System.EventHandler(this.FormFilter_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tlpDate.ResumeLayout(false);
            this.tlpDate.PerformLayout();
            this.tlpNumber.ResumeLayout(false);
            this.tlpNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumberMin)).EndInit();
            this.tlpCollection.ResumeLayout(false);
            this.pnlString.ResumeLayout(false);
            this.pnlString.PerformLayout();
            this.tlpStringLength.ResumeLayout(false);
            this.tlpStringLength.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStringMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStringMax)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvFilter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Panel pnlString;
        private System.Windows.Forms.ToolStripMenuItem exportToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToClipBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromClipBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ComboBox cmbString;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.TableLayoutPanel tlpCollection;
        private System.Windows.Forms.ListBox lstCollection;
        private System.Windows.Forms.Button btnEditSub;
        private System.Windows.Forms.Button btnAddSub;
        private System.Windows.Forms.Button btnRemoveSub;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.ToolStripMenuItem addChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBrotherToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tlpStringLength;
        private System.Windows.Forms.CheckBox chkStringMin;
        private System.Windows.Forms.NumericUpDown numStringMin;
        private System.Windows.Forms.CheckBox chkStringMax;
        private System.Windows.Forms.NumericUpDown numStringMax;
        private System.Windows.Forms.TableLayoutPanel tlpNumber;
        private System.Windows.Forms.CheckBox chkNumberMax;
        private System.Windows.Forms.NumericUpDown numNumberMax;
        private System.Windows.Forms.CheckBox chkNumberMin;
        private System.Windows.Forms.NumericUpDown numNumberMin;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TableLayoutPanel tlpDate;
        private System.Windows.Forms.CheckBox chkDateStart;
        private System.Windows.Forms.CheckBox chkDateEnd;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDateStart;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.CheckedListBox clbEnum;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;


    }
}