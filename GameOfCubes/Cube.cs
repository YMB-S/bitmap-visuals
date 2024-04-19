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

        public Cube(IntVector2 position, IntVector2 velocity, int edgeLength, System.Drawing.Color color) : base()
        {
            Position = position;
            Velocity = velocity;
            this.edgeLength = edgeLength;
            Color = color;

            Pixels = CalculatePixels();
        }

        protected override List<PixelData> CalculatePixels()
        {
            List<PixelData> pixels = new();

            for (int i = 0; i < edgeLength; i++)
            {
                for (int j = 0; j < edgeLength; j++)
                {
                    pixels.Add(new PixelData(i, j, Color));
                }
            }
            return pixels;
        }
    }
}
