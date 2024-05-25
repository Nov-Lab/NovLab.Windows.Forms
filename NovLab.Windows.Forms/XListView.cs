// @(h)XListView.cs ver 0.00 ( '22.05.16 Nov-Lab ) 作成開始
// @(h)XListView.cs ver 0.21 ( '22.05.16 Nov-Lab ) アルファ版完成
// @(h)XListView.cs ver 0.22 ( '22.05.20 Nov-Lab ) 機能追加：XSetSelectedIndex, XGetSelectedIndex, XAdd を追加した。
// @(h)XListView.cs ver 0.23 ( '24.05.25 Nov-Lab ) 機能修正：XListView.XAddItemWithScroll メソッドで、一度に複数のリストビュー項目を追加できるようにした。

// @(s)
// 　【ListView 拡張メソッド】System.Windows.Forms.ListView クラスに拡張メソッドを追加します。

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace NovLab.Windows.Forms
{
    //====================================================================================================
    /// <summary>
    /// 【ListView 拡張メソッド】System.Windows.Forms.ListView クラスに拡張メソッドを追加します。
    /// </summary>
    //====================================================================================================
    public static partial class XListView
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【スクロール付きリストビュー項目追加】
        /// リストビューに項目を追加し、追加前の選択状態に応じてスクロールや選択状態の変更を行います。
        /// </summary>
        /// <param name="listView">[in ]：対象リストビュー</param>
        /// <param name="items">   [in ]：リストビュー項目配列</param>
        /// <returns>
        /// 最後に追加したリストビュー項目
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> が null です。</exception>
        /// <exception cref="ArgumentException">    <paramref name="items"/> に要素がありません。</exception>
        /// <remarks>
        /// <code>
        /// 追加前の選択状態            ：追加後の動作
        /// ------------------------------------------------------------------------------
        /// 選択項目なし                ：スクロールする。選択状態やフォーカスは変更しない
        /// 単一選択状態(最後の項目)    ：スクロールする。追加した項目を単一選択状態にしてフォーカスも移動する
        /// 単一選択状態(最後以外の項目)：スクロールしない。選択状態やフォーカスは変更しない
        /// 複数選択状態                ：スクロールしない。選択状態やフォーカスは変更しない
        /// </code>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static ListViewItem XAddItemWithScroll(this ListView listView, params ListViewItem[] items)
        {
            //------------------------------------------------------------
            /// 引数をチェックする
            //------------------------------------------------------------
            if (items == null)
            {                                                           //// リストビュー項目配列 = null の場合
                throw                                                   /////  引数不正例外(null値)をスローする
                    new ArgumentNullException(nameof(items));
            }
            if (items.Length == 0)
            {                                                           //// リストビュー項目配列に要素がない場合
                throw                                                   /////  引数不正例外(空の配列)をスローする
                    new ArgumentException("配列に要素がありません。", nameof(items));
            }


            //------------------------------------------------------------
            /// 追加処理後にスクロールすべきかどうかを決定する
            //------------------------------------------------------------
            bool postScroll = false;                                    //// 追加処理後スクロールフラグ = false に初期化する
            bool lastItemSelected = false;                              //// 最終アイテム単一選択中フラグ = false に初期化する

            switch (listView.SelectedIndices.Count)
            {                                                           //// リストビューの選択中インデックスの数で分岐
                case 0:                                                 /////  １つも選択されていない場合
                    postScroll = true;                                  //////   追加処理後スクロールフラグ = true
                    break;

                case 1:                                                 /////  １つだけ選択されている場合
                    if (listView.SelectedIndices[0] == listView.Items.Count - 1)
                    {                                                   //////   最後のアイテムが選択されている場合
                        postScroll = true;                              ///////    追加処理後スクロールフラグ = true
                        lastItemSelected = true;                        ///////    最終アイテム単一選択中フラグ = true
                    }
                    else
                    {                                                   //////   最後以外のアイテムが選択されている場合
                        postScroll = false;                             ///////    追加処理後スクロールフラグ = false
                    }
                    break;

                default:                                                /////  上記以外の場合(複数選択されている場合)
                    postScroll = false;                                 //////   追加処理後スクロールフラグ = false
                    break;
            }


            //------------------------------------------------------------
            /// リストビューに項目を追加する
            //------------------------------------------------------------
            listView.Items.AddRange(items);                             //// リストビューにリストビュー項目配列をまとめて追加する
            var addedItem = listView.Items[listView.Items.Count - 1];   //// 最後に追加したリストビュー項目を取得する

            if (postScroll)
            {                                                           //// 追加処理後スクロールフラグ = true の場合
                addedItem.EnsureVisible();                              /////  最後に追加したリストビューアイテムが表示されるようにスクロールする
            }
            if (lastItemSelected)
            {                                                           //// 最終アイテム単一選択中フラグ = true の場合
                listView.SelectedIndices.Clear();                       /////  最後に追加したアイテムを単一選択状態にしてフォーカスを移動する
                addedItem.Selected = true;
                listView.FocusedItem = addedItem;
            }

            return addedItem;                                           //// 戻り値 = 追加したリストビュー項目 で関数終了
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【単一選択インデックス設定】
        /// インデックスで指定された項目を単一選択状態にします。
        /// -1 を指定した場合は選択項目なし状態にします。
        /// </summary>
        /// <param name="target">       [in ]：対象リストビュー</param>
        /// <param name="index">        [in ]：インデックス</param>
        /// <param name="moveFocus">    [in ]：フォーカス移動要求フラグ</param>
        /// <param name="ensureVisible">[in ]：スクロール要求フラグ</param>
        //--------------------------------------------------------------------------------
        public static void XSetSelectedIndex(this ListView target, int index, bool moveFocus = true, bool ensureVisible = true)
        {
            //------------------------------------------------------------
            /// -1 を指定された場合は選択項目なし状態にする
            //------------------------------------------------------------
            if (index == -1)
            {                                                           //// インデックス = -1(選択項目なし) の場合
                target.SelectedIndices.Clear();                         /////  選択中項目インデックスコレクションをクリアする
                return;                                                 /////  関数終了
            }


            //------------------------------------------------------------
            /// インデックスで指定された項目を単一選択状態にする
            //------------------------------------------------------------
            target.SelectedIndices.Clear();                             //// 選択中項目インデックスコレクションをクリアする
            target.SelectedIndices.Add(index);                          //// 選択中項目インデックスコレクションに指定されたインデックスを追加する

            if (moveFocus)
            {                                                           //// フォーカス移動要求フラグ = true の場合
                target.FocusedItem = target.SelectedItems[0];           /////  選択中項目にフォーカスを移動する
            }

            if (ensureVisible)
            {                                                           //// スクロール要求フラグ = true の場合
                target.EnsureVisible(index);                            /////  選択した項目が表示されるようにスクロールする
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【単一選択インデックス取得】単一選択状態にある項目のインデックスを取得します。
        /// 選択項目がないか複数選択されている場合は -1 を返します。
        /// </summary>
        /// <param name="target">[in ]：対象リストビュー</param>
        /// <returns>
        /// 単一選択状態にある項目のインデックス[-1 = 選択項目がないか複数選択されている]
        /// </returns>
        //--------------------------------------------------------------------------------
        public static int XGetSelectedIndex(this ListView target)
        {
            //------------------------------------------------------------
            /// 単一選択状態にある項目のインデックスを取得する
            //------------------------------------------------------------
            if (target.SelectedIndices.Count == 1)
            {                                                           //// 選択中項目数 = 1 の場合
                return target.SelectedIndices[0];                       /////  戻り値 = 単一選択状態にある項目のインデックス で関数終了
            }
            else
            {                                                           //// 選択中項目数 = 1 でない場合
                return -1;                                              /////  戻り値 = -1(選択項目がないか複数選択されている) で関数終了
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【リストビューサブ項目追加】テキストとキーを指定して、サブ項目をコレクションに追加します。
        /// </summary>
        /// <param name="target">[in ]：対象リストビューサブ項目コレクション</param>
        /// <param name="key">   [in ]：キー文字列</param>
        /// <param name="text">  [in ]：テキスト</param>
        /// <returns>
        /// 追加したリストビューサブ項目
        /// </returns>
        /// <remarks>
        /// 補足<br></br>
        /// ・リストビューサブ項目コレクションでは、キー文字列の大文字と小文字は区別されません。<br></br>
        /// ・フィールドから追加する場合は、listView.SubItems.XAdd(nameof(&lt;フィールド名&gt;), &lt;フィールド名&gt;) のように使うと、
        ///   キー文字列の重複や誤記などのミスを回避しやすくなります。<br></br>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static ListViewItem.ListViewSubItem XAdd(this ListViewItem.ListViewSubItemCollection target, string key, string text)
        {
            //------------------------------------------------------------
            /// テキストとキーを指定してサブ項目をコレクションに追加する
            //------------------------------------------------------------
            var subItem = target.Add(text);                             //// テキスト指定でサブ項目をコレクションに追加する
            subItem.Name = key;                                         //// 追加したサブ項目にキー文字列を設定する
            return subItem;                                             //// 戻り値 = 追加したサブ項目 で関数終了
        }

    } // class

} // namespace
