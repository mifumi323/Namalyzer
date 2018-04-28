using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MifuminLib;
using MifuminLib.AccessAnalyzer;
using System.Linq;

namespace Namalyzer
{
    public partial class FormFilter : Form
    {
        //LogFilter filter;
        TreeNode selectedNode = null;

        public FormFilter()
        {
            InitializeComponent();
        }

        private void FormFilter_Load(object sender, EventArgs e)
        {
            cmbFilter.Items.AddRange(new object[]{
                new AliasObject<ELogFilter>(ELogFilter.All, "無条件フィルタ(全部通す)"),
                //new AliasObject<ELogFilter>(ELogFilter.Unknown, "不明なフィルタ"),

                new AliasObject<ELogFilter>(ELogFilter.Host, "ホスト名/IP"),
                new AliasObject<ELogFilter>(ELogFilter.RemoteLog, "リモートログ名"),
                new AliasObject<ELogFilter>(ELogFilter.User, "ユーザー名"),
                new AliasObject<ELogFilter>(ELogFilter.Date, "日付"),
                new AliasObject<ELogFilter>(ELogFilter.Month, "月のみ"),
                new AliasObject<ELogFilter>(ELogFilter.Day, "日のみ"),
                new AliasObject<ELogFilter>(ELogFilter.Weekday, "曜日"),
                new AliasObject<ELogFilter>(ELogFilter.Hour, "時間"),
                new AliasObject<ELogFilter>(ELogFilter.Method, "メソッド"),
                new AliasObject<ELogFilter>(ELogFilter.Requested, "リクエスト先"),
                new AliasObject<ELogFilter>(ELogFilter.HTTP, "HTTPのバージョン"),
                new AliasObject<ELogFilter>(ELogFilter.StatusCode, "ステータスコード"),
                new AliasObject<ELogFilter>(ELogFilter.SendSize, "転送量"),
                new AliasObject<ELogFilter>(ELogFilter.Referer, "リファラ"),
                new AliasObject<ELogFilter>(ELogFilter.Domain, "リファラのドメイン"),
                new AliasObject<ELogFilter>(ELogFilter.SearchPhrase, "検索に使われた語句"),
                new AliasObject<ELogFilter>(ELogFilter.UserAgent, "ユーザーエージェント"),

                new AliasObject<ELogFilter>(ELogFilter.And, "すべてのサブフィルタにマッチ"),
                new AliasObject<ELogFilter>(ELogFilter.Or, "少なくともひとつのサブフィルタにマッチ"),
                new AliasObject<ELogFilter>(ELogFilter.Nand, "すべてのサブフィルタにはマッチしない"),
                new AliasObject<ELogFilter>(ELogFilter.Nor, "どのサブフィルタにもマッチしない"),
            });
            cmbString.Items.AddRange(new object[]{
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.Length, "長さが範囲内"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.Match, "どれかひとつに完全一致"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.UnmatchAll, "どれにも完全一致しない"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.Contain, "どれかひとつを含む"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.UncontainAll, "どれも含まない"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.ContainAll, "すべてを含む"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.Uncontain, "すべては含まない"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.Start, "どれかひとつから始まる"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.NotStartAll, "どれからも始まらない"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.End, "どれかひとつで終わる"),
                new AliasObject<LogFilterString.MatchRule>(LogFilterString.MatchRule.NotEndAll, "どれでも終わらない"),
            });
        }

        public LogFilter Filter
        {
            get
            {
                return (LogFilter)trvFilter.Nodes[0].Tag;
            }
            set
            {
                trvFilter.Nodes.Clear();
                trvFilter.Nodes.Add(CreateTreeNode(value.Clone()));
            }
        }

