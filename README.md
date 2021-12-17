# AddFrameToImage
画像に縁取りをするアプリケーション

## はじめに
格納したディレクトリ(フォルダ)内のイメージに対して「黒1pxでの縁取り」を行うプログラムです。

## 実行環境
* Windows
  * .NET Core 3.1 以上  
  (バージョンごとにcsprojが異なる)

* Windows以外
  * System.Drawing.Common版(AddFrameToImage/AddFrameToImage.csproj)
    * .NET Core 3.1 または .NET 5  
        (バージョンごとにcsprojが異なる)
    * libgdiplus必須

  * SkiaSharp版(AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp.csproj)
    * .NET Core 3.1 以上

## 実行方法
* ローカル実行  
    dotnet runで実行する。  
    ※イメージ格納パスを必ず設定すること  
    * System.Drawing.Common版
        ```sh
        #.NET Core 3.1
        dotnet run --project AddFrameToImage/AddFrameToImage.csproj [イメージを格納したディレクトリ(フォルダ)パス]

        #.NET 5
        dotnet run --project AddFrameToImage/AddFrameToImage_NET5.csproj [イメージを格納したディレクトリ(フォルダ)パス]

        #.NET 6
        dotnet run --project AddFrameToImage/AddFrameToImage_NET6.csproj [イメージを格納したディレクトリ(フォルダ)パス]
        ```  
        例)sample-images/afterを対象とする場合(.NET Core 3.1)  
        ```sh
        #copy image files
        cp sample-images/before/* sample-images/after

        #run AddFrameToImage(.NET Core 3.1)
        dotnet run --project AddFrameToImage/AddFrameToImage.csproj ./sample-images/after
        ```  

    * SkiaSharp版
        ```sh
        #.NET Core 3.1
        dotnet run --project AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp.csproj [イメージを格納したディレクトリ(フォルダ)パス]

        #.NET 5
        dotnet run --project AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp_NET5.csproj [イメージを格納したディレクトリ(フォルダ)パス]

        #.NET 6
        dotnet run --project AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp_NET6.csproj [イメージを格納したディレクトリ(フォルダ)パス]
        ```  
        例)sample-images/afterを対象とする場合(.NET Core 3.1)  
        ```sh
        #copy image files
        cp sample-images/before/* sample-images/after

        #run AddFrameToImage_SkiaSharp
        dotnet run --project AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp.csproj ./sample-images/after
        ```

* Dockerコンテナでの実行  
    Dockerコンテナ上で開発環境を構築する。  
   * 前提  
     * Docker EngineやDocker Desktopがインストール済みであること。

   * 実行手順  
     * System.Drawing.Common版
        1. docker_devに移動  
            ```sh
            cd docker_dev
            ```

        1. (**初回のみ**)ビルド  
            ```sh
            docker-compose build
            ```

        1. コンテナ起動  
            ```sh
            docker-compose up -d
            ```

        1. コンテナに入る  
            ```sh
            docker exec -it docker_dev_dotnet_1 /bin/bash
            ```

        1. コンテナ内で実行 
            1. /source/sample-images/beforeを/source/sample-images/afterにコピーする。
                ```sh
                 cp /source/sample-images/before/* /source/sample-images/after
                ```

            1. dotnet runで実行する。
                ```sh
                #.NET Core 3.1
                dotnet run --project AddFrameToImage/AddFrameToImage.csproj /source/sample-images/after
                ```

            1. コンテナから離脱する。
                ```sh
                 exit
                ```

        1. コンテナ停止・削除  
            ```sh
            docker-compose down
            ```

     * SkiaSharp版
        1. docker_dev_SkiaSharpに移動  
            ```sh
            cd docker_dev_SkiaSharp
            ```

        1. (**初回のみ**)ビルド  
            ```sh
            docker-compose build
            ```

        1. コンテナ起動  
            ```sh
            docker-compose up -d
            ```

        1. コンテナに入る  
            ```sh
            docker exec -it docker_dev_skiasharp_dotnet_skiasharp_1 /bin/bash
            ```

        1. コンテナ内で実行 
            1. /source/sample-images/beforeを/source/sample-images/afterにコピーする。
                ```sh
                 cp /source/sample-images/before/* /source/sample-images/after
                ```

            1. dotnet runで実行する。
                * SkiaSharp版
                    ```sh
                    #.NET Core 3.1
                    dotnet run --project AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp.csproj /source/sample-images/after

                    #.NET 5.0
                    dotnet run --project AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp_NET5.csproj /source/sample-images/after

                    #.NET 6.0
                    dotnet run --project AddFrameToImage_SkiaSharp/AddFrameToImage_SkiaSharp_NET6.csproj /source/sample-images/after
                    ```

            1. コンテナから離脱する。
                ```sh
                 exit
                ```

        1. コンテナ停止・削除  
            ```sh
            docker-compose down
            ```