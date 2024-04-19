using System;
using System.Collections.Generic;
using System.Drawing;

namespace BitmapLib
{
    public static class ColorUtils
    {
        public static List<Color> GetSystemColors()
        {
            List<Color> colors = new();
            KnownColor[] knownColors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor c in knownColors)
            {
                colors.Add(Color.FromKnownColor(c));
            }
            return colors;
        }

        public static List<Color> GetRainbowColors(int amount)
        {
            List<Color> colors = new();
            double increment = 360.0 / amount;
            for (int i = 0; i < amount; i++)
            {
                double hue = i * increment;
                colors.Add(FromHSV(hue, 1, 1));
            }
            return colors;
        }

        private static Color FromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }
}
