using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

namespace Namalyzer
{
    /// <summary>
    /// ログの一行に相当する
    /// オリジナルのテキストは保持されないので注意
    /// </summary>
    public class Log
    {
        public enum EMethod : byte { UNKNOWN, GET, HEAD, POST, PUT, DELETE, CONNECT, OPTIONS, TRACE, LINK, UNLINK }
        public enum EHTTP : byte { HTTP10, HTTP11 }

        public LogFile parent;

        /// <summary>ホスト名orIP</summary>
        public string strHost;
        public string Host { get { return strHost; } set { strHost = value; } }
        /// <summary>リモートログ名</summary>
        public string strRemoteLog;
        public string RemoteLog { get { return strRemoteLog; } set { strRemoteLog = value; } }
        /// <summary>ユーザー名</summary>
        public string strUser;
        public string User { get { return strUser; } set { strUser = value; } }
        /// <summary>日付(DateTimeとしないのは検索の高速化のため)</summary>
        public long lDate;
        public string Date { get { return (new DateTime(lDate)).ToString("yyyy/MM/dd HH:mm:ss"); } }
        /// <summary>メソッド</summary>
        public EMethod eMethod;
        public EMethod Method { get { return eMethod; } set { eMethod = value; } }
        /// <summary>リクエスト先</summary>
        public string strRequested;
        public string Requested { get { return strRequested; } set { strRequested = value; } }
        /// <summary>HTTPのバージョン</summary>
        public EHTTP eHTTP;
        public string HTTP { get { return (eHTTP == EHTTP.HTTP10) ? "HTTP 1.0" : "HTTP 1.1"; } set { eHTTP = (value == "HTTP 1.0") ? EHTTP.HTTP10 : EHTTP.HTTP11; } }
        /// <summary>ステータスコード</summary>
        public short sStatus = 0;
        public short Status { get { return sStatus; } set { sStatus = value; } }
        /// <summary>転送量</summary>
        public int iSendSize = 0;
        public int SendSize { get { return iSendSize; } set { iSendSize = value; } }
        /// <summary>参照元</summary>
        public string strReferer;
        public string Referer { get { return strReferer; } set { strReferer = value; } }
        /// <summary>ユーザーエージェント</summary>
        public string strUserAgent;
        public string UserAgent { get { return strUserAgent; } set { strUserAgent = value; } }
    }

    /// <summary>一ファイル内の全てのログを格納する</summary>
    public class LogFile
    {
        public string FileName;
        public Log[] LogList = new Log[0];
        private volatile bool canceled = false;

