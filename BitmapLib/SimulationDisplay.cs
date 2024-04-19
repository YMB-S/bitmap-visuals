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
                    if (obj.Pixels == null) { continue; } // Some service/manager type objects don't have Pixels
                    foreach (PixelData pixel in obj.Pixels)
                    {
                        int xCoordinate = obj.Position.X + pixel.XPosition;
                        int yCoordinate = obj.Position.Y + pixel.YPosition;

                        if (!IsOutOfBounds(xCoordinate, yCoordinate))
                        {
                            bitmap.SetPixel(xCoordinate, yCoordinate, pixel.Color);
                        }
                    }
                }
            }
        }

        private bool IsOutOfBounds(int xCoordinate, int yCoordinate)
        {
            return (
                xCoordinate < 0 || yCoordinate < 0 ||
                xCoordinate >= bitmap.Width || yCoordinate >= bitmap.Height
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
