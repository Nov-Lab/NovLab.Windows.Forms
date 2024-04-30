// @(h)XListBox.cs ver 0.00 ( '24.04.30 Nov-Lab ) 作成開始
// @(h)XListBox.cs ver 0.21 ( '24.04.30 Nov-Lab ) アルファ版完成

// @(s)
// 　【ListBox 拡張メソッド】ListBox クラスに拡張メソッドを追加します。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;


namespace NovLab.Windows.Forms
{
    //====================================================================================================
    /// <summary>
    /// 【ListBox 拡張メソッド】<see cref="ListBox"/> クラスに拡張メソッドを追加します。
    /// </summary>
    //====================================================================================================
    public static partial class XListBox
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【スクロール付きリストボックス項目追加】
        /// リストボックスに項目を追加し、追加前の選択状態に応じて選択項目の変更を行います。
        /// </summary>
        /// <param name="lstTarget">[in ]：対象リストボックス</param>
        /// <param name="item">     [in ]：追加する項目</param>
        /// <returns>
        /// 追加したインデックス
        /// </returns>
        /// <exception cref="InvalidOperationException">操作不正例外。このメソッドは単一選択リストボックスでなければ使用できません。</exception>
        /// <remarks>
        /// 補足<br/>
        /// <code>
        /// 追加前の選択状態        ：追加後の動作
        /// -----------------------------------------------------------------------------
        /// 選択項目なし            ：追加した項目を単一選択状態にする
        /// 最後の項目が選択状態    ：追加した項目を単一選択状態にする
        /// 最後以外の項目が選択状態：選択状態は変更しない
        /// </code>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static int XAddItemWithScroll(this ListBox lstTarget, object item)
        {
            bool postSelect;    // 追加処理後選択フラグ


            //------------------------------------------------------------
            /// 単一選択リストボックスでない場合は例外
            //------------------------------------------------------------
            if (lstTarget.SelectionMode != SelectionMode.One)
            {                                                           //// リストボックスの選択モード = 単一選択 でない場合
                throw                                                   /////  操作不正例外をスローする
                    new InvalidOperationException("このメソッドは単一選択リストボックスでなければ使用できません。");
            }


            //------------------------------------------------------------
            /// 追加処理後に選択状態にすべきかどうかを決定する
            //------------------------------------------------------------
            if (lstTarget.SelectedIndex == -1)
            {                                                           //// 選択中の項目がない場合
                postSelect = true;                                      /////  追加処理後選択フラグ = true
            }
            else if (lstTarget.SelectedIndex == lstTarget.Items.Count - 1)
            {                                                           //// 最後の項目を選択している場合
                postSelect = true;                                      /////  追加処理後選択フラグ = true
            }
            else
            {                                                           //// 最後以外の項目を選択している場合
                postSelect = false;                                     /////  追加処理後選択フラグ = false
            }


            //------------------------------------------------------------
            /// 項目を追加する
            //------------------------------------------------------------
            var addedIndex = lstTarget.Items.Add(item);                 //// リストボックスに項目を追加する
            if (postSelect)
            {                                                           //// 追加処理後選択フラグ = true の場合
                lstTarget.SetSelected(addedIndex, true);                /////  追加した項目を選択状態にする
            }

            return addedIndex;                                          //// 戻り値 = 追加したインデックス で関数終了
        }

    } // class

} // namespace
