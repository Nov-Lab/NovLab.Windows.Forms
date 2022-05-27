// 下書き用

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovLab.Windows.Forms
{



#if false   //[-] 保留：カレット位置の調整機能付きテキスト追加。ほぼ完成状態のところで使わなくなった。後で必要になったら参考になる。
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【出力テキスト追加】出力テキストボックスにテキストを追加します。
        /// </summary>
        /// <param name="text">[in ]：追加するテキスト</param>
        //--------------------------------------------------------------------------------
        protected void M_AppendOutputText(string text)
        {
            bool restorationCaretPos;   // カレット位置復元フラグ

            // ＜メモ＞
            // ・AppendText で文字列を追加すると、文字列選択状態は解除され、カレット位置はテキストの末尾に移動する。
            //------------------------------------------------------------
            /// 追加後にカーソル位置を移動すべきかどうか決定する
            //  【文字列選択状態：カレット位置：追加後にカレット位置を復元すべきかどうか】
            //    されている    ：N/A         ：復元すべき
            //    されていない  ：末尾以外    ：復元すべき
            //    されていない  ：末尾        ：復元しない
            //------------------------------------------------------------
            var selStart = TxtOutput.SelectionStart;                    //// 選択開始位置を取得する
            var selLength = TxtOutput.SelectionLength;                  //// 選択文字数を取得する

            if (TxtOutput.SelectionLength != 0)
            {                                                           //// 文字列を選択中の場合
                restorationCaretPos = true;                             /////  カレット位置復元フラグ = true
            }
            else
            {                                                           //// 文字列を選択中でない場合
                if (TxtOutput.SelectionStart < TxtOutput.Text.Length)
                {                                                       /////  カレット位置が末尾以外の場合
                    restorationCaretPos = true;                         //////   カレット位置復元フラグ = true
                }
                else
                {                                                       /////  カレット位置が末尾の場合
                    restorationCaretPos = false;                        //////   カレット位置復元フラグ = false
                }
            }


            TxtOutput.AppendText(text);

            if (restorationCaretPos)
            {
                TxtOutput.Select(selStart, selLength);
            }
            TxtOutput.ScrollToCaret();


            //TxtOutput.Text += strValue;

            //            TxtOutput.Select(selStart, selLength);                      //// 追加前の選択範囲

#if false
            if (moveCaretPos == true)
            {
                TxtOutput.Select(TxtOutput.Text.Length-1, 0);
                TxtOutput.ScrollToCaret();
            }
#endif

            //TxtOutput.SelectAll();
        }
#endif


}
