using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using MifuminLib;
using MifuminLib.AccessAnalyzer;

namespace Namalyzer
{
    public partial class FormMain : Form
    {
        AccessLog logData;
        public AccessLog LogData { get { return logData; } }

        DateTime start;
        string[] readList;
        int readCount = 0;

        public FormMain()
        {
            InitializeComponent();
            logData = new AccessLog(this);
        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogData.Release((LogFile)((ToolStripMenuItem)sender).Tag);
            UpdateFileMenu();
        }

        private void addFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) LogRead(openFileDialog1.FileNames);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateFileMenu();
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) LogRead((string[])e.Data.GetData(DataFormats.FileDrop));
        }

        private void LogRead(string[] p)
        {
            BeginRead(p.Length);

            readList = p;
            backgroundWorker1.DoWork += ReadLog_DoWork;
            backgroundWorker1.RunWorkerCompleted += ReadLog_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
        }

        private void ReadLog_DoWork(object sender, DoWorkEventArgs e)
        {
            LogData.Read(readList);
        }

        private void ReadLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EndRead();
            readList = null;
            backgroundWorker1.DoWork -= ReadLog_DoWork;
            backgroundWorker1.RunWorkerCompleted -= ReadLog_RunWorkerCompleted;
        }

        private void AllReload()
        {
            if (LogData.GetFile().Length == 0) return;
            BeginRead(LogData.GetFile().Length);

            backgroundWorker1.DoWork += ReloadAll_DoWork;
            backgroundWorker1.RunWorkerCompleted += ReloadLog_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
        }

        private void ReloadAll_DoWork(object sender, DoWorkEventArgs e)
        {
            LogData.ReloadAll();
        }

        private void ReloadLog_DoWork(object sender, DoWorkEventArgs e)
        {
            LogData.Reload((LogFile)e.Argument);
        }

        private void ReloadLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EndRead();
            backgroundWorker1.DoWork -= ReloadAll_DoWork;
            backgroundWorker1.DoWork -= ReloadLog_DoWork;
            backgroundWorker1.RunWorkerCompleted -= ReloadLog_RunWorkerCompleted;
        }

        private void BeginRead(int length)
        {
            readCount = length;
            start = DateTime.Now;
            toolStripStatusLabel1.Text = readCount.ToString() + "個のファイルを読み込み中...";

            // 中止メニュー以外を無効化する
            foreach (ToolStripItem menu in menuStrip1.Items)
            {
                if (menu != abortToolStripMenuItem) menu.Enabled = false;
                else menu.Visible = true;
            }
            foreach (Form form in MdiChildren)
            {
                form.Enabled = false;
            }
        }

        private void EndRead()
        {
            UpdateFileMenu();

            // 無効化した項目を復元する
            foreach (Form form in MdiChildren)
            {
                form.Enabled = true;
            }
            foreach (ToolStripItem menu in menuStrip1.Items)
            {
                if (menu != abortToolStripMenuItem) menu.Enabled = true;
                else menu.Visible = false;
            }

            toolStripStatusLabel1.Text = readCount.ToString() + "個のファイルを読み込みました。経過時間：" + DateTime.Now.Subtract(start).ToString();
        }

        private void UpdateFileMenu()
        {
            deleteFileToolStripMenuItem.DropDownItems.Clear();
            reloadFileToolStripMenuItem.DropDownItems.Clear();
            if (LogData.GetFile().Length > 0)
            {
                deleteFileToolStripMenuItem.DropDownItems.Add(closeAllToolStripMenuItem);
                deleteFileToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
                reloadFileToolStripMenuItem.DropDownItems.Add(reloadAllToolStripMenuItem);
                reloadFileToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
                foreach (LogFile file in LogData.GetFile())
                {
                    ToolStripMenuItem tsm = new ToolStripMenuItem(file.FileName);
                    tsm.Click += new EventHandler(deleteFileToolStripMenuItem_Click);
                    tsm.Tag = file;
                    deleteFileToolStripMenuItem.DropDownItems.Add(tsm);
                    tsm = new ToolStripMenuItem(file.FileName);
                    tsm.Click += new EventHandler(reloadFileToolStripMenuItem_Click);
                    tsm.Tag = file;
                    reloadFileToolStripMenuItem.DropDownItems.Add(tsm);
                }
            }
        }

        private void readFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilter f = new FormFilter();
            f.Filter = LogData.ReadFilter;
            f.Text = "読み込みフィルタ編集";
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LogData.ReadFilter = f.Filter;
                if (LogData.GetFile().Length > 0 &&
                    MessageBox.Show(this, "ファイルを読み込みなおしますか？", Application.ProductName, MessageBoxButtons.YesNo)
                    == DialogResult.No) return;
                AllReload();
                UpdateFileMenu();
            }
        }

        private void analyzeFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFilter f = new FormFilter();
            f.Filter = LogData.AnalyzeFilter;
            f.Text = "解析フィルタ編集";
            if (f.ShowDialog(this) == DialogResult.OK) LogData.AnalyzeFilter = f.Filter;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormList formList = new FormList();
            formList.MdiParent = this;
            formList.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExplorer formExplorer = new FormExplorer();
            formExplorer.LogData = LogData;
            formExplorer.MdiParent = this;
            formExplorer.Explore("/");
            formExplorer.Show();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogData.Clear();
            UpdateFileMenu();
        }

        private void reloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginRead(1);

            backgroundWorker1.DoWork += ReloadLog_DoWork;
            backgroundWorker1.RunWorkerCompleted += ReloadLog_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync((LogFile)((ToolStripMenuItem)sender).Tag);
        }

        private void reloadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllReload();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            formStatistics.MdiParent = this;
            formStatistics.Show();
        }

        private void abortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogData.CancelRead();
        }

        private void readOptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            FieldInfo info = typeof(LogReadOption).GetField((string)item.Tag);
            decimal value = (decimal)(int)info.GetValue(LogData.ReadOption);
            value = NumberInputBox.Show(this, item.Text, 0, 65536, value);
            info.SetValue(LogData.ReadOption, (int)value);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                LogData.CancelRead();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Application.ProductName + "\n" + Application.ProductVersion);
        }
    }
}