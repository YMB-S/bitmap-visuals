using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BitmapLib;

namespace BouncingPixels
{
    internal class Pixel : SimulationObject
    {
        Color color;

        public Pixel()
        {
            this.color = Color.Red;
        }

        public override PixelData[] GetPixels()
        {
            return new PixelData[]
            {
                new PixelData((int)Position.X, (int)Position.Y, this.color)
            };
        }
    }
}