using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BitmapLib;

namespace GameOfCubes
{
    internal class Cube : SimulationObject
    {
        int edgeLength;

        public Cube(int x, int y, int edgeLength, System.Drawing.Color color, Vector2 velocity)
        {
            Position = new System.Numerics.Vector2 (x, y);
            this.edgeLength = edgeLength;
            Color = color;
            Velocity = velocity;
        }

        public override List<PixelData> GetPixels()
        {
            List<PixelData> pixels = new();

            for (int i = (int)(Position.X); i < (int)(Position.X + edgeLength); i++)
            {
                for (int j = (int)(Position.Y); j < (int)(Position.Y + edgeLength); j++)
                {
                    pixels.Add(new PixelData(i, j, base.Color));
                }
            }
            return pixels;
        }
    }
}
