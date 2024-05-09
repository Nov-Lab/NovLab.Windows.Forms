// @(h)Program.cs ver 0.00 ( '24.05.10 Nov-Lab ) 作成開始
// @(h)Program.cs ver 0.51 ( '24.05.10 Nov-Lab ) ベータ版完成
// @(h)Program.cs ver 0.51a( '24.05.12 Nov-Lab ) その他  ：NovLab.Windows.Forms アセンブリを読み込む処理を追加した

// @(s)
// 　【NovLab.Windows.Form ソリューション用テストメイン】

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Test_NovLab.Windows.Forms
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // テスト用メソッドを列挙できるように、NovLab.Windows.Forms アセンブリを事前に読み込んでおく
            AppDomain.CurrentDomain.Load("NovLab.Windows.Forms");

            // 自動生成された部分
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAppTestNovLab());    // Test_NovLab プロジェクトにあるテスト用メインフォームをそのまま利用する
        }

    } // class

} // namespace