        /// <summary>特定のファイルを開く</summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="option">読み込みオプション</param>
        /// <returns>最後まで読み込んだかどうか</returns>
        public bool Read(string filename, LogReadOption option)
        {
            canceled = false;
            FileName = filename;
            char[] array = new char[GetBufferSize(option)];
            int size, buffersize;
            int day, month, year, hour, minute, second;
            byte buf, old;
            bool failed;
            LinkedList<Log> list = new LinkedList<Log>();
            if (File.Exists(filename))
            {
                BinaryReader binReader = new BinaryReader(
                    new BufferedStream(File.Open(filename, FileMode.Open), 1024 * 1024)
                    );
                try
                {
                    Log l;
                    // LogFormat "%h %l %u %t \"%r\" %>s %b \"%{Referer}i\" \"%{User-Agent}i\"" combined
                    // %s %s %s [%02d/%3s/%04d:%02d:%02d:%02d %1s%04d] \"%s %s %s\" %3d %d \"%s\" \"%s\"
                    while (true)
                    {
                        if (canceled) break;
                        failed = false;
                        l = new Log();
                        l.parent = this;
                        // ホスト/IP
                        size = 0; buffersize = option.hostBuffer;
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if (buf == ' ') { l.Host = new string(array, 0, size); break; }
                            else if (buf == '\n' || buf == '\r') { failed = true; break; }
                            if (size < buffersize) array[size++] = (char)buf;
                        }
                        if (failed) continue;
                        // リモートログ名
                        size = 0; buffersize = option.remoteLogBuffer;
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if (buf == ' ') { l.RemoteLog = new string(array, 0, size); break; }
                            else if (buf == '\n' || buf == '\r') { failed = true; break; }
                            if (size < buffersize) array[size++] = (char)buf;
                        }
                        if (failed) continue;
                        // ユーザー名
                        size = 0; buffersize = option.userBuffer;
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if (buf == ' ') { l.User = new string(array, 0, size); break; }
                            else if (buf == '\n' || buf == '\r') { failed = true; break; }
                            if (size < buffersize) array[size++] = (char)buf;
                        }
                        if (failed) continue;
                        // 時刻(手抜きでエラーチェックしてない)
                        size = 0;
                        binReader.ReadByte();   // '['
                        day = (binReader.ReadByte() - '0') * 10 + (binReader.ReadByte() - '0'); // 日
                        binReader.ReadByte();   // '/'
                        // 月(Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec)
                        array[0] = (char)binReader.ReadByte();
                        array[1] = (char)binReader.ReadByte();
                        array[2] = (char)binReader.ReadByte();
                        if (array[0] == 'D') { month = 12; }        // Dec
                        else if (array[0] == 'F') { month = 2; }    // Feb
                        else if (array[0] == 'N') { month = 11; }   // Nov
                        else if (array[0] == 'O') { month = 10; }   // Oct
                        else if (array[0] == 'S') { month = 9; }    // Sep
                        else if (array[1] == 'p') { month = 4; }    // Apr
                        else if (array[2] == 'g') { month = 8; }    // Aug
                        else if (array[2] == 'l') { month = 7; }    // Jul
                        else if (array[2] == 'r') { month = 3; }    // Mar
                        else if (array[2] == 'y') { month = 5; }    // May
                        else if (array[1] == 'a') { month = 1; }    // Jan
                        else if (array[1] == 'u') { month = 6; }    // Jun
                        else { month = 0; }
                        binReader.ReadByte();   // '/'
                        year = (binReader.ReadByte() - '0') * 1000 + (binReader.ReadByte() - '0') * 100
                            + (binReader.ReadByte() - '0') * 10 + (binReader.ReadByte() - '0'); // 年
                        binReader.ReadByte();   // ':'
                        hour = (binReader.ReadByte() - '0') * 10 + (binReader.ReadByte() - '0'); // 時
                        binReader.ReadByte();   // ':'
                        minute = (binReader.ReadByte() - '0') * 10 + (binReader.ReadByte() - '0'); // 分
                        binReader.ReadByte();   // ':'
                        second = (binReader.ReadByte() - '0') * 10 + (binReader.ReadByte() - '0'); // 秒
                        binReader.ReadBytes(9);   // ' +0900] "'
                        try { l.lDate = (new DateTime(year, month, day, hour, minute, second)).Ticks; }
                        catch (ArgumentOutOfRangeException) { l.lDate = 0; }
                        // メソッド
                        buf = binReader.ReadByte();
                        if (buf == 'G') { l.eMethod = Log.EMethod.GET; }
                        else if (buf == 'P')
                        {
                            buf = binReader.ReadByte();
                            if (buf == 'O') { l.eMethod = Log.EMethod.POST; }
                            else if (buf == 'U') { l.eMethod = Log.EMethod.PUT; }
                            else { l.eMethod = Log.EMethod.UNKNOWN; }
                        }
                        else if (buf == 'H') { l.eMethod = Log.EMethod.HEAD; }
                        else if (buf == 'C') { l.eMethod = Log.EMethod.CONNECT; }
                        else if (buf == 'D') { l.eMethod = Log.EMethod.DELETE; }
                        else if (buf == 'L') { l.eMethod = Log.EMethod.LINK; }
                        else if (buf == 'O') { l.eMethod = Log.EMethod.OPTIONS; }
                        else if (buf == 'T') { l.eMethod = Log.EMethod.TRACE; }
                        else if (buf == 'U') { l.eMethod = Log.EMethod.UNLINK; }
                        else { l.eMethod = Log.EMethod.UNKNOWN; }
                        while (binReader.ReadByte() != ' ') { }
                        // リクエスト先
                        size = 0; buffersize = option.requestedBuffer;
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if (buf == ' ') { l.Requested = new string(array, 0, size); break; }
                            else if (buf == '\n' || buf == '\r') { failed = true; break; }
                            if (size < buffersize) array[size++] = (char)buf;
                        }
                        if (failed) continue;
                        // HTTP(やっぱり手抜きでエラーチェックなし)
                        binReader.ReadBytes(7);   // 'HTTP/1.'
                        l.eHTTP = binReader.ReadByte() == '0' ? Log.EHTTP.HTTP10 : Log.EHTTP.HTTP11;
                        binReader.ReadBytes(2);   // '" '
                        // ステータスコード
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if ('0' <= buf && buf <= '9') { l.sStatus = (short)(l.sStatus * 10 + buf - '0'); }
                            else if (buf == ' ') { break; }
                            else if (buf == '\n' || buf == '\r') { failed = true; break; }
                        }
                        if (failed) continue;
                        // 転送量
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if ('0' <= buf && buf <= '9') { l.iSendSize = l.iSendSize * 10 + buf - '0'; }
                            else if (buf == ' ') { break; }
                            else if (buf == '\n' || buf == '\r')
                            {
                                // ここでの失敗のみ特別な処理をする
                                // (combinedとしては失敗だがcommonとしては成功)
                                l.Referer = "";
                                l.UserAgent = "";
                                failed = true;
                                break;
                            }
                        }
                        if (failed) continue;
                        // リファラ
                        binReader.ReadByte();   // '"'
                        size = 0; buffersize = option.refererBuffer;
                        old = 0;
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if (buf == '"' && old != '\\') { l.Referer = new string(array, 0, size); break; }
                            else if (buf == '\n' || buf == '\r') { failed = true; break; }
                            if (size < buffersize) array[size++] = (char)buf;
                            old = buf;
                        }
                        if (failed) continue;
                        binReader.ReadByte();   // ' '
                        // ユーザーエージェント
                        binReader.ReadByte();   // '"'
                        size = 0; buffersize = option.userAgentBuffer;
                        old = 0;
                        while (true)
                        {
                            buf = binReader.ReadByte();
                            if (buf == '"' && old != '\\') { l.UserAgent = new string(array, 0, size); break; }
                            else if (buf == '\n' || buf == '\r') { failed = true; break; }
                            if (size < buffersize) array[size++] = (char)buf;
                            old = buf;
                        }
                        if (failed) continue;
                        binReader.ReadByte();   // '\n'
                        if (option.filter.Match(l)) list.AddLast(l);
                    }
                }
                catch (EndOfStreamException) { }
                finally { binReader.Close(); }
                LogList = new Log[list.Count];
                int num = 0;
                foreach (Log l in list) LogList[num++] = l;
            }
            return !canceled;
        }

        /// <summary>すでに開いたファイルを設定を変えて読み直す</summary>
        /// <param name="option">読み込みオプション</param>
        /// <returns>最後まで読み込んだかどうか</returns>
        public bool Reload(LogReadOption option)
        { return Read(FileName, option); }

        public void Cancel()
        { canceled = true; }

        private int GetBufferSize(LogReadOption option)
        {
            int size = 3;   // 最低でも3バイトのバッファを使用する
            if (size < option.hostBuffer) size = option.hostBuffer;
            if (size < option.remoteLogBuffer) size = option.remoteLogBuffer;
            if (size < option.userBuffer) size = option.userBuffer;
            if (size < option.requestedBuffer) size = option.requestedBuffer;
            if (size < option.refererBuffer) size = option.refererBuffer;
            if (size < option.userAgentBuffer) size = option.userAgentBuffer;
            return size;
        }
    }

    public class LogReadOption
    {
        public int hostBuffer = 255;        // 有効なホスト名は255文字以下
        public int remoteLogBuffer = 256;   // わからんけど念のため256用意しとく
        public int userBuffer = 256;        // わからんけど念のため256用意しとく
        public int requestedBuffer = 1024;  // 1024も読み込めれば充分でしょう
        public int refererBuffer = 1024;    // 1024も読み込めれば充分でしょう
        public int userAgentBuffer = 1024;  // 1024も読み込めれば充分でしょう
        public LogFilter filter = new LogFilterAll();
    }

    public delegate void UpdateFunc(Log[] logs);

    /// <summary>ログ統括クラス</summary>
    public class AccessLog
    {
        LogFile[] AllLog = new LogFile[0];  // ファイルごとのログの内容
        Log[] Target = new Log[0];          // 基本的に表示や詳しい解析などはこのTargetに対して行う
        LogFilter analyzeFilter = new LogFilterAll();
        UpdateFunc UpdateFuncs;
        Form owner;
        LogFile NowLoading = null;          // 読み込み中のログ
        LogReadOption readOption = new LogReadOption();
        public LogReadOption ReadOption
        { get { return readOption; } }
	

        public AccessLog(Form owner)
        {
            this.owner = owner;
        }

        /// <summary>ファイルを読み込んでログに追加する</summary>
        /// <param name="filenames">ファイル名の配列</param>
        public void Read(string[] filenames)
        {
            int nOldLength = AllLog.Length;
            bool continueload = true;
            Array.Resize(ref AllLog, nOldLength + filenames.Length);
            for (int i = 0; i < filenames.Length; i++)
            {
                NowLoading = AllLog[nOldLength + i] = new LogFile();
                if (continueload) continueload = NowLoading.Read(filenames[i], readOption);
                else NowLoading.FileName = filenames[i];
            }
            lock (this) { NowLoading = null; }
            Update();
        }
        public void Release(LogFile file)
        {
            LogFile[] newLog = new LogFile[AllLog.Length - 1];
            int i = 0;
            foreach (LogFile lf in AllLog)
            {
                if (lf != file) newLog[i++] = lf;
            }
            if (i == newLog.Length)
            {
                AllLog = newLog;
                Update();
            }
        }
        public void Clear()
        {
            AllLog = new LogFile[0];
            Update();
        }
        public LogFilter ReadFilter
        {
            set { readOption.filter = value; }
            get { return readOption.filter; }
        }
        public LogFilter AnalyzeFilter
        {
            set { analyzeFilter = value; Target = GetLogs(); Update(); }
            get { return analyzeFilter; }
        }
        public void Update()
        {
            Target = GetLogs();
            if (UpdateFuncs != null)
            {
                owner.Invoke(UpdateFuncs, new object[] { Target });
            }
        }
        public void AddUpdateFunc(UpdateFunc update) { UpdateFuncs += update; update(Target); }
        public void RemoveUpdateFunc(UpdateFunc update) { UpdateFuncs -= update; }
        public Log[] GetLogs()
        {
            LinkedList<Log> list = new LinkedList<Log>();
            foreach (LogFile file in AllLog)
                foreach (Log log in file.LogList)
                    if (analyzeFilter.Match(log)) list.AddLast(log);
            Log[] ret = new Log[list.Count];
            int num = 0;
            foreach (Log log in list) ret[num++] = log;
            return ret;
        }
        public Log[] GetTarget() { return Target; }
        public LogFile[] GetFile() { return AllLog; }
        public void Reload(LogFile file)
        {
            (NowLoading = file).Reload(readOption);
            lock (this) { NowLoading = null; }
            Update();
        }
        public void ReloadAll()
        {
            foreach (LogFile file in AllLog)
            {
                if (!(NowLoading = file).Reload(readOption)) break;
            }
            lock (this) { NowLoading = null; }
            Update();
        }

        public void CancelRead()
        {
            lock (this)
            {
                if (NowLoading != null) NowLoading.Cancel();
            }
        }
    }
}
