using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using BitmapLib;

namespace GameOfCubes
{
    internal class CrawlingCubeSpawner : SimulationObject, IClickEventReceiver
    {
        List<Cube> cubes;
        Random random;
        List<Color> colors;

        private readonly int CUBE_EDGE_LENGTH = 1;
        private readonly int AMOUNT_COLORS_TO_GENERATE = 1000;

        public CrawlingCubeSpawner()
        {
            random = new Random();
            colors = ColorUtils.GetRainbowColors(AMOUNT_COLORS_TO_GENERATE);

            cubes = new()
            {
                new Cube(
                    new IntVector2(250, 250),
                    new IntVector2(0, 0),
                    CUBE_EDGE_LENGTH,
                    colors.First()
                    )
            };

            InputManager.GetInstance().AddClickEventReceiver(this);
        }

        public void ReceiveClick(IntVector2 mousePosition, System.Windows.Input.MouseEventArgs e)
        {
            cubes.Add(new(
                new IntVector2 (mousePosition.X, mousePosition.Y),
                new IntVector2 (0, 0),
                CUBE_EDGE_LENGTH,
                colors.First()
                ));
        }

        public override void Update()
        {
            base.Update();
            var lastCube = cubes.ElementAt(cubes.Count - 1);
            IntVector2 newPosition = GetNewCubePositionFrom(lastCube);

            int attempts = 0;   // Try picking a new position that isn't occupied yet
            while (cubes.Exists(x => x.Position.X == newPosition.X && x.Position.Y == newPosition.Y))
            {
                newPosition = GetNewCubePositionFrom(lastCube);
                attempts++;
                if (attempts == 4)  // If we're stuck, remove the cube that is blocking us
                {
                    cubes.Remove(lastCube); break;
                }
            }

            int colorIndex = (colors.IndexOf(lastCube.Color) + 1) % colors.Count;

            Cube newCube = new Cube(new IntVector2(newPosition.X, newPosition.Y),
                new IntVector2(0, 0),
                CUBE_EDGE_LENGTH,
                colors.ElementAt(colorIndex)
            );

            //Debug.WriteLine("newCube position: " + newCube.Position[0].ToString() + " " + newCube.Position[1].ToString());

            cubes.Add(newCube);
            SimulationManager.AddToSimulation(newCube);
        }

        private IntVector2 GetNewCubePositionFrom(Cube lastCube)
        {
            int xDirection = 1;
            if (random.Next(2) == 1) { xDirection = -1; }
            int yDirection = 1;
            if (random.Next(2) == 1) { yDirection = -1; }
            if (random.Next(2) == 1) { xDirection = 0; }
            if (random.Next(2) == 1) { yDirection = 0; }

            int xPosition = lastCube.Position.X;
            xPosition += (CUBE_EDGE_LENGTH) * xDirection;

            int yPosition = lastCube.Position.Y;
            yPosition += (CUBE_EDGE_LENGTH) * yDirection;

            return new IntVector2(xPosition, yPosition);
        }
    }
}