        private void SetFilter(TreeNode node, LogFilter filter)
        {
            // 本項目を更新
            node.Tag = filter;
            node.Text = filter.ToString();

            // 子項目を更新
            node.Nodes.Clear();
            if (typeof(LogFilterCollection).IsInstanceOfType(filter))
            {
                LogFilter[] subFilter = ((LogFilterCollection)filter).subFilter;
                TreeNode[] children = new TreeNode[subFilter.Length];
                for (int i = 0; i < subFilter.Length; i++)
                {
                    children[i] = CreateTreeNode(subFilter[i]);
                }
                node.Nodes.AddRange(children);
                node.ExpandAll();
            }

            // 親項目を更新
            if (node.Parent != null)
            {
                if (typeof(LogFilterCollection).IsInstanceOfType(node.Parent.Tag))
                {
                    LogFilterCollection parent = (LogFilterCollection)node.Parent.Tag;
                    for (int i = 0; i < parent.subFilter.Length; i++)
                    {
                        if (node.Parent.Nodes[i] == node)
                        {
                            parent.subFilter[i] = filter;
                        }
                    }
                }
            }
        }

        TreeNode CreateTreeNode(LogFilter filter)
        {
            TreeNode node = new TreeNode();
            node.ContextMenuStrip = contextMenuStrip1;
            SetFilter(node, filter);
            return node;
        }

