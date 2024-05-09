// @(h)FrmTestEnumListItem.cs ver 0.00 ( '24.05.10 Nov-Lab ) 作成開始
// @(h)FrmTestEnumListItem.cs ver 0.21 ( '24.05.12 Nov-Lab ) アルファ版完成
// @(h)FrmTestEnumListItem.cs ver 0.21a( '24.05.14 Nov-Lab ) その他  ：コメント整理

// @(s)
// 　【EnumListItem クラスのテスト画面】EnumListItem クラスなどの動作を、実際のリストボックスやコンボボックスでテストするための画面です。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Media;
using System.Windows.Forms;

using NovLab;
using NovLab.DebugSupport;
using NovLab.EnumDisplayNameUtil;
using NovLab.Windows.Forms;
using Test_NovLab;


namespace NovLab.Windows.Forms
{
    //====================================================================================================
    /// <summary>
    /// 【EnumListItem クラスのテスト画面】EnumListItem クラスなどの動作を、実際のリストボックスやコンボボックスでテストするための画面です。
    /// </summary>
    //====================================================================================================
    public partial class FrmTestEnumListItem : Form
    {
        //====================================================================================================
        // テスト用フォーム表示関連(NovLabテストメイン画面からの呼び出しに使用します)
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【テスト用フォーム表示】本フォームを表示します。
        /// </summary>
        //--------------------------------------------------------------------------------
        [TestFormShowMethod("EnumListItem クラスのテスト(リストボックスなどに列挙値表示名を表示する)")]
        public static void TestFormOpen()
        {
            //------------------------------------------------------------
            /// 本フォームを表示する
            //------------------------------------------------------------
            if (m_singleton != null && m_singleton.IsDisposed == false)
            {                                                           //// シングルトンインスタンスが生成されていて、かつ破棄されていない場合
                if (m_singleton.WindowState == FormWindowState.Minimized)
                {                                                       /////  フォームが最小化されている場合
                    m_singleton.WindowState = FormWindowState.Normal;   //////   通常表示にする
                }

                m_singleton.Activate();                                 /////  フォームをアクティブにする
            }
            else
            {                                                           //// シングルトンインスタンスが生成されていないか、破棄されている場合
                m_singleton = new FrmTestEnumListItem();                /////  シングルトンインスタンスを生成する(破棄されていた場合は再生成する)
                m_singleton.Show();                                     /////  フォームを表示する
            }
        }

        /// <summary>
        /// 【シングルトンインスタンス】本フォームのシングルトンインスタンスです。
        /// </summary>
        protected static FrmTestEnumListItem m_singleton = null;


