using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BitmapLib
{
    public abstract class SimulationObject
    {
        public int[] Position { get; set; }

        public int[] Velocity { get; set; }

        public List<PixelData> Pixels { get; protected set; }
        protected abstract List<PixelData> CalculatePixels();

        public Color Color { get; set; }

        public virtual void Update()
        {
            Position[0] += Velocity[0];
            Position[1] += Velocity[1];
        }

        public SimulationObject()
        {
            Position = new int[] { 0, 0 };
            Velocity = new int[] { 0, 0 };
        }
    }
}
