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

        public Cube(int[] position, int[] velocity, int edgeLength, System.Drawing.Color color) : base()
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

            for (int i = Position[0]; i < Position[0] + edgeLength; i++)
            {
                for (int j = Position[1]; j < Position[1] + edgeLength; j++)
                {
                    pixels.Add(new PixelData(i, j, Color));
                }
            }
            return pixels;
        }
    }
}
