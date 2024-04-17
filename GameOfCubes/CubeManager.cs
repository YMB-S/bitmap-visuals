using System;
using System.Collections.Generic;
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

        public override List<PixelData> GetPixels()
        {
            List<PixelData> pixels = new();
            cubes.ForEach(cube => { pixels.AddRange(cube.GetPixels()); });
            return pixels;
        }

        public override void Update()
        {
            if(random.Next(30) % 3 == 0)
            {
                cubes.Add(GetRandom());
            }

            cubes.ForEach(cube => { cube.Update(); });
        }

        private Cube GetRandom()
        {
            return new(
                x: random.Next(0, SimulationDisplay.DISPLAY_WIDTH),
                y: random.Next(0, SimulationDisplay.DISPLAY_HEIGHT),
                random.Next(3, 25),
                System.Drawing.Color.Aquamarine,
                new Vector2(
                    random.Next(-5, 5),
                    random.Next(-5, 5)
                )
            ); 
        }
    }
}
