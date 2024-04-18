using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BitmapLib;

namespace GameOfCubes
{
    public class CubeManager : SimulationObject
    {
        Random random;
        List<Cube> cubes;

        public CubeManager() 
        {
            random = new Random();
            cubes = new List<Cube>();
        }

        protected override List<PixelData> CalculatePixels()
        {
            List<PixelData> pixels = new();
            cubes.ForEach(cube => { pixels.AddRange(cube.Pixels); });
            return pixels;
        }

        public override void Update()
        {
            Pixels = CalculatePixels();

            if(random.Next(30) % 3 == 0)
            {
                cubes.Add(GetRandom());
            }

            cubes.ForEach(cube => { cube.Update(); });
        }

        private Cube GetRandom()
        {
            return new(

                position: (new[] {
                    random.Next(0, SimulationDisplay.DISPLAY_WIDTH),
                    random.Next(0, SimulationDisplay.DISPLAY_HEIGHT)
                }),

                velocity: (new[] {
                    random.Next(-5, 5),
                    random.Next(-5, 5)
                }),

                edgeLength: random.Next(3, 25),

                color: System.Drawing.Color.Aquamarine             
            ); 
        }
    }
}
