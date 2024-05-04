// @(h)XRectangle.cs ver 0.00 ( '24.05.04 Nov-Lab ) 作成開始
// @(h)XRectangle.cs ver 0.21 ( '24.05.04 Nov-Lab ) アルファ版完成

// @(s)
// 　【Rectangle 拡張メソッド】Rectangle クラスに拡張メソッドを追加します。

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace NovLab.Windows.Forms
{
    //====================================================================================================
    /// <summary>
    /// 【Rectangle 拡張メソッド】<see cref="Rectangle"/> クラスに拡張メソッドを追加します。
    /// </summary>
    //====================================================================================================
    public static partial class XRectangle
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【中心へ移動】この Rectangle を、指定した Rectangle の中心位置へ移動します。
        /// </summary>
        /// <param name="target">[ref]：対象インスタンス</param>
        /// <param name="other"> [in ]：相手Rectangle</param>
        /// <remarks>
        /// 補足<br/>
        /// ・被所有フォームを所有者フォームの中心位置に移動する場合などに使用します。<br/>
        /// ・このとき、フォームが作業領域からはみ出さないように調整したい場合は、
        ///   さらに <c>XMoveToInnerOf(SystemInformation.WorkingArea)</c> を呼び出します。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XMoveToCenterOf(this ref Rectangle target, Rectangle other)
        {
            //------------------------------------------------------------
            /// 指定した Rectangle の中心位置に移動する
            //------------------------------------------------------------
            target.Location = other.Location;
            target.Offset((other.Width - target.Width) / 2,
                          (other.Height - target.Height) / 2);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【範囲内へ移動】この Rectangle を、指定した Rectangle の範囲内に収まる位置へ移動します。
        /// </summary>
        /// <param name="target">[ref]：対象インスタンス</param>
        /// <param name="other"> [in ]：相手Rectangle</param>
        /// <remarks>
        /// 補足<br/>
        /// ・フォームの位置を作業領域の範囲内に収まるように調整する場合などに使用します。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XMoveToInnerOf(this ref Rectangle target, Rectangle other)
        {
            //------------------------------------------------------------
            /// 指定した Rectangle の範囲内に収まる位置へ移動する
            //------------------------------------------------------------
            if (target.Width >= other.Width)
            {                                                           //// 対象インスタンスの横幅が相手Rectangleの横幅以上の場合
                target.X = other.X;                                     /////  X座標 = 相手RectangleのX座標
            }
            else
            {                                                           //// 対象インスタンスの横幅が相手Rectangleの横幅に収まる場合
                if (target.Left < other.Left)
                {                                                       /////  左端がはみ出している場合
                    target.X = other.Left;                              //////   相手Rectangleの横範囲に収まるようにX座標を調整する
                }
                if (target.Right > other.Right)
                {                                                       /////  右端がはみ出している場合
                    target.X = other.Right - target.Width;              //////   相手Rectangleの横範囲に収まるようにX座標を調整する
                }
            }

            if (target.Height >= other.Height)
            {                                                           //// 対象インスタンスの高さが相手Rectangleの高さ以上の場合
                target.Y = other.Y;                                     /////  Y座標 = 相手RectangleのY座標
            }
            else
            {                                                           //// 対象インスタンスの高さが相手Rectangleの高さに収まる場合
                if (target.Top < other.Top)
                {                                                       /////  上端がはみ出している場合
                    target.Y = other.Top;                               //////   相手Rectangleの縦範囲に収まるようにY座標を調整する
                }
                if (target.Bottom > other.Bottom)
                {                                                       /////  下端がはみ出している場合
                    target.Y = other.Bottom - target.Height;            //////   相手Rectangleの縦範囲に収まるようにY座標を調整する
                }
            }
        }

    } // class

} // namespace
