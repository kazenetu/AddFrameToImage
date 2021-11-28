# AddFrameToImage
画像に縁取りをするアプリケーション

## はじめに
格納したディレクトリ(フォルダ)内のイメージに対して「黒1pxでの縁取り」を行うプロフラムです。

## 実行環境
* .Net Core 3.1 以上
* Windows  
 
## 実行方法
dotnetコマンドで実行する。  
※イメージ格納パスを必ず設定すること  
```sh
dotnet run --project AddFrameToImage/AddFrameToImage.csproj [イメージを格納したディレクト(フォルダ)リパス]
```