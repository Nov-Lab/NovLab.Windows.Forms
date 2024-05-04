// @(h)XForm.cs ver 0.00 ( '24.05.04 Nov-Lab ) 作成開始
// @(h)XForm.cs ver 0.21 ( '24.05.04 Nov-Lab ) アルファ版完成

// @(s)
// 　【Form 拡張メソッド】Form クラスに拡張メソッドを追加します。

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace NovLab.Windows.Forms
{
    //====================================================================================================
    /// <summary>
    /// 【Form 拡張メソッド】<see cref="Form"/> クラスに拡張メソッドを追加します。
    /// </summary>
    //====================================================================================================
    public static partial class XForm
    {
        //[-] 保留：マルチモニター環境での動作は未確認：XForm.XCenterTo
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【他のフォームの中心位置へ移動】フォームを指定したフォームの境界内の中央に配置します。
        /// </summary>
        /// <param name="target">[in ]：対象インスタンス</param>
        /// <param name="other"> [in ]：相手フォーム</param>
        /// <remarks>
        /// 補足<br/>
        /// ・被所有フォームを所有者フォームの中央に配置したい場合などに使用します。<br/>
        /// ・このメソッドを呼び出すと、<see cref="Form.StartPosition"/> は <see cref="FormStartPosition.Manual"/> に設定されます。<br/>
        /// ・なお、<see cref="FormStartPosition.CenterParent"/> は、
        ///   MDI子フォームをMDI親フォームの中央に配置するためのものなので、
        ///   被所有フォームを所有者フォームの中央に配置する用途には使えません。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XCenterTo(this Form target, Form other)
        {
            //------------------------------------------------------------
            /// フォームを指定したフォームの境界内の中央に配置する
            //------------------------------------------------------------
            var rect = target.DesktopBounds;                            //// フォームの位置サイズを取得する
            rect.XMoveToCenterOf(other.DesktopBounds);                  //// 相手フォームの中心位置へ配置するように位置を調整する
            rect.XMoveToInnerOf(SystemInformation.WorkingArea);         //// 作業領域の範囲内に収まるように位置を調整する

            target.StartPosition = FormStartPosition.Manual;            //// フォームの開始位置 = 手動 に設定する
            target.DesktopBounds = rect;                                //// 調整した位置サイズをフォームに反映する
        }

    } // class

} // namespace
