// @(h)EnumListItem.cs ver 0.00 ( '24.05.06 Nov-Lab ) 作成開始
// @(h)EnumListItem.cs ver 0.51 ( '24.05.12 Nov-Lab ) ベータ版完成
// @(h)EnumListItem.cs ver 0.51a( '24.05.14 Nov-Lab ) その他  ：コメント整理

// @(s)
// 　【列挙値リスト項目】EnumDisplayName クラスで表示名を取得可能な列挙値を、
// 　リストボックスやコンボボックスのリスト項目として扱うための仕組みを提供します。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

using NovLab.EnumDisplayNameUtil;
using NovLab.DebugSupport;


namespace NovLab.Windows.Forms
{
#if DEBUG
    //====================================================================================================
    /// <summary>
    /// 
    /// 【概要説明】<br/>
    ///   EnumListItem クラスおよび XListControl_EnumListItem クラスは、EnumDisplayName で表示名を取得可能な列挙値を、
    ///   リストボックスやコンボボックスのリスト項目として扱うための仕組みを提供します。<br/>
    /// 
    /// <br/>
    /// ・列挙値に表示名を付加する方法については <see cref="About_NovLab_EnumDisplayNameUtil"/> を参照してください。<br/>
    ///   
    /// </summary>
    //====================================================================================================
    public class About_EnumListItem : ZZZ
    {
        // 以下のサンプルコードは、「EnumListItem クラスのテスト」画面の「サンプルコードを実行」メニューで実際に実行できます。
        // (このクラス内にある Action<ListControl> デリゲートに合致するメソッドは自動的にメニューへ追加されます。)


        //
        // 【使い方①】
        //   EnumListItem および XListControl_EnumListItem の基本的な使用方法
        //
        public static void Sample1(ListControl ListControl1)
        {
            //
            // DayOfWeek 列挙体の有効列挙値すべてを ListControl1 に設定する(リストには EnumDisplayName で取得した列挙値表示名を表示する)
            //
            ListControl1.XSetEnumDataSource<DayOfWeek>();

            //
            // DayOfWeek.Saturday 列挙値に対応する項目を選択する
            //
            ListControl1.SelectedValue = DayOfWeek.Saturday;

            //
            // 選択中項目から DayOfWeek 列挙値を取得する
            //
            var enumValue = (DayOfWeek)ListControl1.SelectedValue;
            Debug.Print("選択中項目の列挙定数名 = " + enumValue);

            //
            // 選択中項目から既定の列挙値表示名を取得する
            //
            var displayName = ((DayOfWeek)ListControl1.SelectedValue).XToDisplayName();
            Debug.Print("選択中項目の列挙値表示名 = " + displayName);
        }

        //
        // 【使い方②】
        //   リストコントロール上の表示名に特定の列挙値表示名供給関数を使いたい場合は、使用したい供給関数を引数で渡します。
        //
        public static void Sample2(ListControl ListControl1)
        {
            //
            // DayOfWeek 列挙体の有効列挙値すべてを ListControl1 に設定する(リストには日本語１文字で曜日を表示する)
            //
            ListControl1.XSetEnumDataSource<DayOfWeek>(NovLabEnumDisplayNameProvider.ForDayOfWeek.GetEnumDisplayNameByJP1Char);

            //
            // リストコントロール上の表示名が変わっても、同じ列挙値でアクセスできる
            //
            ListControl1.SelectedValue = DayOfWeek.Saturday;
            var enumValue = (DayOfWeek)ListControl1.SelectedValue;
            Debug.Print("選択中項目の列挙定数名 = " + enumValue);
        }

        //
        // 【使い方③】
        //   リスト項目に含める列挙値の一覧とその並びを指定したい場合は、列挙値配列を引数で渡します。
        //
        public static void Sample3(ListControl ListControl1)
        {
            //
            // リストコントロールに「土曜日」「日曜日」「月曜日」だけを設定する
            //
            DayOfWeek[] customItems =
            {
                DayOfWeek.Saturday, // 土曜日
                DayOfWeek.Sunday,   // 日曜日
                DayOfWeek.Monday,   // 月曜日
            };

            ListControl1.XSetEnumDataSource(customItems);

            //
            // リストコントロール上の並び順や表示名が変わっても、同じ列挙値でアクセスできる
            //
            ListControl1.SelectedValue = DayOfWeek.Saturday;
            var enumValue = (DayOfWeek)ListControl1.SelectedValue;
            Debug.Print("選択中項目の列挙定数名 = " + enumValue);
        }

