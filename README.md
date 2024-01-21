# NovLab.Windows.Forms クラスライブラリ

Windows用のGUI機能を提供する .NET Framework用クラスライブラリです。

System.Windows.Forms.dll などGUI関係のアセンブリに依存します。


# 動作環境

- Windows 8.1以降
- .NET Framework 4.5.1 以降、または互換性のある .NET 実装


# 依存リポジトリ

- [NovLab.Base](https://github.com/Nov-Lab/NovLab.Base) クラスライブラリ

### ローカルリポジトリにおけるフォルダー配置について

本リポジトリのソリューションと、依存リポジトリのソリューションは、以下のように同じ親フォルダーの下へ配置してください。
```
＜親フォルダー＞
  ├ NovLab.Base ソリューション
  └ NovLab.Windows.Forms ソリューション
```


# 特長

一例として、以下のような機能があります。


# XMessageBox クラス

定型的なスタイルのメッセージボックス表示機能を提供します。

- `ShowInformation`：情報メッセージを表示します。
- `ShowWarning`：警告メッセージを表示します。
- `ShowError`：エラーメッセージを表示します。
- `ShowQuestionYN`：問い合わせメッセージを表示します。
- `ShowExclamationYN`：注意を要する操作用の問い合わせメッセージを表示します。
- `ShowExclamationYNC`：注意を要する操作用の問い合わせメッセージを表示します。

###### 使用例
```
XMessageBox.ShowInformation("123通のメールを受信しました。", "メール受信");

XMessageBox.ShowWarning("サーバーに接続できませんでした。", "メール受信");

XMessageBox.ShowError("エラーメッセージ", "重大なエラー");

DialogResult result = XMessageBox.ShowQuestionYN("メールをごみ箱に送りますか？", "ごみ箱へ送る");

DialogResult result = XMessageBox.ShowExclamationYN("ファイルはすでに存在します。上書きしますか？", "名前を付けて保存");

DialogResult result = XMessageBox.ShowExclamationYNC("ドキュメントは更新されています。アプリケーションを終了する前に保存しますか？", "<アプリケーション名>");
```


# フォルダー構成

- `binfile` ：コンパイル済みのバイナリーファイルです。
- `NovLab.Windows.Forms` ：クラスライブラリ本体のプロジェクトです。


# ライセンス

本ソフトウェアは、MITライセンスに基づいてライセンスされています。

ただし、改変する場合は、namespace の名前を変えて重複や混乱を避けることを強く推奨します。


# 開発環境

## 開発ツール、SDKなど
- Visual Studio Community 2019
  - ワークロード：.NET デスクトップ開発

## 言語
- C#


# その他

Nov-Lab 独自の記述ルールと用語については [NovLabRule.md](https://github.com/Nov-Lab/Nov-Lab/blob/main/NovLabRule.md) を参照してください。
