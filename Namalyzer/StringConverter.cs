// StringConverter
//  作者      ：美文
//  URL       ：http://tgws.fromc.jp/prog/stringconverter/
//  バージョン：1.1.0
using System.Text;
using System.Text.RegularExpressions;

namespace MifuminLib
{
    /// <summary>文字列の変換などをするクラスです。</summary>
    public class StringConverter
    {
        /// <summary>全角英数字とスペースを半角に、半角カタカナを全角に変換します。</summary>
        /// <param name="str">変換前の文字列</param>
        /// <returns>変換後の文字列</returns>
        public static string ConvertNarrowWide(string str)
        {
            StringBuilder buf = new StringBuilder(str.Length);
            foreach (char ch in str)
            {
                if (ch == '　') buf.Append(' ');
                else if ('０' <= ch && ch <= '９') buf.Append((char)(ch + ('0' - '０')));
                else if ('ａ' <= ch && ch <= 'ｚ') buf.Append((char)(ch + ('a' - 'ａ')));
                else if ('Ａ' <= ch && ch <= 'Ｚ') buf.Append((char)(ch + ('A' - 'Ａ')));
                else if ('ｦ' <= ch && ch <= 'ﾟ')
                {
                    switch (ch)
                    {
                        case 'ｦ': buf.Append('ヲ'); break;
                        case 'ｧ': buf.Append('ァ'); break;
                        case 'ｨ': buf.Append('ィ'); break;
                        case 'ｩ': buf.Append('ゥ'); break;
                        case 'ｪ': buf.Append('ェ'); break;
                        case 'ｫ': buf.Append('ォ'); break;
                        case 'ｬ': buf.Append('ャ'); break;
                        case 'ｭ': buf.Append('ュ'); break;
                        case 'ｮ': buf.Append('ョ'); break;
                        case 'ｯ': buf.Append('ッ'); break;
                        case 'ｰ': buf.Append('ー'); break;
                        case 'ｱ': buf.Append('ア'); break;
                        case 'ｲ': buf.Append('イ'); break;
                        case 'ｳ': buf.Append('ウ'); break;
                        case 'ｴ': buf.Append('エ'); break;
                        case 'ｵ': buf.Append('オ'); break;
                        case 'ｶ': buf.Append('カ'); break;
                        case 'ｷ': buf.Append('キ'); break;
                        case 'ｸ': buf.Append('ク'); break;
                        case 'ｹ': buf.Append('ケ'); break;
                        case 'ｺ': buf.Append('コ'); break;
                        case 'ｻ': buf.Append('サ'); break;
                        case 'ｼ': buf.Append('シ'); break;
                        case 'ｽ': buf.Append('ス'); break;
                        case 'ｾ': buf.Append('セ'); break;
                        case 'ｿ': buf.Append('ソ'); break;
                        case 'ﾀ': buf.Append('タ'); break;
                        case 'ﾁ': buf.Append('チ'); break;
                        case 'ﾂ': buf.Append('ツ'); break;
                        case 'ﾃ': buf.Append('テ'); break;
                        case 'ﾄ': buf.Append('ト'); break;
                        case 'ﾅ': buf.Append('ナ'); break;
                        case 'ﾆ': buf.Append('ニ'); break;
                        case 'ﾇ': buf.Append('ヌ'); break;
                        case 'ﾈ': buf.Append('ネ'); break;
                        case 'ﾉ': buf.Append('ノ'); break;
                        case 'ﾊ': buf.Append('ハ'); break;
                        case 'ﾋ': buf.Append('ヒ'); break;
                        case 'ﾌ': buf.Append('フ'); break;
                        case 'ﾍ': buf.Append('ヘ'); break;
                        case 'ﾎ': buf.Append('ホ'); break;
                        case 'ﾏ': buf.Append('マ'); break;
                        case 'ﾐ': buf.Append('ミ'); break;
                        case 'ﾑ': buf.Append('ム'); break;
                        case 'ﾒ': buf.Append('メ'); break;
                        case 'ﾓ': buf.Append('モ'); break;
                        case 'ﾔ': buf.Append('ヤ'); break;
                        case 'ﾕ': buf.Append('ユ'); break;
                        case 'ﾖ': buf.Append('ヨ'); break;
                        case 'ﾗ': buf.Append('ラ'); break;
                        case 'ﾘ': buf.Append('リ'); break;
                        case 'ﾙ': buf.Append('ル'); break;
                        case 'ﾚ': buf.Append('レ'); break;
                        case 'ﾛ': buf.Append('ロ'); break;
                        case 'ﾜ': buf.Append('ワ'); break;
                        case 'ﾝ': buf.Append('ン'); break;
                        case 'ﾞ':
                            if (buf.Length > 0)
                            {
                                switch (buf[buf.Length - 1])
                                {
                                    case 'ウ': buf[buf.Length - 1] = 'ヴ'; break;
                                    case 'カ': buf[buf.Length - 1] = 'ガ'; break;
                                    case 'キ': buf[buf.Length - 1] = 'ギ'; break;
                                    case 'ク': buf[buf.Length - 1] = 'グ'; break;
                                    case 'ケ': buf[buf.Length - 1] = 'ケ'; break;
                                    case 'コ': buf[buf.Length - 1] = 'ゴ'; break;
                                    case 'サ': buf[buf.Length - 1] = 'ザ'; break;
                                    case 'シ': buf[buf.Length - 1] = 'ジ'; break;
                                    case 'ス': buf[buf.Length - 1] = 'ズ'; break;
                                    case 'セ': buf[buf.Length - 1] = 'ゼ'; break;
                                    case 'ソ': buf[buf.Length - 1] = 'ゾ'; break;
                                    case 'タ': buf[buf.Length - 1] = 'ダ'; break;
                                    case 'チ': buf[buf.Length - 1] = 'ヂ'; break;
                                    case 'ツ': buf[buf.Length - 1] = 'ヅ'; break;
                                    case 'テ': buf[buf.Length - 1] = 'デ'; break;
                                    case 'ト': buf[buf.Length - 1] = 'ド'; break;
                                    case 'ハ': buf[buf.Length - 1] = 'バ'; break;
                                    case 'ヒ': buf[buf.Length - 1] = 'ビ'; break;
                                    case 'フ': buf[buf.Length - 1] = 'ブ'; break;
                                    case 'ヘ': buf[buf.Length - 1] = 'ベ'; break;
                                    case 'ホ': buf[buf.Length - 1] = 'ボ'; break;
                                    default: buf.Append('゛'); break;
                                }
                            }
                            else
                            {
                                buf.Append('゛');
                            }
                            break;
                        case 'ﾟ':
                            if (buf.Length > 0)
                            {
                                switch (buf[buf.Length - 1])
                                {
                                    case 'ハ': buf[buf.Length - 1] = 'パ'; break;
                                    case 'ヒ': buf[buf.Length - 1] = 'ピ'; break;
                                    case 'フ': buf[buf.Length - 1] = 'プ'; break;
                                    case 'ヘ': buf[buf.Length - 1] = 'ペ'; break;
                                    case 'ホ': buf[buf.Length - 1] = 'ポ'; break;
                                    default: buf.Append('゜'); break;
                                }
                            }
                            else
                            {
                                buf.Append('゜');
                            }
                            break;
                        default: buf.Append(ch); break;
                    }
                }
                else buf.Append(ch);
            }
            return buf.ToString();
        }

        /// <summary>簡易的にHTMLタグ(角括弧に囲まれた部分)を除去します。</summary>
        /// <param name="str">除去前の文字列</param>
        /// <returns>除去後の文字列</returns>
        public static string RemoveHTMLTagsSimple(string str)
        {
            Regex r = new Regex("<[^<>]*?>", RegexOptions.Singleline);
            return r.Replace(str, "");
        }
    }
}