        private void trvFilter_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = e.Node;
            LogFilter selected = (LogFilter)selectedNode.Tag;
            ResetForm();
            EditForm(selected);
        }

        private void SetFilterSelector(LogFilter filter)
        {
            AliasObject<ELogFilter> oldType = (AliasObject<ELogFilter>)cmbFilter.SelectedItem;
            if (oldType != null && filter.FilterType() == oldType.Get()) return;

            cmbFilter.SelectedIndex = -1;
            for (int i = 0; i < cmbFilter.Items.Count; i++)
            {
                if (cmbFilter.Items[i].Equals(filter.FilterType()))
                {
                    cmbFilter.SelectedIndex = i;
                    break;
                }
            }
        }

        private void EditForm(LogFilter filter)
        {
            SetFilterSelector(filter);
            if (typeof(LogFilterAll).IsInstanceOfType(filter))
            {
                lblMessage.Text = "無条件フィルタなので設定項目はありません。";
                ShowForm(lblMessage);
            }
            else if (typeof(LogFilterString).IsInstanceOfType(filter))
            {
                LogFilterString strfilter = ((LogFilterString)filter);
                txtString.Text = strfilter.Matches;
                for (int i = 0; i < cmbString.Items.Count; i++)
                {
                    if (cmbString.Items[i].Equals(strfilter.matchRule))
                    {
                        cmbString.SelectedIndex = i;
                        break;
                    }
                }
                chkIgnoreCase.Checked = strfilter.IgnoreCase;
                txtString.Enabled = !(tlpStringLength.Enabled = strfilter.matchRule == LogFilterString.MatchRule.Length);
                chkStringMin.Checked = numStringMin.Enabled = strfilter.Min != long.MinValue;
                chkStringMax.Checked = numStringMax.Enabled = strfilter.Max != long.MaxValue;
                numStringMin.Minimum = numStringMax.Minimum = strfilter.LowerLimit();
                numStringMin.Maximum = numStringMax.Maximum = strfilter.UpperLimit();
                numStringMin.Value = numStringMin.Enabled ? strfilter.Min : strfilter.LowerLimit();
                numStringMax.Value = numStringMax.Enabled ? strfilter.Max : strfilter.UpperLimit();
                ShowForm(pnlString);
            }
            else if (typeof(LogFilterDate).IsInstanceOfType(filter))
            {
                LogFilterDate datfilter = ((LogFilterDate)filter);
                chkDateStart.Checked = dtpDateStart.Enabled = datfilter.Min != long.MinValue;
                chkDateEnd.Checked = dtpDateEnd.Enabled = datfilter.Max != long.MaxValue;
                dtpDateStart.MinDate = dtpDateEnd.MinDate = new DateTime(datfilter.LowerLimit());
                dtpDateStart.MaxDate = dtpDateEnd.MaxDate = new DateTime(datfilter.UpperLimit());
                dtpDateStart.Value = dtpDateStart.Enabled ? new DateTime(datfilter.Min) : new DateTime(datfilter.LowerLimit());
                dtpDateEnd.Value = dtpDateEnd.Enabled ? new DateTime(datfilter.Max) : DateTime.Now;
                lblDate.Text = datfilter.ToString();
                ShowForm(tlpDate);
            }
            else if (typeof(LogFilterNumber).IsInstanceOfType(filter))
            {
                LogFilterNumber numfilter = ((LogFilterNumber)filter);
                chkNumberMin.Checked = numNumberMin.Enabled = numfilter.Min != long.MinValue;
                chkNumberMax.Checked = numNumberMax.Enabled = numfilter.Max != long.MaxValue;
                numNumberMin.Minimum = numNumberMax.Minimum = numfilter.LowerLimit();
                numNumberMin.Maximum = numNumberMax.Maximum = numfilter.UpperLimit();
                numNumberMin.Value = numNumberMin.Enabled ? numfilter.Min : numfilter.LowerLimit();
                numNumberMax.Value = numNumberMax.Enabled ? numfilter.Max : numfilter.UpperLimit();
                lblNumber.Text = numfilter.ToString();
                ShowForm(tlpNumber);
            }
            else if (typeof(LogFilterCollection).IsInstanceOfType(filter))
            {
                lstCollection.Items.Clear();
                LogFilter[] subFilter = ((LogFilterCollection)filter).subFilter;
                lstCollection.Items.AddRange(subFilter);
                ShowForm(tlpCollection);
            }
            else if (typeof(LogFilterEnum).IsInstanceOfType(filter))
            {
                clbEnum.Items.Clear();
                foreach (KeyValuePair<object, bool> keyvalue in ((LogFilterEnum)filter).Matches)
                {
                    clbEnum.Items.Add(keyvalue.Key, keyvalue.Value);
                }
                ShowForm(clbEnum);
            }
            else
            {
                lblMessage.Text = "未知のフィルタです。\n適切なフィルタを設定しなおしてください。";
                ShowForm(lblMessage);
                ShowError(lblMessage.Text);
            }
        }

        private void ResetForm()
        {
            HideForm();

            // 設定項目なし
            lblMessage.Text = "";

            // 文字列フィルタ
            txtString.Text = "";
            cmbString.SelectedIndex = 0;
            chkIgnoreCase.Checked = false;
            chkStringMax.Checked = false;
            chkStringMin.Checked = false;

            // 日付フィルタ
            chkDateStart.Checked = false;
            chkDateEnd.Checked = false;

            // 数値フィルタ
            chkNumberMax.Checked = false;
            chkNumberMin.Checked = false;

            // 列挙型フィルタ
            clbEnum.Items.Clear();

            // 集合フィルタ
            lstCollection.Items.Clear();
        }

        private void HideForm()
        {
            lblMessage.Hide();
            pnlString.Hide();
            tlpNumber.Hide();
            tlpDate.Hide();
            clbEnum.Hide();
            tlpCollection.Hide();
        }

        private void ShowForm(Control control)
        {
            control.Dock = DockStyle.Fill;
            control.Show();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var parentFilter = (LogFilterCollection)trvFilter.SelectedNode.Parent.Tag;
            var parentNode = trvFilter.SelectedNode.Parent;
            if (RemoveFilter(SelectedFilter, parentFilter))
            {
                trvFilter.SelectedNode = parentNode;
                SelectedFilter = parentFilter;
            }
        }

        private bool RemoveFilter(LogFilter filter, LogFilterCollection parentFilter)
        {
            if (MessageBox.Show(this,
                "フィルタ\n　" +
                filter.ToString() +
                "\nを削除してもよろしいですか？",
                "削除の確認", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)
                != DialogResult.Yes)
            {
                return false;
            }

            parentFilter.subFilter = parentFilter.subFilter.Where(f => f != filter).ToArray();

            return true;
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            trvFilter.SelectedNode = selectedNode;
            if (selectedNode.Parent == null)
            {
                removeToolStripMenuItem.Enabled = false;
                addBrotherToolStripMenuItem.Enabled = false;
            }
            else
            {
                removeToolStripMenuItem.Enabled = true;
                addBrotherToolStripMenuItem.Enabled = true;
            }
            if (selectedNode.PrevNode == null)
            {
                upToolStripMenuItem.Enabled = false;
            }
            else
            {
                upToolStripMenuItem.Enabled = true;
            }
            if (selectedNode.NextNode == null)
            {
                downToolStripMenuItem.Enabled = false;
            }
            else
            {
                downToolStripMenuItem.Enabled = true;
            }
            if (typeof(LogFilterCollection).IsInstanceOfType(selectedNode.Tag))
            {
                addChildToolStripMenuItem.Enabled = true;
                sortToolStripMenuItem.Enabled = true;
            }
            else
            {
                addChildToolStripMenuItem.Enabled = false;
                sortToolStripMenuItem.Enabled = false;
            }
        }

        private void trvFilter_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            selectedNode = e.Node;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnAction, 0, btnAction.Height);
        }

        private void trvFilter_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            ;
        }

        private void ShowError(string err)
        {
            MessageBox.Show(this, err +
                "\n\nあなたが正しい操作をしたにもかかわらずこのエラーが起きた場合は開発側のミスです。" +
                "\nもしお差し支えなければエラーが起こった状況をご報告お願いします。"
                , "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // フィルタの種類がどのように変化したのか判断する
            if (cmbFilter.SelectedIndex < 0) return;
            ELogFilter type = ((AliasObject<ELogFilter>)cmbFilter.SelectedItem).Get();
            LogFilter oldfilter = SelectedFilter;
            if (type == oldfilter.FilterType()) return;

            // フィルタの種類が変更になったので作り直す
            LogFilter filter = LogFilter.Create(type);
            if (typeof(LogFilterString).IsInstanceOfType(filter))
            {
                LogFilterString strfilter = (LogFilterString)filter;
                strfilter.Matches = txtString.Text;
                strfilter.matchRule = ((AliasObject<LogFilterString.MatchRule>)cmbString.SelectedItem).Get();
                strfilter.IgnoreCase = chkIgnoreCase.Checked;
                if (chkStringMin.Checked) strfilter.Min = (long)numStringMin.Value;
                if (chkStringMax.Checked) strfilter.Max = (long)numStringMax.Value;
            }
            else if (typeof(LogFilterCollection).IsInstanceOfType(filter))
            {
                LogFilterCollection colfilter = (LogFilterCollection)filter;
                colfilter.subFilter = new LogFilter[lstCollection.Items.Count];
                for (int i = 0; i < lstCollection.Items.Count; i++)
                {
                    colfilter.subFilter[i] = (LogFilter)lstCollection.Items[i];
                }
            }

            // フォームに変更を反映
            HideForm();
            EditForm(filter);
            SelectedFilter = filter;
        }

        public LogFilter SelectedFilter
        {
            get
            {
                return (LogFilter)trvFilter.SelectedNode.Tag;
            }
            set
            {
                SetFilter(trvFilter.SelectedNode, value);
            }
        }

        private void exportToClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SafeClipboard.SetText(SelectedFilter.ToXmlString());
        }

        private void importFromClipBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                LogFilter filter = null;
                try
                {
                    filter = LogFilter.FromXmlString(Clipboard.GetText());
                }
                catch (Exception)
                {
                    return;
                }
                if (SelectedFilter.FilterType() != ELogFilter.All &&
                    SelectedFilter.FilterType() != ELogFilter.Unknown)
                {
                    if (MessageBox.Show(this,
                        "現在のフィルタの上書きしてもよろしいですか？", "確認",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.No) return;
                }
                HideForm();
                EditForm(filter);
                SelectedFilter = filter;
            }
        }

        private void exportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SelectedFilter.Save(saveFileDialog1.FileName);
            }
        }

        private void importFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LogFilter filter = LogFilter.Load(openFileDialog1.FileName);
                    if (SelectedFilter.FilterType() != ELogFilter.All &&
                        SelectedFilter.FilterType() != ELogFilter.Unknown)
                    {
                        if (MessageBox.Show(this,
                            "現在のフィルタの上書きしてもよろしいですか？", "確認",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.No) return;
                    }
                    HideForm();
                    EditForm(filter);
                    SelectedFilter = filter;
                }
                catch (Exception)
                {
                    ShowError("フィルタを読み込めませんでした。");
                }
            }
        }

        #region StringFilter

        private LogFilterString GetLogFilterString()
        {
            if (!pnlString.Visible) return null;
            LogFilter obj = SelectedFilter;
            if (typeof(LogFilterString).IsInstanceOfType(obj))
            {
                return (LogFilterString)obj;
            }
            else
            {
                ShowError("テキストを扱わないフィルタにテキストを入力しようとしました。");
                return null;
            }
        }

        private void txtString_TextChanged(object sender, EventArgs e)
        {
            LogFilterString strfilter = GetLogFilterString();
            if (strfilter == null) return;
            strfilter.Matches = txtString.Text;
            trvFilter.SelectedNode.Text = strfilter.ToString();
        }

        private void cmbString_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogFilterString strfilter = GetLogFilterString();
            if (strfilter == null) return;
            strfilter.matchRule = ((AliasObject<LogFilterString.MatchRule>)cmbString.SelectedItem).Get();
            trvFilter.SelectedNode.Text = strfilter.ToString();
            txtString.Enabled = !(tlpStringLength.Enabled = strfilter.matchRule == LogFilterString.MatchRule.Length);
        }

        private void chkIgnoreCase_CheckedChanged(object sender, EventArgs e)
        {
            LogFilterString strfilter = GetLogFilterString();
            if (strfilter == null) return;
            strfilter.IgnoreCase = chkIgnoreCase.Checked;
        }

        private void chkStringMin_CheckedChanged(object sender, EventArgs e)
        {
            LogFilterString strfilter = GetLogFilterString();
            if (strfilter == null) return;
            strfilter.Min = chkStringMin.Checked ?
                (long)numStringMin.Value :
                long.MinValue;
            numStringMin.Enabled = chkStringMin.Checked;
            trvFilter.SelectedNode.Text = strfilter.ToString();
        }

        private void chkStringMax_CheckedChanged(object sender, EventArgs e)
        {
            LogFilterString strfilter = GetLogFilterString();
            if (strfilter == null) return;
            strfilter.Max = chkStringMax.Checked ?
                (long)numStringMax.Value :
                long.MaxValue;
            numStringMax.Enabled = chkStringMax.Checked;
            trvFilter.SelectedNode.Text = strfilter.ToString();
        }

        private void numStringMin_ValueChanged(object sender, EventArgs e)
        {
            LogFilterString strfilter = GetLogFilterString();
            if (strfilter == null) return;
            strfilter.Min = chkStringMin.Checked ?
                (long)numStringMin.Value :
                long.MinValue;
            trvFilter.SelectedNode.Text = strfilter.ToString();
        }

        private void numStringMax_ValueChanged(object sender, EventArgs e)
        {
            LogFilterString strfilter = GetLogFilterString();
            if (strfilter == null) return;
            strfilter.Max = chkStringMax.Checked ?
                (long)numStringMax.Value :
                long.MaxValue;
            trvFilter.SelectedNode.Text = strfilter.ToString();
        }
        
        #endregion

        #region DateFilter

        private LogFilterDate GetLogFilterDate()
        {
            if (!tlpDate.Visible) return null;
            LogFilter obj = SelectedFilter;
            if (typeof(LogFilterDate).IsInstanceOfType(obj))
            {
                return (LogFilterDate)obj;
            }
            else
            {
                ShowError("日付を扱わないフィルタに日付を入力しようとしました。");
                return null;
            }
        }

        private void chkDateStart_CheckedChanged(object sender, EventArgs e)
        {
            LogFilterDate datfilter = GetLogFilterDate();
            if (datfilter == null) return;
            datfilter.Min = chkDateStart.Checked ?
                dtpDateStart.Value.Ticks :
                long.MinValue;
            dtpDateStart.Enabled = chkDateStart.Checked;
            lblDate.Text = trvFilter.SelectedNode.Text = datfilter.ToString();
        }

        private void chkDateEnd_CheckedChanged(object sender, EventArgs e)
        {
            LogFilterDate datfilter = GetLogFilterDate();
            if (datfilter == null) return;
            datfilter.Max = chkDateEnd.Checked ?
                dtpDateEnd.Value.Ticks :
                long.MaxValue;
            dtpDateEnd.Enabled = chkDateEnd.Checked;
            lblDate.Text = trvFilter.SelectedNode.Text = datfilter.ToString();
        }

        private void dtpDateStart_ValueChanged(object sender, EventArgs e)
        {
            LogFilterDate datfilter = GetLogFilterDate();
            if (datfilter == null) return;
            datfilter.Min = chkDateStart.Checked ?
                dtpDateStart.Value.Ticks :
                long.MinValue;
            lblDate.Text = trvFilter.SelectedNode.Text = datfilter.ToString();
        }

        private void dtpDateEnd_ValueChanged(object sender, EventArgs e)
        {
            LogFilterDate datfilter = GetLogFilterDate();
            if (datfilter == null) return;
            datfilter.Max = chkDateEnd.Checked ?
                dtpDateEnd.Value.Ticks :
                long.MaxValue;
            lblDate.Text = trvFilter.SelectedNode.Text = datfilter.ToString();
        }
        
        #endregion

        #region NumberFilter

        private LogFilterNumber GetLogFilterNumber()
        {
            if (!tlpNumber.Visible) return null;
            LogFilter obj = SelectedFilter;
            if (typeof(LogFilterNumber).IsInstanceOfType(obj))
            {
                return (LogFilterNumber)obj;
            }
            else
            {
                ShowError("数値を扱わないフィルタに数値を入力しようとしました。");
                return null;
            }
        }

        private void chkNumberMax_CheckedChanged(object sender, EventArgs e)
        {
            LogFilterNumber numfilter = GetLogFilterNumber();
            if (numfilter == null) return;
            numfilter.Max = chkNumberMax.Checked ?
                (long)numNumberMax.Value :
                long.MaxValue;
            numNumberMax.Enabled = chkNumberMax.Checked;
            lblNumber.Text = trvFilter.SelectedNode.Text = numfilter.ToString();
        }

        private void chkNumberMin_CheckedChanged(object sender, EventArgs e)
        {
            LogFilterNumber numfilter = GetLogFilterNumber();
            if (numfilter == null) return;
            numfilter.Min = chkNumberMin.Checked ?
                (long)numNumberMin.Value :
                long.MinValue;
            numNumberMin.Enabled = chkNumberMin.Checked;
            lblNumber.Text = trvFilter.SelectedNode.Text = numfilter.ToString();
        }

        private void numNumberMax_ValueChanged(object sender, EventArgs e)
        {
            LogFilterNumber numfilter = GetLogFilterNumber();
            if (numfilter == null) return;
            numfilter.Max = chkNumberMax.Checked ?
                (long)numNumberMax.Value :
                long.MaxValue;
            lblNumber.Text = trvFilter.SelectedNode.Text = numfilter.ToString();
        }

        private void numNumberMin_ValueChanged(object sender, EventArgs e)
        {
            LogFilterNumber numfilter = GetLogFilterNumber();
            if (numfilter == null) return;
            numfilter.Min = chkNumberMin.Checked ?
                (long)numNumberMin.Value :
                long.MinValue;
            lblNumber.Text = trvFilter.SelectedNode.Text = numfilter.ToString();
        }
        
        #endregion

        #region EnumFilter

        private LogFilterEnum GetLogFilterEnum()
        {
            if (!clbEnum.Visible) return null;
            LogFilter obj = SelectedFilter;
            if (typeof(LogFilterEnum).IsInstanceOfType(obj))
            {
                return (LogFilterEnum)obj;
            }
            else
            {
                ShowError("列挙型を扱わないフィルタに列挙型を入力しようとしました。");
                return null;
            }
        }

        private void clbEnum_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            LogFilterEnum enumfilter = GetLogFilterEnum();
            if (enumfilter == null) return;
            enumfilter.Matches[clbEnum.Items[e.Index]] = e.NewValue == CheckState.Checked;
            trvFilter.SelectedNode.Text = enumfilter.ToString();
        }
        
        #endregion

        #region CollectionFilter

        private void lstCollection_DoubleClick(object sender, EventArgs e)
        {
            btnEditSub.PerformClick();
        }

        private void btnEditSub_Click(object sender, EventArgs e)
        {
            if (lstCollection.SelectedIndex < 0) return;
            trvFilter.SelectedNode = trvFilter.SelectedNode.Nodes[lstCollection.SelectedIndex];
        }

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            LogFilterCollection target = (LogFilterCollection)SelectedFilter;
            LogFilter[] subFilter = new LogFilter[target.subFilter.Length + 1];
            target.subFilter.CopyTo(subFilter, 0);
            subFilter[subFilter.Length - 1] = new LogFilterAll();
            target.subFilter = subFilter;
            SelectedFilter = target;
            trvFilter.SelectedNode = trvFilter.SelectedNode.Nodes[subFilter.Length - 1];
        }

        private void btnRemoveSub_Click(object sender, EventArgs e)
        {
            ShowError("未実装です＞＜");
        }

        private void addChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddSub.PerformClick();
        }

        private void addBrotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode parent = trvFilter.SelectedNode.Parent;
            LogFilterCollection target = (LogFilterCollection)parent.Tag;
            LogFilter[] subFilter = new LogFilter[target.subFilter.Length + 1];
            target.subFilter.CopyTo(subFilter, 0);
            subFilter[subFilter.Length - 1] = new LogFilterAll();
            target.subFilter = subFilter;
            SetFilter(parent, target);
            trvFilter.SelectedNode = parent.Nodes[subFilter.Length - 1];
        }
        
        #endregion

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = trvFilter.SelectedNode.PrevNode;
            if (node == null) return;
            LogFilter filter = (LogFilter)node.Tag;
            SetFilter(node, (LogFilter)trvFilter.SelectedNode.Tag);
            SetFilter(trvFilter.SelectedNode, filter);
            trvFilter.SelectedNode = node;
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = trvFilter.SelectedNode.NextNode;
            if (node == null) return;
            LogFilter filter = (LogFilter)node.Tag;
            SetFilter(node, (LogFilter)trvFilter.SelectedNode.Tag);
            SetFilter(trvFilter.SelectedNode, filter);
            trvFilter.SelectedNode = node;
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!typeof(LogFilterCollection).IsInstanceOfType(SelectedFilter)) return;
            LogFilterCollection filter = (LogFilterCollection)SelectedFilter;
            Array.Sort(filter.subFilter, FilterComparison);
            SetFilter(trvFilter.SelectedNode, SelectedFilter);
            HideForm();
            EditForm(SelectedFilter);
        }

        private int FilterComparison(LogFilter a, LogFilter b)
        {
            return string.Compare(a.ToString(), b.ToString());
        }

    }
}