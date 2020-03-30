using System;
using System.Windows.Forms;

namespace MifuminLib
{
    /// <summary>例外を出さないクリップボード</summary>
    class SafeClipboard
    {
        /// <summary>可能ならばクリップボードにオブジェクトの文字列表現をセットします</summary>
        /// <param name="o">クリップボードに格納するオブジェクト</param>
        public static void SetText(object o)
        {
            try
            {
                if (o == null) return;
                string s = o.ToString();
                if (s != null && s != string.Empty) Clipboard.SetText(s);
            }
            catch (Exception) { }
        }

        /// <summary>可能ならばクリップボードにセットされているテキストを取得します</summary>
        /// <returns>クリップボードに文字列がなければ空文字列を返します</returns>
        public static string GetText()
        {
            try
            {
                return Clipboard.ContainsText() ? Clipboard.GetText() : string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
