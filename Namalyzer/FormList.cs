using System;
using System.Windows.Forms;
using MifuminLib;
using MifuminLib.AccessAnalyzer;

namespace Namalyzer
{
    public partial class FormList : Form
    {

        Log[] original;
        private LogFilter filter = new LogFilterAll();

        public LogFilter Filter
        {
            get { return filter; }
            set
            {
                Text = "リスト表示 - " + ((Log[])(dgvLog.DataSource = (filter = value).Extract(original))).Length.ToString() + "件";
            }
        }


        public FormList()
        {
            InitializeComponent();
        }

        public void UpdateFunc(Log[] logs)
        {
            if (InvokeRequired)
            {
                Invoke(new UpdateFunc(UpdateFunc), new object []{ logs });
            }
            else
            {
                Text = "リスト表示 - " + ((Log[])(dgvLog.DataSource = filter.Extract(original = logs))).Length.ToString() + "件";
            }
        }

        private void CopyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SafeClipboard.SetText(dgvLog.SelectedCells[0].Value);
        }

        private void FormList_Shown(object sender, EventArgs e)
        { ((FormMain)MdiParent).LogData.AddUpdateFunc(UpdateFunc); }
        private void FormList_FormClosed(object sender, FormClosedEventArgs e)
        { ((FormMain)MdiParent).LogData.RemoveUpdateFunc(UpdateFunc); }

        private void DetailFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilter f = new FormFilter
            {
                Filter = Filter,
                Text = "詳細フィルタ編集"
            };
            if (f.ShowDialog(this) == DialogResult.OK) Filter = f.Filter;
        }
    }
}
