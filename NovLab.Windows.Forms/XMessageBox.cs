// @(h)XMessageBox.cs ver 0.00 ( '22.05.05 Nov-Lab ) 作成開始
// @(h)XMessageBox.cs ver 1.01 ( '22.05.05 Nov-Lab ) 初版完成
// @(h)XMessageBox.cs ver 1.01a( '22.05.18 Nov-Lab ) その他  ：クラス名変更に対応した(ManualTestMethod)。機能変更なし。

// @(s)
// 　【メッセージボックスユーティリティー】定型的なスタイルのメッセージボックス表示機能を提供します。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

using NovLab.DebugSupport;


namespace NovLab.Windows.Forms
{
    //====================================================================================================
    /// <summary>
    /// 【メッセージボックスユーティリティー】定型的なスタイルのメッセージボックス表示機能を提供します。
    /// </summary>
    //====================================================================================================
    public static partial class XMessageBox
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【情報メッセージ表示】情報メッセージを表示します。<br></br>
        /// ・アイコン：情報<br></br>
        /// ・ボタン  ：OK<br></br>
        /// </summary>
        /// <param name="text">   [in ]：メッセージ ボックスに表示するテキスト</param>
        /// <param name="caption">[in ]：メッセージ ボックスのタイトル バーに表示するテキスト</param>
        //--------------------------------------------------------------------------------
        public static void ShowInformation(string text, string caption)
        {
            //------------------------------------------------------------
            /// 情報メッセージを表示する
            //------------------------------------------------------------
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【警告メッセージ表示】警告メッセージを表示します。<br></br>
        /// ・アイコン：警告<br></br>
        /// ・ボタン  ：OK<br></br>
        /// </summary>
        /// <param name="text">   [in ]：メッセージ ボックスに表示するテキスト</param>
        /// <param name="caption">[in ]：メッセージ ボックスのタイトル バーに表示するテキスト</param>
        //--------------------------------------------------------------------------------
        public static void ShowWarning(string text, string caption)
        {
            //------------------------------------------------------------
            /// 警告メッセージを表示する
            //------------------------------------------------------------
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【エラーメッセージ表示】エラーメッセージを表示します。<br></br>
        /// ・アイコン：エラー<br></br>
        /// ・ボタン  ：OK<br></br>
        /// </summary>
        /// <param name="text">   [in ]：メッセージ ボックスに表示するテキスト</param>
        /// <param name="caption">[in ]：メッセージ ボックスのタイトル バーに表示するテキスト</param>
        //--------------------------------------------------------------------------------
        public static void ShowError(string text, string caption)
        {
            //------------------------------------------------------------
            /// エラーメッセージを表示する
            //------------------------------------------------------------
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【問い合わせメッセージ表示(疑問符・はい/いいえ)】<br></br>
        /// 元に戻せる操作用の問い合わせメッセージを表示します。<br></br>
        /// ・アイコン：疑問符<br></br>
        /// ・ボタン  ：はい(既定) / いいえ<br></br>
        /// </summary>
        /// <param name="text">   [in ]：メッセージ ボックスに表示するテキスト</param>
        /// <param name="caption">[in ]：メッセージ ボックスのタイトル バーに表示するテキスト</param>
        /// <returns>
        /// 選択結果[Yes = はいボタン / No = いいえボタン]
        /// </returns>
        //--------------------------------------------------------------------------------
        public static DialogResult ShowQuestionYN(string text, string caption)
        {
            //------------------------------------------------------------
            /// 元に戻せる操作用の問い合わせメッセージを表示する
            //------------------------------------------------------------
            return MessageBox.Show(text, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【問い合わせメッセージ表示(感嘆符・はい/いいえ)】<br></br>
        /// 元に戻せない操作用の問い合わせメッセージを表示します。<br></br>
        /// ・アイコン：感嘆符<br></br>
        /// ・ボタン  ：はい / いいえ(既定)<br></br>
        /// </summary>
        /// <param name="text">   [in ]：メッセージ ボックスに表示するテキスト</param>
        /// <param name="caption">[in ]：メッセージ ボックスのタイトル バーに表示するテキスト</param>
        /// <returns>
        /// 選択結果[Yes = はいボタン / No = いいえボタン]
        /// </returns>
        //--------------------------------------------------------------------------------
        public static DialogResult ShowExclamationYN(string text, string caption)
        {
            //------------------------------------------------------------
            /// 元に戻せない操作用の問い合わせメッセージを表示する
            //------------------------------------------------------------
            return MessageBox.Show(text, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【問い合わせメッセージ表示(感嘆符・はい/いいえ/キャンセル)】<br></br>
        /// 元に戻せない操作用の問い合わせメッセージを表示します。<br></br>
        /// ・アイコン：感嘆符<br></br>
        /// ・ボタン  ：はい / いいえ / キャンセル(既定)<br></br>
        /// </summary>
        /// <param name="text">   [in ]：メッセージ ボックスに表示するテキスト</param>
        /// <param name="caption">[in ]：メッセージ ボックスのタイトル バーに表示するテキスト</param>
        /// <returns>
        /// 選択結果[Yes = はいボタン / No = いいえボタン / Cancel = キャンセルボタン]
        /// </returns>
        //--------------------------------------------------------------------------------
        public static DialogResult ShowExclamationYNC(string text, string caption)
        {
            //------------------------------------------------------------
            /// 元に戻せない操作用の問い合わせメッセージを表示する
            //------------------------------------------------------------
            return MessageBox.Show(text, caption,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button3);
        }


        //====================================================================================================
        // テスト用メソッド
        //====================================================================================================

#if DEBUG
        [ManualTestMethod("XMessageBox のテスト1")]
        public static void ZZZ_XMessageBox()
        {
            DialogResult result;

            ShowInformation("123通のメールを受信しました。", "メール受信");

            ShowWarning("サーバーに接続できませんでした。", "メール受信");

            ShowError("エラーメッセージ", "重大なエラー");

            result = ShowQuestionYN("メールをごみ箱に送りますか？", "ごみ箱へ送る");
            ShowResult();

            result = ShowExclamationYN("ファイルはすでに存在します。上書きしますか？", "名前を付けて保存");
            ShowResult();

            result = ShowExclamationYNC("ドキュメントは更新されています。アプリケーションを終了する前に保存しますか？", "<アプリケーション名>");
            ShowResult();

            void ShowResult()
            {
                Debug.Print("選択結果：" + result.ToString());
            }
        }
#endif

    }
}
