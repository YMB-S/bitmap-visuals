using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmapLib
{
    public class PixelData
    {
        public PixelData(int x, int y, Color color)
        {
            XPosition = x;
            YPosition = y;
            Color = color;
        }

        public int XPosition { get; private set; }

        public int YPosition { get; private set; }

        public Color Color { get; private set; }
    }
}
