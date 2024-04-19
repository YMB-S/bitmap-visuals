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
    public class MovingCubeSpawner : SimulationObject
    {
        Random random;
        //List<Cube> cubes;

        public MovingCubeSpawner() 
        {
            random = new Random();
            //cubes = new List<Cube>();
        }

        public override void Update()
        {
            if(random.Next(30) % 3 == 0)
            {
                //cubes.Add(GetRandom());
                SimulationManager.AddToSimulation(GetRandomCube());
            }
        }

        private Cube GetRandomCube()
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
