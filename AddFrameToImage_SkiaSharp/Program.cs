using System;
using SkiaSharp;
using System.IO;
using System.Text.RegularExpressions;

namespace AddFrameToImage
{
    class Program
    {
        /// <summary>
        /// エントリメソッド
        /// </summary>
        static void Main(string[] args)
        {
            if(args.Length < 1){
                Console.WriteLine("addFrameImage ImagesDirectoryPath");
                return;
            }

            Console.WriteLine("running...");
            
            var reg = new Regex(@"[jpg|png]$");
            var directoryInfo = new DirectoryInfo(args[0]);
            foreach(var fileInfo in directoryInfo.GetFiles()){
                // 拡張子が存在しない場合は次のファイルへ
                if(!Path.HasExtension(fileInfo.FullName)) continue;

                var ext = Path.GetExtension(fileInfo.FullName);
                if(reg.IsMatch(ext)){
                    // イメージに枠をつける
                    addFrame(fileInfo.FullName);
                    Console.WriteLine($"  drew rectangle [{fileInfo.FullName}]");
                }
            }

            Console.WriteLine("finish!");
        }

        /// <summary>
        /// イメージに枠をつけて保存する
        /// </summary>
        /// <param name="filePath">イメージのパス</param>
        static private void addFrame(string filePath)
        {
            using(var image =  SKImage.FromEncodedData(filePath))
            using(var surface = SKSurface.Create(image.Info))
            {
                surface.Canvas.DrawImage(image,0,0);
                surface.Canvas.DrawRegion(new SKRegion(new SKRectI(0,0,image.Width-1,image.Height-1)),new SKPaint{Color=SKColors.Black,Style = SKPaintStyle.Stroke});

 				// save the file
				using (var saveImage = surface.Snapshot())
                using(var data = saveImage.Encode())
				using (var stream = File.OpenWrite(filePath))
				{
					data.SaveTo(stream);
				}
            }
        }
    }
}
