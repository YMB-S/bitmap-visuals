using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using FastBitmapLib;

namespace BitmapLib
{
    public class SimulationDisplay
    {
        public static int DISPLAY_WIDTH = 450;
        public static int DISPLAY_HEIGHT = 200;

        private Bitmap bitmap;
        public Color BackgroundColor { get; set; }

        private static SimulationDisplay instance;
        public static SimulationDisplay GetInstance()
        {
            if (instance == null)
            {
                instance = new SimulationDisplay();
            }
            return instance;
        }

        private SimulationDisplay()
        {
            bitmap = new Bitmap(DISPLAY_WIDTH, DISPLAY_HEIGHT);
        }

        internal void Resize(int DISPLAY_WIDTH, int DISPLAY_HEIGHT)
        {
            SimulationDisplay.DISPLAY_WIDTH = DISPLAY_WIDTH;
            SimulationDisplay.DISPLAY_HEIGHT = DISPLAY_HEIGHT;
            bitmap = new Bitmap(DISPLAY_WIDTH, DISPLAY_HEIGHT);
        }

        public BitmapImage GetImageFrom(List<SimulationObject> objects)
        {
            DrawTo(bitmap, objects);
            return ToBitmapImage(bitmap);
        }

        public void DrawTo(Bitmap target, List<SimulationObject> objects)
        {
            using (var bitmap = target.FastLock())
            {
                bitmap.Clear(BackgroundColor);

                //objects.ForEach(obj => {
                //    obj.GetPixels().ForEach()
                
                //});

                foreach (SimulationObject obj in objects)
                {
                    List<PixelData> pixels = obj.GetPixels();
                    foreach (PixelData pixel in pixels)
                    {
                        if (!IsOutOfBounds(pixel))
                        {
                            bitmap.SetPixel(obj.Position[0] + pixel.XPosition, obj.Position[1] + pixel.YPosition, pixel.Color);
                        }
                    }
                }
            }
        }

        private bool IsOutOfBounds(PixelData pixel)
        {
            return (
                pixel.XPosition < 0 || pixel.YPosition < 0 ||
                pixel.XPosition >= bitmap.Width || pixel.YPosition >= bitmap.Height
            );   
        }

        private BitmapImage ToBitmapImage(Bitmap bitmap)
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
    }
}
