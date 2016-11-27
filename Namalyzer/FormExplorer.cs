using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Namalyzer
{
    public partial class FormExplorer : Form
    {
        string directory = "";
        Log[] logs;
        public AccessLog LogData;

        class ExplorerItem
        {
            public ExplorerItem()
            {
                item = new ListViewItem();
                item.SubItems.Add("");
                item.SubItems.Add("");
                FileName = "";
            }

            public void Update(ListViewGroupCollection groups)
            {
                item.ImageIndex = ( fileName.EndsWith("/")? 0 : 3) + (statusCode / 100 == 2 ? 0 : (statusCode / 100 < 4 ? 1 : 2));
                item.SubItems[0].Text = fileName;
                item.SubItems[1].Text = requestNumber.ToString();
                item.SubItems[2].Text = statusCode.ToString() + "(" + (100 * statusRate / requestNumber) + "%)";
                item.Group = groups[fileName.EndsWith("/") ? 0 : 1];
            }

            private ListViewItem item;
            public ListViewItem Item { get { return item; } }

            private string fileName;
            public string FileName { get { return fileName; } set { fileName = value; } }

            private short statusCode;
            public short StatusCode { get { return statusCode; } set { statusCode = value; } }

            private int statusRate;
            public int StatusRate { get { return statusRate; } set { statusRate = value; } }

            private int requestNumber;
            public int RequestNumber { get { return requestNumber; } set { requestNumber = value; } }
	
        }
        ExplorerItem[] items = new ExplorerItem[0];
        Comparison<ExplorerItem> comparison = FileNameComparison;

        static int FileNameComparison(ExplorerItem x, ExplorerItem y)
        {
            return String.Compare(x.FileName, y.FileName);
        }
        static int RequestNumberComparison(ExplorerItem x, ExplorerItem y)
        {
                int diff = y.RequestNumber - x.RequestNumber;
                if (diff != 0) return diff;
                return String.Compare(x.FileName, y.FileName);
        }
        static int StatusCodeComparison(ExplorerItem x, ExplorerItem y)
        {
                int diff = x.StatusCode - y.StatusCode;
                if (diff != 0) return diff;
                return String.Compare(x.FileName, y.FileName);
        }

        public FormExplorer()
        {
            InitializeComponent();
        }

        private void tsbViewLargeIcon_Click(object sender, EventArgs e)
        {
            lsvExplorer.View = View.LargeIcon;
            tsbViewLargeIcon.Checked = true;
            tsbViewDetails.Checked = false;
            tsbViewSmallIcon.Checked = false;
            tsbViewList.Checked = false;
            tsbViewTile.Checked = false;
        }

        private void tsbViewDetails_Click(object sender, EventArgs e)
        {
            lsvExplorer.View = View.Details;
            tsbViewLargeIcon.Checked = false;
            tsbViewDetails.Checked = true;
            tsbViewSmallIcon.Checked = false;
            tsbViewList.Checked = false;
            tsbViewTile.Checked = false;
        }

        private void tsbViewSmallIcon_Click(object sender, EventArgs e)
        {
            lsvExplorer.View = View.SmallIcon;
            tsbViewLargeIcon.Checked = false;
            tsbViewDetails.Checked = false;
            tsbViewSmallIcon.Checked = true;
            tsbViewList.Checked = false;
            tsbViewTile.Checked = false;
        }

        private void tsbViewList_Click(object sender, EventArgs e)
        {
            lsvExplorer.View = View.List;
            tsbViewLargeIcon.Checked = false;
            tsbViewDetails.Checked = false;
            tsbViewSmallIcon.Checked = false;
            tsbViewList.Checked = true;
            tsbViewTile.Checked = false;
        }

        private void tsbViewTile_Click(object sender, EventArgs e)
        {
            lsvExplorer.View = View.Tile;
            tsbViewLargeIcon.Checked = false;
            tsbViewDetails.Checked = false;
            tsbViewSmallIcon.Checked = false;
            tsbViewList.Checked = false;
            tsbViewTile.Checked = true;
        }

        public void UpdateFunc(Log[] logs)
        {
            this.logs = logs;
            Explore(directory);
        }

        public void Explore(string directory)
        {
            logs = LogData.GetTarget();
            Dictionary<string, Dictionary<short, int>> dic = new Dictionary<string, Dictionary<short, int>>();
            string req, fileName;
            int dirLength = directory.Length;
            int i1, i2;
            foreach (Log log in logs)
            {
                req = log.Requested;
                if (req.Length >= directory.Length && req.StartsWith(directory))
                {
                    Dictionary<short, int> status;
                    fileName = req.Substring(dirLength);
                    i1 = fileName.IndexOf('?');
                    i2 = fileName.IndexOf('/') + 1;
                    if (i1 >= 0)
                    {
                        if (i2 > 0) fileName = fileName.Substring(0, Math.Min(i1, i2));
                        else fileName = fileName.Substring(0, i1);
                    }
                    else
                    {
                        if (i2 > 0) fileName = fileName.Substring(0, i2);
                    }
                    if (!dic.TryGetValue(fileName, out status)) dic.Add(fileName, status = new Dictionary<short, int>());
                    if (status.ContainsKey(log.sStatus)) status[log.sStatus]++;
                    else status.Add(log.sStatus, 1);
                }
            }
            items = new ExplorerItem[dic.Count];
            int i = 0;
            foreach (KeyValuePair<string, Dictionary<short, int>> d in dic)
            {
                short msc = 0;
                int mrq = 0, arq = 0, rq;
                foreach (KeyValuePair<short, int> sc in d.Value)
                {
                    if ((rq = sc.Value) > mrq)
                    {
                        mrq = rq;
                        msc = sc.Key;
                    }
                    arq += rq;
                }
                items[i] = new ExplorerItem();
                items[i].FileName = d.Key;
                items[i].RequestNumber = arq;
                items[i].StatusCode = msc;
                items[i].StatusRate = mrq;
                items[i].Update(lsvExplorer.Groups);
                i++;
            }
            SortItems();
            Text = "エクスプローラ表示 - " + (tstDirectory.Text = this.directory = directory);
        }

        private void FormExplorer_Load(object sender, EventArgs e)
        {
            LogData.AddUpdateFunc(UpdateFunc);
            tsbViewLargeIcon_Click(null, null);
        }

        private void FormExplorer_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogData.RemoveUpdateFunc(UpdateFunc);
        }

        private void lsvExplorer_DoubleClick(object sender, EventArgs e)
        {
            string sel = lsvExplorer.SelectedItems[0].Text;
            string next = directory + sel;
            if (sel.Length > 0 && next.EndsWith("/")) Explore(next);
            else
            {
                FormStatistics f = new FormStatistics();
                LogFilterRequested l1 = new LogFilterRequested(), l2 = new LogFilterRequested();
                LogFilterOr lf = new LogFilterOr();
                lf.subFilter = new LogFilter[] { l1, l2 };
                l1.Matches = next;
                l1.matchRule = LogFilterString.MatchRule.Match;
                l2.Matches = next + "?";
                l2.matchRule = LogFilterString.MatchRule.Start;
                f.Filter = lf;
                f.MdiParent = MdiParent;
                f.Show();
            }
        }

        private void tsbUpDirectory_Click(object sender, EventArgs e)
        {
            if (directory.Length > 1) Explore(directory.Substring(0, directory.LastIndexOf('/', directory.Length - 2) + 1));
        }

        private void lsvExplorer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (e.Column)
            {
                case 0: comparison = FileNameComparison; break;
                case 1: comparison = RequestNumberComparison; break;
                case 2: comparison = StatusCodeComparison; break;
            }
            SortItems();
        }

        private void SortItems()
        {
            Array.Sort(items, comparison);
            lsvExplorer.Items.Clear();
            foreach (ExplorerItem item in items)
            {
                item.Update(lsvExplorer.Groups);
                lsvExplorer.Items.Add(item.Item);
            }
        }
    }
}