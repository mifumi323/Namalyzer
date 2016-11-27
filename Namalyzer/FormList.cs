using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MifuminLib;

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
            Text = "リスト表示 - " + ((Log[])(dgvLog.DataSource = filter.Extract(original = logs))).Length.ToString() + "件";
        }

        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SafeClipboard.SetText(dgvLog.SelectedCells[0].Value);
        }

        private void FormList_Shown(object sender, EventArgs e)
        { ((FormMain)MdiParent).LogData.AddUpdateFunc(UpdateFunc); }
        private void FormList_FormClosed(object sender, FormClosedEventArgs e)
        { ((FormMain)MdiParent).LogData.RemoveUpdateFunc(UpdateFunc); }

        private void detailFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilter f = new FormFilter();
            f.Filter = Filter;
            f.Text = "詳細フィルタ編集";
            if (f.ShowDialog(this) == DialogResult.OK) Filter = f.Filter;
        }
    }
}