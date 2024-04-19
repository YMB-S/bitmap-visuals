using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitmapLib
{
    public class IntVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static IntVector2 operator + (IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2 (v1.X + v2.X, v1.Y + v2.Y);
        }
        public static IntVector2 operator - (IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static IntVector2 operator * (IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2(v1.X * v2.X, v1.Y * v2.Y);
        }
        public static IntVector2 operator / (IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2(v1.X / v2.X, v1.Y / v2.Y);
        }
    }
}
