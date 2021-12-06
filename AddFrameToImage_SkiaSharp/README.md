# System.DrawingとSkiaSharpの実装の違い
実装の違いの概要を説明する。  
詳細はそれぞれの実装を参照こと。

|System.Drawing|SkiaSharp|備考|
|:-------------|:-------------|:-------------|
|using System.Drawing;|using SkiaSharp;||
|var blackPen = new Pen(Color.Black, 1);|なし|Penクラスなし。<br>削除|
|using(var image = Image.FromFile(filePath))<br>using(var graphics = Graphics.FromImage(image))|using(var image =  SKImage.FromEncodedData(filePath))<br>using(var surface = SKSurface.Create(image.Info))|ファイルロードと描画インスタンス生成|
|using(var image =  SKImage.FromEncodedData(filePath))<br>graphics.DrawRectangle(pen, 0, 0, image.Width-1, image.Height-1);|surface.Canvas.DrawRegion(new SKRegion(new SKRectI(0,0,image.Width-1,image.Height-1)),<br>&nbsp;&nbsp;new SKPaint{Color=SKColors.Black,Style = SKPaintStyle.Stroke});|枠線描画|
|saveImage = new Bitmap(image);<br>saveImage.Save(filePath);|using (var saveImage = surface.Snapshot())<br>using(var data = saveImage.Encode())<br>using (var stream = File.OpenWrite(filePath))<br>{<br>&nbsp;&nbsp;data.SaveTo(stream);<br>}|保存処理|
