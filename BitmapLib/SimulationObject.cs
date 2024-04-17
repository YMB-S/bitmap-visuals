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
        private Vector2 position;
        public Vector2 Position { get; set; }

        private Vector2 velocity;
        public Vector2 Velocity { get; set; }

        public abstract List<PixelData> GetPixels();

        public Color Color { get; set; }

        public virtual void Update()
        {
            Position += Velocity;
        }
    }
}
