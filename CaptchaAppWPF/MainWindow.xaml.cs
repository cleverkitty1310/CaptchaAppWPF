using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yolov5Net.Scorer;

namespace CaptchaAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                string str = File.ReadAllText(dialog.FileName);
                Bitmap bitmap_0 = new Bitmap(this.method_7(str));
                Original_Image.Source = BitmapToImageSource(bitmap_0);

                var resized_image = ResizeImage(bitmap_0, 416, 416);

                using var scorer = new YoloScorer<CaptchaModel>("best.onnx");

                List<YoloPrediction> predictions = scorer.Predict(resized_image);

                using var graphics = Graphics.FromImage(resized_image);

                predictions.Sort(new PredictionComparer());

                string recognized_text = "";
                foreach (var prediction in predictions) // iterate predictions to draw results
                {
                    double score = Math.Round(prediction.Score, 2);

                    graphics.DrawRectangles(new System.Drawing.Pen(System.Drawing.Color.Red, 2),
                        new[] { prediction.Rectangle });

                    var (x, y) = (prediction.Rectangle.X - 3, prediction.Rectangle.Y - 23);

                    graphics.DrawString($"{prediction.Label.Name} ({score})",
                        new Font("Consolas", 16, GraphicsUnit.Pixel), new SolidBrush(System.Drawing.Color.Red),
                        new PointF(x, y));

                    if (prediction.Label.Name == "at")
                        recognized_text += "@";
                    else if (prediction.Label.Name == "eq")
                        recognized_text += "=";
                    else
                        recognized_text += prediction.Label.Name;

                    Status_Box.Text = recognized_text;
                }

                Recognized_Image.Source = BitmapToImageSource(resized_image);
            }
        }

        internal System.Drawing.Image method_7(string string_16)
        {
            byte[] array = Convert.FromBase64String(string_16);
            System.Drawing.Image result;
            using (MemoryStream memoryStream = new MemoryStream(array, 0, array.Length))
            {
                result = System.Drawing.Image.FromStream(memoryStream, true);
            }
            return result;
        }
    }
}