        //
        // 【使い方④】
        //   リストコントロール上の表示名を直接指定したい場合は、EnumListItem<TEnum> の配列を作成して引数で渡します。
        //   この場合、リスト項目に含める列挙値の一覧とその並びも指定することができます。
        //
        public static void Sample4(ListControl ListControl1)
        {
            //
            // リストコントロールに「火曜日(定休日)」「土曜日(特売日)」「日曜日(特売日)」だけを表示する
            //
            EnumListItem<DayOfWeek>[] customItems =
            {
                new EnumListItem<DayOfWeek>("火曜日(定休日)", DayOfWeek.Tuesday),
                new EnumListItem<DayOfWeek>("土曜日(特売日)", DayOfWeek.Saturday),
                new EnumListItem<DayOfWeek>("日曜日(特売日)", DayOfWeek.Sunday),
            };

            ListControl1.XSetEnumDataSource(customItems);

            //
            // リストコントロール上の並び順や表示名が変わっても、同じ列挙値でアクセスできる
            //
            ListControl1.SelectedValue = DayOfWeek.Saturday;
            var enumValue = (DayOfWeek)ListControl1.SelectedValue;
            Debug.Print("選択中項目の列挙定数名 = " + enumValue);
        }

    } // class

#endif


    //====================================================================================================
    /// <summary>
    /// 【ListControl拡張メソッド】<see cref="EnumDisplayName"/> クラスで表示名を取得可能な列挙値を、
    /// ListControl(リストボックスやコンボボックス)のリスト項目として扱うための拡張メソッドを追加します。<br/>
    /// </summary>
    //====================================================================================================
    public static partial class XListControl_EnumListItem
    {
        //====================================================================================================
        // ListControl(リストボックスやコンボボックス)用の拡張メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値データソース設定】以下の内容で、列挙値のリストをリストボックスやコンボボックスのデータソースに設定します。<br/>
        /// <code>
        /// ・リストに含まれる列挙値：既定(列挙体で定義されている有効列挙値すべて)
        /// ・リストの並び順        ：既定(列挙値のバイナリ値昇順)
        /// ・列挙値表示名取得方法  ：既定(<see cref="EnumDisplayName"/> クラスで取得)
        /// </code>
        /// </summary>
        /// <typeparam name="TEnum">列挙体の型</typeparam>
        /// <param name="target">[in ]：対象リストコントロール</param>
        /// <remarks>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XSetEnumDataSource<TEnum>(this ListControl target) where TEnum : struct, Enum
        {
            //------------------------------------------------------------
            /// 列挙値のリストをリストボックスやコンボボックスのデータソースに設定する
            //------------------------------------------------------------
            var enumListItems = EnumListItem<TEnum>.CreateItems();      //// 有効列挙値から列挙値リスト項目配列を生成する
            M_SetToListControl(target, enumListItems);                  //// 列挙値リスト項目配列をリストコントロールへ設定処理を行う
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値データソース設定】以下の内容で、列挙値のリストをリストボックスやコンボボックスのデータソースに設定します。<br/>
        /// <code>
        /// ・リストに含まれる列挙値：任意(引数で指定した列挙値配列の内容すべて[*1])
        /// ・リストの並び順        ：任意(引数で指定した列挙値配列の順番[*2])
        /// ・列挙値表示名取得方法  ：既定(<see cref="EnumDisplayName"/> クラスで取得)
        /// </code>
        /// [*1] <paramref name="enumValues"/> に null を指定した場合は、列挙体で定義されている有効列挙値すべてになります。<br/>
        /// [*2] <paramref name="enumValues"/> に null を指定した場合は、列挙値のバイナリ値昇順になります。<br/>
        /// </summary>
        /// <typeparam name="TEnum">列挙体の型</typeparam>
        /// <param name="target">    [in ]：対象リストコントロール</param>
        /// <param name="enumValues">[in ]：列挙値配列[null = 列挙体に含まれる有効列挙値すべてをバイナリ値昇順で]</param>
        /// <remarks>
        /// 用途<br/>
        /// ・リストに含める列挙値とその並び順を指定したい場合に使います。<br/>
        /// <br/>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XSetEnumDataSource<TEnum>(this ListControl target, TEnum[] enumValues) where TEnum : struct, Enum
        {
            //------------------------------------------------------------
            /// 列挙値のリストをリストボックスやコンボボックスのデータソースに設定する
            //------------------------------------------------------------
            var enumListItems = EnumListItem<TEnum>.CreateItems(enumValues);//// 指定された列挙値配列から列挙値リスト項目配列を生成する
            M_SetToListControl(target, enumListItems);                      //// 列挙値リスト項目配列をリストコントロールへ設定処理を行う
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値データソース設定】以下の内容で、列挙値のリストをリストボックスやコンボボックスのデータソースに設定します。<br/>
        /// <code>
        /// ・リストに含まれる列挙値：既定(列挙体で定義されている有効列挙値すべて)
        /// ・リストの並び順        ：既定(列挙値のバイナリ値昇順)
        /// ・列挙値表示名取得方法  ：指定(引数で指定した列挙値表示名供給関数を使って取得[*1][*2])
        /// </code>
        /// [*1] 指定した列挙値表示名供給関数で列挙値表示名を取得できなかった場合は、列挙値の ToString() の結果が列挙値表示名になります。<br/>
        /// [*2] <paramref name="fncProvider"/> に null を指定した場合は、<see cref="EnumDisplayName"/> クラスで取得します。<br/>
        /// </summary>
        /// <typeparam name="TEnum">列挙体の型</typeparam>
        /// <param name="target">     [in ]：対象リストコントロール</param>
        /// <param name="fncProvider">[in ]：列挙値表示名供給関数[null = <see cref="EnumDisplayName"/> クラスで取得]</param>
        /// <remarks>
        /// 用途<br/>
        /// ・リストの内容と並び順は既定のままで、特定の列挙値表示名供給関数で列挙値表示名を取得したい場合に使います。<br/>
        /// <br/>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XSetEnumDataSource<TEnum>(this ListControl target, EnumDisplayNameProvider fncProvider) where TEnum : struct, Enum
        {
            //------------------------------------------------------------
            /// 列挙値のリストをリストボックスやコンボボックスのデータソースに設定する
            //------------------------------------------------------------
            var enumListItems =                                         //// 指定された列挙値表示名供給関数を使って列挙値リスト項目配列を生成する
                        EnumListItem<TEnum>.CreateItems(fncProvider);
            M_SetToListControl(target, enumListItems);                  //// 列挙値リスト項目配列をリストコントロールへ設定処理を行う
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値データソース設定】以下の内容で、列挙値のリストをリストボックスやコンボボックスのデータソースに設定します。<br/>
        /// <code>
        /// ・リストに含まれる列挙値：任意(引数で指定した列挙値配列の内容すべて[*1])
        /// ・リストの並び順        ：任意(引数で指定した列挙値配列の順番[*2])
        /// ・列挙値表示名取得方法  ：指定(引数で指定した列挙値表示名供給関数を使って取得[*3][*4])
        /// </code>
        /// [*1] <paramref name="enumValues"/> に null を指定した場合は、列挙体で定義されている有効列挙値すべてになります。<br/>
        /// [*2] <paramref name="enumValues"/> に null を指定した場合は、列挙値のバイナリ値昇順になります。<br/>
        /// [*3] 指定した列挙値表示名供給関数で列挙値表示名を取得できなかった場合は、列挙値の ToString() の結果が列挙値表示名になります。<br/>
        /// [*4] <paramref name="fncProvider"/> に null を指定した場合は、<see cref="EnumDisplayName"/> クラスで取得します。<br/>
        /// </summary>
        /// <typeparam name="TEnum">列挙体の型</typeparam>
        /// <param name="target">     [in ]：対象リストコントロール</param>
        /// <param name="enumValues"> [in ]：列挙値配列[null = 列挙体に含まれる有効列挙値すべてをバイナリ値昇順で]</param>
        /// <param name="fncProvider">[in ]：列挙値表示名供給関数[null = <see cref="EnumDisplayName"/> クラスで取得]</param>
        /// <remarks>
        /// 用途<br/>
        /// ・リスト項目に含める列挙値とその並び順を指定しつつ、特定の列挙値表示名供給関数で列挙値表示名を取得したい場合に使います。<br/>
        /// <br/>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XSetEnumDataSource<TEnum>(this ListControl target, TEnum[] enumValues, EnumDisplayNameProvider fncProvider) where TEnum : struct, Enum
        {
            //------------------------------------------------------------
            /// 列挙値のリストをリストボックスやコンボボックスのデータソースに設定する
            //------------------------------------------------------------
            var enumListItems =                                         //// 指定された列挙値表示名供給関数を使い、指定された列挙値配列から列挙値リスト項目配列を生成する
                EnumListItem<TEnum>.CreateItems(enumValues, fncProvider);
            M_SetToListControl(target, enumListItems);                  //// 列挙値リスト項目配列をリストコントロールへ設定処理を行う
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値データソース設定】以下の内容で、列挙値のリストをリストボックスやコンボボックスのデータソースに設定します。<br/>
        /// <code>
        /// ・リストに含まれる列挙値：任意(引数で指定した列挙値リスト項目配列の内容すべて)
        /// ・リストの並び順        ：任意(引数で指定した列挙値リスト項目配列の順番)
        /// ・列挙値表示名          ：任意(引数で指定した列挙値リスト項目配列に設定されている表示名)
        /// </code>
        /// </summary>
        /// <typeparam name="TEnum">列挙体の型</typeparam>
        /// <param name="target">       [in ]：対象リストコントロール</param>
        /// <param name="enumListItems">[in ]：列挙値リスト項目配列</param>
        /// <remarks>
        /// 用途<br/>
        /// ・列挙値表示名供給関数を用意せずに任意の列挙値表示名を表示したい場合に使います。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static void XSetEnumDataSource<TEnum>(this ListControl target, EnumListItem<TEnum>[] enumListItems) where TEnum : struct, Enum
        {
            //------------------------------------------------------------
            /// 引数をチェックする
            //------------------------------------------------------------
            if (enumListItems == null)
            {                                                           //// 列挙値リスト項目配列 = null の場合
                throw new ArgumentNullException(nameof(enumListItems)); /////  引数不正例外(null)をスローする
            }


            //------------------------------------------------------------
            /// 列挙値のリストをリストボックスやコンボボックスのデータソースに設定する
            //------------------------------------------------------------
            M_SetToListControl(target, enumListItems);                  //// 列挙値リスト項目配列をリストコントロールへ設定処理を行う
        }


        //====================================================================================================
        // 内部メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値リスト項目配列をリストコントロールへ設定】列挙値リスト項目配列をリストコントロールのデータソースに設定します。<br/>
        /// </summary>
        /// <typeparam name="TEnum">列挙体の型</typeparam>
        /// <param name="target">       [in ]：対象リストコントロール</param>
        /// <param name="enumListItems">[in ]：列挙値リスト項目配列</param>
        /// <remarks>
        /// 補足<br/>
        /// ・<see cref="XSetEnumDataSource"/> の各オーバーロードから呼び出される共通部分です。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        private static void M_SetToListControl<TEnum>(ListControl target, EnumListItem<TEnum>[] enumListItems) where TEnum : struct, Enum
        {
            //------------------------------------------------------------
            /// 列挙値リスト項目配列をリストコントロールのデータソースに設定する
            //------------------------------------------------------------
            target.DisplayMember = EnumListItem<TEnum>.GetDisplayMember();  //// DisplayMember を設定する
            target.ValueMember = EnumListItem<TEnum>.GetValueMember();      //// ValueMember を設定する
            target.DataSource = enumListItems;                              //// データソース = 列挙値リスト項目配列
        }

    } // class


    // ＜メモ＞
    // ・このようなラッパークラスを用意することでしか、列挙値表示名をリストに表示しつつ、列挙値を値として使用することはできないはず。
    //   ①ListBox.DisplayMember は、列挙値表示名をリストに表示する用途には使えない。
    //     ListBox.DisplayMember で指定する対象はプロパティーでなければならないが、列挙型にプロパティーを持たせることはできない。
    //   ②ListBox.DisplayMember を指定しない場合は ToString() の結果が表示されるが、列挙型は ToString() をオーバーライドすることもできない。
    //====================================================================================================
    /// <summary>
    /// 【列挙値リスト項目】<see cref="EnumDisplayName"/> クラスで表示名を取得可能な列挙値を、
    /// リストボックスやコンボボックスのリスト項目として扱うためのラッパークラスです。<br/>
    /// </summary>
    /// <typeparam name="TEnum">列挙体の型</typeparam>
    /// <remarks>
    /// 機能概要<br/>
    /// ・列挙値と、それに対応する列挙値表示名をペアで保持します。<br/>
    /// ・<see cref="EnumValue"/> プロパティーで、保持している列挙値を取得できます。<br/>
    /// ・<see cref="DisplayName"/> プロパティーで、保持している列挙値表示名を取得できます。<br/>
    /// ・<see cref="GetDisplayMember"/> メソッドで、<see cref="ListControl.DisplayMember"/> に設定すべき内容を取得できます。<br/>
    /// ・<see cref="GetValueMember"/> メソッドで、<see cref="ListControl.ValueMember"/> に設定すべき内容を取得できます。<br/>
    /// <br/>
    /// 補足<br/>
    /// ・Enum クラスの仕様により、同じ内部整数値を持つ列挙値が複数定義されている列挙型には適しません。
    ///  (参考メモ：<see cref="Memo_DuplicateEnumValue"/>)<br/>
    /// </remarks>
    //====================================================================================================
    public partial class EnumListItem<TEnum> : IDetailString where TEnum : struct, Enum
    {
        // ＜メモ＞
        // ・インターフェイスで定型化したかったが、C#7.3 ではインターフェイスで static メソッドを定義できないので断念した。
        //  (インスタンスメソッドでも良かったが、適切な使い方ではないのでやめておいた)
        //====================================================================================================
        // リストコントロールとの連携用
        // ・DisplayMember(表示するプロパティー) = 列挙値表示名
        // ・ValueMember(項目の値として使用するプロパティー) = 列挙値
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// <see cref="ListControl.DisplayMember"/> に設定すべき内容を取得します。
        /// </summary>
        /// <returns>
        /// 列挙値表示名のプロパティー名
        /// </returns>
        /// <remarks>
        /// 補足<br/>
        /// ・<see cref="EnumListItem{TEnum}"/> をリストボックスやコンボボックスのリスト項目として適切に使用できるようにします。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static string GetDisplayMember() => nameof(DisplayName);


        //--------------------------------------------------------------------------------
        /// <summary>
        /// <see cref="ListControl.ValueMember"/> に設定すべき内容を取得します。
        /// </summary>
        /// <returns>
        /// 列挙値のプロパティー名
        /// </returns>
        /// <remarks>
        /// 補足<br/>
        /// ・<see cref="EnumListItem{TEnum}"/> をリストボックスやコンボボックスのリスト項目として適切に使用できるようにします。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static string GetValueMember() => nameof(EnumValue);


        //====================================================================================================
        // 公開プロパティー
        // ・ListControl.DisplayMember や ListControl.ValueMember に設定する都合上、
        //   フィールドではなく、プロパティーでなければならない。
        //====================================================================================================

        /// <summary>
        /// 【列挙値(読み取り専用)】列挙値を取得します。
        /// </summary>
        /// <remarks>
        /// 補足<br/>
        /// ・リストボックスやコンボボックスの <see cref="ListControl.ValueMember"/> に設定することで、
        ///   項目の値として使用するプロパティーとして扱います。<br/>
        /// </remarks>
        public TEnum EnumValue => bf_enumValue;
        protected readonly TEnum bf_enumValue;


        /// <summary>
        /// 【列挙値表示名(読み取り専用)】列挙値に対応する表示名を取得します。
        /// </summary>
        /// <remarks>
        /// 補足<br/>
        /// ・リストボックスやコンボボックスの <see cref="ListControl.DisplayMember"/> に設定することで、
        ///   表示するプロパティーとして扱います。<br/>
        /// </remarks>
        public string DisplayName => bf_displayName;
        protected readonly string bf_displayName;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【文字列化】列挙値表示名を取得します。
        /// </summary>
        /// <returns>文字列形式(列挙値表示名)</returns>
        /// <remarks>
        /// 補足<br/>
        /// 以下のコントロールでは、ToString() の結果を表示文字列として使用します。<br/>
        /// ・DomainUpDown コントロール<br/>
        /// ・ListBox コントロール (DisplayMember を設定していない場合)<br/>
        /// ・ComboBox コントロール (DisplayMember を設定していない場合)<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public override string ToString() => DisplayName;


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【詳細文字列取得】オブジェクトから詳細文字列を取得します。
        /// </summary>
        /// <returns>詳細文字列</returns>
        /// <remarks>
        /// 補足<br></br>
        /// ・<see cref="IDetailString"/> I/F の実装です。<br/>
        /// ・詳細文字列は以下のような書式になります。<br/>
        /// <code>
        /// 書式：＜列挙型名＞.＜列挙定数名＞(＜内部整数値＞)[＜列挙値表示名＞]
        /// 例  ：DayOfWeek.Monday(1)[月曜日]
        /// </code>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public string GetDetailString() => $"{typeof(TEnum).Name}.{EnumValue}({Enum.Format(typeof(TEnum), EnumValue, "d")})[{DisplayName}]";


        //====================================================================================================
        // コンストラクター
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【基本コンストラクター】基本的な方法で列挙値リスト項目を生成します。<br/>
        /// 列挙値表示名には <see cref="EnumDisplayName"/> クラスを使って取得した内容が設定されます。
        /// </summary>
        /// <param name="enumValue">[in ]：列挙値</param>
        /// <remarks>
        /// 補足<br/>
        /// ・既定の方法で列挙値表示名を取得する場合に使います。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public EnumListItem(TEnum enumValue)
        {
            bf_enumValue = enumValue;
            bf_displayName = EnumDisplayName.GetFrom(enumValue);
        }


        // ＜メモ＞
        // ・new EnumListItem<列挙体の型>(列挙値, null) としたときは列挙値表示名供給関数指定版が呼び出されるように、
        //   列挙値表示名を第一引数にしている。
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値表示名指定コンストラクター】列挙値表示名を指定して列挙値リスト項目を生成します。
        /// </summary>
        /// <param name="displayName">[in ]：列挙値表示名</param>
        /// <param name="enumValue">  [in ]：列挙値</param>
        /// <remarks>
        /// 補足<br/>
        /// ・列挙値表示名を直接指定したい場合に使います。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public EnumListItem(string displayName, TEnum enumValue)
        {
            bf_enumValue = enumValue;
            bf_displayName = displayName;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値表示名供給関数指定コンストラクター】列挙値表示名供給関数で列挙値表示名を取得するようにして、列挙値リスト項目を生成します。
        /// </summary>
        /// <param name="enumValue">  [in ]：列挙値</param>
        /// <param name="fncProvider">[in ]：列挙値表示名供給関数[null = <see cref="EnumDisplayName"/> クラスで取得する]</param>
        /// <remarks>
        /// 補足<br/>
        /// ・特定の列挙値表示名供給関数で列挙値表示名を取得したい場合に使います。<br/>
        /// ・指定した列挙値表示名供給関数で列挙値表示名を取得できなかった場合は、
        ///   列挙値表示名には <paramref name="enumValue"/>.ToString() の結果が設定されます。<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public EnumListItem(TEnum enumValue, EnumDisplayNameProvider fncProvider)
        {
            string displayName; // 列挙値表示名

            //------------------------------------------------------------
            /// 指定された列挙値表示名供給関数で列挙値表示名を取得する
            //------------------------------------------------------------
            if (fncProvider != null)
            {                                                           //// 列挙値表示名供給関数が指定されている場合
                displayName = fncProvider(enumValue);                   /////  列挙値表示名供給関数を使用して列挙値表示名を取得する
            }
            else
            {                                                           //// 列挙値表示名供給関数が指定されていない場合(null の場合)
                displayName = EnumDisplayName.GetFrom(enumValue);       /////  EnumDisplayName を使用して列挙値表示名を取得する
            }

            if (displayName == null)
            {                                                           //// 列挙値表示名 = null の場合(上記処理で取得できなかった場合)
                displayName = enumValue.ToString();                     /////  列挙値表示名 = ToString() の結果
            }


            //------------------------------------------------------------
            /// 列挙値リスト項目を初期化する
            //------------------------------------------------------------
            bf_enumValue = enumValue;                                   //// 列挙値をバッキングフィールドに設定する
            bf_displayName = displayName;                               //// 列挙値表示名をバッキングフィールドに設定する
        }


        //====================================================================================================
        // 配列生成用 static 公開メソッド
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値リスト項目配列生成】以下の内容で列挙値リスト項目配列を生成します。<br/>
        /// <code>
        /// ・配列に含まれる列挙値：既定(列挙体で定義されている有効列挙値すべて)
        /// ・配列の並び順        ：既定(列挙値のバイナリ値昇順)
        /// ・列挙値表示名取得方法：既定(<see cref="EnumDisplayName"/> クラスで取得)
        /// </code>
        /// </summary>
        /// <returns>
        /// 列挙値リスト項目配列。
        /// </returns>
        /// <remarks>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // 積極的にインライン化する
        public static EnumListItem<TEnum>[] CreateItems() => CreateItems(null, null);


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値リスト項目配列生成】以下の内容で列挙値リスト項目配列を生成します。<br/>
        /// <code>
        /// ・配列に含まれる列挙値：任意(引数で指定した列挙値配列の内容すべて[*1])
        /// ・配列の並び順        ：任意(引数で指定した列挙値配列の順番[*2])
        /// ・列挙値表示名取得方法：既定(<see cref="EnumDisplayName"/> クラスで取得)
        /// </code>
        /// [*1] <paramref name="enumValues"/> に null を指定した場合は、列挙体で定義されている有効列挙値すべてになります。<br/>
        /// [*2] <paramref name="enumValues"/> に null を指定した場合は、列挙値のバイナリ値昇順になります。<br/>
        /// </summary>
        /// <param name="enumValues">[in ]：列挙値配列[null = 列挙体に含まれる有効列挙値すべてをバイナリ値昇順で]</param>
        /// <returns>
        /// 列挙値リスト項目配列。
        /// </returns>
        /// <remarks>
        /// 用途<br/>
        /// ・リスト項目に含める列挙値とその並び順を指定したい場合に使います。<br/>
        /// <br/>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // 積極的にインライン化する
        public static EnumListItem<TEnum>[] CreateItems(TEnum[] enumValues) => CreateItems(enumValues, null);


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値リスト項目配列生成】以下の内容で列挙値リスト項目配列を生成します。<br/>
        /// <code>
        /// ・配列に含まれる列挙値：既定(列挙体で定義されている有効列挙値すべて)
        /// ・配列の並び順        ：既定(列挙値のバイナリ値昇順)
        /// ・列挙値表示名取得方法：指定(引数で指定した列挙値表示名供給関数を使って取得[*1][*2])
        /// </code>
        /// [*1] 指定した列挙値表示名供給関数で列挙値表示名を取得できなかった場合は、列挙値の ToString() の結果が列挙値表示名になります。<br/>
        /// [*2] <paramref name="fncProvider"/> に null を指定した場合は、<see cref="EnumDisplayName"/> クラスで取得します。<br/>
        /// </summary>
        /// <param name="fncProvider">[in ]：列挙値表示名供給関数[null = <see cref="EnumDisplayName"/> クラスで取得]</param>
        /// <returns>
        /// 列挙値リスト項目配列。
        /// </returns>
        /// <remarks>
        /// 用途<br/>
        /// ・配列の内容と並び順は既定のままで、特定の列挙値表示名供給関数で列挙値表示名を取得したい場合に使います。<br/>
        /// <br/>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // 積極的にインライン化する
        public static EnumListItem<TEnum>[] CreateItems(EnumDisplayNameProvider fncProvider) => CreateItems(null, fncProvider);


        // ＜メモ＞
        // ・他の各オーバーロードからも利用されているので変更時は気を付けること。
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値リスト項目配列生成】以下の内容で列挙値リスト項目配列を生成します。<br/>
        /// <code>
        /// ・配列に含まれる列挙値：任意(引数で指定した列挙値配列の内容すべて[*1])
        /// ・配列の並び順        ：任意(引数で指定した列挙値配列の順番[*2])
        /// ・列挙値表示名取得方法：指定(引数で指定した列挙値表示名供給関数を使って取得[*3][*4])
        /// </code>
        /// [*1] <paramref name="enumValues"/> に null を指定した場合は、列挙体で定義されている有効列挙値すべてになります。<br/>
        /// [*2] <paramref name="enumValues"/> に null を指定した場合は、列挙値のバイナリ値昇順になります。<br/>
        /// [*3] 指定した列挙値表示名供給関数で列挙値表示名を取得できなかった場合は、列挙値の ToString() の結果が列挙値表示名になります。<br/>
        /// [*4] <paramref name="fncProvider"/> に null を指定した場合は、<see cref="EnumDisplayName"/> クラスで取得します。<br/>
        /// </summary>
        /// <param name="enumValues"> [in ]：列挙値配列[null = 列挙体に含まれる有効列挙値すべてをバイナリ値昇順で]</param>
        /// <param name="fncProvider">[in ]：列挙値表示名供給関数[null = <see cref="EnumDisplayName"/> クラスで取得]</param>
        /// <returns>
        /// 列挙値リスト項目配列。
        /// </returns>
        /// <remarks>
        /// 用途<br/>
        /// ・リスト項目に含める列挙値とその並び順を指定しつつ、特定の列挙値表示名供給関数で列挙値表示名を取得したい場合に使います。<br/>
        /// <br/>
        /// 補足<br/>
        /// ・有効列挙値 = 列挙処理対象外マーク属性(<see cref="EnumerateIgnoreAttribute"/>) が付加されていない列挙値<br/>
        /// ・列挙値のバイナリ値昇順 = <see cref="Enum.GetValues(Type)"/> が返す並び順<br/>
        /// ・<see cref="EnumDisplayName"/> クラスで取得 = 列挙値表示名供給関数や属性を参照して取得<br/>
        /// </remarks>
        //--------------------------------------------------------------------------------
        public static EnumListItem<TEnum>[] CreateItems(TEnum[] enumValues, EnumDisplayNameProvider fncProvider)
        {
            //------------------------------------------------------------
            /// 列挙値リスト項目配列を生成する
            //------------------------------------------------------------
            if (enumValues == null)
            {                                                               //// 列挙値配列 = null(有効列挙値すべてを取得) の場合
                enumValues = XEnum.XGetValidValues<TEnum>();                /////  列挙値配列 = 列挙体の有効列挙値すべて
            }

            var items = new List<EnumListItem<TEnum>>();                    //// 列挙値リスト項目リストを生成する

            foreach (var tmpEnum in enumValues)
            {                                                               //// 列挙値配列を繰り返す
                items.Add(new EnumListItem<TEnum>(tmpEnum, fncProvider));   /////  列挙値表示名供給関数を指定して列挙値リスト項目を生成し、リストに追加する

            }

            return items.ToArray();                                         //// 列挙値リスト項目リストから配列を生成して戻り値とし、関数終了
        }

    } // class



#if DEBUG
    //====================================================================================================
    /// <summary>
    /// EnumListItem のテストコード
    /// </summary>
    //====================================================================================================
    public static partial class ZZZTest_EnumListItem
    {
        //--------------------------------------------------------------------------------
        // EnumListItem<TEnum> コンストラクターの自動テスト
        //--------------------------------------------------------------------------------
        [AutoTestMethod("EnumListItem<TEnum> コンストラクター")]
        public static void Ctor()
        {
            //------------------------------------------------------------
            // 列挙体で定義されている列挙値
            //------------------------------------------------------------
            AutoTest.Print("＜列挙体で定義されている列挙値＞");
            {
                var item = new EnumListItem<DayOfWeek>(DayOfWeek.Monday);
                SubRoutine(item, "DayOfWeek.Monday(1)[月曜日]", "基本コンストラクター(列挙値だけを指定するパターン)：ctor(enumValue)");
            }

            {
                var item = new EnumListItem<DayOfWeek>("マンデー", DayOfWeek.Monday);
                SubRoutine(item, "DayOfWeek.Monday(1)[マンデー]", "任意の表示名を指定するパターン：ctor(displayName, enumValue)");
            }

            {
                var item = new EnumListItem<DayOfWeek>(null, DayOfWeek.Monday);
                SubRoutine(item, "DayOfWeek.Monday(1)[]", "表示名に null を指定するパターン：ctor(displayName, enumValue)");
            }

            {
                var item = new EnumListItem<DayOfWeek>(DayOfWeek.Monday, NovLabEnumDisplayNameProvider.ForDayOfWeek.GetEnumDisplayNameByJP1Char);
                SubRoutine(item, "DayOfWeek.Monday(1)[月]", "列挙値表示名供給関数を指定するパターン：ctor(enumValue, fncProvider)");
            }

            {
                var item = new EnumListItem<DayOfWeek>(DayOfWeek.Monday, null);
                SubRoutine(item, "DayOfWeek.Monday(1)[月曜日]", "列挙値表示名供給関数に null を指定するパターン：ctor(enumValue, null)");
            }


            //------------------------------------------------------------
            // 列挙体で定義されていない内部整数値
            //------------------------------------------------------------
            AutoTest.Print("");
            AutoTest.Print("＜列挙体で定義されていない内部整数値＞");
            {
                var item = new EnumListItem<DayOfWeek>((DayOfWeek)65535);
                SubRoutine(item, "DayOfWeek.65535(65535)[65535]", "基本コンストラクター(列挙値だけを指定するパターン)：ctor(enumValue)");
            }

            {
                var item = new EnumListItem<DayOfWeek>("マンデー", (DayOfWeek)65535);
                SubRoutine(item, "DayOfWeek.65535(65535)[マンデー]", "任意の表示名を指定するパターン：ctor(displayName, enumValue)");
            }

            {
                var item = new EnumListItem<DayOfWeek>(null, (DayOfWeek)65535);
                SubRoutine(item, "DayOfWeek.65535(65535)[]", "表示名に null を指定するパターン：ctor(displayName, enumValue)");
            }

            {
                var item = new EnumListItem<DayOfWeek>((DayOfWeek)65535, NovLabEnumDisplayNameProvider.ForDayOfWeek.GetEnumDisplayNameByJP1Char);
                SubRoutine(item, "DayOfWeek.65535(65535)[65535]", "列挙値表示名供給関数を指定するパターン：ctor(enumValue, fncProvider)");
            }

            {
                var item = new EnumListItem<DayOfWeek>((DayOfWeek)65535, null);
                SubRoutine(item, "DayOfWeek.65535(65535)[65535]", "列挙値表示名供給関数に null を指定するパターン：ctor(enumValue, null)");
            }


            //------------------------------------------------------------
            // 【ローカル関数】
            // コンストラクターを直接テストすることはできないので、
            // 生成されたインスタンスの詳細文字列で結果を判定する
            //------------------------------------------------------------
            void SubRoutine(EnumListItem<DayOfWeek> target,         // [in ]：対象オブジェクト
                            string detailString,                    // [in ]：予想結果(詳細文字列)
                            string testPattern = null)              // [in ]：テストパターン名[null = 省略]
            {
                AutoTest.Test(target.GetDetailString, detailString, testPattern);
            }
        }

    } // class
#endif

} // namespace