        //====================================================================================================
        // フォームイベント
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【コンストラクター】自動生成された内容のままです。
        /// </summary>
        //--------------------------------------------------------------------------------
        public FrmTestEnumListItem()
        {
            InitializeComponent();
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【フォーム_Load】本フォームを初期化します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void FrmTestEnumListItem_Load(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// 本フォームを初期化する
            //------------------------------------------------------------
            LstEnumType.XSetEnumDataSource<EnumTypeKind>();             //// テスト対象列挙型種別を列挙型選択リストボックスのデータソースに設定する
            CboEnumType.XSetEnumDataSource<EnumTypeKind>();             //// テスト対象列挙型種別を列挙型選択コンボボックスのデータソースに設定する

            M_InitializeSampleCodeMenu();                               //// サンプルコード実行メニュー初期化処理を行う
        }


        //====================================================================================================
        // サンプルコード実行機能関連
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【サンプルコード実行メニュー初期化】サンプルコードを検索・収集して「サンプルコードを実行」メニューに追加します
        /// </summary>
        //--------------------------------------------------------------------------------
        protected void M_InitializeSampleCodeMenu()
        {
#if DEBUG
            //------------------------------------------------------------
            /// サンプルコードを検索・収集して「サンプルコードを実行」メニューに追加する
            //------------------------------------------------------------
            foreach (var methodInfo in typeof(About_EnumListItem).GetMethods())
            {                                                           //// サンプルコードを格納しているクラスのメソッド情報を繰り返す
                try
                {                                                       /////  try開始
                    var actSample =                                     //////   メソッド情報からサンプルコードのデリゲートインスタンスを生成する
                        (Action<ListControl>)Delegate.CreateDelegate(
                            typeof(Action<ListControl>), methodInfo);

                    var tmpMenuItem = new ToolStripMenuItem(methodInfo.Name, null, M_MnuSample_Execute_Click)
                    {                                                   //////   メニュー項目を生成する
                        Tag = actSample,                                ///////    タグにサンプルコードデリゲートインスタンスを設定する
                    };

                    MnuSample.DropDownItems.Add(tmpMenuItem);           //////   メニュー項目を「サンプルコードを実行」メニューに追加する
                }
                catch { }                                               /////  catch：例外は無視する(デリゲート不一致など)
            }
#else
            MnuSample.Visible = false;  // リリース版では非表示
#endif
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【メニュー項目：サンプルコードを実行 - ＜サンプルコード名＞_Click】
        /// メニュー項目の Tag に設定されているサンプルコードデリゲートを実行します。
        /// </summary>
        //--------------------------------------------------------------------------------
        protected void M_MnuSample_Execute_Click(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// メニュー項目のTag に設定されているサンプルコードデリゲートを実行する
            //------------------------------------------------------------
            ToolStripItem item = (ToolStripItem)sender;

            if (item.Tag is Action<ListControl> actSample)
            {                                                           //// Tag に設定されているオブジェクトがサンプルコードのデリゲートの場合
                actSample(LstEnumMember);                               /////  サンプルコードを実行する
            }
            else
            {                                                           //// Tag に設定されているオブジェクトがサンプルコードのデリゲートでない場合(バグチェック)
                Debug.Print("Tag プロパティーの内容が不正です：" +      /////  デバッグ出力(Tag内容不正)
                            XObject.XNullSafeToString(item.Tag));
            }
        }


        //====================================================================================================
        // メニューイベント
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【デバッグ操作-選択を解除メニュー_Click】
        /// ListControl.SelectedIndex = -1 による選択解除が正しく動作するかどうかのテストです。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void MnuDebug_Unselect_Click(object sender, EventArgs e)
        {
            LstEnumType.SelectedIndex = -1;
            LstEnumMember.SelectedIndex = -1;

            CboEnumType.SelectedIndex = -1;
            CboEnumMember.SelectedIndex = -1;
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【デバッグ操作-項目を選択メニュー_Click】
        /// ListControl.SelectedValue による項目選択が正しく動作するかどうかのテストです。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void MnuDebug_SelectItem_Click(object sender, EventArgs e)
        {
            LstEnumType.SelectedValue = EnumTypeKind.DayOfWeek;
            LstEnumMember.SelectedValue = DayOfWeek.Wednesday;

            CboEnumType.SelectedValue = EnumTypeKind.DayOfWeek;
            CboEnumMember.SelectedValue = DayOfWeek.Wednesday;
        }


        //====================================================================================================
        // コントロールイベント
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙型選択リストボックス_SelectedIndexChanged】
        /// 選択された列挙型の有効列挙値一覧を、列挙値選択リストボックスに表示します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void LstEnumType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// 選択された列挙型の有効列挙値一覧を、列挙値選択リストボックスに表示する
            //------------------------------------------------------------
            LstEnumMember.SelectedIndex = -1;                           //// 列挙値選択リストボックスの選択中項目を解除する

            if (LstEnumType.SelectedIndex == -1)
            {                                                           //// 選択項目がない場合
                TxtEnumTypeLst.Text = "";                               /////  列挙型情報テキストボックスをクリアする
                LstEnumMember.DataSource = null;                        /////  列挙値選択リストボックスのデータソースをクリアする
                return;                                                 /////  関数終了
            }

            TxtEnumTypeLst.Text =
                DetailString.Get(LstEnumType.SelectedItem);             //// 選択されたリスト項目の詳細文字列を列挙型情報テキストボックスに表示する
            M_SetDataSource(LstEnumMember,                              //// 選択された列挙型の有効列挙値一覧を、列挙値選択リストボックスのデータソースに設定する
                            (EnumTypeKind)LstEnumType.SelectedValue);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙型選択コンボボックス_SelectedIndexChanged】
        /// 選択された列挙型の有効列挙値一覧を、列挙値選択コンボボックスに表示します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void CboEnumType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// 選択された列挙型の有効列挙値一覧を、列挙値選択コンボボックスに表示する
            //------------------------------------------------------------
            CboEnumMember.SelectedIndex = -1;                           //// 列挙値選択コンボボックスの選択中項目を解除する

            if (CboEnumType.SelectedIndex == -1)
            {                                                           //// 選択項目がない場合
                TxtEnumTypeCbo.Text = "";                               /////  列挙型情報テキストボックスをクリアする
                CboEnumMember.DataSource = null;                        /////  列挙値選択コンボボックスのデータソースをクリアする
                return;                                                 /////  関数終了
            }

            TxtEnumTypeCbo.Text = 
                DetailString.Get(CboEnumType.SelectedItem);             //// 選択されたリスト項目の詳細文字列を列挙型情報テキストボックスに表示する
            M_SetDataSource(CboEnumMember,                              //// 選択された列挙型の有効列挙値一覧を、列挙値選択コンボボックスのデータソースに設定する
                            (EnumTypeKind)CboEnumType.SelectedValue);
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値選択リストボックス_SelectedIndexChanged】
        /// 選択された列挙値の情報をテキストボックスに表示します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void LstEnumMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// 選択された列挙値の情報をテキストボックスに表示する
            //------------------------------------------------------------
            if (LstEnumMember.SelectedIndex == -1)
            {                                                           //// 選択項目がない場合
                TxtEnumMemberLst.Text = "";                             /////  列挙値情報テキストボックスをクリアする
                return;                                                 /////  関数終了
            }

            TxtEnumMemberLst.Text = 
                DetailString.Get(LstEnumMember.SelectedItem);           //// 選択されたリスト項目の詳細文字列を列挙値情報テキストボックスに表示する
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【列挙値選択コンボボックス_SelectedIndexChanged】
        /// 選択された列挙値の情報をテキストボックスに表示します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void CboEnumMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// 選択された列挙値の情報をテキストボックスに表示する
            //------------------------------------------------------------
            if (CboEnumMember.SelectedIndex == -1)
            {                                                           //// 選択項目がない場合
                TxtEnumMemberCbo.Text = "";                             /////  列挙値情報テキストボックスをクリアする
                return;                                                 /////  関数終了
            }

            TxtEnumMemberCbo.Text =
                DetailString.Get(CboEnumMember.SelectedItem);           //// 選択されたリスト項目の詳細文字列を列挙値情報テキストボックスに表示する
        }


        //====================================================================================================
        // テスト用内部列挙体定義
        //====================================================================================================

        //================================================================================
        /// <summary>
        /// 【DayOfWeek 用列挙値表示名供給関数(対応する星の名前)】
        /// </summary>
        /// <param name="enumValue">[in ]：列挙値</param>
        /// <returns>
        /// 対応する星の名前
        /// </returns>
        //================================================================================
        public static string DayOfWeekToStarName(Enum enumValue)
        {
            //------------------------------------------------------------
            /// 列挙値に対応する列挙値表示名を取得する
            //------------------------------------------------------------
            if (enumValue is DayOfWeek specificEnum)
            {                                                           //// 列挙値を固有の列挙型に変換できる場合(正しい呼び出しの場合)
                switch (specificEnum)
                {                                                       /////  DayOfWeek 列挙値で分岐して、対応する星の名前を返す
                    case DayOfWeek.Sunday:
                        return "太陽";

                    case DayOfWeek.Monday:
                        return "月";

                    case DayOfWeek.Tuesday:
                        return "火星";

                    case DayOfWeek.Wednesday:
                        return "水星";

                    case DayOfWeek.Thursday:
                        return "木星";

                    case DayOfWeek.Friday:
                        return "金星";

                    case DayOfWeek.Saturday:
                        return "土星";

                    default:                                            //////   ・上記以外の場合(列挙体で定義されていない内部整数値の場合)
                        return null;                                    ///////    戻り値 = null(取得失敗) で関数終了
                }
            }
            else
            {                                                           //// 列挙値を固有の列挙型に変換できない場合(不正な呼び出しの場合)
                return null;                                            /////  戻り値 = null(取得失敗) で関数終了
            }
        }


        //====================================================================================================
        // テスト用各種定義
        //====================================================================================================

        //================================================================================
        /// <summary>
        /// 【テスト対象列挙型種別】列挙値を増やした場合は <see cref="M_SetDataSource"/> も修正します。
        /// </summary>
        /// <remarks>
        /// 補足<br/>
        /// ・この列挙体自体も EnumDisplayName クラスのテストを兼ねています。<br/>
        /// </remarks>
        //================================================================================
        protected enum EnumTypeKind
        {
#if DEBUG
            [EnumDisplayNameInfo("リモートワーク種別")]
            RemoteWorkKind,

            [EnumDisplayNameInfo("フォールバック処理のテスト(機械的)")]
            FallbackTest_Mechanical,

            [EnumDisplayNameInfo("フォールバック処理のテスト(実践的)：交通信号種別")]
            TrafficSignalKind,
#endif

            [EnumDisplayNameInfo("列挙値表示名供給関数優先度")]
            EnumDisplayNameProviderPriority,

            [EnumDisplayNameInfo("DayOfWeek 列挙体")]
            DayOfWeek,

            [EnumDisplayNameInfo("DayOfWeek 列挙体(日本語１文字で)")]
            DayOfWeekJP1Char,

            [EnumDisplayNameInfo("DayOfWeek 列挙体(空の配列で)")]
            DayOfWeekEmpty,

            [EnumDisplayNameInfo("DayOfWeek 列挙体(飛び飛び＆月曜始まり)")]
            DayOfWeekAtIntervals,

            [EnumDisplayNameInfo("DayOfWeek 列挙体(対応する星の名前と並び順で)")]
            DayOfWeekStarNames,

            [EnumDisplayNameInfo("DayOfWeek 列挙体(表示名を直接指定＆月曜始まり)")]
            DayOfWeekCustomDisplayName,

            [EnumDisplayNameInfo("DataGrid.HitTestType 列挙体(表示名を取得できないパターン)")]
            HitTestType,

            [EnumDisplayNameInfo("EventLogEntryType 列挙体")]
            EventLogEntryType,

        } // enum


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【データソース設定】指定された列挙型の有効列挙値一覧を、リストコントロールのデータソースに設定します。
        /// </summary>
        /// <param name="target">      [in ]：対象リストコントロール</param>
        /// <param name="enumTypeKind">[in ]：テスト対象列挙型種別</param>
        //--------------------------------------------------------------------------------
        protected void M_SetDataSource(ListControl target, EnumTypeKind enumTypeKind)
        {
            switch (enumTypeKind)
            {
#if DEBUG
                case EnumTypeKind.RemoteWorkKind:
                    target.XSetEnumDataSource<About_EnumDisplayNameInfoAttribute.RemoteWorkKind>();
                    break;

                case EnumTypeKind.FallbackTest_Mechanical:
                    target.XSetEnumDataSource<ZZZTest_EnumDisplayName_Fallback_Mechanical.FallbackTest>();
                    break;

                case EnumTypeKind.TrafficSignalKind:
                    target.XSetEnumDataSource<ZZZTest_EnumDisplayName_Fallback_Practical.TrafficSignalKind>();
                    break;
#endif

                case EnumTypeKind.EnumDisplayNameProviderPriority:
                    target.XSetEnumDataSource<EnumDisplayNameProviderPriority>();
                    break;


                // ・基本パターンのテスト
                //   XSetEnumDataSource() オーバーロードと
                //   EnumListItem<TEnum>.ctor() オーバーロードのテスト
                case EnumTypeKind.DayOfWeek:
                    target.XSetEnumDataSource<DayOfWeek>();
                    break;

                // ・列挙値表示名供給関数を指定するパターンのテスト
                //   XSetEnumDataSource(fncProvider) オーバーロードと
                //   EnumListItem<TEnum>.ctor(fncProvider) オーバーロードのテスト
                case EnumTypeKind.DayOfWeekJP1Char:
                    target.XSetEnumDataSource<DayOfWeek>(NovLabEnumDisplayNameProvider.ForDayOfWeek.GetEnumDisplayNameByJP1Char);
                    break;

                // ・列挙値配列を指定するパターンのテスト①(空の配列)
                //   XSetEnumDataSource(enumValues) オーバーロードと
                //   EnumListItem<TEnum>.ctor(enumValues) オーバーロードのテスト
                case EnumTypeKind.DayOfWeekEmpty:
                    target.XSetEnumDataSource(new DayOfWeek[] { });
                    break;

                // ・列挙値配列を指定するパターンのテスト②(飛び飛び＆月曜始まり)
                //   XSetEnumDataSource(enumValues) オーバーロードと
                //   EnumListItem<TEnum>.ctor(enumValues) オーバーロードのテスト
                case EnumTypeKind.DayOfWeekAtIntervals:
                    DayOfWeek[] atIntervals =    // 飛び飛び＆月曜始まり
                    {
                        DayOfWeek.Monday,
                        DayOfWeek.Wednesday,
                        DayOfWeek.Friday,
                        DayOfWeek.Sunday,
                    };
                    target.XSetEnumDataSource(atIntervals);
                    break;

                // ・列挙値配列と列挙値表示名供給関数を指定するパターンのテスト
                //   XSetEnumDataSource(enumValues, fncProvider) オーバーロードと
                //   EnumListItem<TEnum>.ctor(enumValues, fncProvider) オーバーロードのテスト
                case EnumTypeKind.DayOfWeekStarNames:
                    DayOfWeek[] atStarsOrder =  // 星の並び順で
                    {
                        DayOfWeek.Sunday,
                        DayOfWeek.Wednesday,
                        DayOfWeek.Friday,
                        DayOfWeek.Monday,
                        DayOfWeek.Tuesday,
                        DayOfWeek.Thursday,
                        DayOfWeek.Saturday
                    };

                    target.XSetEnumDataSource(atStarsOrder, DayOfWeekToStarName);
                    break;

                // ・表示名を直接指定するパターンのテスト
                //   XSetEnumDataSource(enumListItems) オーバーロードのテスト
                case EnumTypeKind.DayOfWeekCustomDisplayName:
                    EnumListItem<DayOfWeek>[] atKatakana =  // カタカナ＆月曜始まり
                    {
                        new EnumListItem<DayOfWeek>("マンデー", DayOfWeek.Monday),
                        new EnumListItem<DayOfWeek>("チューズデー", DayOfWeek.Tuesday),
                        new EnumListItem<DayOfWeek>("ウェンズデー", DayOfWeek.Wednesday),
                        new EnumListItem<DayOfWeek>("サーズデー", DayOfWeek.Thursday),
                        new EnumListItem<DayOfWeek>("フライデー", DayOfWeek.Friday),
                        new EnumListItem<DayOfWeek>("サタデー", DayOfWeek.Saturday),
                        new EnumListItem<DayOfWeek>("サンデー", DayOfWeek.Sunday),
                    };

                    target.XSetEnumDataSource(atKatakana);
                    break;

                // ・表示名を取得できないパターンのテスト(列挙値表示名供給関数を用意することのなさそうな列挙体)
                case EnumTypeKind.HitTestType:
                    target.XSetEnumDataSource<DataGrid.HitTestType>();
                    break;

                case EnumTypeKind.EventLogEntryType:
                    target.XSetEnumDataSource<EventLogEntryType>();
                    break;

                default:
                    target.DataSource = null;
                    Debug.Print("未対応の列挙型です：" + enumTypeKind.ToString());
                    SystemSounds.Beep.Play();
                    break;
            }

        }

    } // class

} // namespace
