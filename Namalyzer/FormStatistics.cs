using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MifuminLib;
using System.Text;
using MifuminLib.AccessAnalyzer;

namespace Namalyzer
{
    public partial class FormStatistics : Form
    {
        Log[] original = new Log[0], logs = new Log[0];

        UpdateFunc view;
        int viewIndex = -1;

        bool urldecode = false;
        Encoding urlencoding = Encoding.UTF8;
        bool ignorecase = false;
        int lowerLimit = 1;

        bool urldecodemenuopened = false;
        ToolStripMenuItem selectedurldecodemenu = null;

        private LogFilter filter;
        public LogFilter Filter
        {
            get { return filter; }
            set
            {
                filter = value != null ? value : new LogFilterAll();
                btnFilter.Text = "フィルタ：" + filter.ToString();
                if (original != null) UpdateFunc(original);
            }
        }

        enum ListLine
        {
            Request,
            SendSum,
            Max
        }

        public FormStatistics()
        {
            InitializeComponent();
            view = UpdateMain;
            for (int i = 0; i < (int)ListLine.Max; i++) lstStatistics.Items.Add("");
            Filter = new LogFilterAll();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FormFilter f = new FormFilter();
            f.Filter = Filter;
            f.Text = "詳細フィルタ編集";
            if (f.ShowDialog(this) == DialogResult.OK) Filter = f.Filter;
        }

        public void UpdateFunc(Log[] o)
        {
            logs = Filter.Extract(original = o);
            CallUpdateFunc(logs);
        }

        private void UpdateGridView<T>(KeyValuePair<T, int>[] c)
        {
            dgvRank.RowCount = c.Length;
            int sum = 0, max = 1;
            foreach (KeyValuePair<T, int> v in c) { sum += v.Value; if (max < v.Value) max = v.Value; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            int val, prev = -1;
            for (int i = 0; i < c.Length; i++)
            {
                val = c[i].Value;
                dgvRank[0, i].Value = (val == prev ? dgvRank[0, i - 1].Value : (i + 1).ToString() + "位");
                dgvRank[1, i].Value = c[i].Key;
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
                prev = val;
            }
        }

        private void FormStatistics_Shown(object sender, EventArgs e)
        { ((FormMain)MdiParent).LogData.AddUpdateFunc(UpdateFunc); }
        private void FormStatistics_FormClosed(object sender, FormClosedEventArgs e)
        { ((FormMain)MdiParent).LogData.RemoveUpdateFunc(UpdateFunc); }

        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object text = null;
            if (dgvRank.Visible) text = dgvRank.SelectedCells[0].Value;
            else if (lstStatistics.Visible) text = lstStatistics.SelectedItem;
            SafeClipboard.SetText(text);
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            AddUpdateFunc("全般", UpdateMain);
            AddUpdateFunc("ホスト名/IP", UpdateHost);
            AddUpdateFunc("リモートログ名", UpdateRemoteLog);
            AddUpdateFunc("ユーザー名", UpdateUser);
            AddUpdateFunc("日付", UpdateDate);
            AddUpdateFunc("年月", UpdateAge);
            AddUpdateFunc("月のみ", UpdateMonth);
            AddUpdateFunc("日のみ", UpdateDay);
            AddUpdateFunc("曜日", UpdateWeekday);
            AddUpdateFunc("時間", UpdateHour);
            AddUpdateFunc("メソッド", UpdateMethod);
            AddUpdateFunc("リクエスト先", UpdateRequested);
            AddUpdateFunc("HTTPのバージョン", UpdateHTTP);
            AddUpdateFunc("ステータスコード", UpdateStatusCode);
            AddUpdateFunc("転送量", UpdateSendSize);
            AddUpdateFunc("リファラ", UpdateReferer);
            AddUpdateFunc("リファラのドメイン", UpdateDomain);
            AddUpdateFunc("検索に使われた語句", UpdateSearchPhrase);
            AddUpdateFunc("ユーザーエージェント", UpdateUserAgent);
            cmsView.Items[0].PerformClick();

            SetLowerLimit(1);
        }

        private void SetLowerLimit(int p)
        {
            lowerLimit = p;
            lowerLimitToolStripMenuItem.Text = p.ToString() + "件以上の項目のみ表示";
        }

        private void AddUpdateFunc(string name, UpdateFunc func)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(name, null, new EventHandler(changeViewToolStripMenuItem_Click));
            item.Tag = func;
            cmsView.Items.Add(item);
        }

        private void CallUpdateFunc(Log[] logs)
        {
            if (logs.Length == 0)
            {
                BeginUpdate();
                EndUpdate(lblEmpty);
                return;
            }
            view(logs);
        }

