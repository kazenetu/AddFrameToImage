using System;
using System.Drawing;
using System.IO;

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

            var blackPen = new Pen(Color.Black, 1);

            Console.Write("running...");
            
            var directoryInfo = new DirectoryInfo(args[0]);
            foreach(var fileInfo in directoryInfo.GetFiles()){
                // イメージに枠をつける
                addFrame(blackPen, fileInfo.FullName);
            }

            Console.WriteLine("finish!");
        }

        /// <summary>
        /// イメージに枠をつけて保存する
        /// </summary>
        /// <param name="pen">枠線</param>
        /// <param name="filePath">イメージのパス</param>
        static private void addFrame(Pen pen, string filePath)
        {
            Image saveImage = null;
            using(var image = Image.FromFile(filePath))
            using(var graphics = Graphics.FromImage(image))
            {
                graphics.DrawRectangle(pen, 0, 0, image.Width-1, image.Height-1);

                saveImage = new Bitmap(image);
            }
            saveImage.Save(filePath);
            saveImage.Dispose();
        }
    }
}
