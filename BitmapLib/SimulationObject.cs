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
        public IntVector2 Position { get; set; }

        public IntVector2 Velocity { get; set; }

        public List<PixelData> Pixels { get; protected set; }
        protected virtual List<PixelData>? CalculatePixels() { return null; }

        public Color Color { get; set; }

        public virtual void Update()
        {
            Position += Velocity;
        }

        public SimulationObject()
        {
            Position = new IntVector2(0, 0);
            Velocity = new IntVector2(0, 0);
        }
    }
}