        private void UpdateMain(Log[] logs)
        {
            BeginUpdate();

            long lSendSum = 0;

            foreach (Log l in logs)
            {
                lSendSum += l.iSendSize;
            }

            lstStatistics.Items[(int)ListLine.Request] = "リクエスト数：" + logs.Length.ToString("N0");
            lstStatistics.Items[(int)ListLine.SendSum] = "転送量合計：" + lSendSum.ToString("N0") + "バイト";

            EndUpdate(lstStatistics);
        }

        private void UpdateHost(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs) IncrementDictionary(d, l.strHost);
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateRemoteLog(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs) IncrementDictionary(d, l.strRemoteLog);
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateUser(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs) IncrementDictionary(d, l.strUser);
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateDate(Log[] logs)
        {
            BeginUpdate();

            Dictionary<int, int> d = new Dictionary<int, int>();

            int val;
            foreach (Log l in logs)
            {
                DateTime date = new DateTime(l.lDate);
                int n = date.Year * 10000 + date.Month * 100 + date.Day;
                d[n] = d.TryGetValue(n, out val) ? val + 1 : 1;
            }

            KeyValuePair<int, int>[] c = new KeyValuePair<int, int>[d.Count];
            int j = 0;
            foreach (KeyValuePair<int, int> p in d) c[j++] = p;
            Array.Sort(c, IntKeyComparison);
            dgvRank.RowCount = c.Length;
            int sum = 0, max = 1;
            foreach (KeyValuePair<int, int> v in c) { sum += v.Value; if (max < v.Value) max = v.Value; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            int prev = -1;
            for (int i = 0; i < c.Length; i++)
            {
                val = c[i].Value;
                dgvRank[0, i].Value = "-";
                dgvRank[1, i].Value = String.Format("{0:d4}/{1:d2}/{2:d2}", c[i].Key / 10000, (c[i].Key / 100) % 100, c[i].Key % 100);
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
                prev = val;
            }

            EndUpdate(dgvRank);
        }

        private void UpdateAge(Log[] logs)
        {
            BeginUpdate();

            Dictionary<int, int> d = new Dictionary<int, int>();

            int val;
            foreach (Log l in logs)
            {
                DateTime date = new DateTime(l.lDate);
                int n = date.Year * 100 + date.Month;
                d[n] = d.TryGetValue(n, out val) ? val + 1 : 1;
            }

            KeyValuePair<int, int>[] c = new KeyValuePair<int, int>[d.Count];
            int j = 0;
            foreach (KeyValuePair<int, int> p in d) c[j++] = p;
            Array.Sort(c, IntKeyComparison);
            dgvRank.RowCount = c.Length;
            int sum = 0, max = 1;
            foreach (KeyValuePair<int, int> v in c) { sum += v.Value; if (max < v.Value) max = v.Value; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            for (int i = 0; i < c.Length; i++)
            {
                val = c[i].Value;
                dgvRank[0, i].Value = "-";
                dgvRank[1, i].Value = String.Format("{0:d2}年{1:d2}月", (c[i].Key / 100) % 100, c[i].Key % 100);
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
            }

            EndUpdate(dgvRank);
        }

        private void UpdateMonth(Log[] logs)
        {
            BeginUpdate();

            int[] a = new int[12];

            int val;
            foreach (Log l in logs)
            {
                DateTime date = new DateTime(l.lDate);
                a[date.Month - 1]++;
            }

            dgvRank.RowCount = a.Length;
            int sum = 0, max = 1;
            foreach (int v in a) { sum += v; if (max < v) max = v; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            for (int i = 0; i < 12; i++)
            {
                val = a[i];
                dgvRank[0, i].Value = "-";
                dgvRank[1, i].Value = String.Format("{0:d2}月", i + 1);
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
            }

            EndUpdate(dgvRank);
        }

        private void UpdateDay(Log[] logs)
        {
            BeginUpdate();

            int[] a = new int[31];

            int val;
            foreach (Log l in logs)
            {
                DateTime date = new DateTime(l.lDate);
                a[date.Day - 1]++;
            }

            dgvRank.RowCount = a.Length;
            int sum = 0, max = 1;
            foreach (int v in a) { sum += v; if (max < v) max = v; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            for (int i = 0; i < 31; i++)
            {
                val = a[i];
                dgvRank[0, i].Value = "-";
                dgvRank[1, i].Value = String.Format("{0:d2}日", i + 1);
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
            }

            EndUpdate(dgvRank);
        }

        private void UpdateWeekday(Log[] logs)
        {
            BeginUpdate();

            int[] a = new int[7];

            int val;
            foreach (Log l in logs)
            {
                DateTime date = new DateTime(l.lDate);
                a[(int)date.DayOfWeek]++;
            }

            dgvRank.RowCount = a.Length;
            int sum = 0, max = 1;
            foreach (int v in a) { sum += v; if (max < v) max = v; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            dgvRank[1, 0].Value = "日";
            dgvRank[1, 1].Value = "月";
            dgvRank[1, 2].Value = "火";
            dgvRank[1, 3].Value = "水";
            dgvRank[1, 4].Value = "木";
            dgvRank[1, 5].Value = "金";
            dgvRank[1, 6].Value = "土";
            for (int i = 0; i < 7; i++)
            {
                val = a[i];
                dgvRank[0, i].Value = "-";
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
            }

            EndUpdate(dgvRank);
        }

        private void UpdateHour(Log[] logs)
        {
            BeginUpdate();

            int[] a = new int[24];

            int val;
            foreach (Log l in logs)
            {
                DateTime date = new DateTime(l.lDate);
                a[date.Hour]++;
            }

            dgvRank.RowCount = a.Length;
            int sum = 0, max = 1;
            foreach (int v in a) { sum += v; if (max < v) max = v; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            for (int i = 0; i < a.Length; i++)
            {
                val = a[i];
                dgvRank[0, i].Value = "-";
                dgvRank[1, i].Value = String.Format("{0:d2}時", i);
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
            }

            EndUpdate(dgvRank);
        }

        private void UpdateMethod(Log[] logs)
        {
            BeginUpdate();

            Dictionary<Log.EMethod, int> d = new Dictionary<Log.EMethod, int>();

            int val;
            foreach (Log l in logs) d[l.eMethod] = d.TryGetValue(l.eMethod, out val) ? val + 1 : 1;
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateRequested(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs) IncrementDictionary(d, l.strRequested);
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateHTTP(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs) IncrementDictionary(d, l.HTTP);
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateStatusCode(Log[] logs)
        {
            BeginUpdate();

            Dictionary<short, int> d = new Dictionary<short, int>();

            int val;
            foreach (Log l in logs) d[l.sStatus] = d.TryGetValue(l.sStatus, out val) ? val + 1 : 1;
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateSendSize(Log[] logs)
        {
            BeginUpdate();

            int[] a = new int[10];

            int val;
            foreach (Log l in logs) a[Log10B(l.SendSize)]++;

            dgvRank.RowCount = a.Length;
            int sum = 0, max = 1;
            foreach (int v in a) { sum += v; if (max < v) max = v; }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            dgvRank[1, 0].Value = "なし";
            dgvRank[1, 1].Value = "1B～";
            dgvRank[1, 2].Value = "10B～";
            dgvRank[1, 3].Value = "100B～";
            dgvRank[1, 4].Value = "1KB～";
            dgvRank[1, 5].Value = "10KB～";
            dgvRank[1, 6].Value = "100KB～";
            dgvRank[1, 7].Value = "1MB～";
            dgvRank[1, 8].Value = "10MB～";
            dgvRank[1, 9].Value = "100MB～";
            for (int i = 0; i < 10; i++)
            {
                val = a[i];
                dgvRank[0, i].Value = "-";
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
            }

            EndUpdate(dgvRank);
        }

        private int Log10B(int p)
        {
            return p == 0 ? 0 :
                (p < 10 ? 1 :
                (p < 100 ? 2 :
                (p < 1000 ? 3 :
                (p < 10000 ? 4 :
                (p < 100000 ? 5 :
                (p < 1000000 ? 6 :
                (p < 10000000 ? 7 :
                (p < 100000000 ? 8 :
                9))))))));
        }

        private void UpdateReferer(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs) IncrementDictionary(d, l.strReferer);
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateDomain(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs)
            {
                string domain;
                if (l.strReferer.Contains("://"))
                {
                    try { domain = new Uri(l.strReferer).Host; }
                    catch (Exception) { continue; }
                }
                else
                {
                    continue;
                }
                IncrementDictionary(d, domain);
            }
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateSearchPhrase(Log[] logs)
        {
            BeginUpdate();

            var d = new Dictionary<string, int>();

            var refererAnalyzer = new RefererAnalyzer();
            foreach (Log l in logs)
            {
                if (l.strReferer == null || l.strReferer.Length < 8) continue;
                try
                {
                    var phrase = refererAnalyzer.GetSearchQuery(l.strReferer);
                    if (!string.IsNullOrWhiteSpace(phrase))
                    {
                        IncrementDictionary(d, phrase.Trim());
                    }
                }
                catch (Exception)
                {
                    // エラーは無視しちゃおうねー
                }
            }
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateUserAgent(Log[] logs)
        {
            BeginUpdate();

            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (Log l in logs) IncrementDictionary(d, l.strUserAgent);
            UpdateGridView(d);

            EndUpdate(dgvRank);
        }

        private void UpdateGridView<T>(Dictionary<T, int> d)
        {
            KeyValuePair<T, int>[] c = new KeyValuePair<T, int>[d.Count];
            int j = 0;
            foreach (KeyValuePair<T, int> p in d)
            {
                if (p.Value >= lowerLimit) c[j++] = p;
            }
            Array.Sort(c, 0, j, new RankComparer<T>());
            dgvRank.RowCount = j;
            int sum = 0, max = 1;
            for (int i = 0; i < j; i++)
            {
                KeyValuePair<T, int> v = c[i];
                sum += v.Value; if (max < v.Value) max = v.Value;
            }
            string f = 100 * sum / max >= 10 ? "0.0" : "0.00";
            int val, prev = -1;
            for (int i = 0; i < j; i++)
            {
                val = c[i].Value;
                dgvRank[0, i].Value = (val == prev ? dgvRank[0, i - 1].Value : (i + 1).ToString() + "位");
                dgvRank[1, i].Value = c[i].Key;
                dgvRank[2, i].Value = val;
                dgvRank[3, i].Value = (100.0 * val / sum).ToString(f) + "%";
                dgvRank[4, i].Value = new string('+', 10 * val / max);
                prev = val;
            }
        }

        public void IncrementDictionary(Dictionary<string, int> d, string value)
        {
            int num;
            if (urldecode) value = System.Web.HttpUtility.UrlDecode(value, urlencoding);
            if (ignorecase) value = value.ToLower();
            d[value] = d.TryGetValue(value, out num) ? num + 1 : 1;
        }

        private class RankComparer<T> : IComparer<KeyValuePair<T, int>>
        {
            public int Compare(KeyValuePair<T, int> x, KeyValuePair<T, int> y)
            {
                int ret = y.Value - x.Value;
                return ret != 0 ? ret : string.Compare(x.Key.ToString(), y.Key.ToString());
            }
        }

        public int IntKeyComparison(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            return x.Key - y.Key;
        }

        private void BeginUpdate()
        {
            if (viewIndex < 0) return;
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls[viewIndex].Visible = false;
            tableLayoutPanel1.Controls.RemoveAt(viewIndex);
        }

        private void EndUpdate(Control control)
        {
            tableLayoutPanel1.Controls.Add(control, 0, 1);
            viewIndex = tableLayoutPanel1.Controls.IndexOf(control);
            tableLayoutPanel1.SetColumnSpan(control, 2);
            control.Dock = DockStyle.Fill;
            control.Visible = true;
            tableLayoutPanel1.ResumeLayout();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            cmsView.Show(btnView, 0, btnView.Height);
        }

        private void changeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ctrl = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem var in cmsView.Items)
            {
                var.Checked = (var == ctrl);
            }
            btnView.Text = "表示：" + ctrl.Text;
            view = (UpdateFunc)ctrl.Tag;
            CallUpdateFunc(logs);
        }

        private void ignoreCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ignoreCaseToolStripMenuItem.Checked = ignorecase = !ignorecase;
            CallUpdateFunc(logs);
        }

        private void lowerLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLowerLimit((int)NumberInputBox.Show(
                this,
                "下限を入力してください。",
                (decimal)1,
                (decimal)int.MaxValue,
                (decimal)lowerLimit
                ));
            CallUpdateFunc(logs);
        }

        private void urldecodeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (!urldecodemenuopened)
            {
                int t = System.Environment.TickCount;
                EncodingInfo[] eis = Encoding.GetEncodings();
                ToolStripMenuItem[] mis = new ToolStripMenuItem[eis.Length];
                for (int i = 0; i < eis.Length; i++)
                {
                    mis[i] = new ToolStripMenuItem(eis[i].DisplayName);
                    mis[i].Tag = eis[i].CodePage;
                    mis[i].Click += urldecodeToolStripMenuItem_Click;
                }
                urldecodeToolStripMenuItem.DropDownItems.AddRange(mis);
                selectedurldecodemenu = urlnodecodeToolStripMenuItem;
                urldecodemenuopened = true;
            }
        }

        private void urldecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            selectedurldecodemenu.Checked = false;
            menu.Checked = true;
            urlencoding = Encoding.GetEncoding((int)menu.Tag, EncoderFallback.ReplacementFallback, DecoderFallback.ReplacementFallback);
            urldecode = true;
            selectedurldecodemenu = menu;
            CallUpdateFunc(logs);
        }

        private void urlnodecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedurldecodemenu.Checked = false;
            urlnodecodeToolStripMenuItem.Checked = true;
            urldecode = false;
            selectedurldecodemenu = urlnodecodeToolStripMenuItem;
            CallUpdateFunc(logs);
        }
    }
}